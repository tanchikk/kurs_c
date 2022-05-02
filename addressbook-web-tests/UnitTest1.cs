using NUnit.Framework;
using System;

namespace addressbook_web_tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
        }
    }

    internal class TestMethodAttribute : Attribute
    {
    }

    internal class TestClassAttribute : Attribute
    {
    }
}
