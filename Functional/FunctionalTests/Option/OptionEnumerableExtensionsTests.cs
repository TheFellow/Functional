using Functional.Optional;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace FunctionalTests.Option
{
    [TestClass]
    public class OptionEnumerableExtensionsTests
    {
        [TestMethod]
        public void Flatten_ReturnsEntriesMatchingMap()
        {
            var values = Enumerable.Range(0, 6);

            var result = values.Flatten(
                i => i % 2 == 0
                    ? (Option<string>)new Some<string>(i.ToString())
                    : None.Value);

            Assert.IsTrue(result.SequenceEqual(new string[] { "0", "2", "4" }));
        }

        [TestMethod]
        public void FirstOrNone_OnEmptySequence_IsNone()
        {
            var result = Enumerable.Empty<int>().FirstOrNone();

            Assert.IsInstanceOfType(result, typeof(None<int>));
        }

        [TestMethod]
        public void FirstOrNone_OnNonEmptySequence_IsFirstEntry()
        {
            var result = Enumerable.Range(4, 8).FirstOrNone();

            if (result is Some<int> someInt)
            {
                Assert.AreEqual(4, someInt.Content);
            }
            else
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void FirstOrNone_WithTruePredicate_IsSome()
        {
            var result = Enumerable.Range(1, 6).FirstOrNone(i => i % 2 == 0);

            if (result is Some<int> someInt)
            {
                Assert.AreEqual(2, someInt.Content);
            }
            else
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void FirstOrNone_WithContradiction_IsNone()
        {
            var result = Enumerable.Range(1, 6).FirstOrNone(i => i < 1);

            Assert.IsInstanceOfType(result, typeof(None<int>));
        }
    }
}
