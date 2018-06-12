using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using SimpleValidationLibrary.Primary;

namespace SimpleValidationLibrary.Validators
{
    public class NestedValidator : Validator
    {
        protected override Type[] ValidPropertyTypes
        {
            get { return new Type[] { typeof(ValidatableBase) }; }
        }

        public NestedValidator(PropertyInfo propertyInfo) : this(null, propertyInfo) { }

        public NestedValidator(string errorMessage, PropertyInfo propertyInfo) : base(errorMessage, propertyInfo)
        {
            if (string.IsNullOrEmpty(errorMessage))
                this.ErrorMessage = string.Format(Resources.DefaultErrorMessages.NotEmpty, propertyInfo.Name);
        }

        protected override bool DoIsValid(object instance, object value)
        {
            if (value == null) return false;

            ValidatableBase validatable = (ValidatableBase)value;

            return validatable.IsValid;
        }

        public static NestedValidator CreateValidator<T>(string propertyName)
        {
            return CreateValidator(typeof(T), propertyName);
        }

        public static NestedValidator CreateValidator(Type type, string propertyName)
        {
            return new NestedValidator(Validator.GetPropertyInfo(type, propertyName));
        }

        public static NestedValidator CreateValidator<T>(string errorMessage, string propertyName)
        {
            return CreateValidator(typeof(T), errorMessage, propertyName);
        }

        public static NestedValidator CreateValidator(Type type, string errorMessage, string propertyName)
        {
            return new NestedValidator(errorMessage, Validator.GetPropertyInfo(type, propertyName));
        }
    }
}
