using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace SquareMatrix.Lab3
{
    public sealed class SquareMatrix : IEnumerable<double>
    {
        private readonly IList<IList<double>> _matrix;
        public string Name { get; }
        public int Size { get; }
        public SquareMatrix(int size, string name)
        {
            if (size <= 0)
            {
                throw new ArgumentException(nameof(size)); 
            }
            if (name == null)
            {
                throw new ArgumentNullException($"\"{nameof(name)}\" cannot be empty.", nameof(name));
            }
            Size = size;
            Name = name;
        }
        public SquareMatrix(IList<IList<double>> matrix, string name) : this(matrix.Count(), name)
        {
            if (matrix == null)
            {
                throw new ArgumentNullException("Matrix cannot be null", nameof(matrix));
            }
            if(CheckSizes(matrix) == false)
            {
                throw new ArgumentException("Sizes of rows are not the same");
            }
            _matrix = matrix;
            Name = name;
        }
        public double this[int row, int column]
        {
            get
            {
                if(row >= Size || column >= Size || row < 0 || column < 0)
                {
                    throw new IndexOutOfRangeException("Index was out of range");
                }
                return _matrix[row][column];
            }
            set
            {
                if (row >= Size || column >= Size || row < 0 || column < 0)
                {
                    throw new IndexOutOfRangeException("Index was out of range");
                }
                _matrix[row][column] = value;
            }
        }
        public static SquareMatrix operator-(SquareMatrix a, SquareMatrix b)
        {
            if (a.Size != b.Size) throw new InvalidOperationException("Sizes of matrices are not equal");
            IList<IList<double>> newMatrixCarcass = new List<IList<double>>();

            for (int i = 0; i < a.Size; i++)
            {
                newMatrixCarcass.Add(new List<double>());
                for (int j = 0; j < a.Size; j++)
                {
                    newMatrixCarcass[i].Add(a[i, j] - b[i, j]);
                }
            }
            return new SquareMatrix(newMatrixCarcass, a.Name + b.Name);
        }
        public static bool operator ==(SquareMatrix a, SquareMatrix b)
        {
            if (a.Size != b.Size) return false;
            for (int i = 0; i < a.Size; i++)
            {
                for (int j = 0; j < a.Size; j++)
                {
                    if(a[i,j] != b[i, j])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        public static bool operator !=(SquareMatrix a, SquareMatrix b) => !(a == b);
        public static explicit operator string(SquareMatrix matrix)
        {
            var max = matrix.Max();
            var min = matrix.Min();
            return string.Format("Matrix: {0}, size: {1}, max element: {2}, min element: {3}", matrix.Name, matrix.Size, max, min);
        }
        public override string ToString()
        {
            return string.Format("{0}. Size: {1}", Name, Size);
        }
        public IEnumerable<IList<double>> GetRows()
        {
            foreach (var row in _matrix)
            {
                yield return row;
            }
        }
        public IEnumerator<double> GetEnumerator()
        {
            foreach (var row in _matrix)
            {
                foreach (var num in row)
                {
                    yield return num;
                }
            }
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        public static SquareMatrix Empty(int size)
        {
            var carcass = new List<IList<double>>();
            for (int i = 0; i < size; i++)
            {
                carcass.Add(new List<double>());
                for (int j = 0; j < size; j++)
                {
                    carcass[i].Add(0.0);
                }
            }
            return new SquareMatrix(carcass, "A");
        }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj)) return true;
            if (ReferenceEquals(obj, null)) return false;
            if (obj is SquareMatrix sq) return sq == this;
            return false;
        }
        public override int GetHashCode()
        {
            return Name.GetHashCode() * Size;
        }
        private bool CheckSizes(IList<IList<double>> matrix)
        {
            var rowCount = matrix.Count();
            return matrix.All(row => row.Count() == rowCount);
        }
    }
}
