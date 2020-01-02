using Functional.Optional;
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
    }
}
