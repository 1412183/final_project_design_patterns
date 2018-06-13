using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleValidator.Model
{
    public class Address : SimpleValidationLibrary.Primary.ValidatableBase
    {
        [SimpleValidationLibrary.Attributes.RequiredValidator()]
        public string province { get; set; }

        [SimpleValidationLibrary.Attributes.RequiredValidator()]
        public string city { get; set; }

        [SimpleValidationLibrary.Attributes.RequiredValidator()]
        public string address { get; set; }
    }
}
