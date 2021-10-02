using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace StringWorking
{
    public class WordInMaticeChecker
    {
        private readonly string _matriceOfChars;

        public WordInMaticeChecker(IEnumerable<IEnumerable<char>> matriceOfChars)
        {
            if (matriceOfChars == null)
            {
                throw new ArgumentNullException(nameof(matriceOfChars));
            }

            var matrToString = MatriceOfCharsToString(matriceOfChars);

            if (MatriceHasNotOnlyRussianSymbols(matrToString) == false)
            {
                throw new ArgumentException("Матрица содержит не только русские символы");
            }
            if (CheckForContainingMoreThanOneSimilarChar(matrToString))
            {
                throw new ArgumentException("Матрица содержит два одинаковых символа");
            }
            _matriceOfChars = matrToString;
        }

        public bool Check(string word)
        {
            var lowerCaseWord = word.ToLower();
            foreach (var charInWord in lowerCaseWord)
            {
                if (!_matriceOfChars.Contains(charInWord))
                {
                    return false;
                }
            }
            return true;
        }
        private string MatriceOfCharsToString(IEnumerable<IEnumerable<char>> matr)
        {
            var sb = new StringBuilder();
            foreach (var row in matr)
            {
                foreach (var ch in row)
                {
                    var lowerChar = char.ToLower(ch);
                    sb.Append(lowerChar);
                }
            }
            return sb.ToString();
        }
        private bool CheckForContainingMoreThanOneSimilarChar(string matriceOfChars) =>
                                                              matriceOfChars.Distinct().Count() < matriceOfChars.Length;
        private bool MatriceHasNotOnlyRussianSymbols(string matriceOfChars) =>
                                                     new Regex(@"^[а-яА-ЯЁё]+$").IsMatch(matriceOfChars);
    }
}
