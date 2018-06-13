using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleValidationLibrary.Exception
{
    [Serializable]
    public class InvalidValidatorException : InvalidOperationException
    {
        private Type propertyType;
        private Type validatorType;

        public InvalidValidatorException(Type validatorType, Type propertyType)
           : base(string.Format("{0} could not be applied to {1}.", validatorType.FullName, propertyType.FullName))
        {
            this.propertyType = propertyType;
            this.validatorType = validatorType;
        }

        public Type PropertyType
        {
            get { return this.propertyType; }
        }

        public Type ValidatorType
        {
            get { return this.validatorType; }
        }
       
    }
}
