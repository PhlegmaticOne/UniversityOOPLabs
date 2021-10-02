using NUnit.Framework;
using SquareMatrix.Lab3;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SquareMtrixTests
{
    public class SquareMatrixControllerTests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void SquareMatrix_ConstructorThrowsArgumentException_Size()
        {
            var list1 = new List<double>() { 3, 3, 3 };
            var list2 = new List<double>() { 2, 2, 2 };
            var list3 = new List<double>() { 1, 1, 1 };
            var res = new List<IList<double>>() { list1, list2, list3 };

            var matrix = new SquareMatrix.Lab3.SquareMatrix(res, "A");
            var controller = new SquareMatrixController(matrix);

            var multiplicationResults = controller.GetMultiplicationOfDiagonals(2, 1, -1, -2, 2, 1, 0, -1, 2);
            var trueResults = new List<int>() { 3, 6, 2, 1, 6 };

            for (int i = 0; i < multiplicationResults.Count(); i++)
            {
                Assert.AreEqual(trueResults[i], multiplicationResults.ElementAt(i).OperationResult);
            }
        }
    }
}
