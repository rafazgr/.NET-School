class Program
{
    static int[] RemoveDuplicates(int[] array)
    {
        int length = array.Length;
        int newSize = 0; // The size of the new array with unique elements
        int[] uniqueArray = new int[length];

        for (int i = 0; i < length; i++)
        {
            bool isDuplicate = false;
            for (int j = 0; j < newSize; j++)
            {
                if (array[i] == uniqueArray[j])
                {
                    isDuplicate = true;
                    break;
                }
            }
            if (isDuplicate == false)
            {
                uniqueArray[newSize] = array[i];
                newSize++;
            }
        }

        // Create a new array with the exact size of the unique elements 
        int[] resultArray = new int[newSize];
        for (int i = 0; i < newSize; i++)
        {
            resultArray[i] = uniqueArray[i];
        }

        return resultArray;
    }

    static void PrintArray(int[] array)
    {
        foreach (int element in array)
        {
            Console.Write($"{element} ");
        }
        Console.WriteLine();
    }

    static void Main(string[] args)
    {
        Console.Write("Enter the number of elements: ");
        int size = int.Parse(Console.ReadLine());

        int[] originalArray = new int[size];

        for (int i = 0; i < size; i++)
        {
            Console.Write($"Enter element {i + 1}: ");
            originalArray[i] = int.Parse(Console.ReadLine());
        }

        int[] cleanArray = RemoveDuplicates(originalArray);

        Console.Write("Original Array: ");
        PrintArray(originalArray);

        Console.Write("Unique Array: ");
        PrintArray(cleanArray);
    }
}