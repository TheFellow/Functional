using Functional.Option;
using System;

namespace Functional.Results
{
    public sealed class Result<T>
    {
        private readonly Option<T> _value;
        private readonly string _message;

        internal Result(T value, string message, bool success)
        {
            _value = success ? (Option<T>)new Some<T>(value) : None.Value;
            _message = message;
        }

        public void OnOk(Action onOk)
        {
            if (_value is Some<T>)
                onOk();
        }
        
        public void OnOk(Action<T> onOk)
        {
            if (_value is Some<T> some)
                onOk(some.Content);
        }

        public void OnFail(Action onFail)
        {
            if (_value is None<T>)
                onFail();
        }

        public void OnFail(Action<string> onFail)
        {
            if (_value is None<T>)
                onFail(_message);
        }
    }

    public static class Result
    {
        public static Result<string> Ok() => new Result<string>("Ok", string.Empty, true);
        public static Result<T> Ok<T>(T value) => new Result<T>(value, string.Empty, true);
        public static Result<string> Fail() => new Result<string>(string.Empty, string.Empty, false);
        public static Result<T> Fail<T>(string message) => new Result<T>(default!, message, false);
    }
}
