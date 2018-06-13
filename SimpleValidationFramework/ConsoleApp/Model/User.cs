using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Model
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
        //contain letters a-zA-Z and at least one digit 0-9
       [SimpleValidationLibrary.Attributes.RegexValidator(@"\\D")]
        public string password { get; set; }

        //[SimpleValidationLibrary.Attributes.CompareValidator(SimpleValidationLibrary.Util.ComparableOperator.Equal,]
        //public string confirmpass { get; set; }

        [SimpleValidationLibrary.Attributes.RangeValidator(16, 32)]
        public int age { get; set; }

        [SimpleValidationLibrary.Attributes.NestedValidator]
        public Address Address { get; set; }

        public User() { this.Address = new Address(); }


    }
}
