using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmergencyTrack.Domain.Shared.ValueObjects
{
    public class Title : Common.ValueObject
    {
        public string Value { get; }

        private Title() { }

        private Title(string value)
        {
            Value = value;
        }

        public static Result<Title> Create(string value)
        {
            if (string.IsNullOrWhiteSpace(value) || value.Length > Constraints.Constraints.MAX_VALUE_LENGTH)
                return Result.Failure<Title>("title is invalid");

            return new Title(value);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
