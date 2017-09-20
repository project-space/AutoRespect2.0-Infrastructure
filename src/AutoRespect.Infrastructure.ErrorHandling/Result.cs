using System;
using System.Collections.Generic;
using System.Linq;

namespace AutoRespect.Infrastructure.ErrorHandling
{
    public class Result<T>
    {
        public List<Error> Failures { get; private set; } = new List<Error>();
        public T Value { get; private set; }
        public bool IsSuccess { get; private set; }
        public bool IsFailure => !IsSuccess;

        private Result() { }

        private Result(List<Error> errors)
        {
            IsSuccess = false;
            Failures = errors;
        }

        private Result(Error error)
        {
            IsSuccess = false;
            Failures.Add(error);
        }

        private Result(T value)
        {
            IsSuccess = true;
            Value = value;
        }

        public static implicit operator Result<T>(List<Error> errors) => new Result<T>(errors);
        public static implicit operator Result<T>(Error error) => new Result<T>(error);
        public static implicit operator Result<T>(T value) => new Result<T>(value);
    }
}
