using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace CustomerClasses
{
    public class Customer : IFormattable
    {
        public string Name { get; private set; }
        public string ContactPhone { get; private set; }
        public decimal Revenue { get; private set; }

        public Customer(string name, string phone, decimal revenue)
        {
            if (name == null || phone == null)
            {
                throw new ArgumentNullException();
            }
            if (revenue < 0)
            {
                throw new ArgumentException();
            }
            if (name == string.Empty || phone == string.Empty ||
                name == Environment.NewLine || phone == Environment.NewLine)
            {
                throw new ArgumentException();
            }
            Name = name;
            ContactPhone = phone;
            Revenue = revenue;
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            format = format.Replace("{N}", "{0}");
            format = format.Replace("{P}", "{1}");
            format = format.Replace("{R", "{2");
            //try
            //{
                return String.Format(formatProvider, format, this.Name, this.ContactPhone, this.Revenue);
            //}
            //catch(FormatException e)
            //{
            //    throw new FormatException();
            //}
        }

        public override string ToString()
        {
            return this.ToString("{N}, {P}, {R}", CultureInfo.CurrentCulture);
        }
    }
}
