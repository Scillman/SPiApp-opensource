using System.Diagnostics;
using System.Collections.Generic;
using System.Windows.Controls;

namespace SPiApp2.Components.Settings.Converters
{
    public class RadioGroupConverter : Converter<string, string>
    {
        private string def;
        private readonly RadioButton[] controls;

        public RadioGroupConverter(string obj) :
            base(obj)
        {
            def = string.Copy(obj);
        }

        public RadioGroupConverter(params RadioButton[] controls) :
            base(controls[0].Name)
        {
            this.controls = controls;
            def = GetDefaultSelected();
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
                foreach (RadioButton control in controls)
                {
                    bool? state = control.IsChecked;

                    if (state.HasValue && state.Value)
                    {
                        List<string> tags = GetTags(control);

                        int count = tags.Count;
                        if (count > 0)
                        {
                            return tags[0];
                        }
                        else
                        {
                            return control.Name;
                        }
                    }
                }

                return string.Empty;
            }
            set
            {
                foreach (RadioButton control in controls)
                {
                    List<string> tags = GetTags(control);
                    
                    if (tags.Contains(value))
                    {
                        control.IsChecked = true;
                        return;
                    }
                }

                foreach (RadioButton control in controls)
                {
                    if (control.Name == value)
                    {
                        control.IsChecked = true;
                        return;
                    }
                }
            }
        }

        public override void Default()
        {
            if (string.IsNullOrWhiteSpace(def))
            {
                obj = string.Empty;
            }
            else
            {
                obj = def;
            }
        }

        public override void SetDefault(string value)
        {
            if (def != value)
            {
                foreach (RadioButton control in controls)
                {
                    List<string> tags = GetTags(control);

                    if (tags.Contains(value))
                    {
                        def = value;
                        break;
                    }
                }

                if (def != value)
                {
                    def = string.Empty;
                }
            }
        }

        private string GetDefaultSelected()
        {
            Debug.Assert(controls.Length > 0);

            foreach (RadioButton control in controls)
            {
                List<string> tags = GetTags(control);

                if (tags.Contains("default"))
                {
                    return control.Name;
                }
            }

            if (controls.Length > 0 )
            {
                return controls[0].Name;
            }

            return string.Empty;
        }

        private List<string> GetTags(RadioButton control)
        {
            List<string> result = new List<string>();

            if (control.Tag is string tag)
            {
                result.AddRange(tag.Split(' '));
            }

            return result;
        }
    }
}
