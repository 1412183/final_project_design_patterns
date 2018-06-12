using SimpleValidationLibrary.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SimpleValidationLibrary.Attributes
{
    public abstract class ValidatorAttribute : Attribute
    {

        private string errorMessage;
        private uint priority;

        public ValidatorAttribute()
        {
            this.errorMessage = null;
            this.priority = 0;
        }

        public string ErrorMessage
        {
            get { return this.errorMessage; }
            set { this.errorMessage = value; }
        }

        public uint Priority
        {
            get { return this.priority; }
            set { this.priority = value; }
        }
        public abstract Validator GetValidator(PropertyInfo propertyInfo);
    }
}
