namespace MatrixTask
{
    public static class DiagonalMatrixExtensions
    {
        public static DiagonalMatrix<T> Add<T>(this DiagonalMatrix<T> matrix1, DiagonalMatrix<T> matrix2, Func<T, T, T> addFunction)
        {
            int maxSize = Math.Max(matrix1.Size, matrix2.Size);
            DiagonalMatrix<T> resultMatrix = new DiagonalMatrix<T>(maxSize);

            for (int i = 0; i < maxSize; i++)
            {
                T value1 = matrix1[i, i];
                T value2 = matrix2[i, i];
                resultMatrix[i, i] = addFunction(value1, value2);
            }

            return resultMatrix;
        }
    }
}
