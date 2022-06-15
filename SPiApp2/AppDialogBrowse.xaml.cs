using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Shell;

namespace SPiApp2
{
    [Flags]
    public enum BrowseType
    {
        Files = 1,
        Directories = 2,
        All = (Files | Directories)
    }

    /// <summary>
    /// Interaction logic for BrowseDialog.xaml
    /// </summary>
    public partial class AppDialogBrowse : SPiApp2.Controls.CompilerWindow
    {
        private BrowseType browseType;
        private string initialDirectory;
        private string currentPath;
        private string[] extensions;

        /// <summary>
        /// Get the path of the directory/file selected by the user.
        /// </summary>
        public string SelectedPath
        {
            get;
            private set;
        }

        private string extension = null;

        private ObservableCollection<BrowseItem> displayedItems =
            new ObservableCollection<BrowseItem>();

        public ObservableCollection<BrowseItem> DisplayedItems
        {
            get
            {
                return displayedItems;
            }
        }

        public AppDialogBrowse() :
            this(BrowseType.All, new string[] { "*.*", "All files" })
        {
            ; // NOTE: All logic is in the other constructor
        }

        public AppDialogBrowse(BrowseType type, string[] extensions, string initialDirectory = null)
        {
            InitializeComponent();
            CenterOnParent();
            browseType = type;
            this.initialDirectory = (string.IsNullOrEmpty(initialDirectory) ? null : initialDirectory);
            viewList.ItemsSource = DisplayedItems;
            this.extensions = extensions;
            Loaded += OnLoaded;
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            SetExtensions();

            // Take the application directory if nothing else worked...
            if (initialDirectory == null || !Directory.Exists(initialDirectory))
            {
                initialDirectory = Environment.CurrentDirectory;
            }

            UpdateView(initialDirectory);
            LoadDrives();
        }

        public override void GetWindowChrome(out WindowChrome chrome)
        {
            chrome = this.chrome;
        }

        private void Click_Select(object sender, RoutedEventArgs e)
        {
            bool isFile = false;
            bool isDirectory = false;
            string path = string.Empty;

            // It may be that there is no item selected
            if (!(viewList.SelectedItem is BrowseItem item))
            {
                if ((browseType & BrowseType.Directories) == BrowseType.Directories)
                {
                    path = viewDirectory.Text;
                }
            }
            else
            {
                path = item.Path;
            }

            // Determine what the selected item is
            if (Directory.Exists(path))
            {
                isDirectory = true;
            }
            else if (File.Exists(path))
            {
                isFile = true;
            }

            // May be files only!
            if (browseType == BrowseType.Files && !isFile)
            {
                AppDialogMessage.Show(string.Format("Could not find file at '{0}'.", path),
                    "File not found", MessageButtons.OK, MessageIcon.Warning);
            }
            else if (browseType == BrowseType.Directories && !isDirectory)
            {
                AppDialogMessage.Show(string.Format("Could not find file at '{0}'.", path),
                    "File not found", MessageButtons.OK, MessageIcon.Warning);
            }
            else if (!isDirectory && !isFile)
            {
                AppDialogMessage.Show(string.Format("No file or directory could be found at'{0}'.", path),
                    "Invalid path", MessageButtons.OK, MessageIcon.Warning);
            }
            else
            {
                SelectedPath = path;
                DialogResult = true;
            }
        }

        private void SetExtensions()
        {
            Debug.Assert((extensions.Length > 0));
            Debug.Assert((extensions.Length & 1) == 0);

            viewExtension.SelectionChanged -= Changed_SelectedExtension;
            viewExtension.Items.Clear();

            // Load extensions
            for (int i = 0; i < extensions.Length; i += 2)
            {
                BrowseExtension item = new BrowseExtension()
                {
                    Extension = extensions[i],
                    Description = extensions[i+1]
                };
                
                viewExtension.Items.Add(item);
            }

            viewExtension.SelectedIndex = 0;
            BrowseExtension extension = viewExtension.SelectedItem as BrowseExtension;
            Debug.Assert(extension != null);
            this.extension = extension.Extension;

            viewExtension.SelectionChanged += Changed_SelectedExtension;
        }

        private void Changed_SelectedExtension(object sender, SelectionChangedEventArgs e)
        {
            BrowseExtension item = (e.AddedItems[0] as BrowseExtension);
            Debug.Assert(item != null);
            extension = item.Extension;

            UpdateView(currentPath);
        }

        private void LoadDrives()
        {
            viewDrive.SelectionChanged -= View_DriveChanged;
            viewDrive.Items.Clear();

            DriveInfo[] drives = System.IO.DriveInfo.GetDrives();
            foreach (DriveInfo drive in drives)
            {
                // The medium may be non-static meaning it is not present
                if (!Directory.Exists(drive.RootDirectory.FullName))
                    continue;

                string root = drive.RootDirectory.FullName;

                bool selected = (!string.IsNullOrEmpty(root) && initialDirectory.StartsWith(root));
                int index = viewDrive.Items.Count;

                viewDrive.Items.Add(drive);

                if (selected)
                {
                    viewDrive.SelectedIndex = index;
                }
            }

            viewDrive.SelectionChanged += View_DriveChanged;
        }

