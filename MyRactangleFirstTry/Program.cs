using ConsoleMenuUI.Lib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace MyRectangle
{
    class Program
    {
        static void Main(string[] args)
        {
            //var menu = new ConsoleMenu("Приложение для работы с MyRectangle")
            //               .AddMenuChoice(CreateRectangleFromPoints, null, "Создать прямоугольник через задание точек")
            //               .AddMenuChoice(CheckRectangleOnContainingPoint, null, "Проверить заданный прямоугольник на содержание заданной точки");
            //menu.Draw();

            Regex _regex = new Regex(@"</?form\s*.*>|</?h1\s*.*>|</?html\s*.*>");
            //IEnumerable<string> html = new List<string>()
            //{
            //    "<!DOCTYPE HTML>",
            //        "<html>",
            //            "<head>",
            //                "<meta charset=\"utf-8\">",
            //                "<title>Тег FORM</title>",
            //            "</head>",
            //        "<body>",
            //            "<h1 style=\"text-align:center\">Заголовок</h1>",
            //            "<form action=\"handler.php\">",
            //                 "<p><b>Как по вашему мнению расшифровывается аббревиатура &quot; ОС&quot;?</b></p>",
            //                 "<p><input type = \"radio\" name=\"answer\" value=\"a1\">Офицерский состав<Br>",
            //                 "<input type = \"radio\" name= \"answer\" value= \"a2\" > Операционная система<Br>",
            //                 "<input type = \"radio\" name= \"answer\" value= \"a3\" > Большой полосатый мух</p>",
            //                 "<p><input type = \"submit\" ></ p >",
            //             "</ form >",
            //        "</ body >",
            //    "</ html >",
            //};

            //foreach (var htmlStr in html)
            //{
            //    var s = _regex.Matches(htmlStr);
            //    foreach (var enter in s)
            //    {
            //        Console.WriteLine(enter);
            //    }
            //}

            var s = @"C:\Users\lolol\source\repos\MyRactangleFirstTry\StringWorking\HtmlFiles";
            var dir = Directory.GetFiles(s);
            var sbm = new List<StringBuilder>();
            using (var fs = new StreamReader(dir[0]))
            {
                string f;
                while((f = fs.ReadLine()) != null)
                {
                    if (_regex.IsMatch(f))
                    {
                        sbm.Add(new StringBuilder(f));
                    }
                }
            }

            foreach (var html in sbm)
            {
                Console.WriteLine(html.ToString());
            }

            Console.ReadLine();
        }
        private static void CreateRectangleFromPoints(object obj)
        {
            var rect = CreateRectanglePoint();
            if (rect == null) return;
            var menu = new ConsoleMenu()
                       .AddMenuChoice(CheckOnContainingPoint, rect, "Проверить этот прямоугольник на содержание точки")
                       .AddMenuChoice(GetInfoAboutRectangle, rect, "Вывести информацию об этом прямоугольнике")
                       .AddMenuChoice(CreateRectangleFromPoints, null, "Создать новый прямоугольник");
            menu.Draw();
        }

        private static void CheckRectangleOnContainingPoint(object obj)
        {
            var rect = CreateRectanglePoint();
            if (rect == null) return;
            CheckOnContainingPoint(rect);
        }

        private static void GetInfoAboutRectangle(object obj)
        {
            if(obj is MyRectangle rectangle)
            {
                Console.WriteLine(rectangle);
            }
        }

        private static void CheckOnContainingPoint(object obj)
        {
            if(obj is MyRectangle rectangle)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Пишите координаты двух точек через пробел\n" +
                                  "Если чисел будет меньше2, то будет ошибка, если больше 2 - остальные числа проигнорируются");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Пример: 1,2 1,22");

                var coordsString = Console.ReadLine();

                var coords = SplitString(coordsString, 2);
                if (coords == null) return;

                var point = new Point(coords[0], coords[1]);

                Console.WriteLine(rectangle.CheckLocation(point));
            }
        }
        private static MyRectangle CreateRectanglePoint()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Пишите координаты точек через пробел, начиная с левой нижней точки прямоугольника. \n" +
                              "Если чисел будет мельше 8, то будет ошибка, если больше 8 - остальные числа проигнорируются");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Пример: 1 1 1 2 2 2 2 1");

            var coordsString = Console.ReadLine();

            var coords = SplitString(coordsString, 8);
            if (coords == null) return null;

            var point1 = new Point(coords[0], coords[1]);
            var point2 = new Point(coords[2], coords[3]);
            var point3 = new Point(coords[4], coords[5]);
            var point4 = new Point(coords[6], coords[7]);

            MyRectangle rect;
            try
            {
                rect = new MyRectangle(point1, point2, point3, point4);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            return rect;
        }
        private static List<double> SplitString(string stringToSplit, int necessaryCount)
        {
            var coords = stringToSplit.Split(' ');
            if (coords.Length < necessaryCount) { ConsoleMenu.PrintError($"Ошибка. Вы ввели {coords.Length} чисел"); return null; }
            if (coords.Length > necessaryCount) coords = coords[0..necessaryCount];

            var c = new List<double>(necessaryCount);
            for (int i = 0; i < coords.Length; i++)
            {
                if (double.TryParse(coords[i], out double result))
                {
                    c.Add(result);
                }
                else
                {
                    ConsoleMenu.PrintError($"{coords[i]} не число");
                    return null;
                }
            }
            return c;
        }
    }
}
