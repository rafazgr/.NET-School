class Program
{
    static int CountA(int number)
    {
        int count = 0;
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
        Console.WriteLine("Enter the lower limit:");
        int a = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter the upper limit:");
        int b = int.Parse(Console.ReadLine());

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
