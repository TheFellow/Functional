using Functional.Either;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FunctionalTests.Either
{
    [TestClass]
    public class EitherTests
    {
        [TestMethod]
        public void ImplicitCastToLeft()
        {
            Either<int, string> either = 4;

            if (either is Left<int, string> left)
            {
                Assert.AreEqual(4, left);
            }
            else
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void ImplicitCastToRight()
        {
            Either<int, string> either = "Hello";

            if (either is Right<int, string> right)
            {
                Assert.AreEqual("Hello", right);
            }
            else
            {
                Assert.Fail();
            }
        }
    }
}
