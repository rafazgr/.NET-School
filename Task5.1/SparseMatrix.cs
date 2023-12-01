using System.Collections;
using System.Text;

namespace SparseMatrixTask
{
    public class SparseMatrix : IEnumerable<long>
    {
        private Dictionary<(int, int), long> matrix;
        private int rows;
        private int columns;

        public SparseMatrix(int rows, int columns)
        {
            if (rows <= 0 || columns <= 0)
                throw new ArgumentException("Rows and columns must be strictly greater than zero.");

            this.rows = rows;
            this.columns = columns;
            matrix = new Dictionary<(int, int), long>();
        }

        private void VerifyIndex(int i, int j)
        {
            if (i < 0 || i >= rows || j < 0 || j >= columns)
                throw new IndexOutOfRangeException("Invalid matrix indices.");
        }

        public long this[int i, int j]
        {
            get
            {
                VerifyIndex(i, j);

                return matrix.TryGetValue((i, j), out var value) ? value : 0;
            }
            set
            {
                VerifyIndex(i, j);

                if (value != 0)
                    matrix[(i, j)] = value;
                else if (matrix.ContainsKey((i, j)))
                    matrix.Remove((i, j));
            }
        }

        public IEnumerator<long> GetEnumerator()
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    yield return this[i, j];
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public IEnumerable<(int, int, long)> GetNonzeroElements()
        {
            for (int j = 0; j < columns; j++)
            {
                for (int i = 0; i < rows; i++)
                {
                    if (matrix.TryGetValue((i, j), out long value))
                    {
                        yield return (i, j, value);
                    }
                }
            }
        }

        public int GetCount(long x)
        {
            return x == 0 ? rows * columns - matrix.Count : matrix.Count(entry => entry.Value == x);
        }

        public override string ToString()
        {
            StringBuilder resultBuilder = new StringBuilder();

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    resultBuilder.Append($"{this[i, j]} ");
                }

                resultBuilder.AppendLine();
            }

            return resultBuilder.ToString();
        }

    }
}