namespace RationalNumberTask
{
    class Program
    {
        static void Main()
        {
            RationalNumber r1 = new RationalNumber(4, 6);
            RationalNumber r2 = new RationalNumber(5, 10);
            RationalNumber r3 = new RationalNumber(2, 3);
            // RationalNumber r4 = new RationalNumber(4, 0); // This will throw an exception

            Console.WriteLine($"r1: {r1}");
            Console.WriteLine($"r2: {r2}");
            Console.WriteLine($"r3: {r3}");

            Console.WriteLine($"r1 equals r2: {r1.Equals(r2)}");
            Console.WriteLine($"r1 equals r3: {r1.Equals(r3)}");

            Console.WriteLine($"r1 + r2: {r1 + r2}");
            Console.WriteLine($"r1 - r2: {r1 - r2}");
            Console.WriteLine($"r1 * r2: {r1 * r2}");
            Console.WriteLine($"r1 / r2: {r1 / r2}");

            Console.WriteLine($"r1 compared to r2: {r1.CompareTo(r2)}");
            Console.WriteLine($"r2 compared to r3: {r2.CompareTo(r3)}");
            Console.WriteLine($"r1 compared to r3: {r1.CompareTo(r3)}");

            double r1AsDouble = (double)r1;
            Console.WriteLine($"r1 as double: {r1AsDouble}");

            RationalNumber intToRational = 5;
            Console.WriteLine($"5 as rational: {intToRational}");
        }
    }
}
