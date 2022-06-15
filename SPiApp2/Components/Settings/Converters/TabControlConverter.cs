using System.Diagnostics;
using System.Windows.Controls;

namespace SPiApp2.Components.Settings.Converters
{
    public class TabControlConverter : Converter<TabControl, int>
    {
        public TabControlConverter(ref TabControl obj) :
            base(ref obj)
        {
            ; // Do nothing...
        }

        public override int Value
        {
            get
            {
                return int.Parse(Ambiguous);
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
                Debug.Assert(obj.Items.Count > 0, "Can't get item from an empty TabControl object.");
                return obj.SelectedIndex.ToString();
            }
            set
            {
                Debug.Assert(obj.Items.Count > 0, "Can't set item for an empty TabControl object.");
                
                if (!int.TryParse(value, out int index) || index >= obj.Items.Count)
                {
                    index = 0;
                }

                obj.SelectedIndex = index;
            }
        }

        public override void Default()
        {
            int index;

            if (obj.Tag is string value)
            {
                Debug.Assert(obj.Items.Count > 0);

                if (!int.TryParse(value, out index) || index >= obj.Items.Count)
                {
                    index = 0;
                }
            }
            else
            {
                index = 0;
            }

            if (obj.SelectedIndex != index)
            {
                obj.SelectedIndex = index;
            }
        }

        public override void SetDefault(int value)
        {
            obj.Tag = value.ToString();
        }
    }
}
