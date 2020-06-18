using Functional.Results;

namespace Demo.ResultDemos
{
    public class ResultDemo
    {
        public Result Demo()
        {
            return Result.Fail("An error has occurred");
        }

        public Result<int> Demo2()
        {
            return Result<int>.Fail("error");
        }
    }
}
