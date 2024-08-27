using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmergencyTrack.Domain.Shared.ValueObjects
{
    public class RequestDateTime : Common.ValueObject
    {
        public DateTime Time { get; }

        private RequestDateTime() { }

        private RequestDateTime(DateTime time)
        {
            Time = time;
        }

        public static Result<RequestDateTime> Create(DateTime time)
        {
            if (time > DateTime.Now)
                return Result.Failure<RequestDateTime>("time is invalid");

            return Result.Success(new RequestDateTime(time));
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Time;
        }
    }
}
