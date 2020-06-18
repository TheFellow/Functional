using Functional.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FunctionalTests.Results
{

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

        private void SetCallbackInvoked() => SetCallbackInvoked(string.Empty);

        [TestMethod]
        public void OkResult_OnOk_CallsAction()
        {
            var result = Result.Ok();

            result.OnOk(SetCallbackInvoked);

            Assert.IsTrue(_callbackInvoked);
        }

        [TestMethod]
        public void OkResult_OnFail_DoesNotCallAction()
        {
            var result = Result.Ok();

            result.OnFail(SetCallbackInvoked);

            Assert.IsFalse(_callbackInvoked);
        }

        [TestMethod]
        public void FailResult_OnOk_DoesNotCallAction()
        {
            var result = Result.Fail(_failureMessage);

            result.OnOk(SetCallbackInvoked);

            Assert.IsFalse(_callbackInvoked);
        }

        [TestMethod]
        public void FailResult_OnFail_CallsAction()
        {
            var result = Result.Fail(_failureMessage);

            result.OnFail(SetCallbackInvoked);

            Assert.IsTrue(_callbackInvoked);
        }

        [TestMethod]
        public void FailResult_OnFail_PassesMessageToAction()
        {
            var result = Result.Fail(_failureMessage);

            result.OnFail(SetCallbackInvoked);

            Assert.AreEqual(_failureMessage, _message);
        }
    }
}
