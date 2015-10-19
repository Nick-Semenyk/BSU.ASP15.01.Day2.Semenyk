using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomerClasses;
using NUnit.Framework;

namespace Customer.Tests
{
    [TestFixture]
    public class CustomerTests
    {
        private static IFormatProvider _usualFormatProvider;
        private static CustomerClasses.Customer _customer;

        [TestFixtureSetUp]
        public void ObjectAndFormatCreator()
        {
            _usualFormatProvider = CultureInfo.CurrentCulture;
            _customer = new CustomerClasses.Customer("Ivan Ivanovich","(029)1234567", 9001);
        }

        [TestCase("{N}, {P}, {R}", Result = "Ivan Ivanovich, (029)1234567, 9001")]
        [TestCase("{N}; {R}; {P};", Result = "Ivan Ivanovich; 9001; (029)1234567;")]
        [TestCase("{N}", Result = "Ivan Ivanovich")]
        [TestCase("{R:C2}", Result = "9 001,00р.")]
        public string ToStringTests(string format)
        {
            return _customer.ToString(format, _usualFormatProvider);
        }

        [ExpectedException(typeof(ArgumentNullException))]
        [TestCase(null,"pp",0)]
        [TestCase("pp", null, 0)]
        [TestCase(null, null, 0)]
        public void ConstructorNullTests(string name, string phone, decimal revenue)
        {
            CustomerClasses.Customer customer = new CustomerClasses.Customer(name, phone, revenue);
        }

        [ExpectedException(typeof(ArgumentException))]
        [Test]
        public void ConstructorStringTests()
        {
            CustomerClasses.Customer customer = new CustomerClasses.Customer(String.Empty, "ss", 0);
            customer = new CustomerClasses.Customer(String.Empty, "ss", 0);
            customer = new CustomerClasses.Customer("ss", String.Empty, 0);
            customer = new CustomerClasses.Customer(String.Empty, String.Empty, 0);
            customer = new CustomerClasses.Customer(Environment.NewLine, String.Empty, 0);
            customer = new CustomerClasses.Customer(String.Empty,Environment.NewLine, 0);
        }
    }
}