        private bool IsVolume(string path)
        {
            string root = System.IO.Path.GetPathRoot(path);
            if (root != path)
                return false;

            DriveInfo[] drives = System.IO.DriveInfo.GetDrives();
            foreach (DriveInfo drive in drives)
            {
                if (drive.RootDirectory.FullName == root)
                    return true;
            }

            return false;
        }

        private void View_DriveChanged(object sender, SelectionChangedEventArgs e)
        {
            DriveInfo drive = e.AddedItems[0] as DriveInfo;
            Debug.Assert(drive != null);

            try
            {
                UpdateView(drive.RootDirectory.FullName);
            }
            catch (IOException)
            {
                // Clear all views
                viewList.MouseDoubleClick -= View_DoubleClick;
                viewList.SelectionChanged -= View_SelectionChanged;
                displayedItems.Clear();

                viewDirectory.Text = string.Empty;
                viewPath.Text = string.Empty;
            }
        }

        private bool ShouldAddEntry(string path)
        {
            if (Directory.Exists(path) || File.Exists(path))
            {
                var attribs = File.GetAttributes(path);

                if (attribs.HasFlag(FileAttributes.Hidden))
                    return false;

                if (attribs.HasFlag(FileAttributes.System))
                    return false;

                return true;
            }

            return false;
        }

        private void UpdateView(string dir)
        {
            Debug.Assert(Directory.Exists(dir));

            // Update the current path
            currentPath = System.IO.Path.GetFullPath(dir);

            // All the available entries
            List<string> entries = new List<string>();

            // Add directories if requested
            entries.AddRange(Directory.GetDirectories(currentPath, "*", SearchOption.TopDirectoryOnly));

            // Add files if requested
            if ((browseType & BrowseType.Files) == BrowseType.Files)
            {
                string extension = (this.extension == "*.*" ? "*" : this.extension);
                entries.AddRange(Directory.GetFiles(currentPath, extension, SearchOption.TopDirectoryOnly));
            }

            // Remove the event handler, clear the view and refill with the new entries
            viewList.MouseDoubleClick -= View_DoubleClick;
            viewList.SelectionChanged -= View_SelectionChanged;
            displayedItems.Clear();

            // We can go up?
            // NOTE: untested so do that :P
            if (!IsVolume(currentPath))
            {
                displayedItems.Add(new BrowseItem()
                {
                    Path = System.IO.Path.GetFullPath(string.Format("{0}{1}..", currentPath, System.IO.Path.DirectorySeparatorChar)),
                    Filename = ".."
                });
            }
            
            // Add new items to the view
            foreach (string entry in entries)
            {
                if (ShouldAddEntry(entry))
                {
                    displayedItems.Add(new BrowseItem()
                    {
                        Path = entry,
                        Filename = System.IO.Path.GetFileName(entry)
                    });
                }
            }

            // Scroll to the top item
            if (viewList.Items.Count > 0)
            {
                viewList.ScrollIntoView(viewList.Items[0]);
            }

            // Add the selection event handler
            viewList.SelectionChanged += View_SelectionChanged;
            viewList.MouseDoubleClick += View_DoubleClick;

            // Update the view components
            viewDirectory.Text = currentPath;
        }

        private void SelectedChanged(BrowseItem item)
        {
            Debug.Assert(item != null);

            // If the selected item is a directory go to that directory
            if (Directory.Exists(item.Path))
            {
                UpdateView(item.Path);
            }
        }

        private void View_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            ListBox obj = sender as ListBox;
            Debug.Assert(obj != null);
            SelectedChanged(obj.SelectedItem as BrowseItem);
        }

        private void View_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BrowseItem item = e.AddedItems[0] as BrowseItem;
            Debug.Assert(item != null);

#if FALSE
            if ((browseType & BrowseType.Directories) != BrowseType.Directories)
            {
                SelectedChanged(item);
            }
#endif

            viewPath.Text = item.Filename;
        }
    }

    public class BrowseItem : INotifyPropertyChanged
    {
        private string filename;
        public string Filename
        {
            get { return filename; }
            set { filename = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Filename")); }
        }

        private string path;
        public string Path
        {
            get { return path; }
            set { path = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Path")); }
        }

        public override string ToString()
        {
            return filename;
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }

    public class BrowseExtension
    {
        public string Extension { get; set; }
        public string Description { get; set; }

        public override string ToString()
        {
            return string.Format("{0} ({1})", Description, Extension);
        }
    }
}
