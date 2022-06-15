namespace SPiApp2.Components.Settings.Converters
{
    public class StringConverter : Converter<string, string>
    {
        private string def;

        public StringConverter(string obj) :
            base(obj)
        {
            def = string.Copy(obj);
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
                return obj;
            }
            set
            {
                obj = value;
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
            def = value;
        }
    }
}
