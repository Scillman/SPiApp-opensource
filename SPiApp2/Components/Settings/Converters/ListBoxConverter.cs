using System;
using System.Diagnostics;
using System.Windows.Controls;

namespace SPiApp2.Components.Settings.Converters
{
    public class ListBoxConverter : Converter<ListBox, string>
    {
        public ListBoxConverter(ref ListBox obj) :
            base(ref obj)
        {
            ; // Do nothing...
        }

        public override string Value
        {
            get
            {
                return Ambiguous;
            }
            set
            {
                Ambiguous = value;
            }
        }

        public override string Ambiguous
        {
            get
            {
                Debug.Assert(obj.Items.Count > 0, "Can't get item from an empty ListBox object.");

                object item = obj.SelectedItem;
                if (item == null)
                {
                    item = obj.Items[0];
                }

                Type type = item.GetType();
                string content = null;

                if (type == typeof(ListBoxItem))
                {
                    ListBoxItem control = item as ListBoxItem;
                    content = control.Content as string;
                }
                else
                {
                    Debug.Assert(type == typeof(string), "Encountered unsupported object type.");
                    content = item as string;
                }

                Debug.Assert(content != null, "Selected ListBoxItem content is NULL.");
                return content;
            }
            set
            {
                Debug.Assert(obj.Items.Count > 0);

                if (obj.Items.Count > 0)
                {
                    Type type = obj.Items[0].GetType();

                    if (type == typeof(ListBoxItem))
                    {
                        int i;

                        for (i = 0; i < obj.Items.Count; i++)
                        {
                            ListBoxItem item = obj.Items[i] as ListBoxItem;
                            Debug.Assert(item != null, "ListBox contains mixed object types.");

                            string content = item.Content as string;
                            Debug.Assert(content != null, "ListBoxItem content is NULL.");

                            if (content == value)
                            {
                                break;
                            }
                        }

                        if (i < obj.Items.Count)
                        {
                            obj.SelectedIndex = i;
                        }
                        else
                        {
                            obj.SelectedIndex = 0;
                        }
                    }
                    else
                    {
                        Debug.Assert(type == typeof(string), "Encountered unsupported object type.");
                        Debug.Assert(obj.Items.Contains(value));
                        Debug.WriteLine(string.Format("SelectedMap = '{0}'", value));

                        if (obj.Items.Contains(value))
                        {
                            obj.SelectedItem = value;
                        }
                        else
                        {
                            obj.SelectedIndex = 0;
                        }
                    }
                }
            }
        }

        public override void Default()
        {
            Debug.Assert(obj.Items.Count > 0);

            int index = 0;

            if (obj.Tag is string value)
            {
                if (!int.TryParse(value, out index) || index < 0 || index >= obj.Items.Count)
                {
                    index = 0;
                }
            }

            obj.SelectedIndex = index;
        }

        public override void SetDefault(string value)
        {
            obj.Tag = value;
        }
    }
}
