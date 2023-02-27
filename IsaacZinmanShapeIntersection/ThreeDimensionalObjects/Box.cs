using ShapeIntersectionEngine.InputParsing;

namespace ShapeIntersectionEngine.ThreeDimensionalObjects
{
    /// <summary>
    /// A three-dimensional box shape, defined by its minimum vertex coordinate and its dimensions.
    /// </summary>
    /// <remarks>
    /// This is currently only used internally to calculate the area of intersection of two cubes, but could also be 
    /// </remarks>
    public class Box : Shape
    {
        // This vector represents the coordinates of the corner of the box that has minimum x, y, and z values
        public Vector3 MinimumCoordinates { get; }

        // This vector represents the x, y and z dimensions of the box
        public Vector3 Dimensions { get; }
        public Box(Vector3 minimumCoordinates, Vector3 dimensions, ValidShapes shapeType = ValidShapes.Box) : base(shapeType)
        {
            MinimumCoordinates = minimumCoordinates;
            Dimensions = dimensions;
        }

        public override double Volume 
        { 
            get
            {
                 return Dimensions.X * Dimensions.Y * Dimensions.Z;
            } 
        }

        public override bool Equals(object otherObject)
        {
            return Equals(otherObject as Box);
        }

        public bool Equals(Box otherBox)
        {
            return otherBox != null && this.MinimumCoordinates.Equals(otherBox.MinimumCoordinates) &&
                                       this.Dimensions.Equals(otherBox.Dimensions);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(MinimumCoordinates, Dimensions);
        }
    }
}
