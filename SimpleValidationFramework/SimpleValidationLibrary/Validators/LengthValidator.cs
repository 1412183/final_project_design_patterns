using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace SimpleValidationLibrary.Validators
{
 
    public class LengthValidator : Validator
    {

        private uint maxLength;
        private uint minLength;

        public uint MaxLength
        {
            get { return this.maxLength; }
        }

  
        public uint MinLength
        {
            get { return this.minLength; }
        }
           
        protected override Type[] ValidPropertyTypes
        {
            get { return new Type[] { typeof(ICollection), typeof(string) }; }
        }

        public LengthValidator(PropertyInfo propertyInfo, uint minLength, uint maxLength)
            : this(null, propertyInfo, minLength, maxLength)
        {
        }

        public LengthValidator(string errorMessage, PropertyInfo propertyInfo, uint minLength, uint maxLength)
            : base(errorMessage, propertyInfo)
        {
            this.minLength = minLength;
            this.maxLength = maxLength;
            if (string.IsNullOrEmpty(errorMessage))
                this.ErrorMessage = string.Format(Resources.DefaultErrorMessages.Length, propertyInfo.Name, this.minLength, this.maxLength);

        }

        protected override bool DoIsValid(object instance, object value)
        {
            if (value == null) return false;

            ICollection col = value as ICollection;

            if (col != null) return IsValidLength((uint)col.Count);

            string s = value as string;

            if (s != null) return IsValidLength((uint)s.Length);

            return false;
        }

        private bool IsValidLength(uint length)
        {
            return this.minLength <= length && length <= this.maxLength;
        }

        public static LengthValidator CreateValidator<T>(string propertyName, uint minLength, uint maxLength)
        {
            return CreateValidator(typeof(T), propertyName, minLength, maxLength);
        }

        public static LengthValidator CreateValidator(Type type, string propertyName, uint minLength, uint maxLength)
        {
            return new LengthValidator(Validator.GetPropertyInfo(type, propertyName), minLength, maxLength);
        }

        public static LengthValidator CreateValidator<T>(string errorMessage, string propertyName, uint minLength, uint maxLength)
        {
            return CreateValidator(typeof(T), errorMessage, propertyName, minLength, maxLength);
        }

        public static LengthValidator CreateValidator(Type type, string errorMessage, string propertyName, uint minLength, uint maxLength)
        {
            return new LengthValidator(errorMessage, Validator.GetPropertyInfo(type, propertyName), minLength, maxLength);
        }

    }
}
