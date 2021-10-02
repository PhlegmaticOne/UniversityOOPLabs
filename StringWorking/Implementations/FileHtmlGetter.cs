using System;
using System.Collections.Generic;
using System.IO;

namespace StringWorking
{
    public class FileHtmlGetter : IHtmlGetter
    {
        private readonly string _filePath;

        public FileHtmlGetter(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
            {
                throw new ArgumentException($"\"{nameof(filePath)}\" не может быть пустым или содержать только пробел.", nameof(filePath));
            }
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("Файл не существует");
            }
            _filePath = filePath;
        }

        public IEnumerable<string> GetHtml()
        {
            var result = new List<string>();
            using (var fs = new StreamReader(_filePath))
            {
                string f;
                while ((f = fs.ReadLine()) != null)
                {
                    result.Add(f);
                }
            }
            return result;
        }
    }
}
