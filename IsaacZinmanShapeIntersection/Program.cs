using ShapeIntersectionEngine;
using ShapeIntersectionEngine.Exceptions;
using ShapeIntersectionEngine.InputParsing;
using ShapeIntersectionEngine.IntersectionComputation;
using ShapeIntersectionEngine.ThreeDimensionalObjects;

internal class Program
{
    static void Main(string[] args)
    {
        List<Shape> shapes;

        // Loop until the user gives a valid input
        while (true)
        {
            shapes = new List<Shape>();
            Console.WriteLine("Please enter the coordinates and dimensions of the cubes for which you would like to calculate the intersection.");
            Console.WriteLine("For each cube, enter a single line which contains four integers or decimals separated by spaces: the first three numbers represent the minimum x, y and z coordinates of the box, and the last number represents the dimensions of the cube.");

            for (int i = 1; i < GlobalConstants.MAX_SHAPES + 1; ++i)
            {
                Console.WriteLine($"Enter coordinates and dimensions for cube {i}:");
                var boxInput = Console.ReadLine();

                // Parse the input, giving user feedback if they give invalid input
                try
                {
                    // If additional non-cube shapes were added in the future, we could detect that from the input and parse a different kind of shape here
                    var box = InputParser.ParseShape(boxInput, ValidShapes.Cube);
                    shapes.Add(box);
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("One or more of the inputs was a Very Large Number. Please enter only numbers that can fit within a double-precision float for each coordinate and the dimensions.");
                    break;
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("There were not four numbers provided as input. Please provide four numbers for each cube, as described above.");
                    break;
                }
                catch (NonNumericalInputException)
                {
                    Console.WriteLine("One or more of the inputs were not recognizable as integers or decimal numbers. Please enter only numerical input for each coordinate and the dimensions.");
                    break;
                }
                catch (InvalidDimensionsException)
                {
                    Console.WriteLine("The number provided for the dimensions of the cube was negative or zero. Please provide only positive numbers for the dimensions.");
                    break;
                }
            }

            // If one or more failed to parse, start from the beginning
            if (shapes.Count == GlobalConstants.MAX_SHAPES)
            {
                break;
            }
        }

        // Compute the intersection volume and print the result
        double resultingVolume = IntersectionComputationEngine.ComputeIntersection(shapes);
        if (resultingVolume > 0)
        {
            Console.WriteLine($"The volume of the intersection of the cubes is {resultingVolume}.");
        }
        else
        {
            Console.WriteLine("The provided cubes do not intersect, and therefore the volume of their intersection is zero.");
        }

        Console.WriteLine("Thanks for using the Shape Intersection Calculator! Goodbye!");
    }
}
