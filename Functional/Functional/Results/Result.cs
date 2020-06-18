using Functional.Option;
using System;

namespace Functional.Results
{
    /// <summary>
    /// Represents the success or failure status of a command
    /// </summary>
    public sealed class Result
    {
        private readonly bool _success;
        private readonly string _message = string.Empty;

        private Result() => _success = true;
        private Result(string message)
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
    public sealed class Result<T>
    {
        private readonly Option<T> _content;
        private readonly string _message = string.Empty;

        private Result(T value) => _content = value;
        private Result(string message)
        {
            _content = None.Value;
            _message = message;
        }

        public void OnOk(Action<T> onOk)
        {
            if (_content is Some<T> some)
                onOk(some.Content);
        }

        public void OnFail(Action<string> onFail)
        {
            if (_content == None.Value)
                onFail(_message);
        }

        public static Result<T> Ok(T value) => new Result<T>(value);
        public static Result<T> Fail(string message) => new Result<T>(message);
    }
}
