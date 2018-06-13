using SimpleValidationLibrary.Exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SimpleValidationLibrary.Validators
{
    public abstract class Validator
    {
        private string errorMessage;
        private PropertyInfo propertyInfo;

        protected Validator(string errorMessage, PropertyInfo propertyInfo)
        {
            if (string.IsNullOrEmpty(errorMessage))
                this.errorMessage = string.Format(Resources.DefaultErrorMessages.Default, propertyInfo.Name);
            else
                this.errorMessage = errorMessage;

            this.propertyInfo = propertyInfo;

            ThrowIfInvalidPropertyType();
        }
        public string ErrorMessage
        {
            get { return errorMessage; }
            protected set { errorMessage = value; }
        }
        public PropertyInfo PropertyInfo
        {
            get { return propertyInfo; }
        }

        protected abstract Type[] ValidPropertyTypes { get; }

        public bool IsValid(object instance)
        {
            object value = this.GetValue(instance);
            return DoIsValid(instance, value);
        }

        protected object GetValue(object instance)
        {
            object value = this.propertyInfo.GetValue(instance, null);
            return value;
        }

        protected abstract bool DoIsValid(object instance, object value);

        // Kiem tra 2 type co the so sanh nhau
        protected bool AreCompatibleTypes(Type type, Type testType)
        {
            if (testType == type)
                return true;

            Type underTestType = Nullable.GetUnderlyingType(testType);
            if (underTestType != null && underTestType == type)
                return true;

            if (type.IsInterface)
            {
                foreach (Type iface in testType.GetInterfaces())
                    if (iface == type)
                        return true;
            }

            if (testType.IsSubclassOf(type))
                return true;

            return false;
        }

        // Lay property info
        protected static PropertyInfo GetPropertyInfo(Type type, string propertyName)
        {
            return type.GetProperty(propertyName);
        }

        // Kiem tra type khong the validate
        protected virtual void ThrowIfInvalidPropertyType()
        {
            if (this.ValidPropertyTypes == null || this.ValidPropertyTypes.Length == 0)
                return;

            Type propType = this.propertyInfo.PropertyType;
            foreach (Type type in this.ValidPropertyTypes)
            {
                if (AreCompatibleTypes(type, propType))
                    return;
            }

            throw new InvalidValidatorException(this.GetType(), propType);
        }
    }
}
