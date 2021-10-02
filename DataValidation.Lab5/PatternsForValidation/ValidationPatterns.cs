namespace DataValidation.Lab5
{
    internal sealed class ValidationPatterns
    {
        internal const string PERSON_NAME_REGULAR_EXPRESSION_PATTERN =
        @"[А-ЯЁA-Z]([a-zа-яё]{1,29})$";
        internal const string TELEPHONE_NUMBER_PATTERN =
        @"/((\+375[\-\s]?((29)|(44)|(33)|(25))[\-\s]?(\d{3}[\-\s]?)(\d{2}[\-\s]?)(\d{2}));?)+/gm";
        internal const string BELARUS_TELEPHONE_NUMBER_PATTERN =
        @"(((\+375[\-\s]?((29)|(44)|(33)|(25))[\-\s]?(\d{3}[\-\s]?)(\d{2}[\-\s]?)(\d{2}));?)+[, ]+)*((\+375[\-\s]?((29)|(44)|(33)|(25))[\-\s]?(\d{3}[\-\s]?)(\d{2}[\-\s]?)(\d{2}));?)+";
        internal const string STREET_NAME_PATTERN = @"(([a-zA-Z' -\.,]{1,60})|([а-яА-ЯЁё -\.,]{1,60}))$";
        internal const string BUILDINGS_NUMBER_PATTERN = @"^[1-9]\d*$";
        internal const string EMAIL_PATTERN = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|"
                                            + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)"
                                            + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";
    }
}
