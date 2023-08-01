/*  Complex Number
    Requirements
    ----------------------
    Implement a class that represents a complex number along with all the basic operations
    Implement a method to return the absolute value of the current number
    Overload plus, minus, and multiply by a scalar operators
    Overload implicit and explicit cast operators for the real part of the number
    Overload ToString method to return the string representation of the current number
*/

    public class ComplexNumber
    {
        public double Real { get; set; }
        public double Imaginary { get; set; }

        public ComplexNumber(double real = 0.0, double imaginary = 0.0)
        {
            Real = real;
            Imaginary = imaginary;
        }

        //a method to return the absolute value of the current number
        public double Absolute()
        {
            return Math.Sqrt(Real * Real + Imaginary * Imaginary);
        }

        //plus operator
        public static ComplexNumber operator +(ComplexNumber c1, ComplexNumber c2)
        {
            return new ComplexNumber(c1.Real + c2.Real, c1.Imaginary + c2.Imaginary);
        }

        //minus operator
        public static ComplexNumber operator -(ComplexNumber c1, ComplexNumber c2)
        {
            return new ComplexNumber(c1.Real - c2.Real, c1.Imaginary - c2.Imaginary);
        }

        // multiply by a scalar operators
        public static ComplexNumber operator *(ComplexNumber c, double scalar)
        {
            return new ComplexNumber(c.Real * scalar, c.Imaginary * scalar);
        }

        public static ComplexNumber operator *(double scalar, ComplexNumber c)
        {
            return c * scalar;
        }

        //implicit cast operator for the real part of the number
        public static implicit operator double(ComplexNumber c)
        {
            return c.Real;
        }

        //explicit cast operator for the real part of the number
        public static explicit operator ComplexNumber(double real)
        {
            return new ComplexNumber(real, 0);
        }

        //ToString method to return the string representation of the current number
        public override string ToString()
        {
            if (Imaginary >= 0)
            {
                return $"{Real} + {Imaginary}i";
            }
            else
            {
                return $"{Real} - {-Imaginary}i";
            }
        }

}

    class Program
    {
        static void Main()
        {
            ComplexNumber c1 = new ComplexNumber(2, 3);
            ComplexNumber c2 = new ComplexNumber(4, 5);

            ComplexNumber c3 = c1 + c2;
            Console.WriteLine(c3.ToString());  // Output: 6 + 8i

            ComplexNumber c4 = c2 - c1;
            Console.WriteLine(c4.ToString());  // Output: 2 + 2i

            ComplexNumber c5 = c1 * 2;
            Console.WriteLine(c5.ToString());  // Output: 4 + 6i

            double realPart = c1;
            Console.WriteLine(realPart.ToString());  // Output: 2

            ComplexNumber c6 = (ComplexNumber)3.5;
            Console.WriteLine(c6.ToString());  // Output: 3.5 + 0i

            Console.ReadLine();
        }
    }


