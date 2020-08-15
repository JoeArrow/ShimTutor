using System;

using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using ShimTutor;

namespace ShimTutor_UnitTests
{
    [TestClass]
    public class SystemToTest_UnitTests
    {
        private static string cr = Environment.NewLine;
        private static string crt = $"{Environment.NewLine}\t";

        [TestMethod]
        [DataRow("Input String", "input string_INPUT STRING")]
        public void MethodToTest_Shimed_ShimTutor(string input, string expected)
        {
            using(ShimsContext.Create())
            {
                // -------
                // Arrange

                ShimTutor.Fakes.ShimSystemToTest.CapitalizeString = (string inp) => { return inp.ToLower(); };
                ShimTutor.Fakes.ShimSystemToTest.LowerCaseString = (string imp) => { return imp.ToUpper(); };
                
                // ---
                // Act

                var resp = SystemToTest.MethodToTest(input);

                // ---
                // Log

                Console.WriteLine($"Input:{crt}{input}{cr}Response:{crt}{resp}");

                // ------
                // Assert

                Assert.AreEqual(expected, resp);
            }
        }

        // ------------------------------------------------

        [TestMethod]
        [DataRow("Input String", "INPUT STRING_input string")]
        public void MethodToTest_Unshimed_ShimTutor(string input, string expected)
        {
            // ---
            // Act

            var resp = SystemToTest.MethodToTest(input);

            // ------
            // Assert

            Assert.AreEqual(expected, resp);
        }
    }
}
