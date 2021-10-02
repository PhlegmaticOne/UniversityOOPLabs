using System;

namespace SquareMatrix.Lab3
{
    public class DiagonalResult : IEquatable<DiagonalResult>
    {
        public int DiagonalNumber { get; }
        public double OperationResult { get; }
        public DiagonalResult(int diagonalNumber, double operationResult)
        {
            DiagonalNumber = diagonalNumber;
            OperationResult = operationResult;
        }
        public override string ToString()
        {
            return string.Format("Diagonal: {0}, Result: {1}", DiagonalNumber, OperationResult);
        }

        public bool Equals(DiagonalResult other)
        {
            return DiagonalNumber == other.DiagonalNumber && OperationResult.CompareTo(other.OperationResult) == 0;
        }
    }
}
