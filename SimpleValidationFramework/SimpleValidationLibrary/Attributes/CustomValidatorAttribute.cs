using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using SimpleValidationLibrary.Validators;

namespace SimpleValidationLibrary.Attributes
{
    public class CustomValidatorAttribute : ValidatorAttribute
    {

        private ICustomValidationRule customBr;

        public ICustomValidationRule CustomBridge
        {
            get { return this.customBr; }
            set { this.customBr = value; }
        }

        public CustomValidatorAttribute(string errorMessage, ICustomValidationRule customBridge)
        {
            this.ErrorMessage = errorMessage;
            this.customBr = customBridge;
        }

        public override Validator GetValidator(PropertyInfo propertyInfo)
        {
            return new CustomValidator(this.ErrorMessage, propertyInfo, customBr);
        }
    }
}
