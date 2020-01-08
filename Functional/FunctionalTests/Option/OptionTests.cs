using Functional.Option;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FunctionalTests.Option
{
    [TestClass]
    public class OptionTests
    {
        [TestMethod]
        public void Some_OfTypeUpcast_ReturnsSomeOfNewType()
        {
            var some = new Some<MySubtype1>(new MySubtype1());

            var converted = some.OfType<MyType1>();

            Assert.IsInstanceOfType(converted, typeof(Some<MyType1>));
        }

        [TestMethod]
        public void Some_OfTypeDowncast_ReturnsSomeOfNewType()
        {
            var some = new Some<MyType1>(new MySubtype1());

            var converted = some.OfType<MySubtype1>();

            Assert.IsInstanceOfType(converted, typeof(Some<MySubtype1>));
        }

        [TestMethod]
        public void Some_OfTypeInvalidcast_ReturnsNoneOfNewType()
        {
            var some = new Some<MyType1>(new MyType1());

            var converted = some.OfType<MyType2>();

            Assert.IsInstanceOfType(converted, typeof(None<MyType2>));
        }

        [TestMethod]
        public void None_OfTypeDowncast_ReturnsNoneOfNewType()
        {
            var none = new None<MyType1>();

            var converted = none.OfType<MySubtype1>();

            Assert.IsInstanceOfType(converted, typeof(None<MySubtype1>));
        }

        [TestMethod]
        public void None_OfTypeUpcast_ReturnsNoneOfNewType()
        {
            var none = new None<MySubtype1>();

            var converted = none.OfType<MyType1>();

            Assert.IsInstanceOfType(converted, typeof(None<MyType1>));
        }

        [TestMethod]
        public void OptionOfT_BehavesAsAValueTypeForEquality()
        {
            Option<int> some1 = 5;
            Option<int> some2 = 5;

            Assert.AreEqual(some1, some2);
            Assert.IsTrue(some1.Equals(some2));
            Assert.IsTrue(some1 == some2);
            Assert.IsTrue(some2 == some1);
            Assert.IsTrue(some1.GetHashCode() == some2.GetHashCode());
            Assert.IsFalse(some1 != some2);
            Assert.IsFalse(some2 != some1);
        }

        [TestMethod]
        public void Option_EqualsOption_WhenSomeWithSameContent()
        {
            Option<int> option1 = 5;
            Option<int> option2 = 5;

            Assert.IsTrue(option1.Equals(option2));
            Assert.IsTrue(option2.Equals(option1));
            Assert.IsTrue(option1 == option2);
            Assert.IsTrue(option2 == option1);
            Assert.IsFalse(option1 != option2);
            Assert.IsFalse(option2 != option1);
        }

        [TestMethod]
        public void Option_DoesNotEqualOption_WhenSomeWithDifferentContent()
        {
            Option<int> option1 = 4;
            Option<int> option2 = 5;

            Assert.IsFalse(option1.Equals(option2));
            Assert.IsFalse(option2.Equals(option1));
            Assert.IsFalse(option1 == option2);
            Assert.IsFalse(option2 == option1);
            Assert.IsTrue(option1 != option2);
            Assert.IsTrue(option2 != option1);
        }
    }
}
