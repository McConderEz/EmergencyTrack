using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmergencyTrack.Domain.Shared.ValueObjects
{
    public class Price : Common.ValueObject
    {
        public decimal Value { get; }

        private Price() { }

        private Price(decimal value)
        {
            Value = value;
        }

        public static Result<Price> Create(decimal value)
        {
            if (value < 0)
                return Result.Failure<Price>("price is invalid");

            return Result.Success(new Price(value));
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
