using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Core
{
    /// <summary>
    /// Implementation of the Result pattern for handling operation outcomes.
    /// </summary>
    public class Result
    {
        internal Result(bool isSuccess, string error)
        {
            if (isSuccess && error != string.Empty)
                throw new InvalidOperationException();
            
            if (!isSuccess && error == string.Empty)
                throw new InvalidOperationException();
            
            IsSuccess = isSuccess;
            Error = error;
        }

        public bool IsSuccess { get; }
        public string Error { get; }

        public static Result Success() => new Result(true, string.Empty);

        public static Result Fail(string message) => new Result(false, message);
    }

    public class Result<T> : Result
    {
        internal Result(T value, bool isSuccess, string error)
            : base(isSuccess, error)
        {
            Value = value;
        }

        public T Value { get; }
        
        public static Result<T> Success(T value) => new Result<T>(value, true, string.Empty);
        
        public new static Result<T> Fail(string message) => new Result<T>(default!, false, message);
    }
}
