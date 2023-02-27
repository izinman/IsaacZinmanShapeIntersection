using ShapeIntersectionEngine.Exceptions;
using ShapeIntersectionEngine.ThreeDimensionalObjects;

namespace ShapeIntersectionEngine.InputParsing
{
    /// <summary>
    /// Factory class which takes a string input and converts it to the appropriate concrete sublass of Shape. Currently only Cube is implemented.
    /// </summary>
    public static class InputParser
    {
        public static Shape ParseShape(string input, ValidShapes shape) => shape switch
        {
            ValidShapes.Cube => ParseCube(input),
            _ => throw new NotImplementedException("Shapes besides cubes have not yet been implemented")
        };

        private static Cube ParseCube(string? boxInput)
        {
            if (boxInput == null)
            {
                throw new ArgumentNullException(nameof(boxInput));
            }

            var tokens = boxInput.Split(' ').ToList();
            if (tokens.Count != 4)
            {
                throw new ArgumentException();
            }

            foreach (var token in tokens)
            {
                if (token.ContainsNonNumericCharacters())
                {
                    throw new NonNumericalInputException();
                }
            }


            double xCoord;
            double yCoord;
            double zCoord;
            double dimensions;
            try
            {
                xCoord = double.Parse(tokens[0]);
                yCoord = double.Parse(tokens[1]);
                zCoord = double.Parse(tokens[2]);
                dimensions = double.Parse(tokens[3]);
            }
            catch
            {
                throw new NonNumericalInputException();
            }

            if (IsInvalidValue(xCoord) || IsInvalidValue(yCoord) || IsInvalidValue(zCoord) || IsInvalidValue(dimensions))
            {
                throw new ArgumentOutOfRangeException();
            }

            if (dimensions <= 0)
            {
                throw new InvalidDimensionsException();
            }

            var coordinates = new Vector3(xCoord, yCoord, zCoord);

            return new Cube(coordinates, dimensions);
        }

        private static bool IsInvalidValue(double number)
        {
            if (number == double.PositiveInfinity || number == double.NegativeInfinity || number == double.NaN)
            {
                return true;
            }

            return false;
        }
    }


}
