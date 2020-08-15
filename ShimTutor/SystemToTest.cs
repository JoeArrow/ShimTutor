
namespace ShimTutor
{
    public static class SystemToTest
    {
        public static string MethodToTest(string input)
        {
            return $"{Capitalize(input)}_{LowerCase(input)}";
        }

        // ------------------------------------------------

        private static string Capitalize(string input)
        {
            return input.ToUpper();
        }

        // ------------------------------------------------

        private static string LowerCase(string input)
        {
            return input.ToLower();
        }
    }
}
