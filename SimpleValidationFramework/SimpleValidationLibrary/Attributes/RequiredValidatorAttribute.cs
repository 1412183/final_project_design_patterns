using SimpleValidationLibrary.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SimpleValidationLibrary.Attributes
{
    public class RequiredValidatorAttribute : ValidatorAttribute
    {
        public override Validator GetValidator(PropertyInfo propertyInfo)
        {
            return new RequiredValidator(this.ErrorMessage, propertyInfo);
        }
    }
}
