using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

namespace SimpleValidationLibrary.Validators
{
    public class CustomValidator : Validator
    {

        ICustomValidationRule custValidationRule;
        protected override Type[] ValidPropertyTypes { get { return null; } }

        public CustomValidator(string errorMessage, PropertyInfo propertyInfo, ICustomValidationRule customValidationRule)
            : base(errorMessage, propertyInfo)
        {
            this.custValidationRule = customValidationRule;
        }

        protected override bool DoIsValid(object instance, object value)
        {
            return this.custValidationRule.DoIsValid(value);
        }

        public static CustomValidator CreateValidator<T>(string errorMessage, string propertyName, ICustomValidationRule customValidationRule)
        {
            return CreateValidator(typeof(T), errorMessage, propertyName, customValidationRule);
        }


        public static CustomValidator CreateValidator(Type type, string errorMessage, string propertyName, ICustomValidationRule customValidationRule)
        {
            return new CustomValidator(errorMessage, Validator.GetPropertyInfo(type, propertyName), customValidationRule);
        }

    }
}
