using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmergencyTrack.Domain.Shared.ValueObjects
{
    public class BirthDate : Common.ValueObject
    {
        public DateOnly Date { get; }

        private BirthDate() { }

        private BirthDate(DateOnly date)
        {
            Date = date;
        }

        public static Result<BirthDate> Create(DateOnly date)
        {
            //TODO: проверить 
            if (date > DateOnly.FromDayNumber(1))
                return Result.Failure<BirthDate>("date is invalid");

            return Result.Success(new BirthDate(date));
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Date;
        }
    }
}
