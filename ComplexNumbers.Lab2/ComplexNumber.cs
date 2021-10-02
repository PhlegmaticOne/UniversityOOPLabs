using System;

namespace ComplexNumbers.Lab2
{
    public class ComplexNumber
    {
        public double RealPart { get; }
        public double ImaginaryPart { get; }
        public  double Module => Math.Sqrt(RealPart * RealPart + ImaginaryPart * ImaginaryPart);
        public  double Angle
        {
            get
            {
                if (IsImaginary) return Math.PI / 2;
                if (IsReal) return 0;
                return Math.Atan2(ImaginaryPart, RealPart);
            }
        }
        public bool IsImaginary => RealPart == 0;
        public bool IsReal => ImaginaryPart == 0;
        public ComplexNumber(double realPart, double imaginaryPart)
        {
            if (realPart == 0 && imaginaryPart == 0)
            {
                throw new ArgumentException("Module of an complex number cannot be less or equal to 0");
            }
            ImaginaryPart = imaginaryPart;
            RealPart = realPart;
        }
        public static ComplexNumber operator +(ComplexNumber a, ComplexNumber b)
        {
            return new ComplexNumber(a.RealPart + b.RealPart, a.ImaginaryPart + b.ImaginaryPart);
        }
        public static ComplexNumber operator -(ComplexNumber a, ComplexNumber b)
        {
            return new ComplexNumber(a.RealPart - b.RealPart, a.ImaginaryPart - b.ImaginaryPart);
        }
        public static ComplexNumber operator *(ComplexNumber a, ComplexNumber b)
        {
            return new ComplexNumber(a.RealPart * b.RealPart - a.ImaginaryPart * b.ImaginaryPart,
                                     a.RealPart * b.ImaginaryPart + b.RealPart * a.ImaginaryPart);
        }
        public static ComplexNumber operator /(ComplexNumber a, ComplexNumber b)
        {
            var denominator = b.RealPart * b.RealPart + b.ImaginaryPart * b.ImaginaryPart;
            var numerator1 = (a.RealPart * b.RealPart + a.ImaginaryPart * b.ImaginaryPart) / denominator;
            var numerator2 = (a.ImaginaryPart * b.RealPart - b.ImaginaryPart * a.RealPart) / denominator;
            return new ComplexNumber(numerator1, numerator2);
        }
        public override string ToString() => ToString(ComplexNumberOutput.Algebraic);
        public string ToString(ComplexNumberOutput outputStyle)
        {
            switch (outputStyle)
            {
                case ComplexNumberOutput.Exponential:
                {
                    return string.Format("{0:f4} * e^(i * {1:f4})", Module, Angle);
                }
                    
                case ComplexNumberOutput.Trigonometric:
                {
                    if (IsReal)
                        return RealPart.ToString();
                    else if (IsImaginary)
                        return string.Format("cos({0:f4})+ i * sin({0:f4})", Angle);
                    return string.Format("{0:f4} * (cos({1:f4}) + i * sin({1:f4}))", Module, Angle);
                }

                case ComplexNumberOutput.Algebraic:
                default:
                    if (ImaginaryPart == 0.0)
                        return string.Format("{0:f4}", RealPart);
                    else if (RealPart == 0.0)
                        return string.Format("{0:f4} * i", ImaginaryPart);
                    return string.Format("({0:f4} + {1:f4} * i)", RealPart, ImaginaryPart);
            }
        }
        public override bool Equals(object obj)
        {
            if (obj is ComplexNumber number)
            {
                return ImaginaryPart == number.ImaginaryPart && RealPart == number.RealPart;
            }
            return false;
        }
        public override int GetHashCode()
        {
            return (ImaginaryPart * RealPart).ToString().GetHashCode();
        }
    }
}
