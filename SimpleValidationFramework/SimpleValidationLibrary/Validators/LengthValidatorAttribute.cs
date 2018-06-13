using System;
using System.Collections.Generic;
using System.Reflection;

using SimpleValidationLibrary.Validators;

namespace SimpleValidationLibrary.Attributes
{
    public class LengthValidatorAttribute : ValidatorAttribute
    {
        private uint minLength;
        private uint maxLength;

        public uint MinLength
        {
            get { return this.minLength; }
        }
        public uint MaxLength
        {
            get { return this.maxLength; }
        }

        public LengthValidatorAttribute(uint minLength, uint maxLength)
        {
            this.minLength = minLength;
            this.maxLength = maxLength;
        }

        //public LengthValidatorAttribute(uint maxLength) : this(uint.MinValue, maxLength){ }

        public override Validator GetValidator(PropertyInfo propertyInfo)
        {
            return new LengthValidator(this.ErrorMessage, propertyInfo, this.minLength, this.maxLength);
        }
    
    }
}