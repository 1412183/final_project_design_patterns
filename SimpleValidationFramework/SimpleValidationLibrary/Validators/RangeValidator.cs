using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SimpleValidationLibrary.Validators
{
   public class RangeValidator : Validator
    {
        private object maxValue;
        private object minValue;
        public RangeValidator(PropertyInfo propertyInfo, object minValue, object maxValue) : this(null, propertyInfo, minValue, maxValue) { }

        public RangeValidator(string errorMessage, PropertyInfo propertyInfo, object minValue, object maxValue) : base(errorMessage, propertyInfo)
        {
            this.minValue = minValue;
            this.maxValue = maxValue;
            if (string.IsNullOrEmpty(errorMessage))
                this.ErrorMessage = string.Format(Resources.DefaultErrorMessages.Range, propertyInfo.Name, this.minValue, this.maxValue);

        }

        public object MinValue
        {
            get { return this.minValue; }
        }

        public object MaxValue
        {
            get { return this.maxValue; }
        }

        protected override Type[] ValidPropertyTypes
        {
            get { return new Type[] { typeof(IComparable) }; }
        }
        protected override bool DoIsValid(object instance, object value)
        {
            if (value == null) return this.minValue == null;

            object minValue = Convert.ChangeType(this.minValue, value.GetType());
            object maxValue = Convert.ChangeType(this.maxValue, value.GetType());

            IComparable val = value as IComparable;
            return val.CompareTo(minValue) >= 0 && val.CompareTo(maxValue) <= 0;
        }

        public static RangeValidator CreateValidator<T>(string propertyName, object minValue, object maxValue)
        {
            return CreateValidator(typeof(T), propertyName, minValue, maxValue);
        }

        public static RangeValidator CreateValidator(Type type, string propertyName, object minValue, object maxValue)
        {
            return new RangeValidator(Validator.GetPropertyInfo(type, propertyName), minValue, maxValue);
        }

        public static RangeValidator CreateValidator<T>(string errorMessage, string propertyName, object minValue, object maxValue)
        {
            return CreateValidator(typeof(T), errorMessage, propertyName, minValue, maxValue);
        }

        public static RangeValidator CreateValidator(Type type, string errorMessage, string propertyName, object minValue, object maxValue)
        {
            return new RangeValidator(errorMessage, Validator.GetPropertyInfo(type, propertyName), minValue, maxValue);
        }
    }
}
