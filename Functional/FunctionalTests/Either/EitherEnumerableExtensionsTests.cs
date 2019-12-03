using Functional;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace FunctionalTests.Either
{
    [TestClass]
    public class EitherEnumerableExtensionsTests
    {
        class Item { public int Value { get; set; } }

        private const string empty = "Empty!";

        [TestMethod]
        public void FirstOrDefaultOfStruct_WhenNonEmpty_ReturnsRight()
        {
            var seq = Enumerable.Range(4, 8);

            var result = seq.FirstOrDefault(empty);

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
        public void FirstOrDefaultOfStruct_WhenEmpty_ReturnsLeft()
        {
            var seq = Enumerable.Empty<int>();

            var result = seq.FirstOrDefault(empty);

            if (result is Left<string, int> left)
            {
                Assert.AreEqual(empty, left.Content);
            }
            else
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void FirstOrDefaultOfClass_WhenNonEmpty_ReturnsRight()
        {
            var seq = new[] { new Item { Value = 1 }, new Item { Value = 2 } };

            var result = seq.FirstOrDefault(empty);

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
        public void FirstOrDefaultOfClass_WhenEmpty_ReturnsLeft()
        {
            var seq = new Item[] { };

            var result = seq.FirstOrDefault(empty);

            if (result is Left<string, Item> left)
            {
                Assert.AreEqual(empty, left.Content);
            }
            else
            {
                Assert.Fail();
            }
        }
    }
}
