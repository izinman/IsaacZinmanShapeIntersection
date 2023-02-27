namespace ShapeIntersectionEngine.ThreeDimensionalObjects
{
    /// <summary>
    /// A simple 3-dimensional vector which can represent coordinates or dimensions, depending on context.
    /// </summary>
    /// <remarks>
    /// This could be reasonably implemented as a struct, but we adhere to the Microsoft guidelines and make it a class since it exceeds 16 bytes: https://learn.microsoft.com/en-us/dotnet/standard/design-guidelines/choosing-between-class-and-struct
    /// </remarks>
    public class Vector3
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public Vector3()
        {
            X = 0;
            Y = 0;
            Z = 0;
        }

        public Vector3(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public static Vector3 operator +(Vector3 left, Vector3 right)
        {
            return new Vector3(left.X + right.X, left.Y + right.Y, left.Z + right.Z);
        }

        public static Vector3 operator -(Vector3 left, Vector3 right)
        {
            return new Vector3(left.X - right.X, left.Y - right.Y, left.Z - right.Z);
        }

        public override bool Equals(object otherObject)
        {
            return Equals(otherObject as Vector3);
        }

        public bool Equals(Vector3 otherVector)
        {
            return otherVector != null && this.X == otherVector.X &&
                                     this.Y == otherVector.Y &&
                                     this.Z == otherVector.Z;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y, Z);
        }
    }
}
