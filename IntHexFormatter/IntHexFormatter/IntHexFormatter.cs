using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntHexFormatter
{
    public class IntHexFormatter : ICustomFormatter, IFormatProvider
    {
        IFormatProvider _parent;

        public IntHexFormatter() : this (CultureInfo.CurrentCulture) { }

        public IntHexFormatter(IFormatProvider parent)
        {
            _parent = parent;
        }


        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            if (arg == null || (format != "h" && format != "H") || !object.ReferenceEquals(arg.GetType(), typeof(int)))
                return string.Format(_parent, "{0:" + format + "}", arg);
            string hexSymbols = "0123456789abcdef";
            if (format == "H")
            {
                hexSymbols = hexSymbols.ToUpper();
            }
            int number = (int) arg;
            uint f = (uint)15 << 7 * 4;
            StringBuilder result = new StringBuilder();
            for (int i = 7; i >= 0; i--)
            {
                UInt32 currentSymbol = (UInt32)(number & f);
                currentSymbol = currentSymbol >> i * 4;
                result.Append(hexSymbols[(int)currentSymbol]);
                f = f >> 4;
            }
            return result.ToString();
        }

        public object GetFormat(Type formatType)
        {
            if (formatType == typeof(ICustomFormatter))
                return this;
            return null;
        }
    }
}
