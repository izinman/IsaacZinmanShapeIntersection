using ShapeIntersectionEngine.ThreeDimensionalObjects;

namespace ShapeIntersectionEngine.IntersectionComputation
{
    /// <summary>
    /// Class which takes a list of shapes and provides methods to compute the intersected volume of those shapes
    /// </summary>
    public static class IntersectionComputationEngine
    {
        public static double ComputeIntersection(List<Shape> shapes)
        {
            // Currently we only know how to compute the intersection of Boxes. (We use the Box type instead of Cube to simplify the call to the recursive method)
            if (shapes.All(shape => shape is Box))
            {
                return IntersectBoxes(shapes.Select(shape => (shape as Box)!).ToList());
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Uses recursion to compute the intersection of a set of boxes. I.e. if there are 3 boxes in the list, computes the intersection of 1 & 2, then computes the intersection of that with 3.
        /// </summary>
        /// <param name="boxes">The boxes for which to calculate the intersection</param>
        /// <returns>Zero if the boxes do not intersect; otherwise the volume of the intersection of all boxes</returns>
        private static double IntersectBoxes(List<Box> boxes)
        {
            if (boxes.Count < 2)
            {
                throw new InvalidOperationException("Cannot intersect a single box");
            }
            var firstCube = boxes[0];
            var secondCube = boxes[1];

            // Compute minimum coordinates of the intersected cubes by taking the maximum of their minimum coordinates
            var minCoords = new Vector3(Math.Max(firstCube.MinimumCoordinates.X, secondCube.MinimumCoordinates.X),
                                        Math.Max(firstCube.MinimumCoordinates.Y, secondCube.MinimumCoordinates.Y),
                                        Math.Max(firstCube.MinimumCoordinates.Z, secondCube.MinimumCoordinates.Z));

            // Now do the same operation with the maximum coordinates (computed by adding the appropriate dimension to the minimum coordinate)
            var maxCoords = new Vector3(Math.Min(firstCube.MinimumCoordinates.X + firstCube.Dimensions.X, secondCube.MinimumCoordinates.X + secondCube.Dimensions.X),
                                        Math.Min(firstCube.MinimumCoordinates.Y + firstCube.Dimensions.Y, secondCube.MinimumCoordinates.Y + secondCube.Dimensions.Y),
                                        Math.Min(firstCube.MinimumCoordinates.Z + firstCube.Dimensions.Z, secondCube.MinimumCoordinates.Z + secondCube.Dimensions.Z));

            // If they do not intersect, short-circuit and return 0.
            if (minCoords.X >= maxCoords.X || minCoords.Y >= maxCoords.Y || minCoords.Z >= maxCoords.Z)
            {
                return 0;
            }

            var resultBox = new Box(minCoords, maxCoords - minCoords);

            // Recursive base case - if we have computed the intersection of the last two boxes, then we are done and it represents the intersection of all shapes originally passed to this method
            if (boxes.Count == 2)
            {
                return resultBox.Volume;
            }

            // Otherwise, recurse on the remaining list
            var remainingList = new List<Box> { resultBox };
            remainingList.AddRange(boxes.Skip(2));

            return IntersectBoxes(remainingList);
        }
    }
}
