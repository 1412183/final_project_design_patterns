using SimpleValidationLibrary.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace SimpleValidationLibrary.Attributes
{
    public class RegexValidatorAttribute : ValidatorAttribute
    {
        private string regex;

        public RegexValidatorAttribute(string regex)
        {
            this.regex = regex;
        }

        public string Regex
        {
            get { return this.regex; }
        }

        public override Validator GetValidator(PropertyInfo propertyInfo)
        {
            return new RegexValidator(this.ErrorMessage, propertyInfo, this.regex);
        }
    }
}
