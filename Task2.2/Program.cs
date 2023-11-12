public class DiagonalMatrix
{
    private int[] diagonalElements;

    public int Size { get; }

    public DiagonalMatrix(params int[] elements)
    {
        if (elements == null)
        {
            Size = 0;
            diagonalElements = new int[0];
        }
        else
        {
            Size = elements.Length;
            diagonalElements = new int[Size];
            Array.Copy(elements, diagonalElements, Size);
        }
    }

    public int this[int i, int j]
    {
        get
        {
            if (i < 0 || i >= Size || j < 0 || j >= Size || i != j)
            {
                return 0;
            }
            return diagonalElements[i];
        }
        set
        {
            if (i >= 0 && i < Size && j >= 0 && j < Size && i == j)
            {
                diagonalElements[i] = value;
            }
        }
    }

    public int Track()
    {
        int sum = 0;
        for (int i = 0; i < Size; i++)
        {
            sum += diagonalElements[i];
        }
        return sum;
    }

    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
            return false;

        DiagonalMatrix other = (DiagonalMatrix)obj;

        if (Size != other.Size)
            return false;

        for (int i = 0; i < Size; i++)
        {
            if (this[i, i] != other[i, i])
                return false;
        }

        return true;
    }

    public override int GetHashCode()
    {
        return diagonalElements.GetHashCode();
    }

    public override string ToString()
    {
        return $"DiagonalMatrix({string.Join(", ", diagonalElements)})";
    }
}

public static class DiagonalMatrixExtensions
{
    public static DiagonalMatrix Add(this DiagonalMatrix matrix1, DiagonalMatrix matrix2)
    {
        int maxSize = Math.Max(matrix1.Size, matrix2.Size);
        int[] resultElements = new int[maxSize];

        for (int i = 0; i < maxSize; i++)
        {
            resultElements[i] = matrix1[i, i] + matrix2[i, i];
        }

        return new DiagonalMatrix(resultElements);
    }
}

class Program
{
    static void Main()
    {
        DiagonalMatrix matrix1 = new DiagonalMatrix(2, 4, 6, 8);
        DiagonalMatrix matrix2 = new DiagonalMatrix(9, 6, 3);

        Console.WriteLine($"Matrix 1: {matrix1}");
        Console.WriteLine($"Matrix 2: {matrix2}");

        DiagonalMatrix result = matrix1.Add(matrix2);
        Console.WriteLine($"Matrix Sum: {result}");
    }
}