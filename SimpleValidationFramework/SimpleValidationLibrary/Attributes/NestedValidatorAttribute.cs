using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using SimpleValidationLibrary.Validators;


namespace SimpleValidationLibrary.Attributes
{
    class NestedValidatorAttribute : ValidatorAttribute
    {
        public override Validator GetValidator(PropertyInfo propertyInfo)
        {
            return new NestedValidator(this.ErrorMessage, propertyInfo);
        }
    }
}
