
public class PointWithMass
{
    private int[] coordinates = new int[3];
    private double mass;

    public int X
    {
        get { return coordinates[0]; }
        set { coordinates[0] = value; }
    }

    public int Y
    {
        get { return coordinates[1]; }
        set { coordinates[1] = value; }
    }

    public int Z
    {
        get { return coordinates[2]; }
        set { coordinates[2] = value; }
    }

    public double Mass
    {
        get { return mass; }
        set { mass = Math.Max(value, 0); }
    }

    public bool IsZero()
    {
        return X == 0 && Y == 0 && Z == 0;
    }

    public double CalculateDistance(PointWithMass otherPoint)
    {
        int deltaX = X - otherPoint.X;
        int deltaY = Y - otherPoint.Y;
        int deltaZ = Z - otherPoint.Z;

        return Math.Sqrt(deltaX * deltaX + deltaY * deltaY + deltaZ * deltaZ);
    }
}

class Program
{
    static void Main()
    {
        PointWithMass point1 = new PointWithMass { X = 1, Y = 2, Z = 3, Mass = 5.0 };
        PointWithMass point2 = new PointWithMass { X = 4, Y = 5, Z = 6, Mass = -2.0 }; // Mass should be set to 0
        PointWithMass point3 = new PointWithMass { X = 0, Y = 0, Z = 0, Mass = 0 };

        // Displaying coordinates and mass
        Console.WriteLine($"Point 1: X={point1.X}, Y={point1.Y}, Z={point1.Z}, Mass={point1.Mass}");
        Console.WriteLine($"Point 2: X={point2.X}, Y={point2.Y}, Z={point2.Z}, Mass={point2.Mass}");
        Console.WriteLine($"Point 3: X={point3.X}, Y={point3.Y}, Z={point3.Z}, Mass={point3.Mass}");

        // Checking if a point is zero
        Console.WriteLine($"Is Point 1 zero? {point1.IsZero()}"); // Should be false
        Console.WriteLine($"Is Point 2 zero? {point2.IsZero()}"); // Should be false
        Console.WriteLine($"Is Point 3 zero? {point3.IsZero()}"); // Should be true

        // Calculating distance between two points
        double distance = point1.CalculateDistance(point2);
        Console.WriteLine($"Distance between Point 1 and Point 2: {distance}");
    }
}