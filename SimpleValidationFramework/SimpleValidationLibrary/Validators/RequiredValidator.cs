using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SimpleValidationLibrary.Validators
{
    public class RequiredValidator : Validator
    {
        public RequiredValidator(PropertyInfo propertyInfo) : this(null, propertyInfo)
        {
        }

        public RequiredValidator(string errorMessage, PropertyInfo propertyInfo) : base(errorMessage, propertyInfo)
        {
            if (string.IsNullOrEmpty(errorMessage))
                this.ErrorMessage = string.Format(Resources.DefaultErrorMessages.Required, propertyInfo.Name);
        }
        protected override Type[] ValidPropertyTypes
        {
            get { return null; }
        }

        protected override bool DoIsValid(object instance, object value)
        {
            return value != null;
        }

        public static RequiredValidator CreateValidator<T>(string propertyName)
        {
            return CreateValidator(typeof(T), propertyName);
        }

        public static RequiredValidator CreateValidator(Type type, string propertyName)
        {
            return new RequiredValidator(Validator.GetPropertyInfo(type, propertyName));
        }

        public static RequiredValidator CreateValidator<T>(string errorMessage, string propertyName)
        {
            return CreateValidator(typeof(T), errorMessage, propertyName);
        }

        public static RequiredValidator CreateValidator(Type type, string errorMessage, string propertyName)
        {
            return new RequiredValidator(errorMessage, Validator.GetPropertyInfo(type, propertyName));
        }
    }
}
