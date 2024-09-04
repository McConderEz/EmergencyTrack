using CSharpFunctionalExtensions;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EmergencyTrack.Application.Validators
{
    public static class CustomValidator
    {
        public static IRuleBuilderOptionsConditions<T,TElement> MustBeValueObject<T,TElement,TValueObject>(
            this IRuleBuilder<T,TElement> ruleBuilder,
            Func<TElement, Result<TValueObject>> factoryMethod)
        {
            return ruleBuilder.Custom((value, context) =>
            {
                Result<TValueObject> result = factoryMethod(value);

                if (result.IsSuccess)
                    return;

                context.AddFailure(result.Error);
            });
        }

        public static IRuleBuilderOptions<T, TProperty> WithError<T, TProperty>(
        this IRuleBuilderOptions<T, TProperty> rule, Result error)
        {
            return rule.WithMessage(error.Error);
        }

    }
}
