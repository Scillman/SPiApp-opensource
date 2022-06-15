
namespace SPiApp
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// Ensure bottom-to-top drawing order.
        /// </summary>
        protected override System.Windows.Forms.CreateParams CreateParams
        {
            get
            {
                System.Windows.Forms.CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000; // WS_EX_COMPOSITED 
                return cp;
            }
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.ctrlMain = new System.Windows.Forms.TabControl();
            this.tabPreferences = new System.Windows.Forms.TabPage();
            this.ctrlPreferences = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.ctrlRequiredSave = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.ctrlZipperBrowse = new System.Windows.Forms.Button();
            this.ctrlZipper = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ctrlInstallPathBrowse = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.ctrlInstallPath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ctrlLanguageSelect = new System.Windows.Forms.ComboBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.ctrlAdvancedReset = new System.Windows.Forms.Button();
            this.ctrlAdvancedSave = new System.Windows.Forms.Button();
            this.ctrlSyncTools = new System.Windows.Forms.CheckBox();
            this.ctrlExeNameBrowse = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.ctrlTextEditorBrowse = new System.Windows.Forms.Button();
            this.ctrlExeName = new System.Windows.Forms.TextBox();
            this.ctrlTextEditor = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.ctrlCustomSave = new System.Windows.Forms.Button();
            this.ctrlCustomClear = new System.Windows.Forms.Button();
            this.label24 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.ctrlC3Browse = new System.Windows.Forms.Button();
            this.ctrlC0Text = new System.Windows.Forms.TextBox();
            this.ctrlC3Value = new System.Windows.Forms.TextBox();
            this.ctrlC0Value = new System.Windows.Forms.TextBox();
            this.ctrlC3Text = new System.Windows.Forms.TextBox();
            this.ctrlC0Browse = new System.Windows.Forms.Button();
            this.ctrlC2Browse = new System.Windows.Forms.Button();
            this.ctrlC1Text = new System.Windows.Forms.TextBox();
            this.ctrlC2Value = new System.Windows.Forms.TextBox();
            this.ctrlC1Value = new System.Windows.Forms.TextBox();
            this.ctrlC2Text = new System.Windows.Forms.TextBox();
            this.ctrlC1Browse = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tabDevelopment = new System.Windows.Forms.TabPage();
            this.column5 = new System.Windows.Forms.Panel();
            this.ctrlCustom3 = new System.Windows.Forms.Button();
            this.ctrlCustom2 = new System.Windows.Forms.Button();
            this.ctrlCustom1 = new System.Windows.Forms.Button();
            this.ctrlCustom0 = new System.Windows.Forms.Button();
            this.column4 = new System.Windows.Forms.Panel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.ctrlFileEffectsEditor = new System.Windows.Forms.Button();
            this.ctrlFileAssetManager = new System.Windows.Forms.Button();
            this.ctrlFileRadiant = new System.Windows.Forms.Button();
            this.column3 = new System.Windows.Forms.Panel();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.ctrlNewMod = new System.Windows.Forms.Button();
            this.ctrlRefreshModList = new System.Windows.Forms.Button();
            this.ctrlModList = new System.Windows.Forms.ListBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ctrlModIWD = new System.Windows.Forms.Button();
            this.ctrlModBrowse = new System.Windows.Forms.Button();
            this.ctrlModCustom = new System.Windows.Forms.TextBox();
            this.ctrlModRun = new System.Windows.Forms.Button();
            this.ctrlModBuild = new System.Windows.Forms.Button();
            this.ctrlModUpdate = new System.Windows.Forms.Button();
            this.ctrlModOptions = new System.Windows.Forms.CheckedListBox();
            this.column2 = new System.Windows.Forms.Panel();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.ctrlShowCode = new System.Windows.Forms.Button();
            this.ctrlShowSoundaliases = new System.Windows.Forms.Button();
            this.ctrlShowLocalizedstrings = new System.Windows.Forms.Button();
            this.ctrlShowFx = new System.Windows.Forms.Button();
            this.ctrlShowAnim = new System.Windows.Forms.Button();
            this.ctrlShowMap = new System.Windows.Forms.Button();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.ctrlFolderSoundaliases = new System.Windows.Forms.Button();
            this.ctrlFolderSound = new System.Windows.Forms.Button();
            this.ctrlFolderMaps = new System.Windows.Forms.Button();
            this.ctrlFolderLocalizedstrings = new System.Windows.Forms.Button();
            this.ctrlFolderMapSource = new System.Windows.Forms.Button();
            this.ctrlFolderMods = new System.Windows.Forms.Button();
            this.column1 = new System.Windows.Forms.Panel();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.ctrlOptionsTab = new System.Windows.Forms.TabControl();
            this.tabOptionsBSP = new System.Windows.Forms.TabPage();
            this.ctrlBspBlockValue = new System.Windows.Forms.TextBox();
            this.ctrlBspSampleValue = new System.Windows.Forms.TextBox();
            this.ctrlBspCustomValue = new System.Windows.Forms.TextBox();
            this.ctrlBspCustom = new System.Windows.Forms.CheckBox();
            this.ctrlBspDebug = new System.Windows.Forms.CheckBox();
            this.ctrlBspSample = new System.Windows.Forms.CheckBox();
            this.ctrlBspBlock = new System.Windows.Forms.CheckBox();
            this.ctrlBspEnts = new System.Windows.Forms.CheckBox();
            this.tabOptionsLight = new System.Windows.Forms.TabPage();
            this.ctrlLightCustom = new System.Windows.Forms.CheckBox();
            this.ctrlLightCustomValue = new System.Windows.Forms.TextBox();
            this.ctrlLightTracesValue = new System.Windows.Forms.TextBox();
            this.ctrlLightJitterValue = new System.Windows.Forms.TextBox();
            this.ctrlLightJitter = new System.Windows.Forms.CheckBox();
            this.ctrlLightTraces = new System.Windows.Forms.CheckBox();
            this.ctrlLightDump = new System.Windows.Forms.CheckBox();
            this.ctrlLightNoShadow = new System.Windows.Forms.CheckBox();
            this.ctrlLightShadow = new System.Windows.Forms.CheckBox();
            this.ctrlLightVerbose = new System.Windows.Forms.CheckBox();
            this.ctrlLightExtra = new System.Windows.Forms.CheckBox();
            this.ctrlLightFast = new System.Windows.Forms.CheckBox();
            this.ctrlCompile = new System.Windows.Forms.CheckedListBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.ctrlGridStart = new System.Windows.Forms.Button();
            this.ctrlGridType = new System.Windows.Forms.ComboBox();
            this.ctrlGridCollectDots = new System.Windows.Forms.CheckBox();
            this.column0 = new System.Windows.Forms.Panel();
            this.groupLevel = new System.Windows.Forms.GroupBox();
            this.ctrlNewMap = new System.Windows.Forms.Button();
            this.ctrlRefreshMapList = new System.Windows.Forms.Button();
            this.ctrlMapList = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ctrlMapBSP = new System.Windows.Forms.Button();
            this.ctrlMapReflections = new System.Windows.Forms.Button();
            this.ctrlMapCustom = new System.Windows.Forms.TextBox();
            this.ctrlMapBuild = new System.Windows.Forms.Button();
            this.ctrlMapOptions = new System.Windows.Forms.CheckedListBox();
            this.ctrlMapUpdate = new System.Windows.Forms.Button();
            this.ctrlMapRun = new System.Windows.Forms.Button();
            this.tabBrowsing = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.ctrlBrowseXparts = new System.Windows.Forms.Button();
            this.ctrlBrowseSun = new System.Windows.Forms.Button();
            this.ctrlBrowseXmodels = new System.Windows.Forms.Button();
            this.ctrlBrowseVision = new System.Windows.Forms.Button();
            this.ctrlBrowseMaterials = new System.Windows.Forms.Button();
            this.ctrlBrowseXsurfs = new System.Windows.Forms.Button();
            this.ctrlBrowseXanims = new System.Windows.Forms.Button();
            this.ctrlBrowseMaterialProperties = new System.Windows.Forms.Button();
            this.ctrlBrowseImages = new System.Windows.Forms.Button();
            this.ctrlBrowseWeapons = new System.Windows.Forms.Button();
            this.ctrlBrowseUI = new System.Windows.Forms.Button();
            this.ctrlBrowseImagesMain = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ctrlBrowseLocalizedstrings = new System.Windows.Forms.Button();
            this.ctrlBrowseMaps = new System.Windows.Forms.Button();
            this.ctrlBrowseSoundaliases = new System.Windows.Forms.Button();
            this.ctrlBrowseSound = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ctrlBrowseMapSource = new System.Windows.Forms.Button();
            this.ctrlBrowseMain = new System.Windows.Forms.Button();
            this.ctrlBrowseMods = new System.Windows.Forms.Button();
            this.ctrlBrowseSourceData = new System.Windows.Forms.Button();
            this.ctrlBrowseZoneSource = new System.Windows.Forms.Button();
            this.tabApplications = new System.Windows.Forms.TabPage();
            this.ctrlAppConverter = new System.Windows.Forms.Button();
            this.ctrlAppEffectsEd = new System.Windows.Forms.Button();
            this.ctrlAppAssetManager = new System.Windows.Forms.Button();
            this.ctrlAppRadiant = new System.Windows.Forms.Button();
            this.dialogInstallPath = new System.Windows.Forms.FolderBrowserDialog();
            this.dialogZipper = new System.Windows.Forms.OpenFileDialog();
            this.dialogTextEditor = new System.Windows.Forms.OpenFileDialog();
            this.dialogExeName = new System.Windows.Forms.OpenFileDialog();
            this.dialogCustom = new System.Windows.Forms.OpenFileDialog();
            this.ctrlMain.SuspendLayout();
            this.tabPreferences.SuspendLayout();
            this.ctrlPreferences.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabDevelopment.SuspendLayout();
            this.column5.SuspendLayout();
            this.column4.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.column3.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.panel2.SuspendLayout();
            this.column2.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.column1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.ctrlOptionsTab.SuspendLayout();
            this.tabOptionsBSP.SuspendLayout();
            this.tabOptionsLight.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.column0.SuspendLayout();
            this.groupLevel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabBrowsing.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabApplications.SuspendLayout();
            this.SuspendLayout();
            // 
            // ctrlMain
            // 
            this.ctrlMain.Controls.Add(this.tabPreferences);
            this.ctrlMain.Controls.Add(this.tabDevelopment);
            this.ctrlMain.Controls.Add(this.tabBrowsing);
            this.ctrlMain.Controls.Add(this.tabApplications);
            this.ctrlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlMain.Location = new System.Drawing.Point(0, 0);
            this.ctrlMain.Name = "ctrlMain";
            this.ctrlMain.SelectedIndex = 0;
            this.ctrlMain.Size = new System.Drawing.Size(890, 567);
            this.ctrlMain.TabIndex = 0;
            this.ctrlMain.Selected += new System.Windows.Forms.TabControlEventHandler(this.OnTabChanged);
            // 
            // tabPreferences
            // 
            this.tabPreferences.BackColor = System.Drawing.SystemColors.Control;
            this.tabPreferences.Controls.Add(this.ctrlPreferences);
            this.tabPreferences.Controls.Add(this.panel3);
            this.tabPreferences.Location = new System.Drawing.Point(4, 22);
            this.tabPreferences.Name = "tabPreferences";
            this.tabPreferences.Padding = new System.Windows.Forms.Padding(3);
            this.tabPreferences.Size = new System.Drawing.Size(882, 541);
            this.tabPreferences.TabIndex = 0;
            this.tabPreferences.Text = "Preferences";
            // 
            // ctrlPreferences
            // 
            this.ctrlPreferences.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlPreferences.Controls.Add(this.tabPage1);
            this.ctrlPreferences.Controls.Add(this.tabPage2);
            this.ctrlPreferences.Controls.Add(this.tabPage3);
            this.ctrlPreferences.Location = new System.Drawing.Point(6, 6);
            this.ctrlPreferences.Name = "ctrlPreferences";
            this.ctrlPreferences.SelectedIndex = 0;
            this.ctrlPreferences.Size = new System.Drawing.Size(870, 262);
            this.ctrlPreferences.TabIndex = 23;
            this.ctrlPreferences.Selected += new System.Windows.Forms.TabControlEventHandler(this.PreferencesSubTabChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.ctrlRequiredSave);
            this.tabPage1.Controls.Add(this.label16);
            this.tabPage1.Controls.Add(this.ctrlZipperBrowse);
            this.tabPage1.Controls.Add(this.ctrlZipper);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.ctrlInstallPathBrowse);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.ctrlInstallPath);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.ctrlLanguageSelect);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(862, 236);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Required";
            // 
            // ctrlRequiredSave
            // 
            this.ctrlRequiredSave.Location = new System.Drawing.Point(756, 111);
            this.ctrlRequiredSave.Name = "ctrlRequiredSave";
            this.ctrlRequiredSave.Size = new System.Drawing.Size(100, 23);
            this.ctrlRequiredSave.TabIndex = 36;
            this.ctrlRequiredSave.Text = "Save Changes";
            this.ctrlRequiredSave.UseVisualStyleBackColor = true;
            this.ctrlRequiredSave.Click += new System.EventHandler(this.ClickPreferencesSave);
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(6, 76);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(140, 23);
            this.label16.TabIndex = 9;
            this.label16.Text = "7za.exe:";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ctrlZipperBrowse
            // 
            this.ctrlZipperBrowse.Location = new System.Drawing.Point(781, 76);
            this.ctrlZipperBrowse.Name = "ctrlZipperBrowse";
            this.ctrlZipperBrowse.Size = new System.Drawing.Size(75, 23);
            this.ctrlZipperBrowse.TabIndex = 7;
            this.ctrlZipperBrowse.Text = "Browse";
            this.ctrlZipperBrowse.UseVisualStyleBackColor = true;
            this.ctrlZipperBrowse.Click += new System.EventHandler(this.ClickBrowseZipper);
            // 
            // ctrlZipper
            // 
            this.ctrlZipper.Location = new System.Drawing.Point(152, 78);
            this.ctrlZipper.Name = "ctrlZipper";
            this.ctrlZipper.ReadOnly = true;
            this.ctrlZipper.Size = new System.Drawing.Size(623, 20);
            this.ctrlZipper.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(6, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 23);
            this.label1.TabIndex = 3;
            this.label1.Text = "Call of Duty 4 folder:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ctrlInstallPathBrowse
            // 
            this.ctrlInstallPathBrowse.Location = new System.Drawing.Point(781, 6);
            this.ctrlInstallPathBrowse.Name = "ctrlInstallPathBrowse";
            this.ctrlInstallPathBrowse.Size = new System.Drawing.Size(75, 23);
            this.ctrlInstallPathBrowse.TabIndex = 0;
            this.ctrlInstallPathBrowse.Text = "Browse";
            this.ctrlInstallPathBrowse.UseVisualStyleBackColor = true;
            this.ctrlInstallPathBrowse.Click += new System.EventHandler(this.ClickBrowseInstallPath);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(6, 47);
            this.label3.Margin = new System.Windows.Forms.Padding(3, 12, 3, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(140, 23);
            this.label3.TabIndex = 5;
            this.label3.Text = "Language:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ctrlInstallPath
            // 
            this.ctrlInstallPath.Location = new System.Drawing.Point(152, 8);
            this.ctrlInstallPath.Name = "ctrlInstallPath";
            this.ctrlInstallPath.ReadOnly = true;
            this.ctrlInstallPath.Size = new System.Drawing.Size(623, 20);
            this.ctrlInstallPath.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(152, 28);
            this.label2.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(456, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "WARNING: If the directory does not contain Call of Duty 4 it may result in unexpe" +
    "cted behavior!";
            // 
            // ctrlLanguageSelect
            // 
            this.ctrlLanguageSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ctrlLanguageSelect.FormattingEnabled = true;
            this.ctrlLanguageSelect.Items.AddRange(new object[] {
            "English",
            "French",
            "German",
            "Polish"});
            this.ctrlLanguageSelect.Location = new System.Drawing.Point(152, 48);
            this.ctrlLanguageSelect.Name = "ctrlLanguageSelect";
            this.ctrlLanguageSelect.Size = new System.Drawing.Size(150, 21);
            this.ctrlLanguageSelect.TabIndex = 6;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage2.Controls.Add(this.ctrlAdvancedReset);
            this.tabPage2.Controls.Add(this.ctrlAdvancedSave);
            this.tabPage2.Controls.Add(this.ctrlSyncTools);
            this.tabPage2.Controls.Add(this.ctrlExeNameBrowse);
            this.tabPage2.Controls.Add(this.label14);
            this.tabPage2.Controls.Add(this.ctrlTextEditorBrowse);
            this.tabPage2.Controls.Add(this.ctrlExeName);
            this.tabPage2.Controls.Add(this.ctrlTextEditor);
            this.tabPage2.Controls.Add(this.label15);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(862, 236);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Advanced";
            // 
            // ctrlAdvancedReset
            // 
            this.ctrlAdvancedReset.Location = new System.Drawing.Point(650, 90);
            this.ctrlAdvancedReset.Name = "ctrlAdvancedReset";
            this.ctrlAdvancedReset.Size = new System.Drawing.Size(100, 23);
            this.ctrlAdvancedReset.TabIndex = 36;
            this.ctrlAdvancedReset.Text = "Reset";
            this.ctrlAdvancedReset.UseVisualStyleBackColor = true;
            this.ctrlAdvancedReset.Click += new System.EventHandler(this.ClickResetAdvanced);
            // 
            // ctrlAdvancedSave
            // 
            this.ctrlAdvancedSave.Location = new System.Drawing.Point(756, 90);
            this.ctrlAdvancedSave.Name = "ctrlAdvancedSave";
            this.ctrlAdvancedSave.Size = new System.Drawing.Size(100, 23);
            this.ctrlAdvancedSave.TabIndex = 35;
            this.ctrlAdvancedSave.Text = "Save Changes";
            this.ctrlAdvancedSave.UseVisualStyleBackColor = true;
            this.ctrlAdvancedSave.Click += new System.EventHandler(this.ClickPreferencesSave);
            // 
            // ctrlSyncTools
            // 
            this.ctrlSyncTools.AutoSize = true;
            this.ctrlSyncTools.Location = new System.Drawing.Point(6, 61);
            this.ctrlSyncTools.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.ctrlSyncTools.Name = "ctrlSyncTools";
            this.ctrlSyncTools.Size = new System.Drawing.Size(153, 17);
            this.ctrlSyncTools.TabIndex = 8;
            this.ctrlSyncTools.Text = "Synchronize Compile Tools";
            this.ctrlSyncTools.UseVisualStyleBackColor = true;
            this.ctrlSyncTools.CheckedChanged += new System.EventHandler(this.SyncToolsChanged);
            // 
            // ctrlExeNameBrowse
            // 
            this.ctrlExeNameBrowse.Location = new System.Drawing.Point(781, 6);
            this.ctrlExeNameBrowse.Name = "ctrlExeNameBrowse";
            this.ctrlExeNameBrowse.Size = new System.Drawing.Size(75, 23);
            this.ctrlExeNameBrowse.TabIndex = 15;
            this.ctrlExeNameBrowse.Text = "Browse";
            this.ctrlExeNameBrowse.UseVisualStyleBackColor = true;
            this.ctrlExeNameBrowse.Click += new System.EventHandler(this.ClickBrowseExecutable);
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(6, 6);
            this.label14.Margin = new System.Windows.Forms.Padding(3);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(140, 23);
            this.label14.TabIndex = 10;
            this.label14.Text = "Single player executable:";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ctrlTextEditorBrowse
            // 
            this.ctrlTextEditorBrowse.Location = new System.Drawing.Point(781, 32);
            this.ctrlTextEditorBrowse.Name = "ctrlTextEditorBrowse";
            this.ctrlTextEditorBrowse.Size = new System.Drawing.Size(75, 23);
            this.ctrlTextEditorBrowse.TabIndex = 14;
            this.ctrlTextEditorBrowse.Text = "Browse";
            this.ctrlTextEditorBrowse.UseVisualStyleBackColor = true;
            this.ctrlTextEditorBrowse.Click += new System.EventHandler(this.ClickBrowseTextEditor);
            // 
            // ctrlExeName
            // 
            this.ctrlExeName.Location = new System.Drawing.Point(152, 8);
            this.ctrlExeName.Name = "ctrlExeName";
            this.ctrlExeName.ReadOnly = true;
            this.ctrlExeName.Size = new System.Drawing.Size(623, 20);
            this.ctrlExeName.TabIndex = 11;
            this.ctrlExeName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OptionalBinaryKeyPress);
            // 
            // ctrlTextEditor
            // 
            this.ctrlTextEditor.Location = new System.Drawing.Point(152, 34);
            this.ctrlTextEditor.Name = "ctrlTextEditor";
            this.ctrlTextEditor.ReadOnly = true;
            this.ctrlTextEditor.Size = new System.Drawing.Size(623, 20);
            this.ctrlTextEditor.TabIndex = 13;
            this.ctrlTextEditor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OptionalBinaryKeyPress);
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(6, 32);
            this.label15.Margin = new System.Windows.Forms.Padding(3, 12, 3, 3);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(140, 23);
            this.label15.TabIndex = 12;
            this.label15.Text = "Text editor:";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage3.Controls.Add(this.ctrlCustomSave);
            this.tabPage3.Controls.Add(this.ctrlCustomClear);
            this.tabPage3.Controls.Add(this.label24);
            this.tabPage3.Controls.Add(this.label23);
            this.tabPage3.Controls.Add(this.label22);
            this.tabPage3.Controls.Add(this.label21);
            this.tabPage3.Controls.Add(this.label19);
            this.tabPage3.Controls.Add(this.label20);
            this.tabPage3.Controls.Add(this.label18);
            this.tabPage3.Controls.Add(this.label17);
            this.tabPage3.Controls.Add(this.ctrlC3Browse);
            this.tabPage3.Controls.Add(this.ctrlC0Text);
            this.tabPage3.Controls.Add(this.ctrlC3Value);
            this.tabPage3.Controls.Add(this.ctrlC0Value);
            this.tabPage3.Controls.Add(this.ctrlC3Text);
            this.tabPage3.Controls.Add(this.ctrlC0Browse);
            this.tabPage3.Controls.Add(this.ctrlC2Browse);
            this.tabPage3.Controls.Add(this.ctrlC1Text);
            this.tabPage3.Controls.Add(this.ctrlC2Value);
            this.tabPage3.Controls.Add(this.ctrlC1Value);
            this.tabPage3.Controls.Add(this.ctrlC2Text);
            this.tabPage3.Controls.Add(this.ctrlC1Browse);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(862, 236);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Optional";
            // 
            // ctrlCustomSave
            // 
            this.ctrlCustomSave.Location = new System.Drawing.Point(756, 125);
            this.ctrlCustomSave.Name = "ctrlCustomSave";
            this.ctrlCustomSave.Size = new System.Drawing.Size(100, 23);
            this.ctrlCustomSave.TabIndex = 34;
            this.ctrlCustomSave.Text = "Save Changes";
            this.ctrlCustomSave.UseVisualStyleBackColor = true;
            this.ctrlCustomSave.Click += new System.EventHandler(this.ClickPreferencesSave);
            // 
            // ctrlCustomClear
            // 
            this.ctrlCustomClear.Location = new System.Drawing.Point(650, 125);
            this.ctrlCustomClear.Name = "ctrlCustomClear";
            this.ctrlCustomClear.Size = new System.Drawing.Size(100, 23);
            this.ctrlCustomClear.TabIndex = 33;
            this.ctrlCustomClear.Text = "Clear All";
            this.ctrlCustomClear.UseVisualStyleBackColor = true;
            this.ctrlCustomClear.Click += new System.EventHandler(this.ClickClearOptional);
            // 
            // label24
            // 
            this.label24.Location = new System.Drawing.Point(198, 90);
            this.label24.Margin = new System.Windows.Forms.Padding(3);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(80, 23);
            this.label24.TabIndex = 32;
            this.label24.Text = "Destination #4:";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label23
            // 
            this.label23.Location = new System.Drawing.Point(198, 61);
            this.label23.Margin = new System.Windows.Forms.Padding(3);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(80, 23);
            this.label23.TabIndex = 31;
            this.label23.Text = "Destination #3:";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label22
            // 
            this.label22.Location = new System.Drawing.Point(198, 32);
            this.label22.Margin = new System.Windows.Forms.Padding(3);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(80, 23);
            this.label22.TabIndex = 30;
            this.label22.Text = "Destination #2:";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label21
            // 
            this.label21.Location = new System.Drawing.Point(198, 6);
            this.label21.Margin = new System.Windows.Forms.Padding(3);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(80, 23);
            this.label21.TabIndex = 29;
            this.label21.Text = "Destination #1:";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label19
            // 
            this.label19.Location = new System.Drawing.Point(6, 90);
            this.label19.Margin = new System.Windows.Forms.Padding(3);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(80, 23);
            this.label19.TabIndex = 28;
            this.label19.Text = "Text #4:";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label20
            // 
            this.label20.Location = new System.Drawing.Point(6, 61);
            this.label20.Margin = new System.Windows.Forms.Padding(3);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(80, 23);
            this.label20.TabIndex = 27;
            this.label20.Text = "Text #3:";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label18
            // 
            this.label18.Location = new System.Drawing.Point(6, 32);
            this.label18.Margin = new System.Windows.Forms.Padding(3);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(80, 23);
            this.label18.TabIndex = 26;
            this.label18.Text = "Text #2:";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label17
            // 
            this.label17.Location = new System.Drawing.Point(6, 6);
            this.label17.Margin = new System.Windows.Forms.Padding(3);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(80, 23);
            this.label17.TabIndex = 25;
            this.label17.Text = "Text #1:";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ctrlC3Browse
            // 
            this.ctrlC3Browse.Location = new System.Drawing.Point(781, 90);
            this.ctrlC3Browse.Name = "ctrlC3Browse";
            this.ctrlC3Browse.Size = new System.Drawing.Size(75, 23);
            this.ctrlC3Browse.TabIndex = 24;
            this.ctrlC3Browse.Text = "Browse";
            this.ctrlC3Browse.UseVisualStyleBackColor = true;
            this.ctrlC3Browse.Click += new System.EventHandler(this.ClickBrowseCustom);
            // 
            // ctrlC0Text
            // 
            this.ctrlC0Text.Location = new System.Drawing.Point(92, 8);
            this.ctrlC0Text.Name = "ctrlC0Text";
            this.ctrlC0Text.Size = new System.Drawing.Size(100, 20);
            this.ctrlC0Text.TabIndex = 0;
            // 
            // ctrlC3Value
            // 
            this.ctrlC3Value.Location = new System.Drawing.Point(284, 92);
            this.ctrlC3Value.Name = "ctrlC3Value";
            this.ctrlC3Value.Size = new System.Drawing.Size(491, 20);
            this.ctrlC3Value.TabIndex = 23;
            // 
            // ctrlC0Value
            // 
            this.ctrlC0Value.Location = new System.Drawing.Point(284, 8);
            this.ctrlC0Value.Name = "ctrlC0Value";
            this.ctrlC0Value.Size = new System.Drawing.Size(491, 20);
            this.ctrlC0Value.TabIndex = 1;
            // 
            // ctrlC3Text
            // 
            this.ctrlC3Text.Location = new System.Drawing.Point(92, 92);
            this.ctrlC3Text.Name = "ctrlC3Text";
            this.ctrlC3Text.Size = new System.Drawing.Size(100, 20);
            this.ctrlC3Text.TabIndex = 22;
            // 
            // ctrlC0Browse
            // 
            this.ctrlC0Browse.Location = new System.Drawing.Point(781, 6);
            this.ctrlC0Browse.Name = "ctrlC0Browse";
            this.ctrlC0Browse.Size = new System.Drawing.Size(75, 23);
            this.ctrlC0Browse.TabIndex = 15;
            this.ctrlC0Browse.Text = "Browse";
            this.ctrlC0Browse.UseVisualStyleBackColor = true;
            this.ctrlC0Browse.Click += new System.EventHandler(this.ClickBrowseCustom);
            // 
            // ctrlC2Browse
            // 
            this.ctrlC2Browse.Location = new System.Drawing.Point(781, 61);
            this.ctrlC2Browse.Name = "ctrlC2Browse";
            this.ctrlC2Browse.Size = new System.Drawing.Size(75, 23);
            this.ctrlC2Browse.TabIndex = 21;
            this.ctrlC2Browse.Text = "Browse";
            this.ctrlC2Browse.UseVisualStyleBackColor = true;
            this.ctrlC2Browse.Click += new System.EventHandler(this.ClickBrowseCustom);
            // 
            // ctrlC1Text
            // 
            this.ctrlC1Text.Location = new System.Drawing.Point(92, 34);
            this.ctrlC1Text.Name = "ctrlC1Text";
            this.ctrlC1Text.Size = new System.Drawing.Size(100, 20);
            this.ctrlC1Text.TabIndex = 16;
            // 
            // ctrlC2Value
            // 
            this.ctrlC2Value.Location = new System.Drawing.Point(284, 63);
            this.ctrlC2Value.Name = "ctrlC2Value";
            this.ctrlC2Value.Size = new System.Drawing.Size(491, 20);
            this.ctrlC2Value.TabIndex = 20;
            // 
            // ctrlC1Value
            // 
            this.ctrlC1Value.Location = new System.Drawing.Point(284, 34);
            this.ctrlC1Value.Name = "ctrlC1Value";
            this.ctrlC1Value.Size = new System.Drawing.Size(491, 20);
            this.ctrlC1Value.TabIndex = 17;
            // 
            // ctrlC2Text
            // 
            this.ctrlC2Text.Location = new System.Drawing.Point(92, 63);
            this.ctrlC2Text.Name = "ctrlC2Text";
            this.ctrlC2Text.Size = new System.Drawing.Size(100, 20);
            this.ctrlC2Text.TabIndex = 19;
            // 
            // ctrlC1Browse
            // 
            this.ctrlC1Browse.Location = new System.Drawing.Point(781, 32);
            this.ctrlC1Browse.Name = "ctrlC1Browse";
            this.ctrlC1Browse.Size = new System.Drawing.Size(75, 23);
            this.ctrlC1Browse.TabIndex = 18;
            this.ctrlC1Browse.Text = "Browse";
            this.ctrlC1Browse.UseVisualStyleBackColor = true;
            this.ctrlC1Browse.Click += new System.EventHandler(this.ClickBrowseCustom);
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel3.Controls.Add(this.pictureBox1);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.label11);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.label12);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.label13);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Location = new System.Drawing.Point(6, 274);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(479, 261);
            this.panel3.TabIndex = 19;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::SPiApp.Properties.Resources.spi_tools_icon2;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(250, 250);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(365, 136);
            this.label10.Margin = new System.Windows.Forms.Padding(16, 3, 3, 3);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(100, 13);
            this.label10.TabIndex = 18;
            this.label10.Text = "18120501";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(250, 0);
            this.label4.Margin = new System.Windows.Forms.Padding(0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(165, 24);
            this.label4.TabIndex = 9;
            this.label4.Text = "SPi Compile Tools";
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(365, 117);
            this.label11.Margin = new System.Windows.Forms.Padding(16, 3, 3, 3);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(100, 13);
            this.label11.TabIndex = 17;
            this.label11.Text = "1.0a";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(266, 27);
            this.label5.Margin = new System.Windows.Forms.Padding(16, 3, 3, 3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Designed by:";
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(266, 136);
            this.label12.Margin = new System.Windows.Forms.Padding(16, 3, 3, 3);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(80, 13);
            this.label12.TabIndex = 16;
            this.label12.Text = "Built:";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(266, 46);
            this.label6.Margin = new System.Windows.Forms.Padding(16, 3, 3, 3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Developed by:";
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(266, 117);
            this.label13.Margin = new System.Windows.Forms.Padding(16, 3, 3, 3);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(80, 13);
            this.label13.TabIndex = 15;
            this.label13.Text = "Version:";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(365, 27);
            this.label7.Margin = new System.Windows.Forms.Padding(16, 3, 3, 3);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "SPi";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(253, 90);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(200, 24);
            this.label9.TabIndex = 14;
            this.label9.Text = "Application Information";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(365, 46);
            this.label8.Margin = new System.Windows.Forms.Padding(16, 3, 3, 3);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(100, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "Scillman";
            // 
            // tabDevelopment
            // 
            this.tabDevelopment.BackColor = System.Drawing.SystemColors.Control;
            this.tabDevelopment.Controls.Add(this.column5);
            this.tabDevelopment.Controls.Add(this.column4);
            this.tabDevelopment.Controls.Add(this.column3);
            this.tabDevelopment.Controls.Add(this.column2);
            this.tabDevelopment.Controls.Add(this.column1);
            this.tabDevelopment.Controls.Add(this.column0);
            this.tabDevelopment.Location = new System.Drawing.Point(4, 22);
            this.tabDevelopment.Name = "tabDevelopment";
            this.tabDevelopment.Padding = new System.Windows.Forms.Padding(3);
            this.tabDevelopment.Size = new System.Drawing.Size(882, 541);
            this.tabDevelopment.TabIndex = 1;
            this.tabDevelopment.Text = "Mission Developing";
            // 
            // column5
            // 
            this.column5.BackColor = System.Drawing.SystemColors.Control;
            this.column5.Controls.Add(this.ctrlCustom3);
            this.column5.Controls.Add(this.ctrlCustom2);
            this.column5.Controls.Add(this.ctrlCustom1);
            this.column5.Controls.Add(this.ctrlCustom0);
            this.column5.Location = new System.Drawing.Point(232, 505);
            this.column5.Name = "column5";
            this.column5.Size = new System.Drawing.Size(418, 23);
            this.column5.TabIndex = 11;
            // 
            // ctrlCustom3
            // 
            this.ctrlCustom3.Enabled = false;
            this.ctrlCustom3.Location = new System.Drawing.Point(318, 0);
            this.ctrlCustom3.Name = "ctrlCustom3";
            this.ctrlCustom3.Size = new System.Drawing.Size(100, 23);
            this.ctrlCustom3.TabIndex = 5;
            this.ctrlCustom3.Text = "Custom3";
            this.ctrlCustom3.UseVisualStyleBackColor = true;
            this.ctrlCustom3.Click += new System.EventHandler(this.PressCustomControl);
            // 
            // ctrlCustom2
            // 
            this.ctrlCustom2.Enabled = false;
            this.ctrlCustom2.Location = new System.Drawing.Point(212, 0);
            this.ctrlCustom2.Name = "ctrlCustom2";
            this.ctrlCustom2.Size = new System.Drawing.Size(100, 23);
            this.ctrlCustom2.TabIndex = 4;
            this.ctrlCustom2.Text = "Custom2";
            this.ctrlCustom2.UseVisualStyleBackColor = true;
            this.ctrlCustom2.Click += new System.EventHandler(this.PressCustomControl);
            // 
            // ctrlCustom1
            // 
            this.ctrlCustom1.Enabled = false;
            this.ctrlCustom1.Location = new System.Drawing.Point(106, 0);
            this.ctrlCustom1.Name = "ctrlCustom1";
            this.ctrlCustom1.Size = new System.Drawing.Size(100, 23);
            this.ctrlCustom1.TabIndex = 3;
            this.ctrlCustom1.Text = "Custom1";
            this.ctrlCustom1.UseVisualStyleBackColor = true;
            this.ctrlCustom1.Click += new System.EventHandler(this.PressCustomControl);
            // 
            // ctrlCustom0
            // 
            this.ctrlCustom0.Enabled = false;
            this.ctrlCustom0.Location = new System.Drawing.Point(0, 0);
            this.ctrlCustom0.Name = "ctrlCustom0";
            this.ctrlCustom0.Size = new System.Drawing.Size(100, 23);
            this.ctrlCustom0.TabIndex = 2;
            this.ctrlCustom0.Text = "Custom0";
            this.ctrlCustom0.UseVisualStyleBackColor = true;
            this.ctrlCustom0.Click += new System.EventHandler(this.PressCustomControl);
            // 
            // column4
            // 
            this.column4.BackColor = System.Drawing.SystemColors.Control;
            this.column4.Controls.Add(this.groupBox4);
            this.column4.Location = new System.Drawing.Point(232, 6);
            this.column4.Name = "column4";
            this.column4.Size = new System.Drawing.Size(418, 44);
            this.column4.TabIndex = 10;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.ctrlFileEffectsEditor);
            this.groupBox4.Controls.Add(this.ctrlFileAssetManager);
            this.groupBox4.Controls.Add(this.ctrlFileRadiant);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(0, 0);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(418, 44);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Applications";
            // 
            // ctrlFileEffectsEditor
            // 
            this.ctrlFileEffectsEditor.Location = new System.Drawing.Point(218, 15);
            this.ctrlFileEffectsEditor.Name = "ctrlFileEffectsEditor";
            this.ctrlFileEffectsEditor.Size = new System.Drawing.Size(100, 23);
            this.ctrlFileEffectsEditor.TabIndex = 3;
            this.ctrlFileEffectsEditor.Text = "Effects Editor";
            this.ctrlFileEffectsEditor.UseVisualStyleBackColor = true;
            this.ctrlFileEffectsEditor.Click += new System.EventHandler(this.PressFileEffectsEditor);
            // 
            // ctrlFileAssetManager
            // 
            this.ctrlFileAssetManager.Location = new System.Drawing.Point(112, 15);
            this.ctrlFileAssetManager.Name = "ctrlFileAssetManager";
            this.ctrlFileAssetManager.Size = new System.Drawing.Size(100, 23);
            this.ctrlFileAssetManager.TabIndex = 2;
            this.ctrlFileAssetManager.Text = "Asset Manager";
            this.ctrlFileAssetManager.UseVisualStyleBackColor = true;
            this.ctrlFileAssetManager.Click += new System.EventHandler(this.PressFileAssetManager);
            // 
            // ctrlFileRadiant
            // 
            this.ctrlFileRadiant.Location = new System.Drawing.Point(6, 15);
            this.ctrlFileRadiant.Name = "ctrlFileRadiant";
            this.ctrlFileRadiant.Size = new System.Drawing.Size(100, 23);
            this.ctrlFileRadiant.TabIndex = 1;
            this.ctrlFileRadiant.Text = "Radiant";
            this.ctrlFileRadiant.UseVisualStyleBackColor = true;
            this.ctrlFileRadiant.Click += new System.EventHandler(this.PressFileRadiant);
            // 
            // column3
            // 
            this.column3.BackColor = System.Drawing.SystemColors.Control;
            this.column3.Controls.Add(this.groupBox7);
            this.column3.Controls.Add(this.panel2);
            this.column3.Location = new System.Drawing.Point(656, 6);
            this.column3.Name = "column3";
            this.column3.Size = new System.Drawing.Size(220, 529);
            this.column3.TabIndex = 9;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.ctrlNewMod);
            this.groupBox7.Controls.Add(this.ctrlRefreshModList);
            this.groupBox7.Controls.Add(this.ctrlModList);
            this.groupBox7.Location = new System.Drawing.Point(0, 0);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(220, 286);
            this.groupBox7.TabIndex = 1;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Mod Builder";
            // 
            // ctrlNewMod
            // 
            this.ctrlNewMod.Location = new System.Drawing.Point(6, 15);
            this.ctrlNewMod.Name = "ctrlNewMod";
            this.ctrlNewMod.Size = new System.Drawing.Size(80, 23);
            this.ctrlNewMod.TabIndex = 5;
            this.ctrlNewMod.Text = "New Mod";
            this.ctrlNewMod.UseVisualStyleBackColor = true;
            this.ctrlNewMod.Click += new System.EventHandler(this.CreateNewMod);
            // 
            // ctrlRefreshModList
            // 
            this.ctrlRefreshModList.Location = new System.Drawing.Point(132, 15);
            this.ctrlRefreshModList.Name = "ctrlRefreshModList";
            this.ctrlRefreshModList.Size = new System.Drawing.Size(80, 23);
            this.ctrlRefreshModList.TabIndex = 4;
            this.ctrlRefreshModList.Text = "Refresh";
            this.ctrlRefreshModList.UseVisualStyleBackColor = true;
            this.ctrlRefreshModList.Click += new System.EventHandler(this.RefreshMods);
            // 
            // ctrlModList
            // 
            this.ctrlModList.FormattingEnabled = true;
            this.ctrlModList.Location = new System.Drawing.Point(6, 42);
            this.ctrlModList.Name = "ctrlModList";
            this.ctrlModList.Size = new System.Drawing.Size(208, 238);
            this.ctrlModList.Sorted = true;
            this.ctrlModList.TabIndex = 3;
            this.ctrlModList.SelectedIndexChanged += new System.EventHandler(this.SelectedMod);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.ctrlModIWD);
            this.panel2.Controls.Add(this.ctrlModBrowse);
            this.panel2.Controls.Add(this.ctrlModCustom);
            this.panel2.Controls.Add(this.ctrlModRun);
            this.panel2.Controls.Add(this.ctrlModBuild);
            this.panel2.Controls.Add(this.ctrlModUpdate);
            this.panel2.Controls.Add(this.ctrlModOptions);
            this.panel2.Location = new System.Drawing.Point(0, 289);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(220, 238);
            this.panel2.TabIndex = 5;
            // 
            // ctrlModIWD
            // 
            this.ctrlModIWD.Location = new System.Drawing.Point(6, 58);
            this.ctrlModIWD.Name = "ctrlModIWD";
            this.ctrlModIWD.Size = new System.Drawing.Size(120, 23);
            this.ctrlModIWD.TabIndex = 13;
            this.ctrlModIWD.Text = "Build IWD File";
            this.ctrlModIWD.UseVisualStyleBackColor = true;
            this.ctrlModIWD.Click += new System.EventHandler(this.PressUpdateModIWD);
            // 
            // ctrlModBrowse
            // 
            this.ctrlModBrowse.Location = new System.Drawing.Point(6, 0);
            this.ctrlModBrowse.Name = "ctrlModBrowse";
            this.ctrlModBrowse.Size = new System.Drawing.Size(120, 23);
            this.ctrlModBrowse.TabIndex = 12;
            this.ctrlModBrowse.Text = "Browse Folder";
            this.ctrlModBrowse.UseVisualStyleBackColor = true;
            this.ctrlModBrowse.Click += new System.EventHandler(this.PressBrowseMod);
            // 
            // ctrlModCustom
            // 
            this.ctrlModCustom.Location = new System.Drawing.Point(6, 212);
            this.ctrlModCustom.Name = "ctrlModCustom";
            this.ctrlModCustom.Size = new System.Drawing.Size(202, 20);
            this.ctrlModCustom.TabIndex = 11;
            this.ctrlModCustom.TextChanged += new System.EventHandler(this.OnModSettingsChanged);
            // 
            // ctrlModRun
            // 
            this.ctrlModRun.Location = new System.Drawing.Point(6, 116);
            this.ctrlModRun.Name = "ctrlModRun";
            this.ctrlModRun.Size = new System.Drawing.Size(120, 23);
            this.ctrlModRun.TabIndex = 9;
            this.ctrlModRun.Text = "Run Selected Mod";
            this.ctrlModRun.UseVisualStyleBackColor = true;
            this.ctrlModRun.Click += new System.EventHandler(this.PressRunMod);
            // 
            // ctrlModBuild
            // 
            this.ctrlModBuild.Location = new System.Drawing.Point(6, 29);
            this.ctrlModBuild.Name = "ctrlModBuild";
            this.ctrlModBuild.Size = new System.Drawing.Size(120, 23);
            this.ctrlModBuild.TabIndex = 7;
            this.ctrlModBuild.Text = "Build Fast File";
            this.ctrlModBuild.UseVisualStyleBackColor = true;
            this.ctrlModBuild.Click += new System.EventHandler(this.PressBuildModFF);
            // 
            // ctrlModUpdate
            // 
            this.ctrlModUpdate.Location = new System.Drawing.Point(6, 87);
            this.ctrlModUpdate.Name = "ctrlModUpdate";
            this.ctrlModUpdate.Size = new System.Drawing.Size(120, 23);
            this.ctrlModUpdate.TabIndex = 8;
            this.ctrlModUpdate.Text = "Update Zone File";
            this.ctrlModUpdate.UseVisualStyleBackColor = true;
            this.ctrlModUpdate.Click += new System.EventHandler(this.PressUpdateModZone);
            // 
            // ctrlModOptions
            // 
            this.ctrlModOptions.BackColor = System.Drawing.SystemColors.Control;
            this.ctrlModOptions.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ctrlModOptions.CheckOnClick = true;
            this.ctrlModOptions.FormattingEnabled = true;
            this.ctrlModOptions.Items.AddRange(new object[] {
            "Enable Developer",
            "Enable Developer Script",
            "Enable Cheats",
            "Use Custom Command Line Options"});
            this.ctrlModOptions.Location = new System.Drawing.Point(6, 145);
            this.ctrlModOptions.Name = "ctrlModOptions";
            this.ctrlModOptions.Size = new System.Drawing.Size(202, 60);
            this.ctrlModOptions.TabIndex = 10;
            this.ctrlModOptions.SelectedIndexChanged += new System.EventHandler(this.OnModSettingsChanged);
            // 
            // column2
            // 
            this.column2.BackColor = System.Drawing.SystemColors.Control;
            this.column2.Controls.Add(this.groupBox6);
            this.column2.Controls.Add(this.groupBox9);
            this.column2.Location = new System.Drawing.Point(538, 56);
            this.column2.Name = "column2";
            this.column2.Size = new System.Drawing.Size(112, 396);
            this.column2.TabIndex = 8;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.ctrlShowCode);
            this.groupBox6.Controls.Add(this.ctrlShowSoundaliases);
            this.groupBox6.Controls.Add(this.ctrlShowLocalizedstrings);
            this.groupBox6.Controls.Add(this.ctrlShowFx);
            this.groupBox6.Controls.Add(this.ctrlShowAnim);
            this.groupBox6.Controls.Add(this.ctrlShowMap);
            this.groupBox6.Location = new System.Drawing.Point(0, 0);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(112, 192);
            this.groupBox6.TabIndex = 1;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "File Browsing";
            // 
            // ctrlShowCode
            // 
            this.ctrlShowCode.Location = new System.Drawing.Point(6, 44);
            this.ctrlShowCode.Name = "ctrlShowCode";
            this.ctrlShowCode.Size = new System.Drawing.Size(100, 23);
            this.ctrlShowCode.TabIndex = 5;
            this.ctrlShowCode.Text = "map_code.gsc";
            this.ctrlShowCode.UseVisualStyleBackColor = true;
            this.ctrlShowCode.Click += new System.EventHandler(this.ShowFileCode);
            // 
            // ctrlShowSoundaliases
            // 
            this.ctrlShowSoundaliases.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlShowSoundaliases.Location = new System.Drawing.Point(6, 160);
            this.ctrlShowSoundaliases.Name = "ctrlShowSoundaliases";
            this.ctrlShowSoundaliases.Size = new System.Drawing.Size(100, 23);
            this.ctrlShowSoundaliases.TabIndex = 4;
            this.ctrlShowSoundaliases.Text = "sa/map.csv";
            this.ctrlShowSoundaliases.UseVisualStyleBackColor = true;
            this.ctrlShowSoundaliases.Click += new System.EventHandler(this.ShowFileSoundaliases);
            // 
            // ctrlShowLocalizedstrings
            // 
            this.ctrlShowLocalizedstrings.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlShowLocalizedstrings.Location = new System.Drawing.Point(6, 131);
            this.ctrlShowLocalizedstrings.Name = "ctrlShowLocalizedstrings";
            this.ctrlShowLocalizedstrings.Size = new System.Drawing.Size(100, 23);
            this.ctrlShowLocalizedstrings.TabIndex = 3;
            this.ctrlShowLocalizedstrings.Text = "map.str";
            this.ctrlShowLocalizedstrings.UseVisualStyleBackColor = true;
            this.ctrlShowLocalizedstrings.Click += new System.EventHandler(this.ShowFileLocalizedstrings);
            // 
            // ctrlShowFx
            // 
            this.ctrlShowFx.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlShowFx.Location = new System.Drawing.Point(6, 102);
            this.ctrlShowFx.Name = "ctrlShowFx";
            this.ctrlShowFx.Size = new System.Drawing.Size(100, 23);
            this.ctrlShowFx.TabIndex = 2;
            this.ctrlShowFx.Text = "map_fx.gsc";
            this.ctrlShowFx.UseVisualStyleBackColor = true;
            this.ctrlShowFx.Click += new System.EventHandler(this.ShowFileFx);
            // 
            // ctrlShowAnim
            // 
            this.ctrlShowAnim.Location = new System.Drawing.Point(6, 73);
            this.ctrlShowAnim.Name = "ctrlShowAnim";
            this.ctrlShowAnim.Size = new System.Drawing.Size(100, 23);
            this.ctrlShowAnim.TabIndex = 1;
            this.ctrlShowAnim.Text = "map_anim.gsc";
            this.ctrlShowAnim.UseVisualStyleBackColor = true;
            this.ctrlShowAnim.Click += new System.EventHandler(this.ShowFileAnim);
            // 
            // ctrlShowMap
            // 
            this.ctrlShowMap.Location = new System.Drawing.Point(6, 15);
            this.ctrlShowMap.Name = "ctrlShowMap";
            this.ctrlShowMap.Size = new System.Drawing.Size(100, 23);
            this.ctrlShowMap.TabIndex = 0;
            this.ctrlShowMap.Text = "map.gsc";
            this.ctrlShowMap.UseVisualStyleBackColor = true;
            this.ctrlShowMap.Click += new System.EventHandler(this.ShowFileMap);
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.ctrlFolderSoundaliases);
            this.groupBox9.Controls.Add(this.ctrlFolderSound);
            this.groupBox9.Controls.Add(this.ctrlFolderMaps);
            this.groupBox9.Controls.Add(this.ctrlFolderLocalizedstrings);
            this.groupBox9.Controls.Add(this.ctrlFolderMapSource);
            this.groupBox9.Controls.Add(this.ctrlFolderMods);
            this.groupBox9.Location = new System.Drawing.Point(0, 198);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(112, 192);
            this.groupBox9.TabIndex = 4;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Folder Browsing";
            // 
            // ctrlFolderSoundaliases
            // 
            this.ctrlFolderSoundaliases.Location = new System.Drawing.Point(6, 160);
            this.ctrlFolderSoundaliases.Name = "ctrlFolderSoundaliases";
            this.ctrlFolderSoundaliases.Size = new System.Drawing.Size(100, 23);
            this.ctrlFolderSoundaliases.TabIndex = 5;
            this.ctrlFolderSoundaliases.Text = "soundaliases";
            this.ctrlFolderSoundaliases.UseVisualStyleBackColor = true;
            this.ctrlFolderSoundaliases.Click += new System.EventHandler(this.BrowseSoundaliases);
            // 
            // ctrlFolderSound
            // 
            this.ctrlFolderSound.Location = new System.Drawing.Point(6, 131);
            this.ctrlFolderSound.Name = "ctrlFolderSound";
            this.ctrlFolderSound.Size = new System.Drawing.Size(100, 23);
            this.ctrlFolderSound.TabIndex = 4;
            this.ctrlFolderSound.Text = "sound";
            this.ctrlFolderSound.UseVisualStyleBackColor = true;
            this.ctrlFolderSound.Click += new System.EventHandler(this.BrowseSound);
            // 
            // ctrlFolderMaps
            // 
            this.ctrlFolderMaps.Location = new System.Drawing.Point(6, 102);
            this.ctrlFolderMaps.Name = "ctrlFolderMaps";
            this.ctrlFolderMaps.Size = new System.Drawing.Size(100, 23);
            this.ctrlFolderMaps.TabIndex = 3;
            this.ctrlFolderMaps.Text = "maps";
            this.ctrlFolderMaps.UseVisualStyleBackColor = true;
            this.ctrlFolderMaps.Click += new System.EventHandler(this.BrowseMaps);
            // 
            // ctrlFolderLocalizedstrings
            // 
            this.ctrlFolderLocalizedstrings.Location = new System.Drawing.Point(6, 73);
            this.ctrlFolderLocalizedstrings.Name = "ctrlFolderLocalizedstrings";
            this.ctrlFolderLocalizedstrings.Size = new System.Drawing.Size(100, 23);
            this.ctrlFolderLocalizedstrings.TabIndex = 2;
            this.ctrlFolderLocalizedstrings.Text = "localizedstrings";
            this.ctrlFolderLocalizedstrings.UseVisualStyleBackColor = true;
            this.ctrlFolderLocalizedstrings.Click += new System.EventHandler(this.BrowseLocalizedstrings);
            // 
            // ctrlFolderMapSource
            // 
            this.ctrlFolderMapSource.Location = new System.Drawing.Point(6, 44);
            this.ctrlFolderMapSource.Name = "ctrlFolderMapSource";
            this.ctrlFolderMapSource.Size = new System.Drawing.Size(100, 23);
            this.ctrlFolderMapSource.TabIndex = 1;
            this.ctrlFolderMapSource.Text = "map_source";
            this.ctrlFolderMapSource.UseVisualStyleBackColor = true;
            this.ctrlFolderMapSource.Click += new System.EventHandler(this.BrowseMapSource);
            // 
            // ctrlFolderMods
            // 
            this.ctrlFolderMods.Location = new System.Drawing.Point(6, 15);
            this.ctrlFolderMods.Name = "ctrlFolderMods";
            this.ctrlFolderMods.Size = new System.Drawing.Size(100, 23);
            this.ctrlFolderMods.TabIndex = 0;
            this.ctrlFolderMods.Text = "mods";
            this.ctrlFolderMods.UseVisualStyleBackColor = true;
            this.ctrlFolderMods.Click += new System.EventHandler(this.BrowseMods);
            // 
            // column1
            // 
            this.column1.BackColor = System.Drawing.SystemColors.Control;
            this.column1.Controls.Add(this.groupBox5);
            this.column1.Controls.Add(this.groupBox8);
            this.column1.Location = new System.Drawing.Point(232, 56);
            this.column1.Name = "column1";
            this.column1.Size = new System.Drawing.Size(300, 443);
            this.column1.TabIndex = 7;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.ctrlOptionsTab);
            this.groupBox5.Controls.Add(this.ctrlCompile);
            this.groupBox5.Location = new System.Drawing.Point(0, 0);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(300, 367);
            this.groupBox5.TabIndex = 1;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Level Compiling";
            // 
            // ctrlOptionsTab
            // 
            this.ctrlOptionsTab.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlOptionsTab.Controls.Add(this.tabOptionsBSP);
            this.ctrlOptionsTab.Controls.Add(this.tabOptionsLight);
            this.ctrlOptionsTab.Location = new System.Drawing.Point(6, 66);
            this.ctrlOptionsTab.Name = "ctrlOptionsTab";
            this.ctrlOptionsTab.SelectedIndex = 0;
            this.ctrlOptionsTab.Size = new System.Drawing.Size(288, 295);
            this.ctrlOptionsTab.TabIndex = 8;
            this.ctrlOptionsTab.Selected += new System.Windows.Forms.TabControlEventHandler(this.OnTabMapOptions);
            // 
            // tabOptionsBSP
            // 
            this.tabOptionsBSP.BackColor = System.Drawing.SystemColors.Control;
            this.tabOptionsBSP.Controls.Add(this.ctrlBspBlockValue);
            this.tabOptionsBSP.Controls.Add(this.ctrlBspSampleValue);
            this.tabOptionsBSP.Controls.Add(this.ctrlBspCustomValue);
            this.tabOptionsBSP.Controls.Add(this.ctrlBspCustom);
            this.tabOptionsBSP.Controls.Add(this.ctrlBspDebug);
            this.tabOptionsBSP.Controls.Add(this.ctrlBspSample);
            this.tabOptionsBSP.Controls.Add(this.ctrlBspBlock);
            this.tabOptionsBSP.Controls.Add(this.ctrlBspEnts);
            this.tabOptionsBSP.Location = new System.Drawing.Point(4, 22);
            this.tabOptionsBSP.Name = "tabOptionsBSP";
            this.tabOptionsBSP.Padding = new System.Windows.Forms.Padding(3);
            this.tabOptionsBSP.Size = new System.Drawing.Size(280, 269);
            this.tabOptionsBSP.TabIndex = 0;
            this.tabOptionsBSP.Text = "BSP Options";
            // 
            // ctrlBspBlockValue
            // 
            this.ctrlBspBlockValue.Location = new System.Drawing.Point(112, 33);
            this.ctrlBspBlockValue.Name = "ctrlBspBlockValue";
            this.ctrlBspBlockValue.Size = new System.Drawing.Size(70, 20);
            this.ctrlBspBlockValue.TabIndex = 7;
            this.ctrlBspBlockValue.TextChanged += new System.EventHandler(this.OnMapSettingsChanged);
            // 
            // ctrlBspSampleValue
            // 
            this.ctrlBspSampleValue.Location = new System.Drawing.Point(112, 59);
            this.ctrlBspSampleValue.Name = "ctrlBspSampleValue";
            this.ctrlBspSampleValue.Size = new System.Drawing.Size(70, 20);
            this.ctrlBspSampleValue.TabIndex = 6;
            this.ctrlBspSampleValue.TextChanged += new System.EventHandler(this.OnMapSettingsChanged);
            // 
            // ctrlBspCustomValue
            // 
            this.ctrlBspCustomValue.Location = new System.Drawing.Point(6, 136);
            this.ctrlBspCustomValue.Name = "ctrlBspCustomValue";
            this.ctrlBspCustomValue.Size = new System.Drawing.Size(268, 20);
            this.ctrlBspCustomValue.TabIndex = 5;
            this.ctrlBspCustomValue.TextChanged += new System.EventHandler(this.OnMapSettingsChanged);
            // 
            // ctrlBspCustom
            // 
            this.ctrlBspCustom.Location = new System.Drawing.Point(6, 110);
            this.ctrlBspCustom.Name = "ctrlBspCustom";
            this.ctrlBspCustom.Size = new System.Drawing.Size(268, 23);
            this.ctrlBspCustom.TabIndex = 4;
            this.ctrlBspCustom.Text = "Use Custom Command Line Options";
            this.ctrlBspCustom.UseVisualStyleBackColor = true;
            this.ctrlBspCustom.CheckedChanged += new System.EventHandler(this.OnMapSettingsChanged);
            this.ctrlBspCustom.TextChanged += new System.EventHandler(this.OnMapSettingsChanged);
            // 
            // ctrlBspDebug
            // 
            this.ctrlBspDebug.Location = new System.Drawing.Point(6, 84);
            this.ctrlBspDebug.Name = "ctrlBspDebug";
            this.ctrlBspDebug.Size = new System.Drawing.Size(268, 23);
            this.ctrlBspDebug.TabIndex = 3;
            this.ctrlBspDebug.Text = "debugLightmaps";
            this.ctrlBspDebug.UseVisualStyleBackColor = true;
            this.ctrlBspDebug.CheckedChanged += new System.EventHandler(this.OnMapSettingsChanged);
            this.ctrlBspDebug.TextChanged += new System.EventHandler(this.OnMapSettingsChanged);
            // 
            // ctrlBspSample
            // 
            this.ctrlBspSample.Location = new System.Drawing.Point(6, 58);
            this.ctrlBspSample.Name = "ctrlBspSample";
            this.ctrlBspSample.Size = new System.Drawing.Size(100, 23);
            this.ctrlBspSample.TabIndex = 2;
            this.ctrlBspSample.Text = "samplescale";
            this.ctrlBspSample.UseVisualStyleBackColor = true;
            this.ctrlBspSample.CheckedChanged += new System.EventHandler(this.OnMapSettingsChanged);
            this.ctrlBspSample.TextChanged += new System.EventHandler(this.OnMapSettingsChanged);
            // 
            // ctrlBspBlock
            // 
            this.ctrlBspBlock.Location = new System.Drawing.Point(6, 32);
            this.ctrlBspBlock.Name = "ctrlBspBlock";
            this.ctrlBspBlock.Size = new System.Drawing.Size(100, 23);
            this.ctrlBspBlock.TabIndex = 1;
            this.ctrlBspBlock.Text = "blocksize";
            this.ctrlBspBlock.UseVisualStyleBackColor = true;
            this.ctrlBspBlock.CheckedChanged += new System.EventHandler(this.OnMapSettingsChanged);
            this.ctrlBspBlock.TextChanged += new System.EventHandler(this.OnMapSettingsChanged);
            // 
            // ctrlBspEnts
            // 
            this.ctrlBspEnts.Location = new System.Drawing.Point(6, 6);
            this.ctrlBspEnts.Name = "ctrlBspEnts";
            this.ctrlBspEnts.Size = new System.Drawing.Size(268, 23);
            this.ctrlBspEnts.TabIndex = 0;
            this.ctrlBspEnts.Text = "onlyents";
            this.ctrlBspEnts.UseVisualStyleBackColor = true;
            this.ctrlBspEnts.CheckedChanged += new System.EventHandler(this.OnMapSettingsChanged);
            this.ctrlBspEnts.TextChanged += new System.EventHandler(this.OnMapSettingsChanged);
            // 
            // tabOptionsLight
            // 
            this.tabOptionsLight.BackColor = System.Drawing.SystemColors.Control;
            this.tabOptionsLight.Controls.Add(this.ctrlLightCustom);
            this.tabOptionsLight.Controls.Add(this.ctrlLightCustomValue);
            this.tabOptionsLight.Controls.Add(this.ctrlLightTracesValue);
            this.tabOptionsLight.Controls.Add(this.ctrlLightJitterValue);
            this.tabOptionsLight.Controls.Add(this.ctrlLightJitter);
            this.tabOptionsLight.Controls.Add(this.ctrlLightTraces);
            this.tabOptionsLight.Controls.Add(this.ctrlLightDump);
            this.tabOptionsLight.Controls.Add(this.ctrlLightNoShadow);
            this.tabOptionsLight.Controls.Add(this.ctrlLightShadow);
            this.tabOptionsLight.Controls.Add(this.ctrlLightVerbose);
            this.tabOptionsLight.Controls.Add(this.ctrlLightExtra);
            this.tabOptionsLight.Controls.Add(this.ctrlLightFast);
            this.tabOptionsLight.Location = new System.Drawing.Point(4, 22);
            this.tabOptionsLight.Name = "tabOptionsLight";
            this.tabOptionsLight.Padding = new System.Windows.Forms.Padding(3);
            this.tabOptionsLight.Size = new System.Drawing.Size(280, 269);
            this.tabOptionsLight.TabIndex = 1;
            this.tabOptionsLight.Text = "Light Options";
            // 
            // ctrlLightCustom
            // 
            this.ctrlLightCustom.Location = new System.Drawing.Point(6, 216);
            this.ctrlLightCustom.Name = "ctrlLightCustom";
            this.ctrlLightCustom.Size = new System.Drawing.Size(268, 23);
            this.ctrlLightCustom.TabIndex = 14;
            this.ctrlLightCustom.Text = "Use Custom Command Line Options";
            this.ctrlLightCustom.UseVisualStyleBackColor = true;
            this.ctrlLightCustom.CheckedChanged += new System.EventHandler(this.OnMapSettingsChanged);
            // 
            // ctrlLightCustomValue
            // 
            this.ctrlLightCustomValue.Location = new System.Drawing.Point(6, 242);
            this.ctrlLightCustomValue.Name = "ctrlLightCustomValue";
            this.ctrlLightCustomValue.Size = new System.Drawing.Size(268, 20);
            this.ctrlLightCustomValue.TabIndex = 13;
            this.ctrlLightCustomValue.TextChanged += new System.EventHandler(this.OnMapSettingsChanged);
            // 
            // ctrlLightTracesValue
            // 
            this.ctrlLightTracesValue.Location = new System.Drawing.Point(112, 163);
            this.ctrlLightTracesValue.Name = "ctrlLightTracesValue";
            this.ctrlLightTracesValue.Size = new System.Drawing.Size(70, 20);
            this.ctrlLightTracesValue.TabIndex = 12;
            this.ctrlLightTracesValue.TextChanged += new System.EventHandler(this.OnMapSettingsChanged);
            // 
            // ctrlLightJitterValue
            // 
            this.ctrlLightJitterValue.Location = new System.Drawing.Point(112, 189);
            this.ctrlLightJitterValue.Name = "ctrlLightJitterValue";
            this.ctrlLightJitterValue.Size = new System.Drawing.Size(70, 20);
            this.ctrlLightJitterValue.TabIndex = 10;
            this.ctrlLightJitterValue.TextChanged += new System.EventHandler(this.OnMapSettingsChanged);
            // 
            // ctrlLightJitter
            // 
            this.ctrlLightJitter.Location = new System.Drawing.Point(6, 188);
            this.ctrlLightJitter.Name = "ctrlLightJitter";
            this.ctrlLightJitter.Size = new System.Drawing.Size(100, 23);
            this.ctrlLightJitter.TabIndex = 9;
            this.ctrlLightJitter.Text = "jitter";
            this.ctrlLightJitter.UseVisualStyleBackColor = true;
            this.ctrlLightJitter.CheckedChanged += new System.EventHandler(this.OnMapSettingsChanged);
            // 
            // ctrlLightTraces
            // 
            this.ctrlLightTraces.Location = new System.Drawing.Point(6, 162);
            this.ctrlLightTraces.Name = "ctrlLightTraces";
            this.ctrlLightTraces.Size = new System.Drawing.Size(100, 23);
            this.ctrlLightTraces.TabIndex = 7;
            this.ctrlLightTraces.Text = "traces";
            this.ctrlLightTraces.UseVisualStyleBackColor = true;
            this.ctrlLightTraces.CheckedChanged += new System.EventHandler(this.OnMapSettingsChanged);
            // 
            // ctrlLightDump
            // 
            this.ctrlLightDump.Location = new System.Drawing.Point(6, 136);
            this.ctrlLightDump.Name = "ctrlLightDump";
            this.ctrlLightDump.Size = new System.Drawing.Size(268, 23);
            this.ctrlLightDump.TabIndex = 6;
            this.ctrlLightDump.Text = "DumpOptions";
            this.ctrlLightDump.UseVisualStyleBackColor = true;
            this.ctrlLightDump.CheckedChanged += new System.EventHandler(this.OnMapSettingsChanged);
            // 
            // ctrlLightNoShadow
            // 
            this.ctrlLightNoShadow.Location = new System.Drawing.Point(6, 110);
            this.ctrlLightNoShadow.Name = "ctrlLightNoShadow";
            this.ctrlLightNoShadow.Size = new System.Drawing.Size(268, 23);
            this.ctrlLightNoShadow.TabIndex = 5;
            this.ctrlLightNoShadow.Text = "NoModelShadow";
            this.ctrlLightNoShadow.UseVisualStyleBackColor = true;
            this.ctrlLightNoShadow.CheckedChanged += new System.EventHandler(this.OnMapSettingsChanged);
            // 
            // ctrlLightShadow
            // 
            this.ctrlLightShadow.Location = new System.Drawing.Point(6, 84);
            this.ctrlLightShadow.Name = "ctrlLightShadow";
            this.ctrlLightShadow.Size = new System.Drawing.Size(268, 23);
            this.ctrlLightShadow.TabIndex = 4;
            this.ctrlLightShadow.Text = "ModelShadow";
            this.ctrlLightShadow.UseVisualStyleBackColor = true;
            this.ctrlLightShadow.CheckedChanged += new System.EventHandler(this.OnMapSettingsChanged);
            // 
            // ctrlLightVerbose
            // 
            this.ctrlLightVerbose.Location = new System.Drawing.Point(6, 58);
            this.ctrlLightVerbose.Name = "ctrlLightVerbose";
            this.ctrlLightVerbose.Size = new System.Drawing.Size(268, 23);
            this.ctrlLightVerbose.TabIndex = 3;
            this.ctrlLightVerbose.Text = "verbose";
            this.ctrlLightVerbose.UseVisualStyleBackColor = true;
            this.ctrlLightVerbose.CheckedChanged += new System.EventHandler(this.OnMapSettingsChanged);
            // 
            // ctrlLightExtra
            // 
            this.ctrlLightExtra.Location = new System.Drawing.Point(6, 32);
            this.ctrlLightExtra.Name = "ctrlLightExtra";
            this.ctrlLightExtra.Size = new System.Drawing.Size(268, 23);
            this.ctrlLightExtra.TabIndex = 2;
            this.ctrlLightExtra.Text = "extra";
            this.ctrlLightExtra.UseVisualStyleBackColor = true;
            this.ctrlLightExtra.CheckedChanged += new System.EventHandler(this.OnMapSettingsChanged);
            // 
            // ctrlLightFast
            // 
            this.ctrlLightFast.Location = new System.Drawing.Point(6, 6);
            this.ctrlLightFast.Name = "ctrlLightFast";
            this.ctrlLightFast.Size = new System.Drawing.Size(268, 23);
            this.ctrlLightFast.TabIndex = 1;
            this.ctrlLightFast.Text = "fast";
            this.ctrlLightFast.UseVisualStyleBackColor = true;
            this.ctrlLightFast.CheckedChanged += new System.EventHandler(this.OnMapSettingsChanged);
            // 
            // ctrlCompile
            // 
            this.ctrlCompile.BackColor = System.Drawing.SystemColors.Control;
            this.ctrlCompile.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ctrlCompile.CheckOnClick = true;
            this.ctrlCompile.FormattingEnabled = true;
            this.ctrlCompile.Items.AddRange(new object[] {
            "Compile BSP",
            "Compile Lighting",
            "Connect Paths"});
            this.ctrlCompile.Location = new System.Drawing.Point(6, 15);
            this.ctrlCompile.Name = "ctrlCompile";
            this.ctrlCompile.Size = new System.Drawing.Size(288, 45);
            this.ctrlCompile.TabIndex = 7;
            this.ctrlCompile.SelectedIndexChanged += new System.EventHandler(this.OnMapSettingsChanged);
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.ctrlGridStart);
            this.groupBox8.Controls.Add(this.ctrlGridType);
            this.groupBox8.Controls.Add(this.ctrlGridCollectDots);
            this.groupBox8.Location = new System.Drawing.Point(0, 370);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(300, 67);
            this.groupBox8.TabIndex = 2;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Grid File";
            // 
            // ctrlGridStart
            // 
            this.ctrlGridStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlGridStart.Location = new System.Drawing.Point(194, 15);
            this.ctrlGridStart.Name = "ctrlGridStart";
            this.ctrlGridStart.Size = new System.Drawing.Size(100, 23);
            this.ctrlGridStart.TabIndex = 2;
            this.ctrlGridStart.Text = "Start Grid";
            this.ctrlGridStart.UseVisualStyleBackColor = true;
            this.ctrlGridStart.Click += new System.EventHandler(this.PressStartGrid);
            // 
            // ctrlGridType
            // 
            this.ctrlGridType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlGridType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ctrlGridType.FormattingEnabled = true;
            this.ctrlGridType.Items.AddRange(new object[] {
            "Edit Exisiting Grid",
            "Make New Grid"});
            this.ctrlGridType.Location = new System.Drawing.Point(6, 42);
            this.ctrlGridType.Name = "ctrlGridType";
            this.ctrlGridType.Size = new System.Drawing.Size(288, 21);
            this.ctrlGridType.TabIndex = 1;
            this.ctrlGridType.SelectedIndexChanged += new System.EventHandler(this.OnMapSettingsChanged);
            // 
            // ctrlGridCollectDots
            // 
            this.ctrlGridCollectDots.Location = new System.Drawing.Point(6, 15);
            this.ctrlGridCollectDots.Name = "ctrlGridCollectDots";
            this.ctrlGridCollectDots.Size = new System.Drawing.Size(182, 23);
            this.ctrlGridCollectDots.TabIndex = 0;
            this.ctrlGridCollectDots.Text = "Models collect dots";
            this.ctrlGridCollectDots.UseVisualStyleBackColor = true;
            this.ctrlGridCollectDots.CheckedChanged += new System.EventHandler(this.OnMapSettingsChanged);
            // 
            // column0
            // 
            this.column0.BackColor = System.Drawing.SystemColors.Control;
            this.column0.Controls.Add(this.groupLevel);
            this.column0.Controls.Add(this.panel1);
            this.column0.Location = new System.Drawing.Point(6, 6);
            this.column0.Name = "column0";
            this.column0.Size = new System.Drawing.Size(220, 529);
            this.column0.TabIndex = 6;
            // 
            // groupLevel
            // 
            this.groupLevel.Controls.Add(this.ctrlNewMap);
            this.groupLevel.Controls.Add(this.ctrlRefreshMapList);
            this.groupLevel.Controls.Add(this.ctrlMapList);
            this.groupLevel.Location = new System.Drawing.Point(0, 0);
            this.groupLevel.Name = "groupLevel";
            this.groupLevel.Size = new System.Drawing.Size(220, 286);
            this.groupLevel.TabIndex = 0;
            this.groupLevel.TabStop = false;
            this.groupLevel.Text = "Level";
            // 
            // ctrlNewMap
            // 
            this.ctrlNewMap.Location = new System.Drawing.Point(6, 15);
            this.ctrlNewMap.Name = "ctrlNewMap";
            this.ctrlNewMap.Size = new System.Drawing.Size(80, 23);
            this.ctrlNewMap.TabIndex = 2;
            this.ctrlNewMap.Text = "New Map";
            this.ctrlNewMap.UseVisualStyleBackColor = true;
            this.ctrlNewMap.Click += new System.EventHandler(this.CreateNewMap);
            // 
            // ctrlRefreshMapList
            // 
            this.ctrlRefreshMapList.Location = new System.Drawing.Point(134, 15);
            this.ctrlRefreshMapList.Name = "ctrlRefreshMapList";
            this.ctrlRefreshMapList.Size = new System.Drawing.Size(80, 23);
            this.ctrlRefreshMapList.TabIndex = 1;
            this.ctrlRefreshMapList.Text = "Refresh";
            this.ctrlRefreshMapList.UseVisualStyleBackColor = true;
            this.ctrlRefreshMapList.Click += new System.EventHandler(this.RefreshMaps);
            // 
            // ctrlMapList
            // 
            this.ctrlMapList.FormattingEnabled = true;
            this.ctrlMapList.Location = new System.Drawing.Point(6, 42);
            this.ctrlMapList.Name = "ctrlMapList";
            this.ctrlMapList.Size = new System.Drawing.Size(208, 238);
            this.ctrlMapList.Sorted = true;
            this.ctrlMapList.TabIndex = 0;
            this.ctrlMapList.SelectedIndexChanged += new System.EventHandler(this.SelectedMap);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ctrlMapBSP);
            this.panel1.Controls.Add(this.ctrlMapReflections);
            this.panel1.Controls.Add(this.ctrlMapCustom);
            this.panel1.Controls.Add(this.ctrlMapBuild);
            this.panel1.Controls.Add(this.ctrlMapOptions);
            this.panel1.Controls.Add(this.ctrlMapUpdate);
            this.panel1.Controls.Add(this.ctrlMapRun);
            this.panel1.Location = new System.Drawing.Point(0, 289);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(220, 238);
            this.panel1.TabIndex = 3;
            // 
            // ctrlMapBSP
            // 
            this.ctrlMapBSP.Location = new System.Drawing.Point(6, 0);
            this.ctrlMapBSP.Name = "ctrlMapBSP";
            this.ctrlMapBSP.Size = new System.Drawing.Size(120, 23);
            this.ctrlMapBSP.TabIndex = 0;
            this.ctrlMapBSP.Text = "Compile BSP";
            this.ctrlMapBSP.UseVisualStyleBackColor = true;
            this.ctrlMapBSP.Click += new System.EventHandler(this.PressCompileBSP);
            // 
            // ctrlMapReflections
            // 
            this.ctrlMapReflections.Location = new System.Drawing.Point(6, 29);
            this.ctrlMapReflections.Name = "ctrlMapReflections";
            this.ctrlMapReflections.Size = new System.Drawing.Size(120, 23);
            this.ctrlMapReflections.TabIndex = 1;
            this.ctrlMapReflections.Text = "Compile Reflections";
            this.ctrlMapReflections.UseVisualStyleBackColor = true;
            this.ctrlMapReflections.Click += new System.EventHandler(this.PressCompileReflections);
            // 
            // ctrlMapCustom
            // 
            this.ctrlMapCustom.Location = new System.Drawing.Point(6, 212);
            this.ctrlMapCustom.Name = "ctrlMapCustom";
            this.ctrlMapCustom.Size = new System.Drawing.Size(202, 20);
            this.ctrlMapCustom.TabIndex = 6;
            this.ctrlMapCustom.TextChanged += new System.EventHandler(this.OnMapSettingsChanged);
            // 
            // ctrlMapBuild
            // 
            this.ctrlMapBuild.Location = new System.Drawing.Point(6, 58);
            this.ctrlMapBuild.Name = "ctrlMapBuild";
            this.ctrlMapBuild.Size = new System.Drawing.Size(120, 23);
            this.ctrlMapBuild.TabIndex = 2;
            this.ctrlMapBuild.Text = "Build Fast File";
            this.ctrlMapBuild.UseVisualStyleBackColor = true;
            this.ctrlMapBuild.Click += new System.EventHandler(this.PressBuildMapFF);
            // 
            // ctrlMapOptions
            // 
            this.ctrlMapOptions.BackColor = System.Drawing.SystemColors.Control;
            this.ctrlMapOptions.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ctrlMapOptions.CheckOnClick = true;
            this.ctrlMapOptions.FormattingEnabled = true;
            this.ctrlMapOptions.Items.AddRange(new object[] {
            "Enable Developer",
            "Enable Developer Script",
            "Enable Cheats",
            "Use Custom Command Line Options"});
            this.ctrlMapOptions.Location = new System.Drawing.Point(6, 145);
            this.ctrlMapOptions.Name = "ctrlMapOptions";
            this.ctrlMapOptions.Size = new System.Drawing.Size(202, 60);
            this.ctrlMapOptions.TabIndex = 5;
            this.ctrlMapOptions.SelectedIndexChanged += new System.EventHandler(this.OnMapSettingsChanged);
            // 
            // ctrlMapUpdate
            // 
            this.ctrlMapUpdate.Location = new System.Drawing.Point(6, 87);
            this.ctrlMapUpdate.Name = "ctrlMapUpdate";
            this.ctrlMapUpdate.Size = new System.Drawing.Size(120, 23);
            this.ctrlMapUpdate.TabIndex = 3;
            this.ctrlMapUpdate.Text = "Update Zone File";
            this.ctrlMapUpdate.UseVisualStyleBackColor = true;
            this.ctrlMapUpdate.Click += new System.EventHandler(this.PressUpdateMapZone);
            // 
            // ctrlMapRun
            // 
            this.ctrlMapRun.Location = new System.Drawing.Point(6, 116);
            this.ctrlMapRun.Name = "ctrlMapRun";
            this.ctrlMapRun.Size = new System.Drawing.Size(120, 23);
            this.ctrlMapRun.TabIndex = 4;
            this.ctrlMapRun.Text = "Run Selected Map";
            this.ctrlMapRun.UseVisualStyleBackColor = true;
            this.ctrlMapRun.Click += new System.EventHandler(this.PressRunMap);
            // 
            // tabBrowsing
            // 
            this.tabBrowsing.BackColor = System.Drawing.SystemColors.Control;
            this.tabBrowsing.Controls.Add(this.groupBox3);
            this.tabBrowsing.Controls.Add(this.groupBox2);
            this.tabBrowsing.Controls.Add(this.groupBox1);
            this.tabBrowsing.Location = new System.Drawing.Point(4, 22);
            this.tabBrowsing.Name = "tabBrowsing";
            this.tabBrowsing.Size = new System.Drawing.Size(882, 541);
            this.tabBrowsing.TabIndex = 2;
            this.tabBrowsing.Text = "Browsing";
            // 
            // groupBox3
            // 
            this.groupBox3.AutoSize = true;
            this.groupBox3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox3.Controls.Add(this.button2);
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Controls.Add(this.ctrlBrowseXparts);
            this.groupBox3.Controls.Add(this.ctrlBrowseSun);
            this.groupBox3.Controls.Add(this.ctrlBrowseXmodels);
            this.groupBox3.Controls.Add(this.ctrlBrowseVision);
            this.groupBox3.Controls.Add(this.ctrlBrowseMaterials);
            this.groupBox3.Controls.Add(this.ctrlBrowseXsurfs);
            this.groupBox3.Controls.Add(this.ctrlBrowseXanims);
            this.groupBox3.Controls.Add(this.ctrlBrowseMaterialProperties);
            this.groupBox3.Controls.Add(this.ctrlBrowseImages);
            this.groupBox3.Controls.Add(this.ctrlBrowseWeapons);
            this.groupBox3.Controls.Add(this.ctrlBrowseUI);
            this.groupBox3.Controls.Add(this.ctrlBrowseImagesMain);
            this.groupBox3.Location = new System.Drawing.Point(292, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(258, 235);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Advanced";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(132, 193);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(120, 23);
            this.button2.TabIndex = 17;
            this.button2.Text = "xmodelsurfs";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.BrowseXsurfs);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 193);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 23);
            this.button1.TabIndex = 16;
            this.button1.Text = "ui";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.BrowseUI);
            // 
            // ctrlBrowseXparts
            // 
            this.ctrlBrowseXparts.Location = new System.Drawing.Point(132, 135);
            this.ctrlBrowseXparts.Name = "ctrlBrowseXparts";
            this.ctrlBrowseXparts.Size = new System.Drawing.Size(120, 23);
            this.ctrlBrowseXparts.TabIndex = 15;
            this.ctrlBrowseXparts.Text = "xmodels";
            this.ctrlBrowseXparts.UseVisualStyleBackColor = true;
            this.ctrlBrowseXparts.Click += new System.EventHandler(this.BrowseXmodels);
            // 
            // ctrlBrowseSun
            // 
            this.ctrlBrowseSun.Location = new System.Drawing.Point(6, 135);
            this.ctrlBrowseSun.Name = "ctrlBrowseSun";
            this.ctrlBrowseSun.Size = new System.Drawing.Size(120, 23);
            this.ctrlBrowseSun.TabIndex = 14;
            this.ctrlBrowseSun.Text = "materials";
            this.ctrlBrowseSun.UseVisualStyleBackColor = true;
            this.ctrlBrowseSun.Click += new System.EventHandler(this.BrowseMaterials);
            // 
            // ctrlBrowseXmodels
            // 
            this.ctrlBrowseXmodels.Location = new System.Drawing.Point(132, 106);
            this.ctrlBrowseXmodels.Name = "ctrlBrowseXmodels";
            this.ctrlBrowseXmodels.Size = new System.Drawing.Size(120, 23);
            this.ctrlBrowseXmodels.TabIndex = 13;
            this.ctrlBrowseXmodels.Text = "xanim";
            this.ctrlBrowseXmodels.UseVisualStyleBackColor = true;
            this.ctrlBrowseXmodels.Click += new System.EventHandler(this.BrowseXanims);
            // 
            // ctrlBrowseVision
            // 
            this.ctrlBrowseVision.Location = new System.Drawing.Point(6, 164);
            this.ctrlBrowseVision.Name = "ctrlBrowseVision";
            this.ctrlBrowseVision.Size = new System.Drawing.Size(120, 23);
            this.ctrlBrowseVision.TabIndex = 8;
            this.ctrlBrowseVision.Text = "material_properties";
            this.ctrlBrowseVision.UseVisualStyleBackColor = true;
            this.ctrlBrowseVision.Click += new System.EventHandler(this.BrowseMaterialProperties);
            // 
            // ctrlBrowseMaterials
            // 
            this.ctrlBrowseMaterials.Location = new System.Drawing.Point(6, 77);
            this.ctrlBrowseMaterials.Name = "ctrlBrowseMaterials";
            this.ctrlBrowseMaterials.Size = new System.Drawing.Size(120, 23);
            this.ctrlBrowseMaterials.TabIndex = 6;
            this.ctrlBrowseMaterials.Text = "main/images";
            this.ctrlBrowseMaterials.UseVisualStyleBackColor = true;
            this.ctrlBrowseMaterials.Click += new System.EventHandler(this.BrowseImageMain);
            // 
            // ctrlBrowseXsurfs
            // 
            this.ctrlBrowseXsurfs.Location = new System.Drawing.Point(132, 164);
            this.ctrlBrowseXsurfs.Name = "ctrlBrowseXsurfs";
            this.ctrlBrowseXsurfs.Size = new System.Drawing.Size(120, 23);
            this.ctrlBrowseXsurfs.TabIndex = 12;
            this.ctrlBrowseXsurfs.Text = "xmodelparts";
            this.ctrlBrowseXsurfs.UseVisualStyleBackColor = true;
            this.ctrlBrowseXsurfs.Click += new System.EventHandler(this.BrowseXparts);
            // 
            // ctrlBrowseXanims
            // 
            this.ctrlBrowseXanims.Location = new System.Drawing.Point(132, 77);
            this.ctrlBrowseXanims.Name = "ctrlBrowseXanims";
            this.ctrlBrowseXanims.Size = new System.Drawing.Size(120, 23);
            this.ctrlBrowseXanims.TabIndex = 9;
            this.ctrlBrowseXanims.Text = "weapons/sp";
            this.ctrlBrowseXanims.UseVisualStyleBackColor = true;
            this.ctrlBrowseXanims.Click += new System.EventHandler(this.BrowseWeapons);
            // 
            // ctrlBrowseMaterialProperties
            // 
            this.ctrlBrowseMaterialProperties.Location = new System.Drawing.Point(6, 106);
            this.ctrlBrowseMaterialProperties.Name = "ctrlBrowseMaterialProperties";
            this.ctrlBrowseMaterialProperties.Size = new System.Drawing.Size(120, 23);
            this.ctrlBrowseMaterialProperties.TabIndex = 8;
            this.ctrlBrowseMaterialProperties.Text = "images";
            this.ctrlBrowseMaterialProperties.UseVisualStyleBackColor = true;
            this.ctrlBrowseMaterialProperties.Click += new System.EventHandler(this.BrowseImages);
            // 
            // ctrlBrowseImages
            // 
            this.ctrlBrowseImages.Location = new System.Drawing.Point(6, 48);
            this.ctrlBrowseImages.Name = "ctrlBrowseImages";
            this.ctrlBrowseImages.Size = new System.Drawing.Size(120, 23);
            this.ctrlBrowseImages.TabIndex = 5;
            this.ctrlBrowseImages.Text = "main/video";
            this.ctrlBrowseImages.UseVisualStyleBackColor = true;
            this.ctrlBrowseImages.Click += new System.EventHandler(this.BrowseVideo);
            // 
            // ctrlBrowseWeapons
            // 
            this.ctrlBrowseWeapons.Location = new System.Drawing.Point(132, 48);
            this.ctrlBrowseWeapons.Name = "ctrlBrowseWeapons";
            this.ctrlBrowseWeapons.Size = new System.Drawing.Size(120, 23);
            this.ctrlBrowseWeapons.TabIndex = 10;
            this.ctrlBrowseWeapons.Text = "vision";
            this.ctrlBrowseWeapons.UseVisualStyleBackColor = true;
            this.ctrlBrowseWeapons.Click += new System.EventHandler(this.BrowseVision);
            // 
            // ctrlBrowseUI
            // 
            this.ctrlBrowseUI.Location = new System.Drawing.Point(132, 19);
            this.ctrlBrowseUI.Name = "ctrlBrowseUI";
            this.ctrlBrowseUI.Size = new System.Drawing.Size(120, 23);
            this.ctrlBrowseUI.TabIndex = 11;
            this.ctrlBrowseUI.Text = "sun";
            this.ctrlBrowseUI.UseVisualStyleBackColor = true;
            this.ctrlBrowseUI.Click += new System.EventHandler(this.BrowseSun);
            // 
            // ctrlBrowseImagesMain
            // 
            this.ctrlBrowseImagesMain.Location = new System.Drawing.Point(6, 19);
            this.ctrlBrowseImagesMain.Name = "ctrlBrowseImagesMain";
            this.ctrlBrowseImagesMain.Size = new System.Drawing.Size(120, 23);
            this.ctrlBrowseImagesMain.TabIndex = 7;
            this.ctrlBrowseImagesMain.Text = "bin";
            this.ctrlBrowseImagesMain.UseVisualStyleBackColor = true;
            this.ctrlBrowseImagesMain.Click += new System.EventHandler(this.BrowseBin);
            // 
            // groupBox2
            // 
            this.groupBox2.AutoSize = true;
            this.groupBox2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox2.Controls.Add(this.ctrlBrowseLocalizedstrings);
            this.groupBox2.Controls.Add(this.ctrlBrowseMaps);
            this.groupBox2.Controls.Add(this.ctrlBrowseSoundaliases);
            this.groupBox2.Controls.Add(this.ctrlBrowseSound);
            this.groupBox2.Location = new System.Drawing.Point(148, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(132, 148);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Raw Directory";
            // 
            // ctrlBrowseLocalizedstrings
            // 
            this.ctrlBrowseLocalizedstrings.Location = new System.Drawing.Point(6, 19);
            this.ctrlBrowseLocalizedstrings.Name = "ctrlBrowseLocalizedstrings";
            this.ctrlBrowseLocalizedstrings.Size = new System.Drawing.Size(120, 23);
            this.ctrlBrowseLocalizedstrings.TabIndex = 5;
            this.ctrlBrowseLocalizedstrings.Text = "localizedstrings";
            this.ctrlBrowseLocalizedstrings.UseVisualStyleBackColor = true;
            this.ctrlBrowseLocalizedstrings.Click += new System.EventHandler(this.BrowseLocalizedstrings);
            // 
            // ctrlBrowseMaps
            // 
            this.ctrlBrowseMaps.Location = new System.Drawing.Point(6, 48);
            this.ctrlBrowseMaps.Name = "ctrlBrowseMaps";
            this.ctrlBrowseMaps.Size = new System.Drawing.Size(120, 23);
            this.ctrlBrowseMaps.TabIndex = 6;
            this.ctrlBrowseMaps.Text = "maps";
            this.ctrlBrowseMaps.UseVisualStyleBackColor = true;
            this.ctrlBrowseMaps.Click += new System.EventHandler(this.BrowseMaps);
            // 
            // ctrlBrowseSoundaliases
            // 
            this.ctrlBrowseSoundaliases.Location = new System.Drawing.Point(6, 106);
            this.ctrlBrowseSoundaliases.Name = "ctrlBrowseSoundaliases";
            this.ctrlBrowseSoundaliases.Size = new System.Drawing.Size(120, 23);
            this.ctrlBrowseSoundaliases.TabIndex = 8;
            this.ctrlBrowseSoundaliases.Text = "soundaliases";
            this.ctrlBrowseSoundaliases.UseVisualStyleBackColor = true;
            this.ctrlBrowseSoundaliases.Click += new System.EventHandler(this.BrowseSoundaliases);
            // 
            // ctrlBrowseSound
            // 
            this.ctrlBrowseSound.Location = new System.Drawing.Point(6, 77);
            this.ctrlBrowseSound.Name = "ctrlBrowseSound";
            this.ctrlBrowseSound.Size = new System.Drawing.Size(120, 23);
            this.ctrlBrowseSound.TabIndex = 7;
            this.ctrlBrowseSound.Text = "sound";
            this.ctrlBrowseSound.UseVisualStyleBackColor = true;
            this.ctrlBrowseSound.Click += new System.EventHandler(this.BrowseSound);
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox1.Controls.Add(this.ctrlBrowseMapSource);
            this.groupBox1.Controls.Add(this.ctrlBrowseMain);
            this.groupBox1.Controls.Add(this.ctrlBrowseMods);
            this.groupBox1.Controls.Add(this.ctrlBrowseSourceData);
            this.groupBox1.Controls.Add(this.ctrlBrowseZoneSource);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(132, 177);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Game Directory";
            // 
            // ctrlBrowseMapSource
            // 
            this.ctrlBrowseMapSource.Location = new System.Drawing.Point(6, 19);
            this.ctrlBrowseMapSource.Name = "ctrlBrowseMapSource";
            this.ctrlBrowseMapSource.Size = new System.Drawing.Size(120, 23);
            this.ctrlBrowseMapSource.TabIndex = 5;
            this.ctrlBrowseMapSource.Text = "map_source";
            this.ctrlBrowseMapSource.UseVisualStyleBackColor = true;
            this.ctrlBrowseMapSource.Click += new System.EventHandler(this.BrowseMapSource);
            // 
            // ctrlBrowseMain
            // 
            this.ctrlBrowseMain.Location = new System.Drawing.Point(6, 135);
            this.ctrlBrowseMain.Name = "ctrlBrowseMain";
            this.ctrlBrowseMain.Size = new System.Drawing.Size(120, 23);
            this.ctrlBrowseMain.TabIndex = 9;
            this.ctrlBrowseMain.Text = "main";
            this.ctrlBrowseMain.UseVisualStyleBackColor = true;
            this.ctrlBrowseMain.Click += new System.EventHandler(this.BrowseMain);
            // 
            // ctrlBrowseMods
            // 
            this.ctrlBrowseMods.Location = new System.Drawing.Point(6, 48);
            this.ctrlBrowseMods.Name = "ctrlBrowseMods";
            this.ctrlBrowseMods.Size = new System.Drawing.Size(120, 23);
            this.ctrlBrowseMods.TabIndex = 6;
            this.ctrlBrowseMods.Text = "mods";
            this.ctrlBrowseMods.UseVisualStyleBackColor = true;
            this.ctrlBrowseMods.Click += new System.EventHandler(this.BrowseMods);
            // 
            // ctrlBrowseSourceData
            // 
            this.ctrlBrowseSourceData.Location = new System.Drawing.Point(6, 106);
            this.ctrlBrowseSourceData.Name = "ctrlBrowseSourceData";
            this.ctrlBrowseSourceData.Size = new System.Drawing.Size(120, 23);
            this.ctrlBrowseSourceData.TabIndex = 8;
            this.ctrlBrowseSourceData.Text = "source_data";
            this.ctrlBrowseSourceData.UseVisualStyleBackColor = true;
            this.ctrlBrowseSourceData.Click += new System.EventHandler(this.BrowseSourceData);
            // 
            // ctrlBrowseZoneSource
            // 
            this.ctrlBrowseZoneSource.Location = new System.Drawing.Point(6, 77);
            this.ctrlBrowseZoneSource.Name = "ctrlBrowseZoneSource";
            this.ctrlBrowseZoneSource.Size = new System.Drawing.Size(120, 23);
            this.ctrlBrowseZoneSource.TabIndex = 7;
            this.ctrlBrowseZoneSource.Text = "zone_source";
            this.ctrlBrowseZoneSource.UseVisualStyleBackColor = true;
            this.ctrlBrowseZoneSource.Click += new System.EventHandler(this.BrowseZoneSource);
            // 
            // tabApplications
            // 
            this.tabApplications.BackColor = System.Drawing.SystemColors.Control;
            this.tabApplications.Controls.Add(this.ctrlAppConverter);
            this.tabApplications.Controls.Add(this.ctrlAppEffectsEd);
            this.tabApplications.Controls.Add(this.ctrlAppAssetManager);
            this.tabApplications.Controls.Add(this.ctrlAppRadiant);
            this.tabApplications.Location = new System.Drawing.Point(4, 22);
            this.tabApplications.Name = "tabApplications";
            this.tabApplications.Padding = new System.Windows.Forms.Padding(3);
            this.tabApplications.Size = new System.Drawing.Size(882, 541);
            this.tabApplications.TabIndex = 3;
            this.tabApplications.Text = "Applications";
            // 
            // ctrlAppConverter
            // 
            this.ctrlAppConverter.Location = new System.Drawing.Point(6, 93);
            this.ctrlAppConverter.Name = "ctrlAppConverter";
            this.ctrlAppConverter.Size = new System.Drawing.Size(120, 23);
            this.ctrlAppConverter.TabIndex = 7;
            this.ctrlAppConverter.Text = "Run Converter";
            this.ctrlAppConverter.UseVisualStyleBackColor = true;
            this.ctrlAppConverter.Click += new System.EventHandler(this.AppStartConverter);
            // 
            // ctrlAppEffectsEd
            // 
            this.ctrlAppEffectsEd.Location = new System.Drawing.Point(6, 64);
            this.ctrlAppEffectsEd.Name = "ctrlAppEffectsEd";
            this.ctrlAppEffectsEd.Size = new System.Drawing.Size(120, 23);
            this.ctrlAppEffectsEd.TabIndex = 6;
            this.ctrlAppEffectsEd.Text = "Effects Editor";
            this.ctrlAppEffectsEd.UseVisualStyleBackColor = true;
            this.ctrlAppEffectsEd.Click += new System.EventHandler(this.AppStartEffectsEd);
            // 
            // ctrlAppAssetManager
            // 
            this.ctrlAppAssetManager.Location = new System.Drawing.Point(6, 35);
            this.ctrlAppAssetManager.Name = "ctrlAppAssetManager";
            this.ctrlAppAssetManager.Size = new System.Drawing.Size(120, 23);
            this.ctrlAppAssetManager.TabIndex = 5;
            this.ctrlAppAssetManager.Text = "Asset Manager";
            this.ctrlAppAssetManager.UseVisualStyleBackColor = true;
            this.ctrlAppAssetManager.Click += new System.EventHandler(this.AppStartAssetManager);
            // 
            // ctrlAppRadiant
            // 
            this.ctrlAppRadiant.Location = new System.Drawing.Point(6, 6);
            this.ctrlAppRadiant.Name = "ctrlAppRadiant";
            this.ctrlAppRadiant.Size = new System.Drawing.Size(120, 23);
            this.ctrlAppRadiant.TabIndex = 4;
            this.ctrlAppRadiant.Text = "Radiant";
            this.ctrlAppRadiant.UseVisualStyleBackColor = true;
            this.ctrlAppRadiant.Click += new System.EventHandler(this.AppStartRadiant);
            // 
            // dialogZipper
            // 
            this.dialogZipper.DefaultExt = "*.exe";
            this.dialogZipper.FileName = "7za.exe";
            this.dialogZipper.Filter = "Executables|*.exe";
            this.dialogZipper.Title = "Select the 7za.exe binary...";
            // 
            // dialogTextEditor
            // 
            this.dialogTextEditor.DefaultExt = "*.exe";
            this.dialogTextEditor.Filter = "Executable|*.exe";
            this.dialogTextEditor.Title = "Select the prefered text editor...";
            // 
            // dialogExeName
            // 
            this.dialogExeName.DefaultExt = "*.exe";
            this.dialogExeName.FileName = "iw3sp.exe";
            this.dialogExeName.Filter = "Executable|*.exe";
            this.dialogExeName.Title = "Select prefered iw3sp.exe executable...";
            // 
            // dialogCustom
            // 
            this.dialogCustom.DefaultExt = "*.*";
            this.dialogCustom.Filter = "All Files|*.*";
            this.dialogCustom.Title = "Select...";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(890, 567);
            this.Controls.Add(this.ctrlMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "SPi - SP Compile Tools";
            this.Load += new System.EventHandler(this.OnInitialized);
            this.ctrlMain.ResumeLayout(false);
            this.tabPreferences.ResumeLayout(false);
            this.ctrlPreferences.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabDevelopment.ResumeLayout(false);
            this.column5.ResumeLayout(false);
            this.column4.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.column3.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.column2.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox9.ResumeLayout(false);
            this.column1.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.ctrlOptionsTab.ResumeLayout(false);
            this.tabOptionsBSP.ResumeLayout(false);
            this.tabOptionsBSP.PerformLayout();
            this.tabOptionsLight.ResumeLayout(false);
            this.tabOptionsLight.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.column0.ResumeLayout(false);
            this.groupLevel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabBrowsing.ResumeLayout(false);
            this.tabBrowsing.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.tabApplications.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl ctrlMain;
        private System.Windows.Forms.TabPage tabPreferences;
        private System.Windows.Forms.TabPage tabDevelopment;
        private System.Windows.Forms.TabPage tabBrowsing;
        private System.Windows.Forms.TabPage tabApplications;
        private System.Windows.Forms.TextBox ctrlInstallPath;
        private System.Windows.Forms.Button ctrlInstallPathBrowse;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button ctrlBrowseMapSource;
        private System.Windows.Forms.Button ctrlBrowseMain;
        private System.Windows.Forms.Button ctrlBrowseMods;
        private System.Windows.Forms.Button ctrlBrowseSourceData;
        private System.Windows.Forms.Button ctrlBrowseZoneSource;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button ctrlBrowseImages;
        private System.Windows.Forms.Button ctrlBrowseXanims;
        private System.Windows.Forms.Button ctrlBrowseMaterials;
        private System.Windows.Forms.Button ctrlBrowseVision;
        private System.Windows.Forms.Button ctrlBrowseImagesMain;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button ctrlBrowseLocalizedstrings;
        private System.Windows.Forms.Button ctrlBrowseMaps;
        private System.Windows.Forms.Button ctrlBrowseSoundaliases;
        private System.Windows.Forms.Button ctrlBrowseSound;
        private System.Windows.Forms.Button ctrlBrowseXparts;
        private System.Windows.Forms.Button ctrlBrowseSun;
        private System.Windows.Forms.Button ctrlBrowseXmodels;
        private System.Windows.Forms.Button ctrlBrowseMaterialProperties;
        private System.Windows.Forms.Button ctrlBrowseXsurfs;
        private System.Windows.Forms.Button ctrlBrowseUI;
        private System.Windows.Forms.Button ctrlBrowseWeapons;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupLevel;
        private System.Windows.Forms.Button ctrlAppConverter;
        private System.Windows.Forms.Button ctrlAppEffectsEd;
        private System.Windows.Forms.Button ctrlAppAssetManager;
        private System.Windows.Forms.Button ctrlAppRadiant;
        private System.Windows.Forms.Button ctrlMapRun;
        private System.Windows.Forms.Button ctrlMapUpdate;
        private System.Windows.Forms.Button ctrlMapBuild;
        private System.Windows.Forms.Button ctrlMapReflections;
        private System.Windows.Forms.Button ctrlMapBSP;
        private System.Windows.Forms.CheckedListBox ctrlMapOptions;
        private System.Windows.Forms.TextBox ctrlMapCustom;
        private System.Windows.Forms.CheckedListBox ctrlCompile;
        private System.Windows.Forms.Button ctrlNewMap;
        private System.Windows.Forms.Button ctrlRefreshMapList;
        private System.Windows.Forms.ListBox ctrlMapList;
        private System.Windows.Forms.TabControl ctrlOptionsTab;
        private System.Windows.Forms.TabPage tabOptionsBSP;
        private System.Windows.Forms.TabPage tabOptionsLight;
        private System.Windows.Forms.TextBox ctrlBspCustomValue;
        private System.Windows.Forms.CheckBox ctrlBspCustom;
        private System.Windows.Forms.CheckBox ctrlBspDebug;
        private System.Windows.Forms.CheckBox ctrlBspSample;
        private System.Windows.Forms.CheckBox ctrlBspBlock;
        private System.Windows.Forms.CheckBox ctrlBspEnts;
        private System.Windows.Forms.TextBox ctrlBspBlockValue;
        private System.Windows.Forms.TextBox ctrlBspSampleValue;
        private System.Windows.Forms.CheckBox ctrlLightCustom;
        private System.Windows.Forms.TextBox ctrlLightCustomValue;
        private System.Windows.Forms.TextBox ctrlLightTracesValue;
        private System.Windows.Forms.TextBox ctrlLightJitterValue;
        private System.Windows.Forms.CheckBox ctrlLightJitter;
        private System.Windows.Forms.CheckBox ctrlLightTraces;
        private System.Windows.Forms.CheckBox ctrlLightDump;
        private System.Windows.Forms.CheckBox ctrlLightNoShadow;
        private System.Windows.Forms.CheckBox ctrlLightShadow;
        private System.Windows.Forms.CheckBox ctrlLightVerbose;
        private System.Windows.Forms.CheckBox ctrlLightExtra;
        private System.Windows.Forms.CheckBox ctrlLightFast;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.Button ctrlGridStart;
        private System.Windows.Forms.ComboBox ctrlGridType;
        private System.Windows.Forms.CheckBox ctrlGridCollectDots;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button ctrlShowSoundaliases;
        private System.Windows.Forms.Button ctrlShowLocalizedstrings;
        private System.Windows.Forms.Button ctrlShowFx;
        private System.Windows.Forms.Button ctrlShowAnim;
        private System.Windows.Forms.Button ctrlShowMap;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FolderBrowserDialog dialogInstallPath;
        private System.Windows.Forms.Button ctrlNewMod;
        private System.Windows.Forms.Button ctrlRefreshModList;
        private System.Windows.Forms.ListBox ctrlModList;
        private System.Windows.Forms.TextBox ctrlModCustom;
        private System.Windows.Forms.Button ctrlModBuild;
        private System.Windows.Forms.CheckedListBox ctrlModOptions;
        private System.Windows.Forms.Button ctrlModUpdate;
        private System.Windows.Forms.Button ctrlModRun;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox ctrlLanguageSelect;
        private System.Windows.Forms.Button ctrlModBrowse;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.Button ctrlFolderSoundaliases;
        private System.Windows.Forms.Button ctrlFolderSound;
        private System.Windows.Forms.Button ctrlFolderMaps;
        private System.Windows.Forms.Button ctrlFolderLocalizedstrings;
        private System.Windows.Forms.Button ctrlFolderMapSource;
        private System.Windows.Forms.Button ctrlFolderMods;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.CheckBox ctrlSyncTools;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button ctrlShowCode;
        private System.Windows.Forms.Button ctrlModIWD;
        private System.Windows.Forms.OpenFileDialog dialogZipper;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox ctrlExeName;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel column0;
        private System.Windows.Forms.Panel column1;
        private System.Windows.Forms.Panel column2;
        private System.Windows.Forms.Panel column3;
        private System.Windows.Forms.TextBox ctrlTextEditor;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button ctrlTextEditorBrowse;
        private System.Windows.Forms.Button ctrlExeNameBrowse;
        private System.Windows.Forms.OpenFileDialog dialogTextEditor;
        private System.Windows.Forms.OpenFileDialog dialogExeName;
        private System.Windows.Forms.Panel column4;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button ctrlFileEffectsEditor;
        private System.Windows.Forms.Button ctrlFileAssetManager;
        private System.Windows.Forms.Button ctrlFileRadiant;
        private System.Windows.Forms.Panel column5;
        private System.Windows.Forms.Button ctrlCustom3;
        private System.Windows.Forms.Button ctrlCustom2;
        private System.Windows.Forms.Button ctrlCustom1;
        private System.Windows.Forms.Button ctrlCustom0;
        private System.Windows.Forms.Button ctrlC0Browse;
        private System.Windows.Forms.TextBox ctrlC0Value;
        private System.Windows.Forms.TextBox ctrlC0Text;
        private System.Windows.Forms.Button ctrlC3Browse;
        private System.Windows.Forms.TextBox ctrlC3Value;
        private System.Windows.Forms.TextBox ctrlC3Text;
        private System.Windows.Forms.Button ctrlC2Browse;
        private System.Windows.Forms.TextBox ctrlC2Value;
        private System.Windows.Forms.TextBox ctrlC2Text;
        private System.Windows.Forms.Button ctrlC1Browse;
        private System.Windows.Forms.TextBox ctrlC1Value;
        private System.Windows.Forms.TextBox ctrlC1Text;
        private System.Windows.Forms.OpenFileDialog dialogCustom;
        private System.Windows.Forms.TabControl ctrlPreferences;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button ctrlZipperBrowse;
        private System.Windows.Forms.TextBox ctrlZipper;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Button ctrlCustomSave;
        private System.Windows.Forms.Button ctrlCustomClear;
        private System.Windows.Forms.Button ctrlAdvancedSave;
        private System.Windows.Forms.Button ctrlRequiredSave;
        private System.Windows.Forms.Button ctrlAdvancedReset;
    }
}