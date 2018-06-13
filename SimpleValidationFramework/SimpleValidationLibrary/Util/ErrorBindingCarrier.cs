using SimpleValidationLibrary.Primary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleValidationLibrary.Util
{
    public abstract class ErrorBindingCarrier : IObserver
    {
        protected object _target;
        protected string _propertyName;
        protected ErrorBindingCarrier(object target, string propertyName)
        {
            this._target = target;
            this._propertyName = propertyName;
        }
        public void Update(NotifyIssue subject)
        {
            ValidatableBase instance = (ValidatableBase)subject;
            string errorMessage = "";
            if (instance.ValidationErrors.ContainsKey(this._propertyName))
            {
                errorMessage = instance.ValidationErrors[this._propertyName];
            }
            this.SetTargetValue(errorMessage);
        }

        abstract protected void SetTargetValue(string errorMessage);
    }
}
