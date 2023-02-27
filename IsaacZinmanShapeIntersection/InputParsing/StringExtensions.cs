namespace ShapeIntersectionEngine.InputParsing
{
    /// <summary>
    /// Contains a utility method to search for non-numeric characters in a string
    /// </summary>
    public static class StringExtensions
    {
        private static readonly char[] _validNumerals = { '-', '.', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        public static bool ContainsNonNumericCharacters(this string str)
        {
            foreach (char c in str)
            {
                if (!_validNumerals.Contains(c))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
