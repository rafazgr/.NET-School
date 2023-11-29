namespace RationalNumberTask
{
    public sealed class RationalNumber : IComparable<RationalNumber>
    {
        public int Numerator { get; }
        public int Denominator { get; }

        public RationalNumber(int numerator, int denominator)
        {
            if (denominator == 0)
            {
                throw new ArgumentException("Denominator cannot be zero.");
            }

            int gcd = GreatestCommonDivisor(Math.Abs(numerator), Math.Abs(denominator));
            Numerator = numerator / gcd;
            Denominator = denominator / gcd;

            if (denominator < 0)
            {
                Numerator = -Numerator;
                Denominator = -Denominator;
            }
        }

        public override bool Equals(object obj)
        {
            if (obj is RationalNumber other)
            {
                return Numerator == other.Numerator && Denominator == other.Denominator;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Numerator, Denominator);
        }

        public override string ToString()
        {
            return $"{Numerator}/{Denominator}";
        }

        public int CompareTo(RationalNumber other)
        {
            return ((long)Numerator * other.Denominator).CompareTo((long)other.Numerator * Denominator);
        }

        public static RationalNumber operator +(RationalNumber a, RationalNumber b)
        {
            if (a is null || b is null)
            {
                throw new ArgumentNullException("Operand cannot be null.");
            }

            int numerator = a.Numerator * b.Denominator + b.Numerator * a.Denominator;
            int denominator = a.Denominator * b.Denominator;
            return new RationalNumber(numerator, denominator);
        }

        public static RationalNumber operator -(RationalNumber a, RationalNumber b)
        {
            if (a is null || b is null)
            {
                throw new ArgumentNullException("Operand cannot be null.");
            }

            int numerator = a.Numerator * b.Denominator - b.Numerator * a.Denominator;
            int denominator = a.Denominator * b.Denominator;
            return new RationalNumber(numerator, denominator);
        }

        public static RationalNumber operator *(RationalNumber a, RationalNumber b)
        {
            if (a is null || b is null)
            {
                throw new ArgumentNullException("Operand cannot be null.");
            }

            int numerator = a.Numerator * b.Numerator;
            int denominator = a.Denominator * b.Denominator;
            return new RationalNumber(numerator, denominator);
        }

        public static RationalNumber operator /(RationalNumber a, RationalNumber b)
        {
            if (a is null || b is null)
            {
                throw new ArgumentNullException("Operand cannot be null.");
            }

            if (b.Numerator == 0)
            {
                throw new DivideByZeroException("Cannot divide by zero.");
            }

            int numerator = a.Numerator * b.Denominator;
            int denominator = a.Denominator * b.Numerator;
            return new RationalNumber(numerator, denominator);
        }

        public static explicit operator double(RationalNumber rational)
        {
            return (double)rational.Numerator / rational.Denominator;
        }

        public static implicit operator RationalNumber(int value)
        {
            return new RationalNumber(value, 1);
        }

        private static int GreatestCommonDivisor(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }

            return a;
        }
    }
}
