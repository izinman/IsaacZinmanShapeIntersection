using ShapeIntersectionEngine.ThreeDimensionalObjects;
using ShapeIntersectionEngine.IntersectionComputation;

namespace ShapeIntersectionTests
{
    /// <summary>
    /// Tests to verify correctness of intersection calculation
    /// </summary>
    public class IntersectionComputationEngineTests
    {
        [Theory]
        [MemberData(nameof(GenerateNonOverlappingCubeData))]
        public void ComputeIntersection_NonIntersectingCubes_ReturnsZero(List<Shape> cubes)
        {
            Assert.Equal(0.0, IntersectionComputationEngine.ComputeIntersection(cubes));
        }

        public static IEnumerable<object[]> GenerateNonOverlappingCubeData()
        {
            yield return new object[]
            {
                new List<Shape> { new Cube(new Vector3(0, 0, 0), 1), new Cube(new Vector3(2, 2, 8), 3) }
            };
            yield return new object[]
            {
                new List<Shape> { new Cube(new Vector3(-1, -5, 7), 10), new Cube(new Vector3(18, -5, 7), 8) }
            };
            yield return new object[]
            {
                new List<Shape> { new Cube(new Vector3(0.5, 0.8, 0.99), 1), new Cube(new Vector3(-5.5, 7.9, 14.4), 2.25) }
            };
        }

        [Theory]
        [MemberData(nameof(GenerateParallelButNotIntersectingCubeData))]
        public void ComputeIntersection_ParallelButNotIntersectingCubes_ReturnsZero(List<Shape> cubes)
        {
            Assert.Equal(0.0, IntersectionComputationEngine.ComputeIntersection(cubes));
        }

        public static IEnumerable<object[]> GenerateParallelButNotIntersectingCubeData()
        {
            yield return new object[]
            {
                new List<Shape> { new Cube(new Vector3(0, 0, 0), 1), new Cube(new Vector3(1, 0, 0), 1) }
            };
            yield return new object[]
            {
                new List<Shape> { new Cube(new Vector3(0, 0, 0), 10), new Cube(new Vector3(10, 10, 0), 8) }
            };
            yield return new object[]
            {
                new List<Shape> { new Cube(new Vector3(0.75, 0.2, 0.55), .25), new Cube(new Vector3(1.0, 2.2, 3.3), 8.12) }
            };
        }

        [Theory]
        [MemberData(nameof(GenerateContainedCubeData))]
        public void ComputeIntersection_CubeCompletelyContainedWithinOtherCube_ReturnsSmallerBoxVolume(List<Shape> cubes)
        {
            var minimumVolume = Math.Min(cubes[0].Volume, cubes[1].Volume);

            Assert.Equal(minimumVolume, IntersectionComputationEngine.ComputeIntersection(cubes));
        }

        public static IEnumerable<object[]> GenerateContainedCubeData()
        {
            yield return new object[]
            {
                new List<Shape> { new Cube(new Vector3(0, 0, 0), 1), new Cube(new Vector3(0, 0, 0), 5) }
            };
            yield return new object[]
            {
                new List<Shape> { new Cube(new Vector3(3, 5, 7), 10), new Cube(new Vector3(4, 6, 8), 3) }
            };
            yield return new object[]
            {
                new List<Shape> { new Cube(new Vector3(-13, -12, -11), 10), new Cube(new Vector3(-8, -7, -6), 2.2) }
            };
        }

        [Theory]
        [MemberData(nameof(GeneratePartialOverlapCubeData))]
        public void ComputeIntersection_CubesPartiallyOverlap_ReturnsCorrectVolume(List<Shape> cubes, double expectedResultVolume)
        {
            Assert.Equal(expectedResultVolume, IntersectionComputationEngine.ComputeIntersection(cubes));
        }

        // Expected results hand-calculated
        public static IEnumerable<object[]> GeneratePartialOverlapCubeData()
        {
            yield return new object[]
            {
                new List<Shape> { new Cube(new Vector3(0, 0, 0), 1), new Cube(new Vector3(.5, 0, 0), 1) },
                .5 * 1 * 1
            };
            yield return new object[]
            {
                new List<Shape> { new Cube(new Vector3(-5.25, -4.5, -10), 10), new Cube(new Vector3(-5.25, 1.5, -3.5), 8) },
                8 * 4 * 3.5
            };
        }

        [Fact]
        public void ComputeIntersection_InvalidShapeType_ThrowsNotImplementedException()
        {
            var sphere = new Sphere(new Vector3(), Math.PI);
            var cube = new Cube(new Vector3(), 10.5);
            var testShapes = new List<Shape> { sphere, cube };
            Assert.Throws<NotImplementedException>(() => IntersectionComputationEngine.ComputeIntersection(testShapes));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        public void ComputeIntersection_FewerThanTwoShapeArguments_ThrowsInvalidOperationException(int numShapes)
        {
            var testShapes = new List<Shape>();
            for (int i = 0; i < numShapes; i++)
            {
                var shape = new Cube(new Vector3(), 1.0);
            }

            Assert.Throws<InvalidOperationException>(() => IntersectionComputationEngine.ComputeIntersection(testShapes));
        }
    }
}
