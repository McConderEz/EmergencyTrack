using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EmergencyTrack.Domain.Shared.ValueObjects
{
    public class StationNumber : Common.ValueObject
    {
        public static readonly Regex ValidationRegex = new Regex(
            @"^[\dA-Z]{10}$",
            RegexOptions.Singleline | RegexOptions.Compiled);

        public string Number { get; }

        private StationNumber() { }
        private StationNumber(string number)
        {
            Number = number;
        }

        public static Result<StationNumber> Create(string number)
        {
            if (string.IsNullOrWhiteSpace(number) || !ValidationRegex.IsMatch(number))
                return Result.Failure<StationNumber>("number is in incorrect format");

            var stationNumber = new StationNumber(number);

            return stationNumber;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Number;
        }
    }
}
