using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace StringWorking
{
    public class TagStringsGetter
    {
        private readonly Regex _regex = new Regex(@"</?form\s*.*>|</?h1\s*.*>|</?html\s*.*>");
        private readonly IHtmlGetter _htmlGetter;
        public TagStringsGetter(IHtmlGetter htmlGetter, string tagsPattern = @"</?form\s*.*>|</?h1\s*.*>|</?html\s*.*>")
        {
            if (htmlGetter == null)
            {
                throw new ArgumentNullException(nameof(htmlGetter));
            }

            if (string.IsNullOrWhiteSpace(tagsPattern))
            {
                throw new ArgumentException($"\"{nameof(tagsPattern)}\" не может быть пустым или содержать только пробел.", nameof(tagsPattern));
            }

            _htmlGetter = htmlGetter;
            _regex = new Regex(tagsPattern);
        }

        public IEnumerable<StringBuilder> GetHtmlStringContainTags()
        {
            var result = new List<StringBuilder>();
            foreach (var htmlString in _htmlGetter.GetHtml())
            {
                if (_regex.IsMatch(htmlString))
                {
                    var cleanString = htmlString.Trim();
                    result.Add(new StringBuilder(cleanString));
                }
            }
            return result;
        }
    }
}
