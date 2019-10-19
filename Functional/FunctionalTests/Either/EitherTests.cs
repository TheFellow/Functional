using Functional;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                Assert.AreEqual(4, left.Content);
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
                Assert.AreEqual("Hello", right.Content);
            }
            else
            {
                Assert.Fail();
            }
        }
    }
}
