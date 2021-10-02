using ComplexNumbers.Lab2;
using ConsoleMenuUI.Lib;
using System;
using System.Collections.Generic;

namespace ComplexNumber.Lab2.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            var menu = new ConsoleMenu("Приложение для работы с комплексными числами")
                           .AddMenuChoice(SumOfTwoNumbers, null, "Сложение двух комплексных чисел")
                           .AddMenuChoice(DifOfTwoNumbers, null, "Вычитание двух комплексных чисел")
                           .AddMenuChoice(MulOfTwoNumbers, null, "Умножение двух комплексных чисел")
                           .AddMenuChoice(DivOfTwoNumbers, null, "Деление двух комплексных чисел")
                           .AddMenuChoice(PrintInfoAboutComplexNumber, null, "Вывод информации для введенного числа");
            menu.Draw();
        }

        private static void PrintInfoAboutComplexNumber(object obj)
        {
            var num = CreateAlgebraicNumber();
            if (num == null) return;
            var menu = new ConsoleMenu("")
                       .AddMenuChoice(PrintAlg, num, "Вывести информацию в алгебраической форме")
                       .AddMenuChoice(PrintTrig, num, "Вывести информацию в тригонометрической форме")
                       .AddMenuChoice(PrintExp, num, "Вывести информацию в экспоненциальной форме");
            menu.Draw();
        }

        private static void PrintAlg(object obj)
        {
            if(obj is ComplexNumbers.Lab2.ComplexNumber num)
            {
                Console.WriteLine(num.ToString(ComplexNumberOutput.Algebraic));
            }
        }

        private static void PrintTrig(object obj)
        {
            if (obj is ComplexNumbers.Lab2.ComplexNumber num)
            {
                Console.WriteLine(num.ToString(ComplexNumberOutput.Trigonometric));
            }
        }

        private static void PrintExp(object obj)
        {
            if (obj is ComplexNumbers.Lab2.ComplexNumber num)
            {
                Console.WriteLine(num.ToString(ComplexNumberOutput.Exponential));
            }
        }

        private static void DivOfTwoNumbers(object obj)
        {
            var num1 = CreateAlgebraicNumber();
            if (num1 == null) return;
            var num2 = CreateAlgebraicNumber();
            if (num2 == null) return;

            var num3 = num1 / num2;
            var menu = new ConsoleMenu()
                       .AddMenuChoice(PrintAlg, num3, "Вывести информацию в алгебраической форме")
                       .AddMenuChoice(PrintTrig, num3, "Вывести информацию в тригонометрической форме")
                       .AddMenuChoice(PrintExp, num3, "Вывести информацию в экспоненциальной форме");
            menu.Draw();
        }

        private static void MulOfTwoNumbers(object obj)
        {
            var num1 = CreateAlgebraicNumber();
            if (num1 == null) return;
            var num2 = CreateAlgebraicNumber();
            if (num2 == null) return;

            var num3 = num1 * num2;
            var menu = new ConsoleMenu("")
                       .AddMenuChoice(PrintAlg, num3, "Вывести информацию в алгебраической форме")
                       .AddMenuChoice(PrintTrig, num3, "Вывести информацию в тригонометрической форме")
                       .AddMenuChoice(PrintExp, num3, "Вывести информацию в экспоненциальной форме");
            menu.Draw();
        }

        private static void DifOfTwoNumbers(object obj)
        {
            var num1 = CreateAlgebraicNumber();
            if (num1 == null) return;
            var num2 = CreateAlgebraicNumber();
            if (num2 == null) return;

            var num3 = num1 - num2;
            var menu = new ConsoleMenu("")
                       .AddMenuChoice(PrintAlg, num3, "Вывести информацию в алгебраической форме")
                       .AddMenuChoice(PrintTrig, num3, "Вывести информацию в тригонометрической форме")
                       .AddMenuChoice(PrintExp, num3, "Вывести информацию в экспоненциальной форме");
            menu.Draw();
        }

        private static void SumOfTwoNumbers(object obj)
        {
            var num1 = CreateAlgebraicNumber();
            if (num1 == null) return;
            var num2 = CreateAlgebraicNumber();
            if (num2 == null) return;

            var num3 = num1 + num2;
            var menu = new ConsoleMenu()
                       .AddMenuChoice(PrintAlg, num3, "Вывести информацию в алгебраической форме")
                       .AddMenuChoice(PrintTrig, num3, "Вывести информацию в тригонометрической форме")
                       .AddMenuChoice(PrintExp, num3, "Вывести информацию в экспоненциальной форме");
            menu.Draw();
        }

        private static ComplexNumbers.Lab2.ComplexNumber CreateAlgebraicNumber()
        {
            Console.WriteLine("Введите a и b через пробел. Пример: 8 -2,3123");
            var str = Console.ReadLine();
            ComplexNumbers.Lab2.ComplexNumber complexNumber;
            var coord = SplitString(str, 2);
            try
            {
                complexNumber = new ComplexNumbers.Lab2.ComplexNumber(coord[0], coord[1]);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
            return complexNumber;
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
