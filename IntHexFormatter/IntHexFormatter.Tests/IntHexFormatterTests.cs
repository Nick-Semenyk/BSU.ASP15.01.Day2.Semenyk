using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using IntHexFormatter;

namespace IntHexFormatter.Tests
{
    [TestFixture]
    public class IntHexFormatterTests
    {
        [TestCase(0, Result = "00000000")]
        [TestCase(123, Result = "0000007B")]
        [TestCase(-123, Result = "FFFFFF85")]
        [TestCase(int.MaxValue, Result = "7FFFFFFF")]
        [TestCase(int.MinValue, Result = "80000000")]
        [TestCase(-1, Result = "FFFFFFFF")]
        public string IntHexFormatterUsualTests(int number)
        {
            IFormatProvider fp = new IntHexFormatter();
            return string.Format(fp, "{0:H}", number);
        }

        [Test]
        public void IntHexFormatterAssertTests()
        {
            IFormatProvider fp = new IntHexFormatter();
            for (int i = -1023; i < 1024; i++)
            {
                Assert.AreEqual(string.Format(fp, "{0:H}", i), string.Format("{0:X8}", i));
            }
            for (int i = -1023; i < 1024; i++)
            {
                Assert.AreEqual(string.Format(fp, "{0:h}", i), string.Format("{0:x8}", i));
            }
        }
    }
}
