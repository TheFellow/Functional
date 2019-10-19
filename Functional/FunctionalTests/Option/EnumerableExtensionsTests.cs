using Functional;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace FunctionalTests.Option
{
    [TestClass]
    public class EnumerableExtensionsTests
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
    }
}
