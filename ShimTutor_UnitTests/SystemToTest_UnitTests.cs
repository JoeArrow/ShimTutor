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
            // --------------------------------------------
            // All Shims must be used within a ShimsContext
            // Otherwise, there is a possibility of leaving
            // the Shim(s) in place.
            //
            // There is no corresponding StubsContext.

            using(ShimsContext.Create())
            {
                // -------
                // Arrange

                var sut = new SystemToTest();

                ShimTutor.Fakes.ShimSystemToTest.AllInstances.CapitalizeString = (SystemToTest s, string inp) => { return inp.ToLower(); };
                ShimTutor.Fakes.ShimSystemToTest.AllInstances.LowerCaseString = (SystemToTest s, string imp) => { return imp.ToUpper(); };

                // ---
                // Act

                var resp = sut.MethodToTest(input);

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
            // -------
            // Arrange

            var sut = new SystemToTest();

            // ---
            // Act

            var resp = sut.MethodToTest(input);

            // ------
            // Assert

            Assert.AreEqual(expected, resp);
        }
    }
}
