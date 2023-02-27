using ShapeIntersectionEngine.Exceptions;
using ShapeIntersectionEngine.InputParsing;
using ShapeIntersectionEngine.ThreeDimensionalObjects;

namespace ShapeIntersectionTests
{
    /// <summary>
    /// Tests to verify input parser ability to reject invalid input and correctly parse well-formed inputs
    /// </summary>
    public class InputParserTests
    {
        [Theory]
        [InlineData(ValidShapes.Sphere)]
        [InlineData(ValidShapes.Box)]
        public void ParseShape_UnsupportedShapeType_ThrowsNotImplementedException(ValidShapes shapeType)
        {
            string testString = "0 1 2 3";
            Assert.Throws<NotImplementedException>( () => InputParser.ParseShape(testString, shapeType));
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("3.5 2 1")]
        [InlineData("1 2")]
        [InlineData("1234")]
        [InlineData("1 2 3 4 5")]
        [InlineData("0.6 3.82 5.56 1.49 3.12")]
        public void ParseCube_IncorrectNumberOfTokens_ThrowsArgumentException(string input)
        {
            Assert.ThrowsAny<ArgumentException>( () => InputParser.ParseShape(input, ValidShapes.Cube));
        }

        [Theory]
        [InlineData("123, 456, 789, 10")]
        [InlineData("4.3 8.6x 5.5 19")]
        [InlineData("4_21 3.5 2.5 1.5")]
        [InlineData("1 2 3 4'4")]
        [InlineData("2tlk tyasd4oaii oq5lak gj7z")]
        public void ParseCube_MalformedInput_ThrowsNonNumericalInputException(string input)
        {
            Assert.Throws<NonNumericalInputException>( () => InputParser.ParseShape(input, ValidShapes.Cube));
        }

        [Theory]
        [InlineData("0")]
        [InlineData("-1.2")]
        [InlineData("-200")]
        [InlineData("0.00")]
        public void ParseCube_InvalidDimensions_ThrowsInvalidDimensionsException(string dimensionsAsString)
        {
            var cubeString = string.Concat("0 0 0 ", dimensionsAsString);
            Assert.Throws<InvalidDimensionsException>( () => InputParser.ParseShape(cubeString, ValidShapes.Cube));
        }

        [Theory]
        [MemberData(nameof(GenerateValidCubes))]
        public void ParseCube_Valid_ReturnsExpectedCube(string inputString, Cube expectedCube)
        {
            Assert.Equal(expectedCube, InputParser.ParseShape(inputString, ValidShapes.Cube));
        }

        [Fact]
        public void ParseCube_VeryLargeNumber_ThrowsArgumentOutOfRangeException()
        {
            var veryLargeCube = "1 10 110 15";
            veryLargeCube += new string('0', 1000);
            Assert.Throws<ArgumentOutOfRangeException>(() => InputParser.ParseShape(veryLargeCube, ValidShapes.Cube));

            var veryFarawayCube = "1 10 ";
            veryFarawayCube = veryFarawayCube + "-2" + new string('0', 1500) + " 100";
            Assert.Throws<ArgumentOutOfRangeException>(() => InputParser.ParseShape(veryFarawayCube, ValidShapes.Cube));
        }

        /// <summary>
        /// Helper method to generate pairs of input strings and expected resulting Cube object
        /// </summary>
        public static IEnumerable<object[]> GenerateValidCubes()
        {
            yield return new object[]
            {
                "0 0 0 1", new Cube(new Vector3(0, 0, 0), 1)
            };
            yield return new object[]
            {
                "0.4 1.6 8.2 3.33", new Cube(new Vector3(0.4, 1.6, 8.2), 3.33)
            };
            yield return new object[]
            {
                "-14.52 6.18 0.039 2.59", new Cube(new Vector3(-14.52, 6.18, 0.039), 2.59)
            };
            yield return new object[]
            {
                "1823774 95017293 48573130 24885123", new Cube(new Vector3(1823774, 95017293, 48573130), 24885123)
            };
            yield return new object[]
            {
                "-15 -3 -109 0.00512", new Cube(new Vector3(-15, -3, -109), 0.00512)
            };
        }
    }
}
