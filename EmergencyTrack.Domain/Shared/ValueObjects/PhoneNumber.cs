using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EmergencyTrack.Domain.Shared.ValueObjects
{
    public class PhoneNumber : Common.ValueObject
    {
        public static readonly Regex ValidationRegex = new Regex(
            @"(^\+\d{1,3}\d{10}$|^$)",
            RegexOptions.Singleline | RegexOptions.Compiled);

        public string Number { get; }

        private PhoneNumber() { }
        private PhoneNumber(string number)
        {
            Number = number;
        }

        public static Result<PhoneNumber> Create(string number)
        {
            if (string.IsNullOrWhiteSpace(number) || !ValidationRegex.IsMatch(number))
                return Result.Failure<PhoneNumber>("number is in incorrect format");

            var phoneNumber = new PhoneNumber(number);

            return phoneNumber;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Number;
        }
    }
}
