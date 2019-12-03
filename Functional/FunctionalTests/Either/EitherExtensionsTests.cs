using Functional;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace FunctionalTests.Either
{
    [TestClass]
    public class EitherExtensionsTests
    {
        #region Reduce Tests

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

        #endregion

        #region Map Tests

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

        private static Either<int, char> MapOneToTwo(string str) =>
            str.StartsWith('H')
                ? (Either<int, char>)str[0]
                : str.Length;


        [TestMethod]
        public void MapTwoTrackFunction_WhenRightReturnsNewRight_AppliesMap()
        {
            Either<int, string> either = "Hello World";

            var result = either.Map(MapOneToTwo);

            if (result is Right<int, char> right)
            {
                Assert.AreEqual('H', right.Content);
            }
            else
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void MapTwoTrackFunction_WhenRightReturnsLeft_ReturnsLeft()
        {
            Either<int, string> either = "hello World";

            var result = either.Map(MapOneToTwo);

            if (result is Left<int, char> left)
            {
                Assert.AreEqual(11, left.Content);
            }
            else
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void MapTwoTrackFunction_WhenLeft_DoesNotApplyMap()
        {
            Either<int, string> either = 4;

            var result = either.Map(MapOneToTwo);

            if (result is Left<int, char> left)
            {
                Assert.AreEqual(4, left.Content);
            }
            else
            {
                Assert.Fail();
            }
        }

        #endregion

        #region Tee Tests

        [TestMethod]
        public void Tee_WhenRight_CallsActionWithContentAndPassesEither()
        {
            Either<int, string> either = "Hello World";

            string value = string.Empty;
            var result = either.Tee(s => value = s);

            Assert.AreEqual("Hello World", value);
            Assert.AreEqual(either, result);
        }

        [TestMethod]
        public void Tee_WhenLeft_DoesNotCallActionAndPassesEither()
        {
            Either<int, string> either = 4;

            string value = string.Empty;
            var result = either.Tee(s => value = s);

            Assert.AreEqual(string.Empty, value);
            Assert.AreEqual(either, result);
        }

        #endregion
    }
}
