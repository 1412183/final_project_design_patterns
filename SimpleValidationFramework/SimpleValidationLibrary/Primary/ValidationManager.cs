using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

using SimpleValidationLibrary;
using SimpleValidationLibrary.Attributes;
using SimpleValidationLibrary.Validators;

using ValidatorCollection = System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<SimpleValidationLibrary.Validators.Validator>>;



    public sealed class ValidationManager
    {

        //Danh sach the hien validation cua mot loai
        private static Dictionary<Type, ValidatorCollection> typeValidat;


        private object mark;
        private Type markType;
        private Dictionary<string, string> validatErrors;
        private ValidatorCollection validators;
        private ValidatorCollection instValidators;

        // Dinh kem validation cho the hien cua loai
        public ValidationManager(object instance)
        {
            this.mark = instance;
            this.markType = instance.GetType();
            this.validatErrors = new Dictionary<string, string>();

        }


        // Lay danh sach validators
        public ValidatorCollection Validators
        {
            get { return GetValidators(); }
        }

        // Lay danh sach loi
        public Dictionary<string, string> ValidationErrors
        {
            get { return this.validatErrors; }
        }

        static ValidationManager()
        {
            typeValidat = new Dictionary<Type, ValidatorCollection>();
        }


        // Them validator
        public void AddValidator(Validator validator)
        {
            string key = validator.PropertyInfo.Name;
            if (this.instValidators == null)
                this.instValidators = new Dictionary<string, List<Validator>>();
            if (!this.instValidators.ContainsKey(key))
                this.instValidators[key] = new List<Validator>();
            this.instValidators[key].Add(validator);

            this.validators = null;
        }

        // Kiem tra hop le cho moi element 
        public bool IsPropertyValid(string propertyName)
        {
            ValidatorCollection validators = this.Validators;
            this.validatErrors.Remove(propertyName);
            DoIsValid(validators[propertyName]);
            return this.validatErrors.ContainsKey(propertyName);
        }

        // Kiem tra hop le 
        public bool IsValid()
        {
            this.validatErrors.Clear();
            ValidatorCollection validators = this.Validators;
            foreach (List<Validator> vl in validators.Values)
                DoIsValid(vl);

            return this.validatErrors.Count == 0;
        }

        // neu khong validation,
        // Kiểm tra validation cho tat ca properties cua doi tuong
        private void DoIsValid(List<Validator> validators)
        {
            if (validators == null)
                return;

            for (int i = 0; i < validators.Count; i++)
            {
                if (!validators[i].IsValid(this.mark))
                {
                    this.validatErrors[validators[i].PropertyInfo.Name] = validators[i].ErrorMessage;
                    break;
                }
            }
        }

        // Lay danh sach validators 
        private ValidatorCollection GetValidators()
        {
            if (this.validators == null)
                this.validators = ValidationManager.FindValidatorAttributes(this.markType);

            if (this.instValidators != null)
            {
                foreach (KeyValuePair<string, List<Validator>> kvp in this.instValidators)
                    this.validators[kvp.Key].AddRange(kvp.Value);
            }

            return this.validators;
        }

        // Them global validator
        public static void AddGlobalValidator<T>(Validator validator)
        {
            AddGlobalValidator(typeof(T), validator);
        }

        // Them global validator
        public static void AddGlobalValidator(Type type, Validator validator)
        {
            if (!typeValidat.ContainsKey(type))
                typeValidat[type] = new ValidatorCollection();

            ValidatorCollection validators = typeValidat[type];

            string key = validator.PropertyInfo.Name;
            if (!validators.ContainsKey(key))
                validators[key] = new List<Validator>();

            validators[key].Add(validator);

        }

        // Kiem tra valid cho mot instance
        public static bool IsValid(object instance)
        {
            ValidationManager vm = new ValidationManager(instance);
            return vm.IsValid();
        }

        // Lay validators tu  attribute
        private static ValidatorCollection FindValidatorAttributes(Type type)
        {
            if (!typeValidat.ContainsKey(type))
            {
                ValidatorCollection validators = new ValidatorCollection();
                PropertyInfo[] pis = type.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);

                foreach (PropertyInfo pi in pis)
                {
                    ValidatorAttribute[] vas = (ValidatorAttribute[])pi.GetCustomAttributes(typeof(ValidatorAttribute), true);
                    List<ValidatorAttribute> vasList = new List<ValidatorAttribute>(vas);
                    vasList.Sort((va1, va2) => va1.Priority.CompareTo(va2.Priority));


                    List<Validator> list = vasList.ConvertAll<Validator>((va) => va.GetValidator(pi));

                    validators.Add(pi.Name, list);
                }
                typeValidat.Add(type, validators);
            }

            return typeValidat[type];
        }
    }
