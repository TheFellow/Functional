﻿using Functional;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

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

        [TestMethod]
        public void MapTwoTrackFunction_WhenRightReturnsNewRight_AppliesMap()
        {
            Either<int, string> either = "Hello World";

            var result = either.Map(s => s.First(c => char.ToUpperInvariant(c) == c) == 'H' ? '1' : '0');

            if (result is Right<int, char> right)
            {
                Assert.AreEqual('1', right.Content);
            }
            else
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void MapTwoTrackFunction_WhenRightReturnsLeft_AppliesMap()
        {
            Either<int, string> either = "hello World";

            var result = either.Map(s => s.First(c => char.ToUpperInvariant(c) == 'H') == 'H' ? '1' : '0');

            if (result is Right<int, char> right)
            {
                Assert.AreEqual('0', right.Content);
            }
            else
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void MapTwoTrackFunction_WhenLeft_DoesNotApplyFunction()
        {
            Either<int, string> either = 4;

            var result = either.Map(s => s.First(c => char.ToUpperInvariant(c) == c) == 'H' ? '1' : '0');

            if (result is Left<int, char> left)
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
