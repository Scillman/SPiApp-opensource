using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPiApp2.Components.Settings.Converters
{
    public class BoolConverter : Converter<bool, bool>
    {
        private bool def;

        public BoolConverter(bool obj) :
            base(obj)
        {
            def = obj;
        }

        public override bool Value
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
                if (!bool.TryParse(value, out bool result))
                {
                    result = false;
                }

                obj = result;
            }
        }

        public override void Default()
        {
            obj = def;
        }

        public override void SetDefault(bool value)
        {
            def = value;
        }
    }
}


