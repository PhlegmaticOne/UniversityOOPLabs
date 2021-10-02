using ConsoleMenuUI.Lib;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace StringWorking.Lab4.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            var menu = new ConsoleMenu("Четвертая лабораторная")
                           .AddMenuChoice(TestFirstTask, null, "Протестировать первое задание")
                           .AddMenuChoice(TestSecondTask, null, "Протестировать второе задание");
            menu.Draw();
        }
        
        private static void TestFirstTask(object obj)
        {
            var menu = new ConsoleMenu("")
                           .AddMenuChoice(TestWithPreparedClass, null, "Протестировать с классом, содержащим HTML-файл")
                           .AddMenuChoice(TestWithHtmlFile1, null, "Протестировать с HTML-файлом 1")
                           .AddMenuChoice(TestWithHtmlFile2, null, "Протестировать с HTML-файлом 2");
            menu.Draw();
        }

        private static void TestWithHtmlFile2(object obj)
        {
            var preparedHtmlGetter = new FileHtmlGetter(@"C:\Users\lolol\source\repos\MyRactangleFirstTry\StringWorking\HtmlFiles\TestHtmlFile3.html");

            var tagsGetter = new TagStringsGetter(preparedHtmlGetter);

            var resultStrings = tagsGetter.GetHtmlStringContainTags();

            Console.WriteLine("Заданный html-файл");
            foreach (var htmlString in preparedHtmlGetter.GetHtml())
            {
                Console.WriteLine(htmlString);
            }
            Console.WriteLine("\nНайденные строки");
            foreach (var find in resultStrings)
            {
                Console.WriteLine(find);
            }
        }

        private static void TestWithHtmlFile1(object obj)
        {
            var preparedHtmlGetter = new FileHtmlGetter(@"C:\Users\lolol\source\repos\MyRactangleFirstTry\StringWorking\HtmlFiles\TestHtmlFile2.html");

            var tagsGetter = new TagStringsGetter(preparedHtmlGetter);

            var resultStrings = tagsGetter.GetHtmlStringContainTags();

            Console.WriteLine("Заданный html-файл");
            foreach (var htmlString in preparedHtmlGetter.GetHtml())
            {
                Console.WriteLine(htmlString);
            }
            Console.WriteLine("\nНайденные строки");
            foreach (var find in resultStrings)
            {
                Console.WriteLine(find);
            }
        }

        private static void TestWithPreparedClass(object obj)
        {
            var preparedHtmlGetter = new PreparedHtmlGetter();

            var tagsGetter = new TagStringsGetter(preparedHtmlGetter);

            var resultStrings = tagsGetter.GetHtmlStringContainTags();

            Console.WriteLine("Заданный html-файл");
            foreach (var htmlString in preparedHtmlGetter.GetHtml())
            {
                Console.WriteLine(htmlString);
            }
            Console.WriteLine("\nНайденные строки");
            foreach (var find in resultStrings)
            {
                Console.WriteLine(find);
            }
        }

        private static void TestSecondTask(object obj)
        {
            var menu = new ConsoleMenu("")
                           .AddMenuChoice(CheckWithEnteringMatrice, null, "Ввести матрицу самостоятельно и слова самостоятельно")
                           .AddMenuChoice(SeeExamples, null, "Просмотреть примеры");
            menu.Draw();
        }

        private static void SeeExamples(object obj)
        {
            var alphabets = new char[3][][]
            {
                new char[][]
                {
                    new char[] { 'Н', 'ф', 'б', 'а', 'ы', 'К' },
                    new char[] { 'О', 'т', 'е', 'у', 'й', 'п' },
                    new char[] { 'ю' },
                    new char[] { 'Я' }
                },
                new char[][]
                {
                    new char[] { 'м', 'п', 'о', 'а' },
                    new char[] { 'л', 'т', 'е' },
                    new char[] { 'с', 'ф' }
                },
                new char[][]
                {
                    new char[] { 'г', 'л', 'о', 'б' },
                    new char[] { 'у', 'й', 'е' },
                    new char[] { 'я', 'м' },
                }
            };

            var words = new string[]
            {
                "Самолет", "Глобус", "Розетка", "Зефир", "Стакан", "Облом",
                "Пот", "Платок", "Бак", "Софт", "Лампа", "Яблоко", "Бумага"
            };

            foreach (var alphabet in alphabets)
            {
                Output(alphabet);
                var checker = new WordInMaticeChecker(alphabet);
                foreach (var word in words)
                {
                    Console.WriteLine("Test: {0}. Result: {1}", word, checker.Check(word));
                }
                Console.WriteLine("\n");
            }
        }

        private static void CheckWithEnteringMatrice(object obj)
        {
            Console.WriteLine("Вводите матрицу как последовательность строк, в каждой из которых любое количетсво РУССКИХ символов\n" +
                "и чтобы они НЕ ПОВТОРЯЛИСЬ. Для конца ввода введите 0 и нажмите Enter");

            var matrice = InputMatriceOfChars();

            var wordChecker = new WordInMaticeChecker(matrice);

            Console.WriteLine("Вводите сколько хотитеслов для проверки. Чтобы закончить введите 0 и нажмите Enter");
            EternalWordChecking(wordChecker);
        }

        private static void EternalWordChecking(WordInMaticeChecker wordChecker)
        {
            while (true)
            {
                string wordToCheck = Console.ReadLine();
                if (char.TryParse(wordToCheck, out char breakChar))
                {
                    if (breakChar == '0')
                    {
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("Тест слова: {0}. Результат: {1}", wordToCheck, wordChecker.Check(wordToCheck));
                }
            }
        }

        private static void Output(char[][] alphabet)
        {
            foreach (var row in alphabet)
            {
                foreach (var ch in row)
                {
                    Console.Write(ch + " ");
                }
                Console.WriteLine();
            }
        }
        private static IEnumerable<IEnumerable<char>> InputMatriceOfChars()
        {
            var matrice = new List<List<char>>();
            string input;
            int i = 0;
            while (true)
            {
                input = Console.ReadLine();
                if(char.TryParse(input, out char breakChar))
                {
                    if(breakChar == '0')
                    {
                        break;
                    }
                }
                else
                {
                    var chars = input.Split(' ');
                    matrice.Add(new List<char>());
                    foreach (var ch in chars)
                    {
                        if(char.TryParse(ch, out char resChar) == false)
                        {
                            throw new ArgumentException("В строке не символы");
                        }
                        else
                        {
                            matrice[i].Add(resChar);
                        }
                    }
                    ++i;
                }
            }
            return matrice;
        }
    }
}
