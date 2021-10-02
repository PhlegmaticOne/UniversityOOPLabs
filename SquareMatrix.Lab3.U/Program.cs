using ConsoleMenuUI.Lib;
using SquareMatrix.Lab3.View;
using System;
using System.Collections.Generic;

namespace SquareMatrix.Lab3.U
{
    class Program
    {
        static void Main(string[] args)
        {
            //var menu = new ConsoleMenu("Третья лабораторная")
            //               .AddMenuChoice(InputOutputThreeMatrices, null, "Ввод вывод трех матриц");
            //menu.Draw();
            var view = new SquareMatrixView();
            var matrice3 = new SquareMatrixController(view.Input('0'), "C");
            Console.WriteLine(matrice3.GetMultiplicationOfAllDiagonals());
            
            Console.WriteLine();
            Console.ReadLine();
        }

        private static void InputOutputThreeMatrices(object obj)
        {
            var view = new SquareMatrixView();
            Console.WriteLine("Учтите, что если кол-во введенных строк не будет равняться кол-ву элементов в каждой строке, то будет исключение");
            Console.WriteLine("\nКогда вы завершите набор матрицы, наберите 0 и нажмите Enter\n");
            Console.WriteLine("Вводите строки, в которых {0} чисел через пробел. Пример: 9 0 2 3");
            var matrice1 = new SquareMatrixController(view.Input('0'), "A");

            Console.WriteLine("Вводите строки, в которых {0} чисел через пробел. Пример: 9 0 2 3");
            var matrice2 = new SquareMatrixController(view.Input('0'), "B");

            Console.WriteLine("Вводите строки, в которых {0} чисел через пробел. Пример: 9 0 2 3");
            var matrice3 = new SquareMatrixController(view.Input('0'), "C");

            var matriceWrapper = new MatriceWrapper(matrice1, matrice2, matrice3);

            var menu = new ConsoleMenu("Что делать дальше")
                           .AddMenuChoice(OutputThreeMatrices, matriceWrapper , "Вывод трех матриц")
                           .AddMenuChoice(CountMultiplyOfTwoMatrices, matriceWrapper, "Вычисление произведения элементов диаг. А и В")
                           .AddMenuChoice(CountMultiplyOfThirdMatrice, matriceWrapper, "Вычисление произведения элементов 3 матрицы")
                           .AddMenuChoice(CountMultiplyOfSecondMatrice, matriceWrapper, "Вычисление произведения элементов 2 матрицы на заданных диагоналях")
                           .AddMenuChoice(CheckEquality, matriceWrapper, "Проверить А=В")
                           .AddMenuChoice(PrintInfo, matriceWrapper, "Вывести информацию о трех матрицах");
            menu.Draw();
        }

        private static void PrintInfo(object obj)
        {
            var a = obj as MatriceWrapper;

            Console.WriteLine((string)a.A.Matrix);
            Console.WriteLine((string)a.B.Matrix);
            Console.WriteLine((string)a.C.Matrix);
        }

        private static void CheckEquality(object obj)
        {
            var a = obj as MatriceWrapper;
            var view = new SquareMatrixView();
            var matriceToCheck = a.A.Matrix - a.B.Matrix;
            var emptyMatrice = SquareMatrix.Empty(a.A.Matrix.Size);

            Console.WriteLine("Сравниваются матрицы");
            view.Output(matriceToCheck);
            view.Output(emptyMatrice);

            if (matriceToCheck == emptyMatrice)
            {
                Console.WriteLine("Матрицы равны. Увеличение элементов на главной диагонали матриц в два раза");
                a.A.IncreaseElementsOnMainDiagonal(2);
                a.B.IncreaseElementsOnMainDiagonal(2);
            }
            else
            {
                Console.WriteLine("Матрицы не равны");
            }
        }

        private static void CountMultiplyOfSecondMatrice(object obj)
        {
            var a = obj as MatriceWrapper;
            var view = new SquareMatrixView();

            Console.WriteLine("Введите номера диагоналей матрицы. Главная диагональ = 0, диагонали выше = -1, -2..., ниже = 1, 2...");

            var numsStr = Console.ReadLine().Split(' ');
            var nums = new List<int>();
            foreach (var item in numsStr)
            {
                if(int.TryParse(item, out int val))
                {
                    nums.Add(val);
                }
            }
            var mul = 1.0;
            foreach (var item in a.B.GetMultiplicationOfDiagonals(nums.ToArray()))
            {
                mul *= item.OperationResult;
            }
            view.Output(a.B.Matrix);
            Console.WriteLine("Произведение равно: {0}", mul);
        }

        private static void CountMultiplyOfThirdMatrice(object obj)
        {
            var a = obj as MatriceWrapper;
            var view = new SquareMatrixView();
            view.Output(a.C.Matrix);
            Console.WriteLine(a.C.GetMultiplicationOfAllDiagonals());
        }

        private static void CountMultiplyOfTwoMatrices(object obj)
        {
            var a = obj as MatriceWrapper;
            var view = new SquareMatrixView();

            var res = a.A.Matrix - a.B.Matrix;
            var sec = new SquareMatrixController(res);

            view.Output(a.A.Matrix);
            Console.WriteLine("Произведение гл. диаг. и двух соседних матрицы A");
            Console.WriteLine(a.A.GetMultiplicationOfMainDiagonalAndTwoNeighboring());

            view.Output(res);
            Console.WriteLine("Произведение гл. диаг. и двух соседних матрицы A-B");
            Console.WriteLine(sec.GetMultiplicationOfMainDiagonalAndTwoNeighboring());
        }

        private static void OutputThreeMatrices(object obj)
        {
            var a = obj as MatriceWrapper;
            var view = new SquareMatrixView();

            Console.WriteLine("1 матрица");
            view.Output(a.A.Matrix);
            Console.WriteLine();
            Console.WriteLine("2 матрица");
            view.Output(a.B.Matrix);
            Console.WriteLine();
            Console.WriteLine("3 матрица");
            view.Output(a.C.Matrix);
            Console.WriteLine();
        }
    }

    class MatriceWrapper
    {
        public MatriceWrapper(SquareMatrixController a, SquareMatrixController b, SquareMatrixController c)
        {
            if (a is null)
            {
                throw new ArgumentNullException(nameof(a));
            }

            if (b is null)
            {
                throw new ArgumentNullException(nameof(b));
            }

            if (c is null)
            {
                throw new ArgumentNullException(nameof(c));
            }
            A = a;
            B = b;
            C = c;
        }

        public SquareMatrixController A { get; }
        public SquareMatrixController B { get; }
        public SquareMatrixController C { get; }
    }
}
