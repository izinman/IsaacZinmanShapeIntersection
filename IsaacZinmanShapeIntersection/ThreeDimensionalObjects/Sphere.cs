using System.Diagnostics.CodeAnalysis;
using ShapeIntersectionEngine.InputParsing;

namespace ShapeIntersectionEngine.ThreeDimensionalObjects
{
    /// <summary>
    /// A sphere shape - not used in the implementation, but provided as an example
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class Sphere : Shape
    {
        public Vector3 Origin { get; }

        public double Radius { get; }

        public Sphere(Vector3 origin, double radius) : base(ValidShapes.Sphere)
        { 
            Origin = origin;
            Radius = radius;
        } 

        public override double Volume
        {
            get 
            {
                return (4.0 / 3.0) * Math.PI * Math.Pow(Radius, 3);
            }
        }
    }
}
