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

        [TestMethod]
        public void ReduceWithFunc_WhenRight_ReturnsRight()
        {
            Either<int, string> either = "Hello World";

            var result = either.Reduce(() => "Replacement");

            Assert.AreEqual("Hello World", result);
        }

        [TestMethod]
        public void ReduceWithFunc_WhenLeft_ReturnsReplacement()
        {
            Either<int, string> either = 4;

            var result = either.Reduce(() => "Replacement");

            Assert.AreEqual("Replacement", result);
        }

        [TestMethod]
        public void MapOneTrackFunction_WhenRight_AppliesMap()
        {
            Either<int, string> either = "Hello World";

            var result = either.Map(s => s + "!");

            if (result is Right<int, string> right)
            {
                Assert.AreEqual("Hello World!", right.Content);
            }
            else
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void MapOneTrackFunction_WhenLeft_DoesNotApplyMap()
        {
            Either<int, string> either = 4;

            var result = either.Map(s => s + "!");

            if (either is Left<int, string> left)
            {
                Assert.AreEqual(4, left.Content);
            }
            else
            {
                Assert.Fail();
            }
        }
    }
}
