using NUnit.Framework;
using SquareMatrix.Lab3;
using System;
using System.Collections.Generic;

namespace SquareMtrixTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void SquareMatrix_ConstructorThrowsArgumentException_Size()
        {
            Assert.Throws<ArgumentException>(() => new SquareMatrix.Lab3.SquareMatrix(0, "A"));
        }
        [Test]
        public void SquareMatrix_ConstructorThrowsArgumentException_Name()
        {
            Assert.Throws<ArgumentNullException>(() => new SquareMatrix.Lab3.SquareMatrix(10, " "));
        }
        [Test]
        public void SquareMatrix_ConstructorThrowsArgumentException_Matrix()
        {
            List<IList<double>> matrix = null;
            Assert.Throws<ArgumentNullException>(() => new SquareMatrix.Lab3.SquareMatrix(matrix, "A"));
        }
        [Test]
        public void SquareMatrix_ConstructorThrowsArgumentException_MatrixCount()
        {
            List<IList<double>> matrix = new List<IList<double>>();
            Assert.Throws<ArgumentException>(() => new SquareMatrix.Lab3.SquareMatrix(matrix, "A"));
        }

        [Test]
        public void SquareMatrix_SizesAreNotEqualTest()
        {
            var list1 = new List<double>() { 1, 2, 3 };
            var list2 = new List<double>() { 1, 2, 3 };
            var result = new List<IList<double>>() { list1, list2 };

            Assert.Throws<ArgumentException>(() => new SquareMatrix.Lab3.SquareMatrix(result, "A"));
        }

        [Test]
        public void SquareMatrix_PropertiesCheck()
        {
            var list1 = new List<double>() { 1, 2 };
            var list2 = new List<double>() { 1, 2 };
            var result = new List<IList<double>>() { list1, list2 };

            var matrix = new SquareMatrix.Lab3.SquareMatrix(result, "A");

            Assert.AreEqual(result.Count, matrix.Size);
            Assert.AreEqual("A", matrix.Name);
            Assert.AreEqual(1, matrix[0, 0]);
            Assert.AreEqual("A. Size: 2", matrix.ToString());
        }

        [Test]
        public void SquareMatrix_StringExplicitOperatorTest()
        {
            var list1 = new List<double>() { 3, 3, 3 };
            var list2 = new List<double>() { 2, 2, 2 };
            var list3 = new List<double>() { 1, 1, 1 };
            var res = new List<IList<double>>() { list1, list2, list3 };
            var matrix = new SquareMatrix.Lab3.SquareMatrix(res, "A");
            var stringView = (string)matrix;

            Assert.AreEqual("Matrix: A, size: 3, max element: 3, min element: 1", stringView);
        }

        [Test]
        public void SquareMatrix_SubstractionOperatorTest()
        {
            var list1 = new List<double>() { 3, 3, 3 };
            var list2 = new List<double>() { 2, 2, 2 };
            var list3 = new List<double>() { 1, 1, 1 };
            var res = new List<IList<double>>() { list1, list2, list3 };
            var res2 = new List<IList<double>>() { list3, list2, list1 };

            var matrix1 = new SquareMatrix.Lab3.SquareMatrix(res, "A");
            var matrix2 = new SquareMatrix.Lab3.SquareMatrix(res2, "B");
            var expected = new List<List<double>>()
            {
                new List<double>() {-2, -2, -2},
                new List<double>() {0, 0, 0},
                new List<double>() { 2, 2, 2}
            };

            var result = matrix2 - matrix1;


            var s = new SquareMatrixController(matrix1);
            for (int i = 0; i < result.Size; i++)
            {
                for (int j = 0; j < result.Size; j++)
                {
                    Assert.AreEqual(expected[i][j], result[i, j]);
                }
            }
        }
    }
}