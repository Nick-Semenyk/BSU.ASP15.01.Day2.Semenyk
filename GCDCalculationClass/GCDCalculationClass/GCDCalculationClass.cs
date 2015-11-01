using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCDCalculationClass
{
    /// <summary>
    /// Provides methods for calculating greatest common divisor
    /// </summary>
    public static class GCDCalculationClass
    {
        private delegate int ArrayParams(params int[] numbers);

        private delegate int CalculateGcd(int a, int b);
        
//        {
//        if (numbers == null)
//            {
//                throw new ArgumentNullException();
//    }
//            if (numbers.Count() == 0)
//            {
//                throw new ArgumentNullException();
//}
//            if (numbers.Count() == 1)
//            {
//                return numbers[0];
//            }
//            int temporyGCD = numbers[0];
//            for (int i = 1; i<numbers.Count(); i++)
//            {
//                temporyGCD = BinaryAlgorithm(numbers[i], temporyGCD);
//                if (temporyGCD == 1)
//                    return 1;
//            }
//            return temporyGCD;
//        }

        /// <summary>
        /// Returns GCD of two integers using Euclidean method
        /// </summary>
        /// <param name="a">The first integer for calculating GCD</param>
        /// <param name="b">The second integer for calculating GCD</param>
        /// <returns></returns>
        public static int EuclideanAlgorithm(int a, int b)
        {
            int first, second, tempory;
            a = Math.Abs(a);
            b = Math.Abs(b);
            if (a > b)
            {
                first = a;
                second = b;
            }
            else
            {
                first = b;
                second = a;
            }
            while (second != 0)
            {
                tempory = second;
                second = first % second;
                first = tempory;
            }
            return first;
        }

        /// <summary>
        /// Returns GCD of two integers using Euclidean method
        /// </summary>
        /// <param name="a">The first integer for calculating GCD</param>
        /// <param name="b">The second integer for calculating GCD</param>
        /// <param name="time">Returns time in ticks which this method spent</param>
        /// <returns></returns>
        public static int EuclideanAlgorithm(int a, int b, out long time)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            int result = EuclideanAlgorithm(a,b);
            timer.Stop();
            time = timer.ElapsedTicks;
            return result;
        }

        /// <summary>
        /// Returns GCD of three integers using Euclidean method
        /// </summary>
        /// <param name="a">The first integer for calculating GCD</param>
        /// <param name="b">The second integer for calculating GCD</param>
        /// <param name="c">The third integer for calculating GCD</param>
        /// <returns></returns>
        public static int EuclideanAlgorithm(int a, int b, int c)
        {
            int temporyGCD = EuclideanAlgorithm(a, b);
            temporyGCD = EuclideanAlgorithm(c, temporyGCD);
            return temporyGCD;
        }

        /// <summary>
        /// Returns GCD of three integers using Euclidean method
        /// </summary>
        /// <param name="a">The first integer for calculating GCD</param>
        /// <param name="b">The second integer for calculating GCD</param>
        /// <param name="c">The third integer for calculating GCD</param>
        /// <param name="time">Returns time in ticks which this method spent</param>
        /// <returns></returns>
        public static int EuclideanAlgorithm(int a, int b, int c, out long time)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            int temporyGCD = EuclideanAlgorithm(a, b);
            temporyGCD = EuclideanAlgorithm(c, temporyGCD);
            timer.Stop();
            time = timer.ElapsedTicks;
            return temporyGCD;
        }

        /// <summary>
        /// Returns GCD of two or more integers using Euclidean method
        /// </summary>
        /// <param name="numbers">Numbers for calculating GCD</param>
        /// <returns></returns>
        public static int EuclideanAlgorithm(params int[] numbers)
        {
            CalculateGcd euclideanAlgorithm = EuclideanAlgorithm;
            return CalculateGcdOfValues(euclideanAlgorithm, numbers);
        }

        /// <summary>
        /// Returns GCD of two or more integers using Euclidean method
        /// </summary>
        /// <param name="numbers">Numbers for calculating GCD</param>
        /// <param name="time">Returns time in ticks which this method spent</param>
        /// <returns></returns>
        public static int EuclideanAlgorithm(out long time, params int[] numbers)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            CalculateGcd euclideanAlgorithm = EuclideanAlgorithm;
            int result = CalculateGcdOfValues(euclideanAlgorithm, numbers);
            timer.Stop();
            time = timer.ElapsedTicks;
            return result;
        }

        /// <summary>
        /// Returns GCD of three integers using Binary method
        /// </summary>
        /// <param name="a">The first integer for calculating GCD</param>
        /// <param name="b">The second integer for calculating GCD</param>
        /// <returns></returns>
        public static int BinaryAlgorithm(int a, int b)
        {
            a = Math.Abs(a);
            b = Math.Abs(b);
            int temporyCD = 1;
            do
            {
                if (b == 0)
                    return a * temporyCD;
                if (a == 0)
                    return b * temporyCD;
                if ((a % 2 == 0) && (b % 2 == 0))
                {
                    temporyCD *= 2;
                    a /= 2;
                    b /= 2;
                }
                if ((a % 2 == 0) && (b % 2 == 1))
                {
                    a /= 2;
                }
                if ((a % 2 == 1) && (b % 2 == 0))
                {
                    b /= 2;
                }
                if ((a % 2 == 1) && (b % 2 == 1))
                {
                    if (a < b)
                    {
                        b = b - a;
                    }
                    if (a > b)
                    {
                        a = a - b;
                    }
                }
            } while (a != b);
            return a * temporyCD;
        }

        /// <summary>
        /// Returns GCD of three integers using Binary method
        /// </summary>
        /// <param name="a">The first integer for calculating GCD</param>
        /// <param name="b">The second integer for calculating GCD</param>
        /// <param name="time">Returns time in ticks which this method spent</param>
        /// <returns></returns>
        public static int BinaryAlgorithm(int a, int b, out long time)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            int result = BinaryAlgorithm(a, b);
            timer.Stop();
            time = timer.ElapsedTicks;
            return result;
        }

        /// <summary>
        /// Returns GCD of three integers using Euclidean method
        /// </summary>
        /// <param name="a">The first integer for calculating GCD</param>
        /// <param name="b">The second integer for calculating GCD</param>
        /// <param name="c">The third integer for calculating GCD</param>
        /// <returns></returns>
        public static int BinaryAlgorithm(int a, int b, int c)
        {
            int temporyGCD = BinaryAlgorithm(a, b);
            temporyGCD = BinaryAlgorithm(c, temporyGCD);
            return temporyGCD;
        }

        /// <summary>
        /// Returns GCD of three integers using Euclidean method
        /// </summary>
        /// <param name="a">The first integer for calculating GCD</param>
        /// <param name="b">The second integer for calculating GCD</param>
        /// <param name="c">The third integer for calculating GCD</param>
        /// <param name="time">Returns time in ticks which this method spent</param>
        /// <returns></returns>
        public static int BinaryAlgorithm(int a, int b, int c, out long time)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            int temporyGCD = BinaryAlgorithm(a, b);
            temporyGCD = BinaryAlgorithm(c, temporyGCD);
            timer.Stop();
            time = timer.ElapsedTicks;
            return temporyGCD;
        }

        /// <summary>
        /// Returns GCD of two or more integers using Euclidean method
        /// </summary>
        /// <param name="numbers">Numbers for calculating GCD</param>
        /// <returns></returns>
        public static int BinaryAlgorithm(params int[] numbers)
        {
            CalculateGcd binaryAlgorithm = BinaryAlgorithm;
            return CalculateGcdOfValues(binaryAlgorithm, numbers);
        }

        /// <summary>
        /// Returns GCD of two or more integers using Euclidean method
        /// </summary>
        /// <param name="numbers">Numbers for calculating GCD</param>
        /// <param name="time">Returns time in miliseconds which this method spent</param>
        /// <returns></returns>
        public static int BinaryAlgorithm(out long time, params int[] numbers)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            CalculateGcd binaryAlgorithm = BinaryAlgorithm;
            int result = CalculateGcdOfValues(binaryAlgorithm, numbers);
            timer.Stop();
            time = timer.ElapsedTicks;
            return result;
        }

        private static int CalculateGcdOfValues(CalculateGcd calculateMethod, params int[] values)
        {
            if (values == null)
            {
                throw new ArgumentNullException();
            }
            if (values.Count() == 0)
            {
                throw new ArgumentNullException();
            }
            if (values.Count() == 1)
            {
                return values[0];
            }
            int temporyGCD = values[0];
            for (int i = 1; i < values.Count(); i++)
            {
                temporyGCD = calculateMethod(values[i], temporyGCD);
                if (temporyGCD == 1)
                    return 1;
            }
            return temporyGCD;
        }
    }
}
