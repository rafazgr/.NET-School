namespace MatrixTask
{
    class Program
    {
        static void Main()
        {
            DiagonalMatrix<int> matrix1 = new DiagonalMatrix<int>(3);
            matrix1[0, 0] = 1;
            matrix1[1, 1] = 2;
            matrix1[2, 2] = 3;

            DiagonalMatrix<int> matrix2 = new DiagonalMatrix<int>(3);
            matrix2[0, 0] = 4;
            matrix2[1, 1] = 5;
            matrix2[2, 2] = 6;

            Console.WriteLine("Matrix 1");
            Console.WriteLine(matrix1);
            Console.WriteLine("Matrix 2");
            Console.WriteLine(matrix2);

            DiagonalMatrix<int> sumMatrix = matrix1.Add(matrix2, (x, y) => x + y);
            Console.WriteLine("Matrix 1 + Matrix 2");
            Console.WriteLine(sumMatrix);

            MatrixTracker<int> tracker = new MatrixTracker<int>(matrix1);
            matrix1[1, 1] = 3;
            Console.WriteLine("Element changed on Matrix 1");
            Console.WriteLine(matrix1);
            tracker.Undo();
            Console.WriteLine("Matrix 1 after Undo");
            Console.WriteLine(matrix1);
        }
    }
}