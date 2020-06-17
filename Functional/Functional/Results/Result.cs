using System;

namespace Functional.Results
{
    /// <summary>
    /// Represents the success or failure status of a command
    /// </summary>
    public class Result
    {
        protected readonly bool _success;
        protected readonly string _message = string.Empty;

        private protected Result() => _success = true;
        private protected Result(string message)
        {
            _message = message;
            _success = false;
        }

        public void OnOk(Action onOk)
        {
            if (_success)
                onOk();
        }

        public void OnFail(Action<string> onFail)
        {
            if (!_success)
                onFail(_message);
        }

        public static Result Ok() => new Result();
        public static Result Fail(string message) => new Result(message);
    }

    /// <summary>
    /// Represents the success or failure status of a query returning type <typeparamref name="T"/>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public sealed class Result<T> : Result
    {
        private readonly T _content;

        private Result(T value) : base() => _content = value;

        public void OnOk(Action<T> onOk)
        {
            if (_success)
                onOk(_content);
        }

        public static Result<T> Ok(T value) => new Result<T>(value);
    }
}
