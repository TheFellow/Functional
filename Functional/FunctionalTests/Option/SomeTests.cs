using Functional.Option;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FunctionalTests.Option
{
    [TestClass]
    public partial class SomeTests
    {

        [TestMethod]
        public void SomeOfT1_DoesNotEqual_SomeOfT2()
        {
            var some1 = new Some<MyType1>(new MyType1 { Value = 4 });
            var some2 = new Some<MyType2>(new MyType2 { Value = 4 });

            Assert.AreNotEqual(some1, some2);
            Assert.IsFalse(some1.Equals(some2));
            Assert.IsFalse(some2.Equals(some1));
        }
    }
}
