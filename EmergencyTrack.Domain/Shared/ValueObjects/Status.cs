using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmergencyTrack.Domain.Shared.ValueObjects
{
    public class Status : Common.ValueObject
    {
        public string Value { get; }

        private Status() { }

        private Status(string value)
        {
            Value = value;
        }

        public static Result<Status> Create(string value)
        {
            if (string.IsNullOrWhiteSpace(value) || value.Length > Constraints.Constraints.MAX_VALUE_LENGTH)
                return Result.Failure<Status>("status is invalid");

            return Result.Success(new Status(value));
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
