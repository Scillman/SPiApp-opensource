using System.Windows.Controls;

namespace SPiApp2.Components.Settings.Converters
{
    public class TextBoxConverter : Converter<TextBox, string>
    {
        public TextBoxConverter(ref TextBox obj) :
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
                return obj.Text;
            }
            set
            {
                obj.Text = value;
            }
        }

        public override void Default()
        {
            if (obj.Tag is string value)
            {
                obj.Text = value;
            }
            else
            {
                obj.Text = string.Empty;
            }
        }

        public override void SetDefault(string value)
        {
            obj.Tag = value;
        }
    }
}
