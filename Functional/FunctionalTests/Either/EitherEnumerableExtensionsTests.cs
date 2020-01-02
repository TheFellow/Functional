using Functional;
using Functional.Either;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace FunctionalTests.Either
{
    [TestClass]
    public class EitherEnumerableExtensionsTests
    {
        class Item { public int Value { get; set; } }

        private const string _empty = "Empty!";

        [TestMethod]
        public void FirstOrOtherOfStruct_WhenNonEmpty_ReturnsRight()
        {
            var seq = Enumerable.Range(4, 8);

            var result = seq.FirstOrOther(_empty);

            if (result is Right<string, int> right)
            {
                Assert.AreEqual(4, right.Content);
            }
            else
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void FirstOrOtherOfStruct_WhenEmpty_ReturnsLeft()
        {
            var seq = Enumerable.Empty<int>();

            var result = seq.FirstOrOther(_empty);

            if (result is Left<string, int> left)
            {
                Assert.AreEqual(_empty, left.Content);
            }
            else
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void FirstOrOtherOfStruct_WhenEmpty_ReturnsLeftLazy()
        {
            var seq = Enumerable.Empty<int>();

            var result = seq.FirstOrOther(() => _empty);

            if (result is Left<string, int> left)
            {
                Assert.AreEqual(_empty, left.Content);
            }
            else
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void FirstOrOtherOfClass_WhenNonEmpty_ReturnsRight()
        {
            var seq = new[] { new Item { Value = 1 }, new Item { Value = 2 } };

            var result = seq.FirstOrOther(_empty);

            if (result is Right<string, Item> right)
            {
                Assert.AreEqual(1, right.Content.Value);
            }
            else
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void FirstOrOtherOfClass_WhenEmpty_ReturnsLeft()
        {
            var seq = new Item[] { };

            var result = seq.FirstOrOther(_empty);

            if (result is Left<string, Item> left)
            {
                Assert.AreEqual(_empty, left.Content);
            }
            else
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void FirstOrOtherOfClass_WhenEmpty_ReturnsLeftLazy()
        {
            var seq = new Item[] { };

            var result = seq.FirstOrOther(() => _empty);

            if (result is Left<string, Item> left)
            {
                Assert.AreEqual(_empty, left.Content);
            }
            else
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void FirstOrOther_WithMatchingPredicate_ReturnsRight()
        {
            var seq = Enumerable.Range(4, 8);

            var result = seq.FirstOrOther(i => i % 2 == 1, _empty);

            if (result is Right<string, int> right)
            {
                Assert.AreEqual(5, right.Content);
            }
            else
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void FirstOrOther_WithFailingPredicate_ReturnsLeft()
        {
            var seq = Enumerable.Range(4, 8);

            var result = seq.FirstOrOther(i => i > 20, _empty);

            if (result is Left<string, int> left)
            {
                Assert.AreEqual(_empty, left.Content);
            }
            else
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void FirstOrOther_WithFailingPredicate_ReturnsLeftLazy()
        {
            var seq = Enumerable.Range(4, 8);

            var result = seq.FirstOrOther(i => i > 20, () => _empty);

            if (result is Left<string, int> left)
            {
                Assert.AreEqual(_empty, left.Content);
            }
            else
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void Map_AppliesFunctionOnlyToRightElements()
        {
            var seq = new Either<int, string>[] { 1, "two", 3 };

            var result = seq
                .Map(s => $"'{s}' is of length {s.Length}")
                .Select(e => e.ToString())
                .ToArray();

            var expected = new Either<int, string>[] { 1, "'two' is of length 3", 3 }
                .Select(e => e.ToString())
                .ToArray();

            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Reduce_ReplacesLeftValues_WithRightConstant()
        {
            var seq = new Either<int, string>[] { 1, "two", 3 };

            var result = seq.Reduce("Number").ToArray();

            CollectionAssert.AreEqual(new string[] { "Number", "two", "Number" }, result);
        }

        [TestMethod]
        public void Reduce_ReplacesLeftValues_WithRightLazy()
        {
            var seq = new Either<int, string>[] { 1, "two", 3 };

            var result = seq.Reduce(() => "Number").ToArray();

            CollectionAssert.AreEqual(new string[] { "Number", "two", "Number" }, result);
        }

        [TestMethod]
        public void Reduce_ReplacesLeftValues_WithFunctionOfLeft()
        {
            var seq = new Either<int, string>[] { 1, "two", 3 };

            var result = seq.Reduce(i => i.ToString()).ToArray();

            CollectionAssert.AreEqual(new string[] { "1", "two", "3" }, result);
        }
    }
}
