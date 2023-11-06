class Program
{
    static int CalculateCheckDigit(string digits)
    {
        int sum = 0;
        for (int i = 0; i < 9; i++)
        {
            int digit = int.Parse(digits[i].ToString());
            sum += (10 - i) * digit;
        }

        // We simply add the remaining value to the number so that it is a multiple of 11
        int checkDigit = 11 - (sum % 11);

        return checkDigit;
    }

    static void Main()
    {
        Console.WriteLine("Enter the first 9 digits of the ISBN:");
        string id = Console.ReadLine();

        int checkDigit = CalculateCheckDigit(id);

        string isbn = id + (checkDigit == 10 ? "X" : checkDigit.ToString());

        Console.WriteLine("The ISBN with the check digit is: " + isbn);
    }
}
