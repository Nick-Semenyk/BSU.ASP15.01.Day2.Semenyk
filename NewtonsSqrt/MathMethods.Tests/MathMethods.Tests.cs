using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using static MathMethods.MathMethods;

namespace MathMethods.Tests
{
    [TestFixture]
    public class MathMethodsTests
    {
        [Test]
        public void NewtonsSqrtUsualTests()
        {
            Assert.AreEqual(4, NewtonsSqrt(16, 2), 1E-6);
            Assert.AreEqual(3, NewtonsSqrt(27, 3), 1E-6);
            Assert.AreEqual(Math.Pow(10, 1.0/5), NewtonsSqrt(10, 5), 1E-6);
            Assert.AreEqual(Math.Pow(8897, 1.0 / 3), NewtonsSqrt(8897, 3), 1E-6);
            Assert.AreEqual(Math.Pow(10, 1.0 / 5), NewtonsSqrt(10, 5, 0.5), 0.5);
            Assert.AreEqual(Math.Pow(-100, 1.0/2), NewtonsSqrt(-100, 2));
            Assert.That(Math.Pow(double.MaxValue, 1.0 / 5), Is.EqualTo(NewtonsSqrt(double.MaxValue, 5)).Within(1E-11).Percent);
            Assert.That(Math.Pow(double.MaxValue - 500, 1.0 / 500), Is.EqualTo(NewtonsSqrt(double.MaxValue - 500, 500)).Within(1E-11).Percent);
        }
        
        [ExpectedException(typeof (ArgumentException))]
        [TestCase(-5,-5, 1E-6)]
        [TestCase(-5, 0, 1E-6)]
        [TestCase(400, -1, 1E-6)]
        [TestCase(100, 100, 10)]
        [TestCase(30, 28, -2)]
        public void NewtonsSqrtExceptionsTests(double x, int n, double eps = 1E-6)
        {
            NewtonsSqrt(x, n, eps);
        }
    }
}
