namespace MatrixTask
{
    public class DiagonalMatrix<T>
    {
        private T[] diagonalElements;

        public event EventHandler<MatrixElementChangedEventArgs<T>> ElementChanged;

        public int Size { get; }

        public DiagonalMatrix(int size)
        {
            if (size < 0)
                throw new ArgumentException("Size must be non-negative.");

            Size = size;
            diagonalElements = new T[Size];
        }

        public T this[int i, int j]
        {
            get
            {
                if (i < 0 || i >= Size || j < 0 || j >= Size)
                    throw new IndexOutOfRangeException("Invalid indices.");

                return (i == j) ? diagonalElements[i] : default(T);
            }
            set
            {
                if (i >= 0 && i < Size && j >= 0 && j < Size && i == j)
                {
                    if (!Equals(diagonalElements[i], value))
                    {
                        T oldValue = diagonalElements[i];
                        diagonalElements[i] = value;
                        ElementChanged?.Invoke(this, new MatrixElementChangedEventArgs<T>(i, i, oldValue, value));
                    }
                }
            }
        }

        public override string ToString()
        {
            return $"DiagonalMatrix<{typeof(T).Name}>({string.Join(", ", diagonalElements)})";
        }
    }
}