using System;
using System.Collections.Generic;
using System.Reflection;

using SimpleValidationLibrary.Validators;

namespace SimpleValidationLibrary.Attributes
{

    public class NotEmptyValidatorAttribute : ValidatorAttribute
    {
        public override Validator GetValidator(PropertyInfo propertyInfo)
        {
            return new NotEmptyValidator(this.ErrorMessage, propertyInfo);
        }

    }
}