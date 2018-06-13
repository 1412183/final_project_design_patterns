using SimpleValidationLibrary.Util;
using SimpleValidationLibrary.Validators;
using System;
using System.Collections.Generic;
using System.Linq;  
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SimpleValidationLibrary.Attributes
{
    public class CompareValidatorAttribute : ValidatorAttribute
    {
        private ComparableOperator comparableOperator;
        private object valueToCompare;

        public CompareValidatorAttribute(ComparableOperator comparableOperator, object valueToCompare)
        {
            this.comparableOperator = comparableOperator;
            this.valueToCompare = valueToCompare;
        }

        public ComparableOperator ComparableOperator
        {
            get { return this.comparableOperator; }
        }


        public object ValueToCompare
        {
            get { return this.valueToCompare; }
        }

        public override Validator GetValidator(PropertyInfo propertyInfo)
        {
            return new CompareValidator(this.ErrorMessage, propertyInfo, this.comparableOperator, this.valueToCompare);
        }
    }
}
