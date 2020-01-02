using Functional;
using Functional.Either;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FunctionalTests.Either
{
    [TestClass]
    public class EitherObjectExtensionsTests
    {
        private const string hello = "Hello World";

        private int getLength(string str) => str.Length;

        [TestMethod]
        public void When_PredicateIsTrue_ReturnsRight()
        {
            var either = hello.When(true, 4);
            
            if(either is Right<int, string> right)
            {
                Assert.AreEqual(hello, right.Content);
            }
            else
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void When_PredicateIsFalse_ReturnsLeft()
        {
            var either = hello.When(false, 4);

            if(either is Left<int, string> left)
            {
                Assert.AreEqual(4, left.Content);
            }
            else
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void When_PredicateFuncIsTrue_ReturnsRight()
        {
            var either = hello.When(() => true, 4);

            if(either is Right<int, string> right)
            {
                Assert.AreEqual(hello, right.Content);
            }
            else
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void When_PredicateFuncIsFalse_ReturnsLeft()
        {
            var either = hello.When(() => false, 4);

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
        public void When_PredicateFuncOfTIsTrue_ReturnsRight()
        {
            string calledWith = string.Empty;
            var either = hello.When(s => { calledWith = s; return true; }, 4);

            if (either is Right<int, string> right)
            {
                Assert.AreEqual(hello, right.Content);
                Assert.AreEqual(hello, calledWith);
            }
            else
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void When_PredicateFuncOfTIsFalse_ReturnsLeft()
        {
            string calledWith = string.Empty;
            var either = hello.When(s => { calledWith = s; return false; }, 4);

            if (either is Left<int, string> left)
            {
                Assert.AreEqual(4, left.Content);
                Assert.AreEqual(hello, calledWith);
            }
            else
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void When_PredicateIsTrue_ReturnsLazyRight()
        {
            var either = hello.When(true, () => 4);

            if (either is Right<int, string> right)
            {
                Assert.AreEqual(hello, right.Content);
            }
            else
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void When_PredicateIsFalse_ReturnsLazyLeft()
        {
            var either = hello.When(false, () => 4);

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
        public void When_PredicateFuncIsTrue_ReturnsLazyRight()
        {
            var either = hello.When(() => true, () => 4);

            if (either is Right<int, string> right)
            {
                Assert.AreEqual(hello, right.Content);
            }
            else
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void When_PredicateFuncIsFalse_ReturnsLazyLeft()
        {
            var either = hello.When(() => false, () => 4);

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
        public void When_PredicateFuncOfTIsTrue_ReturnsLazyRight()
        {
            string calledWith = string.Empty;
            var either = hello.When(s => { calledWith = s; return true; }, () => 4);

            if (either is Right<int, string> right)
            {
                Assert.AreEqual(hello, right.Content);
                Assert.AreEqual(hello, calledWith);
            }
            else
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void When_PredicateFuncOfTIsFalse_ReturnsLazyLeft()
        {
            string calledWith = string.Empty;
            var either = hello.When(s => { calledWith = s; return false; }, () => 4);

            if (either is Left<int, string> left)
            {
                Assert.AreEqual(4, left.Content);
                Assert.AreEqual(hello, calledWith);
            }
            else
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void When_PredicateIsTrue_ReturnsLazyRightOfT()
        {
            var either = hello.When(true, getLength);

            if (either is Right<int, string> right)
            {
                Assert.AreEqual(hello, right.Content);
            }
            else
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void When_PredicateIsFalse_ReturnsLazyLeftOfT()
        {
            var either = hello.When(false, getLength);

            if (either is Left<int, string> left)
            {
                Assert.AreEqual(11, left.Content);
            }
            else
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void When_PredicateFuncIsTrue_ReturnsLazyRightOfT()
        {
            var either = hello.When(() => true, getLength);

            if (either is Right<int, string> right)
            {
                Assert.AreEqual(hello, right.Content);
            }
            else
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void When_PredicateFuncIsFalse_ReturnsLazyLeftOfT()
        {
            var either = hello.When(() => false, getLength);

            if (either is Left<int, string> left)
            {
                Assert.AreEqual(11, left.Content);
            }
            else
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void When_PredicateFuncOfTIsTrue_ReturnsLazyRightOfT()
        {
            string calledWith = string.Empty;
            var either = hello.When(s => { calledWith = s; return true; }, getLength);

            if (either is Right<int, string> right)
            {
                Assert.AreEqual(hello, right.Content);
                Assert.AreEqual(hello, calledWith);
            }
            else
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void When_PredicateFuncOfTIsFalse_ReturnsLazyLeftOfT()
        {
            string calledWith = string.Empty;
            var either = hello.When(s => { calledWith = s; return false; }, getLength);

            if (either is Left<int, string> left)
            {
                Assert.AreEqual(11, left.Content);
                Assert.AreEqual(hello, calledWith);
            }
            else
            {
                Assert.Fail();
            }
        }
    }
}
