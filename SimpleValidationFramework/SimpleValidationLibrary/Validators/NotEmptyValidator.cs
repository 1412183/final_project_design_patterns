using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace SimpleValidationLibrary.Validators
{
  
    public class NotEmptyValidator : Validator
    {
        protected override Type[] ValidPropertyTypes
        {
            get { return new Type[] { typeof(IEnumerable) }; }
        }

        public NotEmptyValidator(PropertyInfo propertyInfo) : this(null, propertyInfo) {}

        public NotEmptyValidator(string errorMessage, PropertyInfo propertyInfo) : base(errorMessage, propertyInfo)
        {
            if (string.IsNullOrEmpty(errorMessage))
                this.ErrorMessage = string.Format(Resources.DefaultErrorMessages.NotEmpty, propertyInfo.Name);
        }
   
        protected override bool DoIsValid(object instance, object value)
        {
            if(value == null) return false;

            IEnumerable ienum = value as IEnumerable;

            if (ienum != null) return ienum.GetEnumerator().MoveNext();

            return false;
        }

        public static NotEmptyValidator CreateValidator<T>(string propertyName)
        {
            return CreateValidator(typeof(T), propertyName);
        }

        public static NotEmptyValidator CreateValidator(Type type, string propertyName)
        {
            return new NotEmptyValidator(Validator.GetPropertyInfo(type, propertyName));
        }

        public static NotEmptyValidator CreateValidator<T>(string errorMessage, string propertyName)
        {
            return CreateValidator(typeof(T), errorMessage, propertyName);
        }

        public static NotEmptyValidator CreateValidator(Type type, string errorMessage, string propertyName)
        {
            return new NotEmptyValidator(errorMessage, Validator.GetPropertyInfo(type, propertyName));
        }
    }
}
