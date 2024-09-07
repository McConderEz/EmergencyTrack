using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmergencyTrack.Domain.Shared.ValueObjects
{
    public class Address : Common.ValueObject
    {
        public string Street { get; }
        public string ZipCode { get; }

        private Address() { }
        private Address(string street, string zipCode)
        {
            Street = street;
            ZipCode = zipCode;
        }


        public static Result<Address> Create(string street, string zipCode)
        {
            if (string.IsNullOrWhiteSpace(street) || street.Length > Constraints.Constraints.MAX_VALUE_LENGTH)
                return Result.Failure<Address>("street is invalid");

            if (string.IsNullOrWhiteSpace(zipCode) || zipCode.Length > Constraints.Constraints.MAX_VALUE_LENGTH)
                return Result.Failure<Address>("zip code is invalid");

            return new Address(street, zipCode);
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Street;
            yield return ZipCode;
        }
    }

}
