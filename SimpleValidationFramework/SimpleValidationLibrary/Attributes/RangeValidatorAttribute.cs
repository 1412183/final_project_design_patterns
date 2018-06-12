using SimpleValidationLibrary.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SimpleValidationLibrary.Attributes
{
    public class RangeValidatorAttribute : ValidatorAttribute
    {
        private object maxValue;
        private object minValue;

        public RangeValidatorAttribute(object minValue, object maxValue)
        {
            this.maxValue = maxValue;
            this.minValue = minValue;
        }
        public object MaxValue
        {
            get { return this.maxValue; }
        }

        public object MinValue
        {
            get { return this.minValue; }
        }
        
        public override Validator GetValidator(PropertyInfo propertyInfo)
        {
            return new RangeValidator(this.ErrorMessage, propertyInfo, this.minValue, this.maxValue);
        }
    }
}
