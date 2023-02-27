using ShapeIntersectionEngine.InputParsing;

namespace ShapeIntersectionEngine.ThreeDimensionalObjects
{
    /// <summary>
    /// A special case of a <see cref="Box"/> where all three dimensions are the same
    /// </summary>
    public class Cube : Box
    {
        public Cube(Vector3 minimumCoordinates, double dimensions) : base(minimumCoordinates, new Vector3(dimensions, dimensions, dimensions), ValidShapes.Cube)
        {

        }
    }
}
