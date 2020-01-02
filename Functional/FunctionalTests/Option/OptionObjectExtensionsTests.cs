using Functional.Option;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FunctionalTests.Option
{
    [TestClass]
    public class OptionObjectExtensionsTests
    {
        private const string _sample = "Hello World";

        [TestMethod]
        public void NoneIfNull_OnNullInstance_ReturnsNoneOfThatType()
        {
            string str = null!;

            var result = str.NoneIfNull();

            Assert.IsInstanceOfType(result, typeof(None<string>));
        }

        [TestMethod]
        public void NoneIfNull_OnNonNullInstance_ReturnsSomeOfThatType()
        {
            string str = "";

            var result = str.NoneIfNull();

            Assert.IsInstanceOfType(result, typeof(Some<string>));
        }


        #region When Tests

        [TestMethod]
        public void When_ConditionIsTrue_ReturnsSome()
        {
            Option<string> result = _sample.When(true);

            Assert.IsInstanceOfType(result, typeof(Some<string>));
        }

        [TestMethod]
        public void When_ConditionIsFalse_ReturnsNone()
        {
            Option<string> result = _sample.When(false);

            Assert.IsInstanceOfType(result, typeof(None<string>));
        }

        [TestMethod]
        public void When_PredicateReturnsTrue_ReturnsSome()
        {
            Option<string> result = _sample.When(() => true);

            Assert.IsInstanceOfType(result, typeof(Some<string>));
        }

        [TestMethod]
        public void When_PredicateReturnsFalse_ReturnsNone()
        {
            Option<string> result = _sample.When(() => false);

            Assert.IsInstanceOfType(result, typeof(None<string>));
        }

        [TestMethod]
        public void When_PredicateOfTReturnsTrue_CallsPredicateAndReturnsSome()
        {
            bool calledWithCorrectArg = false;
            Option<string> result = _sample.When(s =>
            {
                calledWithCorrectArg = s == _sample;
                return true;
            });

            Assert.IsTrue(calledWithCorrectArg);
            Assert.IsInstanceOfType(result, typeof(Some<string>));
        }

        [TestMethod]
        public void When_PredicateOfTReturnsFalse_CallsPredicateAndReturnsNone()
        {
            bool calledWithCorrectArg = false;
            Option<string> result = _sample.When(s =>
            {
                calledWithCorrectArg = s == _sample;
                return false;
            });

            Assert.IsTrue(calledWithCorrectArg);
            Assert.IsInstanceOfType(result, typeof(None<string>));
        }

        #endregion
    }
}
