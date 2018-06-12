using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using SimpleValidationLibrary.Util;

namespace SimpleValidationLibrary.Primary
{
    public class ValidatableBase : NotifyIssue
    {
        private ValidationManager validationMg;

        protected ValidatableBase()
        {
            this.validationMg = new ValidationManager(this);
        }
        public bool IsValid
        {
            get
            {
                bool result = this.validationMg.IsValid();
                // Thong bao
                this.Notify();
                return result;
            }
        }

        public Dictionary<string, string> ValidationErrors
        {
            get { return this.validationMg.ValidationErrors; }
        }

    }
}
