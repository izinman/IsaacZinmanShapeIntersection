# IsaacZinmanShapeIntersection
This is a simple C# program to compute the volume of intersection of two cubes in 3D. It is designed primarily for simplicity and readability, while also allowing for future extension.

## Assumptions
The following is assumed:
1. A cube is a three-dimensional rectangular prism with equal dimensions in the X, Y, and Z axes.
2. Cubes are not rotated in the X, Y, and Z axis. That is, there is a single vertex which represents the minimum X, Y, and Z point on the cube, and from there, the cube extends precisely in the positive X, Y, and Z directions.

## Building and running the solution
The C# solution was written using Visual Studio 2022, and is .NET6-based. On a computer with the appropriate version of the .NET runtime installed, it can be built and run using either Visual Studio, or via the dotnet CLI, by executing `dotnet build` and `dotnet run --project .\IsaacZinmanShapeIntersection\ShapeIntersectionEngine.csproj` commands from the solution directory. Unit tests can be run using `dotnet test` also from the solution directory, or from within Visual Studio.

## Potential issues and areas for improvement
There are several ways in which the current, simple implementation could be improved.

First, the program uses double-precision floats for all calculations. The program will currently be unable to parse the input if the numbers input are very small or very large (i.e. unable to fit in a 64-bit double). It also could give unexpected slightly-off results, due to floating-point arithmetic. A more sophisticated approach could handle these scenarios more elegantly, for example by using a custom class to store numerals of arbitrary precision.

Second, the user interface is very basic and inflexible. The program could be improved by including typical command-line shortcuts such as a /help command, allowing users to use files directly as inputs using a /fileinput command, prompting for multiple inputs rather than exiting after a single computation, etc.

## Design philosophy
The solution was built with extensibility in mind. The primary design pattern used here is simple polymorphism: the Shape abstract base class can be inherited by other classes, such as a Sphere, which is provided as an example. Currently Box is only used internally to calculate the resulting volume, but the program could be extended to allow the user to specify a Box or Sphere as input. 

Additionally, the solution is modular and follows the Single Responsibility Principle. The UI is simple enough that much of the code is left directly in the Main method of Program.cs, but if this became more complicated in the future (such as adding other flags or input modes, as suggested above) this could easily be factored out to a separate class. All other aspects of the program are handled by a specific class: the InputParser follows the Factory pattern, parsing user input into the appropriate Shape object; shapes are represented as C# objects; and the intersection is calculated by the IntersectionComputationEngine. This would greatly simplify the process of adding additional shapes because each component would simply have to add appropriate methods for the new shapes. Also, the IntersectionComputationEngine is already designed to handle more than two shapes.

## Test coverage
Unit tests are provided to cover success and failure cases for all of the business logic associated with shapes, parsing and computation. Functional, integration and performance tests aren't appropriate due to the simplicity of the program. If, for example, this program were to be integrated with an external API, it would be appropriate to write integration tests to ensure the various components work together successfully especially in exception cases. Tests currently only cover required functionality, meaning intersections of more than 2 cubes is not currently covered by unit tests.