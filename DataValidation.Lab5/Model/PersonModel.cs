using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace DataValidation.Lab5
{
    public class PersonModel : BaseViewModel, IDataErrorInfo, IClonable<PersonModel>
    {
        [RegularExpressionAttribute(pattern: ValidationPatterns.PERSON_NAME_REGULAR_EXPRESSION_PATTERN,
         ErrorMessage = "Имя должно иметь значение или быть менее 30 символов")]
        public string Name { get; set; }
        [RegularExpressionAttribute(pattern: ValidationPatterns.PERSON_NAME_REGULAR_EXPRESSION_PATTERN,
         ErrorMessage = "Фамилия должно иметь значение или быть менее 40 символов")]
        public string Surname { get; set; }
        [RegularExpressionAttribute(pattern: ValidationPatterns.PERSON_NAME_REGULAR_EXPRESSION_PATTERN,
         ErrorMessage = "Отчество должно иметь значение или быть менее 40 символов")]
        public string Patronymic { get; set; }

        [RegularExpressionAttribute(pattern: ValidationPatterns.STREET_NAME_PATTERN,
         ErrorMessage = "Имя улицы должно иметь значение или быть менее 60 символов")]
        public string StreetName { get; set; }
        [RegularExpressionAttribute(pattern: ValidationPatterns.BUILDINGS_NUMBER_PATTERN,
         ErrorMessage = "Номер дома должен быть больше нуля или иметь какое-либо значение")]
        public int HouseNumber { get; set; }
        [RegularExpressionAttribute(pattern: ValidationPatterns.BUILDINGS_NUMBER_PATTERN,
         ErrorMessage = "Номер квартиры должен быть больше нуля или иметь какое-либо значение")]
        public int FlatNumber { get; set; }

        [RegularExpressionAttribute(pattern: ValidationPatterns.EMAIL_PATTERN,
         ErrorMessage = "Неверный e-mail")]
        public string Email { get; set; }

        [RegularExpressionAttribute(pattern: ValidationPatterns.BELARUS_TELEPHONE_NUMBER_PATTERN,
         ErrorMessage = "Неверный номер телефона")]
        public string Telephones { get; set; }

        public void Reset()
        {
            foreach (var prop in GetAllProperties())
            {
                prop.SetValue(this, null);
            }
        }

        
        public event EventHandler PersonChanged;

        private Dictionary<string, string> _errors = new();
        public string this[string propertyName] => UpdateErrors().ContainsKey(propertyName) ?
                                                                      _errors[propertyName] :
                                                                      string.Empty;
        
        private Dictionary<string, string> UpdateErrors()
        {
            _errors.Clear();
            _props.ForEach(prop => {
                var currentValue = prop.GetValue(this);
                var regexAttribute = prop.GetCustomAttribute<RegularExpressionAttribute>();
                if(regexAttribute != null)
                {
                    if(string.IsNullOrWhiteSpace(currentValue?.ToString()) || regexAttribute.IsValid(currentValue) == false)
                    {
                        _errors.Add(prop.Name, regexAttribute.ErrorMessage);
                    }
                }
            });
            PersonChanged?.Invoke(this, EventArgs.Empty);
            return _errors;
        }

        private static List<PropertyInfo> _propertiesWithAttibutes;
        private static IEnumerable<PropertyInfo> _allProperties;
        private IEnumerable<PropertyInfo> GetAllProperties()
        {
            if(_allProperties is null)
            {
                _allProperties = GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.SetProperty)
                                           .Where(prop => prop.SetMethod != null);
            }
            return _allProperties;
        }
        private List<PropertyInfo> _props
        {
            get
            {
                if(_propertiesWithAttibutes is null)
                {
                    _propertiesWithAttibutes = GetAllProperties()
                                               .Where(prop => prop.IsDefined(typeof(RegularExpressionAttribute), true))
                                               .ToList();
                }
                return _propertiesWithAttibutes;
            }
        }
        public bool IsValid => _errors.Any() == false;
        
        public string Error => string.Empty;

        public override string ToString() =>
            string.Format("Name: {0}; Surname: {1}; Patronymic: {2};" +
                          "Email: {3}; Address: {4}, {5}, {6}; Telephones: {7}",
                           Name, Surname, Patronymic, Email, StreetName, HouseNumber, FlatNumber, Telephones);

        public PersonModel Clone() => new PersonModel()
        {
            Name = Name.Copy(),
            Surname = Surname.Copy(),
            Patronymic = Patronymic.Copy(),
            Email = Email.Copy(),
            Telephones = Telephones.Copy(),
            StreetName = StreetName.Copy(),
            FlatNumber = FlatNumber,
            HouseNumber = HouseNumber
        };
    }
}
