using Functional.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace FunctionalTests.Results
{
    [TestClass]
    public class ResultOfTTests
    {
        private const string _failureMessage = "Test";
        private bool _callbackInvoked = false;
        private string _message = string.Empty;

        private void SetCallbackInvoked(MyClass message)
        {
            _callbackInvoked = true;
            _message = string.Empty;
        }
        private void SetCallbackInvoked(string message)
        {
            _callbackInvoked = true;
            _message = message;
        }

        [TestInitialize]
        public void TestInitialize()
        {
            _callbackInvoked = false;
            _message = string.Empty;
        }

        [TestMethod]
        public void OkResultOfT_OnOk_CallsAction()
        {
            bool called = false;
            var result = Result<MyClass>.Ok(new MyClass());

            result.OnOk(_ => called = true);

            Assert.IsTrue(called);
        }

        [TestMethod]
        public void OkResultOfT_OnOk_PassesOriginalObjectToAction()
        {
            var myInstance = new MyClass();
            MyClass? returnedInstance = null;
            var result = Result<MyClass>.Ok(myInstance);

            result.OnOk(mc => returnedInstance = mc);

            Assert.IsNotNull(returnedInstance);
            Assert.AreEqual(myInstance, returnedInstance);
        }

        [TestMethod]
        public void OkResultOfT_OnFail_DoesNotCallAction()
        {
            var result = Result<MyClass>.Ok(new MyClass());

            result.OnFail(_ => throw new ArgumentException());

            Assert.IsFalse(_callbackInvoked);
        }

        [TestMethod]
        public void FailResultOfT_OnOk_DoesNotCallAction()
        {
            var result = Result<MyClass>.Fail(_failureMessage);

            result.OnOk(SetCallbackInvoked);

            Assert.IsFalse(_callbackInvoked);
        }

        [TestMethod]
        public void FailResultOfT_OnFail_CallsAction()
        {
            var result = Result<MyClass>.Fail(_failureMessage);

            result.OnFail(SetCallbackInvoked);

            Assert.IsTrue(_callbackInvoked);
        }

        [TestMethod]
        public void FailResultOfT_OnFail_PassesMessageToAction()
        {
            var result = Result<string>.Fail(_failureMessage);

            result.OnFail(SetCallbackInvoked);

            Assert.AreEqual(_failureMessage, _message);
        }
    }
}
