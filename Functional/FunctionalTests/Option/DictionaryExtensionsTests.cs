using Functional;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace FunctionalTests.Option
{
    [TestClass]
    public class DictionaryExtensionsTests
    {
        [TestMethod]
        public void TryGetValue_WithValue_IsSome()
        {
            var entries = Enumerable.Range(0, 6)
                .Where(i => i % 2 == 0)
                .ToDictionary(i => i.ToString());

            var result = entries.TryGetValue("2");

            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void TryGetValue_WithoutValue_IsNone()
        {
            var entries = Enumerable.Range(4, 6)
                .Where(i => i < 4)
                .ToDictionary(i => i.ToString());

            var result = entries.TryGetValue("4");

            Assert.IsInstanceOfType(result, typeof(None<int>));
        }
    }
}
