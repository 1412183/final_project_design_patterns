using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleValidation.Interfaces
{
    public interface ICustomValidationRule
    {
        bool DoIsValid(object value);
    }
}
