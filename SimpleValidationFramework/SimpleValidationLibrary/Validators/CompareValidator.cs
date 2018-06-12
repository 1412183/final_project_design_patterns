using SimpleValidationLibrary.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SimpleValidationLibrary.Validators
{
    public class CompareValidator : Validator
    {
        private ComparableOperator comparableOperator;
        private object valueToCompare;

        public ComparableOperator ComparableOperator
        {
            get { return this.comparableOperator; }
        }

        public object ValueToCompare
        {
            get { return this.valueToCompare; }
        }

        protected override Type[] ValidPropertyTypes
        {
            get { return new Type[] { typeof(IComparable) }; }
        }

        public CompareValidator(PropertyInfo propertyInfo, ComparableOperator comparisonOperator, object valueToCompare)
            : this(null, propertyInfo, comparisonOperator, valueToCompare)
        {
        }

        public CompareValidator(string errorMessage, PropertyInfo propertyInfo, ComparableOperator comparisonOperator, object valueToCompare)
            : base(errorMessage, propertyInfo)
        {
            this.comparableOperator = comparisonOperator;
            this.valueToCompare = valueToCompare;
            if (string.IsNullOrEmpty(errorMessage))
                this.ErrorMessage = string.Format(Resources.DefaultErrorMessages.Compare, propertyInfo.Name, this.comparableOperator.ToString(), this.valueToCompare);
        }

        protected override bool DoIsValid(object instance, object value)
        {
            IComparable comp = value as IComparable;

            object valueToCompare = Convert.ChangeType(this.valueToCompare, value.GetType());

            return TestCompareResult(comp.CompareTo(valueToCompare));
        }

        private bool TestCompareResult(int result)
        {
            switch (this.comparableOperator)
            {
                case ComparableOperator.Equal:
                    return result == 0;
                case ComparableOperator.NotEqual:
                    return result != 0;
                case ComparableOperator.GreaterThan:
                    return result > 0;
                case ComparableOperator.GreaterThanOrEqual:
                    return result >= 0;
                case ComparableOperator.LessThan:
                    return result < 0;
                case ComparableOperator.LessThanOrEqual:
                    return result <= 0;
            }
            return false;
        }

        public static CompareValidator CreateValidator<T>(string propertyName, ComparableOperator comparisonOperator, object valueToCompare)
        {
            return CreateValidator(typeof(T), propertyName, comparisonOperator, valueToCompare);
        }
        public static CompareValidator CreateValidator(Type type, string propertyName, ComparableOperator comparisonOperator, object valueToCompare)
        {
            return new CompareValidator(Validator.GetPropertyInfo(type, propertyName), comparisonOperator, valueToCompare);
        }

        public static CompareValidator CreateValidator<T>(string errorMessage, string propertyName, ComparableOperator comparisonOperator, object valueToCompare)
        {
            return CreateValidator(typeof(T), errorMessage, propertyName, comparisonOperator, valueToCompare);
        }

        public static CompareValidator CreateValidator(Type type, string errorMessage, string propertyName, ComparableOperator comparisonOperator, object valueToCompare)
        {
            return new CompareValidator(errorMessage, Validator.GetPropertyInfo(type, propertyName), comparisonOperator, valueToCompare);
        }
    }
}
