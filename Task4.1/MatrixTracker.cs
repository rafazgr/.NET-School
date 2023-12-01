namespace MatrixTask
{
    public class MatrixTracker<T>
    {
        private DiagonalMatrix<T> matrix;
        private MatrixElementChangedEventArgs<T> lastChange;

        public MatrixTracker(DiagonalMatrix<T> matrix)
        {
            this.matrix = matrix ?? throw new ArgumentNullException(nameof(matrix));
            matrix.ElementChanged += Matrix_ElementChanged;
        }

        public void Undo()
        {
            if (lastChange != null)
            {
                matrix[lastChange.Row, lastChange.Column] = lastChange.OldValue;
                lastChange = null;
            }
        }

        private void Matrix_ElementChanged(object sender, MatrixElementChangedEventArgs<T> e)
        {
            lastChange = e;
        }
    }
}