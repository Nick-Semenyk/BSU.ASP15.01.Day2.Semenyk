using System;
using System.Collections.Generic;
using System.Text;

namespace MathMethods
{
    public class MathMethods
    {
        public static double NewtonsSqrt(double x, int n, double eps = 1E-6)
        {
            if (n <= 0)
            {
                throw new ArgumentException();
            }
            if (eps > 1 || eps < 0)
            {
                throw new ArgumentException();
            }
            if (x < 0 && n % 2 == 0)
            {
                return double.NaN;
            }
            double xCurr;
            double xNext = 1.1;
            do
            {
                xCurr = xNext;
                xNext = ((n - 1) * xCurr + x / Math.Pow(xCurr,n-1)) / n;
            } while (Math.Abs(xCurr - xNext) > eps);
            return xNext;
        }
    }
}
