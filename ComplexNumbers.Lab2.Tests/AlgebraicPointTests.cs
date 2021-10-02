using NUnit.Framework;
using System;

namespace ComplexNumbers.Lab2.Tests
{
    public class PointTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ComplexNumber_ConstructorThrowsExceptionBecauseOfNumberWillEqualToZero()
        {
            Assert.Throws<ArgumentException>(() => new ComplexNumber(0, 0));
        }

        [Test]
        public void ComplexNumber_SuccessfulCreating()
        {
            Assert.DoesNotThrow(() => new ComplexNumber(2, 33));
        }

        [Test]
        public void ComplexNumber_SumOperatorSuccessfulTesting()
        {
            var algNum1 = new ComplexNumber(2, 3);
            var algNum2 = new ComplexNumber(4.55, 44);

            var result = algNum1 + algNum2;

            Assert.AreEqual(6.55, result.RealPart);
            Assert.AreEqual(47, result.ImaginaryPart);
        }

        [Test]
        public void ComplexNumber_SumOperatorBadTesting()
        {
            var algNum1 = new ComplexNumber(2, 3);
            var algNum2 = new ComplexNumber(4.55, 44);

            var result = algNum1 + algNum2;

            Assert.AreNotEqual(123, result.RealPart);
            Assert.AreNotEqual(44, result.ImaginaryPart);
        }

        [Test]
        public void ComplexNumber_DifOperatorSuccessfulTesting()
        {
            var algNum1 = new ComplexNumber(-2, -3);
            var algNum2 = new ComplexNumber(0.55, 4);

            var result = algNum1 - algNum2;

            Assert.AreEqual(-2.55, result.RealPart);
            Assert.AreEqual(-7, result.ImaginaryPart);
        }

        [Test]
        public void ComplexNumber_DifOperatorBadTesting()
        {
            var algNum1 = new ComplexNumber(-2, -3);
            var algNum2 = new ComplexNumber(0.55, 4);

            var result = algNum1 - algNum2;

            Assert.AreNotEqual(-123, result.RealPart);
            Assert.AreNotEqual(-22, result.ImaginaryPart);
        }

        [Test]
        public void ComplexNumber_MulOperatorSuccessfulTesting()
        {
            var algNum1 = new ComplexNumber(2, 3);
            var algNum2 = new ComplexNumber(5, 4);

            var result = algNum1 * algNum2;

            Assert.AreEqual(-2, result.RealPart);
            Assert.AreEqual(23, result.ImaginaryPart);
        }

        [Test]
        public void ComplexNumber_MulOperatorBadTesting()
        {
            var algNum1 = new ComplexNumber(2, 3);
            var algNum2 = new ComplexNumber(5, 4);

            var result = algNum1 * algNum2;

            Assert.AreNotEqual(-234, result.RealPart);
            Assert.AreNotEqual(234, result.ImaginaryPart);
        }

        [Test]
        public void ComplexNumber_DivOperatorSuccessfulTesting()
        {
            var algNum1 = new ComplexNumber(1, 1);
            var algNum2 = new ComplexNumber(2, 2);

            var result = algNum1 / algNum2;

            Assert.AreEqual(0.5, result.RealPart);
            Assert.AreEqual(0, result.ImaginaryPart);
        }

        [Test]
        public void ComplexNumber_DivOperatorBadTesting()
        {
            var algNum1 = new ComplexNumber(1, 1);
            var algNum2 = new ComplexNumber(2, 2);

            var result = algNum1 / algNum2;

            Assert.AreNotEqual(234, result.RealPart);
            Assert.AreNotEqual(22, result.ImaginaryPart);
        }

        [Test]
        public void ComplexNumber_ToStringFullAlgebraicTesting()
        {
            var algNum1 = new ComplexNumber(1, 1);

            Assert.AreEqual("(1,0000 + 1,0000 * i)", algNum1.ToString(ComplexNumberOutput.Algebraic));
        }
        [Test]
        public void ComplexNumber_ToStringOnlyRealAlgebraicTesting()
        {
            var algNum1 = new ComplexNumber(0, 1);

            Assert.AreEqual("1,0000 * i", algNum1.ToString(ComplexNumberOutput.Algebraic));
        }
        [Test]
        public void ComplexNumber_ToStringOnlyImaginaryAlgebraicTesting()
        {
            var algNum1 = new ComplexNumber(1, 0);

            Assert.AreEqual("1,0000", algNum1.ToString(ComplexNumberOutput.Algebraic));
        }
        [Test]
        public void ComplexNumber_ToStringTrigonometricTesting()
        {
            var algNum1 = new ComplexNumber(1, 1);

            Assert.AreEqual("1,4142 * (cos(0,7854) + i * sin(0,7854))", algNum1.ToString(ComplexNumberOutput.Trigonometric));
        }
        [Test]
        public void ComplexNumber_ToStringExponentialTesting()
        {
            var algNum1 = new ComplexNumber(1, 1);

            Assert.AreEqual("1,4142 * e^(i * 0,7854)", algNum1.ToString(ComplexNumberOutput.Exponential));
        }
    }
}