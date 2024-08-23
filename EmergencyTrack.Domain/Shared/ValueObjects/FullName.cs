using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EmergencyTrack.Domain.Shared.ValueObjects
{
    public class FullName : Common.ValueObject
    {

        private static readonly Regex ValidationRegex = new Regex(
            @"^[\p{L}\p{M}\p{N}]{1,50}\z",
            RegexOptions.Singleline | RegexOptions.Compiled);

        public string FirstName { get; }
        public string SecondName { get; }
        public string? Patronymic { get; }

        private FullName() { }
        private FullName(string firstName, string secondName, string? patronymic)
        {
            FirstName = firstName;
            SecondName = secondName;
            Patronymic = patronymic;
        }


        public static Result<FullName> Create(string firstName, string secondName, string? patronymic)
        {
            if (string.IsNullOrWhiteSpace(firstName) || !ValidationRegex.IsMatch(firstName))
                return Result.Failure<FullName>("first name is invalid");

            if (string.IsNullOrWhiteSpace(secondName) || !ValidationRegex.IsMatch(secondName))
                return Result.Failure<FullName>("second name is invalid");

            return new FullName(firstName, secondName, patronymic);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return FirstName;
            yield return SecondName;
            yield return Patronymic;
        }

        public override string ToString()
        {
            return $"{SecondName} {FirstName} {Patronymic}";
        }
    }
}
