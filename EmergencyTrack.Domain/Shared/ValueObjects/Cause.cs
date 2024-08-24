using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmergencyTrack.Domain.Shared.ValueObjects
{
    public class Cause : Common.ValueObject
    {
        public string Value { get; }

        private Cause() { }

        private Cause(string value)
        {
            Value = value;
        }

        public static Result<Cause> Create(string value)
        {
            if (string.IsNullOrWhiteSpace(value) || value.Length > Constraints.Constraints.MAX_VALUE_LENGTH)
                return Result.Failure<Cause>("cause is invalid");

            return new Cause(value);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
