using System.Collections.Generic;

namespace AutoRespect.Infrastructure.Errors.Design
{
    public class R<T>
    {
        public List<E> Failures { get; private set; } = new List<E>();
        public T Value { get; private set; }
        public bool IsSuccess { get; private set; }
        public bool IsFailure => !IsSuccess;

        private R() { }

        private R(List<E> errors)
        {
            IsSuccess = false;
            Failures = errors;
        }

        private R(E error)
        {
            IsSuccess = false;
            Failures.Add(error);
        }

        private R(T value)
        {
            IsSuccess = true;
            Value = value;
        }

        public static implicit operator R<T>(List<E> errors) => new R<T>(errors);
        public static implicit operator R<T>(E error) => new R<T>(error);
        public static implicit operator R<T>(T value) => new R<T>(value);
    }
}
