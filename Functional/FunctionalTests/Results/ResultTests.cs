using Microsoft.VisualStudio.TestTools.UnitTesting;
using Functional.Results;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using System;

namespace FunctionalTests.Results
{
    class MyClass { }

    [TestClass]
    public class ResultTests
    {
        private const string _failureMessage = "Test";

        private bool _callbackInvoked = false;
        private string _message = string.Empty;

        [TestInitialize]
        public void TestInitialize()
        {
            _callbackInvoked = false;
            _message = string.Empty;
        }

        private void SetCallbackInvoked(string message)
        {
            _callbackInvoked = true;
            _message = message;
        }

        [TestMethod]
        public void OnOk_WithOkResult_CallsAction()
        {
            var result = Result.Ok();

            result.OnOk(SetCallbackInvoked);

            Assert.IsTrue(_callbackInvoked);
        }

        [TestMethod]
        public void OnOk_WithOkResult_PassesOriginalObjectToAction()
        {
            var myInstance = new MyClass();
            MyClass? returnedInstance = null;
            var result = Result.Ok(myInstance);

            result.OnOk(mc => returnedInstance = mc);

            Assert.IsNotNull(returnedInstance);
            Assert.AreEqual(myInstance, returnedInstance);
        }

        [TestMethod]
        public void OnOk_WithFailResult_DoesNotCallAction()
        {
            var result = Result.Fail();

            result.OnOk(SetCallbackInvoked);

            Assert.IsFalse(_callbackInvoked);
        }

        [TestMethod]
        public void OnOk_WithFailResultAndMessage_DoesNotCallAction()
        {
            var result = Result.Fail<MyClass>(_failureMessage);
            MyClass? myInstance = null;

            result.OnOk(mc => myInstance = mc);

            Assert.IsFalse(_callbackInvoked);
            Assert.IsNull(myInstance);
        }

        [TestMethod]
        public void OnFail_WithOkResult_DoesNotCallAction()
        {
            var result = Result.Ok();

            result.OnFail(SetCallbackInvoked);

            Assert.IsFalse(_callbackInvoked);
        }

        [TestMethod]
        public void OnFail_WithOkResultAndPayload_DoesNotCallAction()
        {
            var result = Result.Ok(new MyClass());

            result.OnFail(_ => throw new ArgumentException());

            Assert.IsFalse(_callbackInvoked);
        }

        [TestMethod]
        public void OnFail_WithFailResult_CallsAction()
        {
            var result = Result.Fail();

            result.OnFail(SetCallbackInvoked);

            Assert.IsTrue(_callbackInvoked);
        }

        [TestMethod]
        public void OnFail_WithFailResult_CallsActionWithMessage()
        {
            var result = Result.Fail<MyClass>(_failureMessage);

            result.OnFail(msg => SetCallbackInvoked(msg));

            Assert.IsTrue(_callbackInvoked);
            Assert.AreEqual(_failureMessage, _message);
        }
    }
}
