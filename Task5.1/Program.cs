namespace SparseMatrixTask
{
    class Program
    {
        static void Main()
        {
            SparseMatrix matrix = new SparseMatrix(4, 5);
            // SparseMatrix matrix2 = new SparseMatrix(-1, 0); // This will throw an exception

            matrix[0, 1] = 5;
            matrix[1, 2] = 8;
            matrix[2, 0] = 3;
            matrix[2, 3] = 2;
            matrix[3, 1] = 5;
            matrix[3, 3] = 5;
            matrix[3, 4] = 7;
            //matrix[4, 5] = 7; // This will throw an exception

            Console.WriteLine(matrix);

            Console.WriteLine("All Elements:");
            foreach (var element in matrix)
            {
                Console.Write($"{element} ");
            }

            Console.WriteLine("\n\nNonzero Elements:");
            foreach (var element in matrix.GetNonzeroElements())
            {
                Console.WriteLine($"({element.Item1}, {element.Item2}): {element.Item3}");
            }

            Console.WriteLine("\nCount of 0 in the matrix: " + matrix.GetCount(0));
            Console.WriteLine("Count of 1 in the matrix: " + matrix.GetCount(1));
            Console.WriteLine("Count of 3 in the matrix: " + matrix.GetCount(3));
            Console.WriteLine("Count of 5 in the matrix: " + matrix.GetCount(5));
        }
    }
}