using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SimpleValidationLibrary.Validators
{
    public class RegexValidator : Validator
    {
        private string regex;

        public string Regex
        {
            get { return this.regex; }
        }

        protected override Type[] ValidPropertyTypes
        {
            get { return new Type[] { typeof(string) }; }
        }

        public RegexValidator(PropertyInfo propertyInfo, string regex) : this(null, propertyInfo, regex) { }

        public RegexValidator(string errorMessage, PropertyInfo propertyInfo, string regex) : base(errorMessage, propertyInfo)
        {
            this.regex = regex;
            if (string.IsNullOrEmpty(errorMessage))
                this.ErrorMessage = string.Format(Resources.DefaultErrorMessages.Regex, propertyInfo.Name, this.regex);
        }

        protected override bool DoIsValid(object instance, object value)
        {
            string s = value as string;
            return System.Text.RegularExpressions.Regex.IsMatch(s ?? "", this.regex);
        }

        public static RegexValidator CreateValidator<T>(string propertyName, string regex)
        {
            return CreateValidator(typeof(T), propertyName, regex);
        }

        public static RegexValidator CreateValidator(Type type, string propertyName, string regex)
        {
            return new RegexValidator(Validator.GetPropertyInfo(type, propertyName), regex);
        }

        public static RegexValidator CreateValidator<T>(string errorMessage, string propertyName, string regex)
        {
            return CreateValidator(typeof(T), errorMessage, propertyName, regex);
        }

        public static RegexValidator CreateValidator(Type type, string errorMessage, string propertyName, string regex)
        {
            return new RegexValidator(errorMessage, Validator.GetPropertyInfo(type, propertyName), regex);
        }
    }
}
