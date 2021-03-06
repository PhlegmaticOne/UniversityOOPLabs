using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StringWorking.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void HtmlTagsGetter_PreparedHtmlGetterTest()
        {
            var expected = new List<string>()
            {
                "<html>",
                 "<h1 style=\"text-align:center\">Заголовок</h1>",
                 "<form action=\"handler.php\">",
                 "</form >",
                 "</html >"
            };

            var preparedHtmlGetter = new PreparedHtmlGetter();

            var tagsGetter = new TagStringsGetter(preparedHtmlGetter);

            var resultStrings = tagsGetter.GetHtmlStringContainTags();

            for (int i = 0; i < resultStrings.Count(); i++)
            {
                Assert.AreEqual(expected[i], resultStrings.ElementAt(i).ToString());
            }
        }

        [Test]
        public void HtmlTagsGetter_FileHtmlGetterTest1()
        {
            var expected = new List<string>()
            {
                "<html lang=\"en\" xmlns=\"http://www.w3.org/1999/xhtml\">",
                 "<h1 style=\"text-align:center\">Заголовок</h1>",
                 "<form action=\"handler.php\">",
                 "</form>",
                 "</html>"
            };

            var preparedHtmlGetter = new FileHtmlGetter(@"C:\Users\lolol\source\repos\MyRactangleFirstTry\StringWorking\HtmlFiles\TestHtmlFile.html");

            var tagsGetter = new TagStringsGetter(preparedHtmlGetter);

            var resultStrings = tagsGetter.GetHtmlStringContainTags();

            for (int i = 0; i < resultStrings.Count(); i++)
            {
                Assert.AreEqual(expected[i], resultStrings.ElementAt(i).ToString());
            }
        }

        [Test]
        public void HtmlTagsGetter_FileHtmlGetterTest2()
        {
            var expected = new List<string>()
            {
                "<html lang=\"ru\">",
                "<h1>Красивые <b>формы</b></h1>",
                "<form action=\"\" class=\"railway\">",
                 "</form>",
                 "</html>"
            };

            var preparedHtmlGetter = new FileHtmlGetter(@"C:\Users\lolol\source\repos\MyRactangleFirstTry\StringWorking\HtmlFiles\TestHtmlFile2.html");

            var tagsGetter = new TagStringsGetter(preparedHtmlGetter);

            var resultStrings = tagsGetter.GetHtmlStringContainTags();

            for (int i = 0; i < resultStrings.Count(); i++)
            {
                Assert.AreEqual(expected[i], resultStrings.ElementAt(i).ToString());
            }
        }

        [Test]
        public void HtmlTagsGetter_FileHtmlGetterTest3()
        {
            var expected = new List<string>()
            {
                "<html lang=\"ru\">",
                 "<h1>Красивые <b>формы</b></h1>",
                 "<form class=\"decor\">",
                 "</form>",
                 "</html>"
            };

            var preparedHtmlGetter = new FileHtmlGetter(@"C:\Users\lolol\source\repos\MyRactangleFirstTry\StringWorking\HtmlFiles\TestHtmlFile3.html");

            var tagsGetter = new TagStringsGetter(preparedHtmlGetter);

            var resultStrings = tagsGetter.GetHtmlStringContainTags();

            for (int i = 0; i < resultStrings.Count(); i++)
            {
                Assert.AreEqual(expected[i], resultStrings.ElementAt(i).ToString());
            }
        }

        [Test]
        public void WordInMatriceChecker_SuccesfullTest1()
        {
            var martrice = new char[][]
            {
                new char[] { 'м', 'п', 'о', 'а' },
                new char[] { 'л', 'т', 'е' },
                new char[] { 'с', 'ф' },
            };
            var testWord = "СаМоЛет";

            var checker = new WordInMaticeChecker(martrice);

            Assert.AreEqual(true, checker.Check(testWord));
        }

        [Test]
        public void WordInMatriceChecker_SuccesfullTest2()
        {
            var martrice = new char[][]
            {
                new char[] { 'м', 'п', 'о', 'а' },
                new char[] { 'р', 'г', 'н', 'е' },
                new char[] { 'в', 'и' },
            };
            var testWord = "ПРОГРАММИРОВАНИЕ";

            var checker = new WordInMaticeChecker(martrice);

            Assert.AreEqual(true, checker.Check(testWord));
        }
        [Test]
        public void WordInMatriceChecker_BadTest1()
        {
            var martrice = new char[][]
            {
                new char[] { 'ч', 'п', 'к', 'а' },
                new char[] { 'л', 'я', 'й' },
                new char[] { 'н', 'ф' },
            };
            var testWord = "чашка";

            var checker = new WordInMaticeChecker(martrice);

            Assert.AreNotEqual(true, checker.Check(testWord));
        }
        [Test]
        public void WordInMatriceChecker_BadTest2()
        {
            var martrice = new char[][]
            {
                new char[] { 'г', 'л', 'о', 'б' },
                new char[] { 'у', 'й', 'е' },
                new char[] { 'я', 'м' },
            };
            var testWord = "ГЛобус";

            var checker = new WordInMaticeChecker(martrice);

            Assert.AreNotEqual(true, checker.Check(testWord));
        }
        [Test]
        public void WordInMatriceChecker_SuccesfullTest3()
        {
            var martrice = new char[][]
            {
                new char[] { 'к', 'л', 'о', 'а' },
                new char[] { 'й', 'т', 'е' },
                new char[] { 'с', 'у' },
            };
            var testWord = "КлЕй";

            var checker = new WordInMaticeChecker(martrice);

            Assert.AreEqual(true, checker.Check(testWord));
        }
        [Test]
        public void WordInMatriceChecker_SuccesfullTest4()
        {
            var martrice = new char[][]
            {
                new char[] { 'Я' },
                new char[] { 'Д' }
            };
            var testWord = "яд";

            var checker = new WordInMaticeChecker(martrice);

            Assert.AreEqual(true, checker.Check(testWord));
        }
        [Test]
        public void WordInMatriceChecker_SuccesfullTest5()
        {
            var martrice = new char[][]
            {
                new char[] { 'Н', 'ф', 'б', 'а', 'ы', 'К' },
                new char[] { 'О', 'т', 'е', 'у', 'й', 'п' },
                new char[] { 'ю' },
                new char[] { 'Я' }
            };
            var testWord = "Ноутбук";

            var checker = new WordInMaticeChecker(martrice);

            Assert.AreEqual(true, checker.Check(testWord));
        }
        [Test]
        public void WordInMatriceChecker_BadTest3()
        {
            var martrice = new char[][]
            {
                new char[] { 'м', 'п', 'о', 'а' },
                new char[] { 'л', 'т', 'е' },
                new char[] { 'с', 'ф' },
            };
            var testWord = "ЗЕФиР";

            var checker = new WordInMaticeChecker(martrice);

            Assert.AreNotEqual(true, checker.Check(testWord));
        }
        [Test]
        public void WordInMatriceChecker_BadTest4()
        {
            var martrice = new char[][]
            {
                new char[] { 'м', 'п', 'о', 'а' },
                new char[] { 'л', 'т', 'е' },
                new char[] { 'с', 'ф' },
            };
            var testWord = "Удлинитель";

            var checker = new WordInMaticeChecker(martrice);

            Assert.AreNotEqual(true, checker.Check(testWord));
        }
        [Test]
        public void WordInMatriceChecker_BadTest5()
        {
            var martrice = new char[][]
            {
                new char[] { 'м', 'п', 'о', 'а' },
                new char[] { 'л', 'т', 'е' },
                new char[] { 'с', 'ф' },
            };
            var testWord = "СвеТофор";

            var checker = new WordInMaticeChecker(martrice);

            Assert.AreNotEqual(true, checker.Check(testWord));
        }
        [Test]
        public void WordInMatriceChecker_BadTest6()
        {
            var martrice = new char[][]
            {
                new char[] { 'у', 'п', 'о', 'а' },
                new char[] { 'л', 'т', 'е' },
                new char[] { 'с', 'й' },
            };
            var testWord = "Передача";

            var checker = new WordInMaticeChecker(martrice);

            Assert.AreNotEqual(true, checker.Check(testWord));
        }
        [Test]
        public void WordInMatriceChecker_ThrowsException()
        {
            var martrice = new char[][]
            {
                new char[] { 'у', 'п', 'о', 'а' },
                new char[] { 'л', 'т', 'е' },
                new char[] { 'с', 'п' },
            };

            Assert.Throws<ArgumentException>(() => new WordInMaticeChecker(martrice));
        }

        [Test]
        public void WordInMatriceChecker_DoesNotThrowsException()
        {
            var martrice = new char[][]
            {
                new char[] { 'у', 'п', 'о', 'а' },
                new char[] { 'л', 'т', 'е' },
                new char[] { 'с', 'й' },
            };

            Assert.DoesNotThrow(() => new WordInMaticeChecker(martrice));
        }
    }
}