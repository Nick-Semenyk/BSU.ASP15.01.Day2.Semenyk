using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntHexFormatter;

namespace HexFormatterConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = -123;
            IFormatProvider fp = new IntHexFormatter.IntHexFormatter();
            Console.WriteLine(string.Format(fp, "{0:X8} = {0:X4} = {0:H}", n));
            Console.WriteLine(string.Format(fp, "{0:x8} = {0:x4} = {0:h}", n));
            Console.WriteLine(string.Format(fp, "{0:x8} = {0:x4} = {0:h}", int.MinValue));
            Console.ReadLine();
        }
    }
}
