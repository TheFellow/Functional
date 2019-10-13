﻿using Functional;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionalTests
{
    [TestClass]
    public class OptionExtensionsTests
    {
        private const string _whenNone = "Replacement";
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
    }
}
