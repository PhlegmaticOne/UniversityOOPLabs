using System;
using System.Collections.Generic;
using System.Linq;

namespace SquareMatrix.Lab3
{
    public class SquareMatrixController
    {    
        public SquareMatrix Matrix { get; private set; }
        public SquareMatrixController(SquareMatrix matrix)
        {
            if (matrix is null)
            {
                throw new ArgumentNullException(nameof(matrix));
            }
            Matrix = matrix;
        }
        public SquareMatrixController(IEnumerable<string> rows, string name)
        {
            var rowsCount = rows.Count();
            var carcass = new List<IList<double>>();
            for (int i = 0; i < rowsCount; ++i)
            {
                carcass.Add(new List<double>());
                string[] nums = rows.ElementAt(i).Split(' ');
                if(rowsCount != nums.Length)
                {
                    throw new ArgumentException("Количество элементов в строках не совпадает с количеством строк");
                }
                for (int j = 0; j < nums.Length; j++)
                {
                    if (double.TryParse(nums[j], out double value))
                    {
                        carcass[i].Add(value);
                    }
                    else
                    {
                        throw new ArgumentException("Элементы в строке не являются числами");
                    }
                }
            }
            Matrix = new SquareMatrix(carcass, name);
        }
        public IEnumerable<DiagonalResult> GetMultiplicationOfDiagonals(params int[] diagonalNumbers)
        {
            if(diagonalNumbers.Length == 0)
            {
                return new List<DiagonalResult>() { new DiagonalResult(0, GetSum())};
            }
            var result = new List<DiagonalResult>();
            var maxDiagonalNumber = Matrix.Size - 1;
            foreach (var diagonalNumber in diagonalNumbers)
            {
                if(diagonalNumber < maxDiagonalNumber || diagonalNumber > maxDiagonalNumber * -1)
                {
                    var potentialMultiply = GetElementsMultiplicationOnDiagonal(diagonalNumber);
                    var potentialOperationResult = new DiagonalResult(diagonalNumber, potentialMultiply);
                    if (!result.Contains(potentialOperationResult))
                    {
                        result.Add(potentialOperationResult);
                    }
                }
            }
            return result;
        }

        public double GetMultiplicationOfMainDiagonalAndTwoNeighboring()
        {
            var diagNums = new int[] { -1, 0, 1 };
            double resMult = 1.0;
            foreach (var num in diagNums)
            {
                resMult *= GetElementsMultiplicationOnDiagonal(num);
            }
            return resMult;
        }

        public double GetMultiplicationOfAllDiagonals()
        {
            List<int> diagNums = new List<int>();
            for (int i = (-1) * (Matrix.Size - 1); i < Matrix.Size; i++)
            {
                diagNums.Add(i);
            }
            double mult = 1.0;
            foreach (var num in diagNums)
            {
                mult *= GetElementsMultiplicationOnDiagonal(num);
            }
            return mult;
        }
        private double GetElementsMultiplicationOnDiagonal(int diagonalNumber)
        {
            double multiplication = 1;
            int realDiagonalNumber;
            if (diagonalNumber >= 0)
            {
                var j = Matrix.Size - 1;
                for (int i = diagonalNumber; i < Matrix.Size; i++)
                {
                    multiplication *= Matrix[i, j];
                    j--;
                }
            }
            else
            {
                realDiagonalNumber = diagonalNumber * (-1);
                var j = Matrix.Size - realDiagonalNumber - 1;
                for (int i = 0; i < Matrix.Size - realDiagonalNumber; i++)
                { 
                    multiplication *= Matrix[i, j];
                    j--;
                }
            }
            return multiplication;
        }

        public double GetSum()
        {
            double sum = 0;
            for (int i = 0; i < Matrix.Size; i++)
            {
                for (int j = 0; j < Matrix.Size; j++)
                {
                    sum += Matrix[i, j];
                }
            }
            return sum;
        }

        public void IncreaseElementsOnMainDiagonal(double times)
        {
            var newMatrice = new List<List<double>>();
            for (int i = 0; i < Matrix.Size; i++)
            {
                Matrix[Matrix.Size - 1 - i, i] *= times;
            }
        }
    }
}
