
namespace SPiApp2.Components.Settings.Converters
{
    public class IntConverter : Converter<int, int>
    {
        private int def;

        public IntConverter(int obj) :
            base(obj)
        {
            def = obj;
        }

        public override int Value
        {
            get
            {
                return obj;
            }
            set
            {
                obj = value;
            }
        }

        public override string Ambiguous
        {
            get
            {
                return obj.ToString();
            }
            set
            {
                if (!int.TryParse(value, out int result))
                {
                    result = -1;
                }

                obj = result;
            }
        }

        public override void Default()
        {
            obj = def;
        }

        public override void SetDefault(int value)
        {
            def = value;
        }
    }
}

