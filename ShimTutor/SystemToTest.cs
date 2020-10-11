
namespace ShimTutor
{
    public class SystemToTest
    {
        public string MethodToTest(string input)
        {
            return $"{Capitalize(input)}_{LowerCase(input)}";
        }

        // ------------------------------------------------

        private string Capitalize(string input)
        {
            return input.ToUpper();
        }

        // ------------------------------------------------

        private string LowerCase(string input)
        {
            return input.ToLower();
        }
    }
}
