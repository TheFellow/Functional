using Functional.Optional;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FunctionalTests.Option
{
    [TestClass]
    public class OptionExtensionsTests
    {
        private const string _whenNone = "Replacement";
        private const string _sample = "Hello World";

        #region Reduce Tests

        [TestMethod]
        public void ReduceWithReplacement_SomeOfT_ReturnsContent()
        {
            Option<string> some = _sample;

            string result = some.Reduce(_whenNone);

            Assert.AreEqual(_sample, result);
        }

        [TestMethod]
        public void ReduceWithFunc_OnSomeOfT_ReturnsContentWithoutCallingFunc()
        {
            Option<string> some = _sample;

            bool calledFunc = false;

            string result = some.Reduce(() =>
            {
                calledFunc = true;
                return _whenNone;
            });

            Assert.IsFalse(calledFunc);
            Assert.AreEqual(_sample, result);
        }

        [TestMethod]
        public void ReduceWithReplacement_NoneOfT_ReturnsReplacement()
        {
            Option<string> none = None.Value;

            string result = none.Reduce(_whenNone);

            Assert.AreEqual(_whenNone, result);
        }

        [TestMethod]
        public void ReduceWithFunc_OnNoneOfT_CallsFuncForReplacement()
        {
            Option<string> none = None.Value;

            bool calledFunc = false;

            string result = none.Reduce(() =>
            {
                calledFunc = true;
                return _whenNone;
            });

            Assert.IsTrue(calledFunc);
            Assert.AreEqual(_whenNone, result);
        }

        #endregion

        #region Map Tests

        [TestMethod]
        public void MapOneTrackFunction_OfSome_MapsToNewSome()
        {
            Option<MyType1> option = new MyType1();

            Option<string> result = option.Map(mt => mt.ToString());

            if (result is Some<string> some)
            {
                Assert.AreEqual(nameof(MyType1), some.Content);
            }
            else
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void MapOneTrackFunction_OfNone_MapsToNewNone()
        {
            Option<MyType1> option = None.Value;

            Option<string> result = option.Map(mt => mt.ToString());

            Assert.IsInstanceOfType(result, typeof(None<string>));
        }

        [TestMethod]
        public void MapTwoTrackFunction_OfSome_MapsToNewSome()
        {
            Option<MyType1> option = new MyType1();

            Option<string> result = option.Map(mt => mt.ToString().NoneIfNull());

            if (result is Some<string> some)
            {
                Assert.AreEqual(nameof(MyType1), some.Content);
            }
            else
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void MapTwoTrackFunction_OfNone_MapsToNewNone()
        {
            Option<MyType1> option = None.Value;

            Option<string> result = option.Map(mt => mt.ToString().NoneIfNull());

            Assert.IsInstanceOfType(result, typeof(None<string>));
        }

        #endregion

        #region Tee Tests

        [TestMethod]
        public void Tee_WhenSome_CallsActionWithContentAndPassesOption()
        {
            Option<int> option = 8;

            int value = 0;
            var result = option.Tee(i => value = i);

            Assert.AreEqual(option, result);
            Assert.AreEqual(8, value);
        }

        [TestMethod]
        public void Tee_WhenNone_DoesNotCallActionAndPassesOption()
        {
            Option<int> option = None.Value;

            int value = 0;
            var result = option.Tee(i => value = i);

            Assert.AreEqual(option, result);
            Assert.AreEqual(0, value);
        }

        #endregion
    }
}
