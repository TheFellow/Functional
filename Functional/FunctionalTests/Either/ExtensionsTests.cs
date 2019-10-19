using Functional;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FunctionalTests.Either
{
    [TestClass]
    public class ExtensionsTests
    {
        [TestMethod]
        public void Reduce_WhenRight_ReturnsRight()
        {
            Either<int, string> either = "Hello World";

            var result = either.Reduce("Replacement");

            Assert.AreEqual("Hello World", result);
        }

        [TestMethod]
        public void Reduce_WhenLeft_ReturnsReplacement()
        {
            Either<int, string> either = 4;

            var result = either.Reduce("Replacement");

            Assert.AreEqual("Replacement", result);
        }
    }
}
