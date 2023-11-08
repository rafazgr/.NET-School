class Program
{
    static int CountA(int number)
    {
        int count = 0;

        if (number < 0)
        {
            number *= -1;
        }

        while (number > 0)
        {
            // The remainder is one digit of the number
            int digit = number % 12;

            // 10 is A in duodecimal, therefore we count it
            if (digit == 10)
            {
                count++;
            }
            // The whole quotient will continue in successive divisions until we reach 0
            number /= 12;
        }
        return count;
    }

    static void Main()
    {
        int a, b;

        do
        {
            Console.WriteLine("Enter the lower limit:");
            a = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the upper limit:");
            b = int.Parse(Console.ReadLine());

            if (a >= b)
            {
                Console.WriteLine("The lower limit must be less than the upper limit. Please try again.");
            }
        } while (a >= b);

        Console.WriteLine($"Numbers between {a} and {b} with two 'A's in duodecimal form:");

        for (int i = a; i <= b; i++)
        {
            if (CountA(i) == 2)
            {
                Console.WriteLine($"Decimal: {i}");
            }
        }
    }
}