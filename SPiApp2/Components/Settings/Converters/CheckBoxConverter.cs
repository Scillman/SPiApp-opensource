using System.Windows.Controls;

namespace SPiApp2.Components.Settings.Converters
{
    public class CheckBoxConverter : Converter<CheckBox, bool>
    {
        public CheckBoxConverter(ref CheckBox obj) :
            base(ref obj)
        {
            ; // Do nothing...
        }

        public override bool Value
        {
            get
            {
                return bool.Parse(Ambiguous);
            }
            set
            {
                Ambiguous = value.ToString();
            }
        }

        public override string Ambiguous
        {
            get
            {
                bool? value = obj.IsChecked;
                if (value != null && value.HasValue == true && value.Value == true)
                {
                    return "True";
                }
                else
                {
                    return "False";
                }
            }
            set
            {
                if (!bool.TryParse(value, out bool result))
                {
                    result = false;
                }

                obj.IsChecked = result;
            }
        }

        public override void Default()
        {
            if (obj.Tag is string value)
            {
                obj.IsChecked = (value == "default");
            }
            else
            {
                obj.IsChecked = false;
            }
        }

        public override void SetDefault(bool value)
        {
            obj.Tag = value.ToString();
        }
    }
}
