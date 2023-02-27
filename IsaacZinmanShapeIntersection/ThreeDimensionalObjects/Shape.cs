using ShapeIntersectionEngine.InputParsing;

namespace ShapeIntersectionEngine.ThreeDimensionalObjects
{
    /// <summary>
    /// Abstract base class for all other 3D shapes. Exposes a Volume property that must be overridden in child classes.
    /// </summary>
    public abstract class Shape
    {
        public abstract double Volume { get; }
        public ValidShapes ShapeType { get; }

        public Shape(ValidShapes shapeType)
        {
            ShapeType = shapeType;
        }
    }
}
