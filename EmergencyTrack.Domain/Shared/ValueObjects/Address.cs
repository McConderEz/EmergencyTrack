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
        public string City { get; }
        public string State { get; }
        public string ZipCode { get; }

        private Address() { }
        private Address(string street, string city, string state, string zipCode)
        {
            Street = street;
            City = city;
            State = state;
            ZipCode = zipCode;
        }


        public static Result<Address> Create(string street, string city, string state, string zipCode)
        {
            if (string.IsNullOrWhiteSpace(street) || street.Length > Constraints.Constraints.MAX_VALUE_LENGTH)
                return Result.Failure<Address>("street is invalid");

            if (string.IsNullOrWhiteSpace(city) || city.Length > Constraints.Constraints.MAX_VALUE_LENGTH)
                return Result.Failure<Address>("city is invalid");

            if (string.IsNullOrWhiteSpace(state) || state.Length > Constraints.Constraints.MAX_VALUE_LENGTH)
                return Result.Failure<Address>("state is invalid");

            if (string.IsNullOrWhiteSpace(zipCode) || zipCode.Length > Constraints.Constraints.MAX_VALUE_LENGTH)
                return Result.Failure<Address>("zip code is invalid");

            return new Address(street, city, state, zipCode);
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Street;
            yield return City;
            yield return State;
            yield return ZipCode;
        }
    }

}
