namespace MatrixTask
{
    public static class DiagonalMatrixExtensions
    {
        public static DiagonalMatrix<T> Add<T>(this DiagonalMatrix<T> matrix1, DiagonalMatrix<T> matrix2, Func<T, T, T> addFunction)
        {
            if (matrix1.Size != matrix2.Size)
            {
                throw new ArgumentException("Matrix sizes must be equal for addition.");
            }

            int maxSize = Math.Max(matrix1.Size, matrix2.Size);
            DiagonalMatrix<T> resultMatrix = new DiagonalMatrix<T>(maxSize);

            for (int i = 0; i < maxSize; i++)
            {
                resultMatrix[i, i] = addFunction(matrix1[i, i], matrix2[i, i]);
            }

            return resultMatrix;
        }
    }
}
