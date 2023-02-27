using ShapeIntersectionEngine.ThreeDimensionalObjects;

namespace ShapeIntersectionTests.ThreeDimensionalObjects
{
    /// <summary>
    /// Tests to verify logic on Box (in this case, just the Volume calculation).
    /// </summary>
    public class BoxTests
    {
        [Theory]
        [InlineData(1, 2, 3)]
        [InlineData(2, 3, 4)]
        [InlineData(.4, .77, 3.96)]
        [InlineData(.000001, .002, 14)]
        [InlineData(0, 3, 29)]
        [InlineData(3012, 44, 2820)]
        public void Volume_Correct(double x, double y, double z)
        {
            var dimensionsVector = new Vector3(x, y, z);
            var testBox = new Box(new Vector3(), dimensionsVector);
            Assert.Equal(x * y * z, testBox.Volume);
        }
    }
}