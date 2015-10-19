using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MathMethods.MathMethods;
using static System.Math;

namespace MathMethodsConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(NewtonsSqrt(double.MaxValue, 5));
            Console.WriteLine(Pow(double.MaxValue, 1.0/5));
            Console.ReadLine();
        }
    }
}
