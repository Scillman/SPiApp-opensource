using System;
using System.Diagnostics;
using System.Windows.Controls;

namespace SPiApp2.Components.Settings.Converters
{
    public class ComboBoxConverter : Converter<ComboBox, string>
    {
        public ComboBoxConverter(ref ComboBox obj) :
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
                Debug.Assert(obj.Items.Count > 0, "Can't get item from an empty ComboBox object.");

                object item = obj.SelectedItem;
                Type type = item.GetType();
                string content = null;

                if (type == typeof(ComboBoxItem))
                {
                    ComboBoxItem control = item as ComboBoxItem;
                    content = control.Content as string;
                }
                else
                {
                    Debug.Assert(type == typeof(string), "Encountered unsupported object type.");
                    content = item as string;
                }

                Debug.Assert(content != null, "Selected ComboBoxItem content is NULL.");
                return content;
            }
            set
            {
                if (obj.Items.Count > 0)
                {
                    Type type = obj.Items[0].GetType();

                    if (type == typeof(ComboBoxItem))
                    {
                        int i;

                        for (i = 0; i < obj.Items.Count; i++)
                        {
                            ComboBoxItem item = obj.Items[i] as ComboBoxItem;
                            Debug.Assert(item != null, "ComboBox contains mixed object types.");

                            string content = item.Content as string;
                            Debug.Assert(content != null, "ComboBoxItem content is NULL.");

                            if (content == value)
                            {
                                break;
                            }
                        }

                        if (i < obj.Items.Count)
                        {
                            obj.SelectedIndex = i;
                        }
                    }
                    else
                    {
                        Debug.Assert(type == typeof(string), "Encountered unsupported object type.");

                        if (obj.Items.Contains(value))
                        {
                            obj.SelectedItem = value;
                        }
                    }
                }
            }
        }

        public override void Default()
        {
            if (obj.Tag is string value)
            {
                Debug.Assert(obj.Items.Count > 0);

                if (!int.TryParse(value, out int index) || index >= obj.Items.Count)
                {
                    index = 0;
                }

                obj.SelectedIndex = index;
            }
            else
            {
                obj.SelectedIndex = 0;
            }
        }

        public override void SetDefault(string value)
        {
            obj.Tag = value;
        }
    }
}
