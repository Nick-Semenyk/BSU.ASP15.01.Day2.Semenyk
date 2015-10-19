using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomerClasses;

namespace CustomerConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Customer customer = new Customer("Ivan Ivanovich","(029)1234567", 9001);
            Console.WriteLine(customer.ToString());
            IFormatProvider fp = new CultureInfo("en-US");
            Console.WriteLine(customer.ToString("{N}, {P}; {R:C2}", fp));
            fp = new CultureInfo("es-ES");
            Console.WriteLine(customer.ToString("{N}, {P}; {R:C2}", fp));
            string val = customer.ToString("{R:C2}", CultureInfo.CurrentCulture);
            Console.WriteLine(customer.ToString("{R:C2}", CultureInfo.CurrentCulture));
            Console.WriteLine(customer.ToString("{N}, {P}; {R:C2}", CultureInfo.InvariantCulture));
            
            Console.ReadLine();
        }
    }
}
