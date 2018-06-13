using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleValidator.Model
{
    public class User : SimpleValidationLibrary.Primary.ValidatableBase
    {
        [SimpleValidationLibrary.Attributes.RequiredValidator()]
        [SimpleValidationLibrary.Attributes.LengthValidator(5, 10)]
        public string firstname { get; set; }

        [SimpleValidationLibrary.Attributes.RequiredValidator()]
        [SimpleValidationLibrary.Attributes.LengthValidator(5, 30)]
        public string lastname { get; set; }

        [SimpleValidationLibrary.Attributes.RequiredValidator()]
        [SimpleValidationLibrary.Attributes.RegexValidator(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$")]
        public string email { get; set; }

        [SimpleValidationLibrary.Attributes.RequiredValidator()]
        // length is at least 6, contains at least one digit and contains at least one lower case or upper case alphabet
        //[SimpleValidationLibrary.Attributes.RegexValidator(@"?=^.{6,}$)(?=.*\d)(?=.*[a - zA - Z]")]
        public string password { get; set; }

        //[SimpleValidationLibrary.Attributes.CompareValidator(SimpleValidationLibrary.Util.ComparableOperator.Equal,]
        //public string confirmpass { get; set; }

        [SimpleValidationLibrary.Attributes.RangeValidator(16, 32)]
        public int age { get; set; }

        [SimpleValidationLibrary.Attributes.NestedValidator]
        public Address Address { get; set; }


    }
}
