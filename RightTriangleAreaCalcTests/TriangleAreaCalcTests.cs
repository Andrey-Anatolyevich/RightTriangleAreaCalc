using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AreaCalc.Tests
{
    /// <summary>
    /// Triangle area calculator test class
    /// </summary>
    [TestClass()]
    public class TriangleAreaCalcTests
    {
        /// <summary>
        /// Here we test GetRightTriangleArea method
        /// </summary>
        [TestMethod()]
        public void GetRightTriangleAreaTest()
        {
            TriangleAreaCalc calc = new TriangleAreaCalc();

            // one segment is too big for a triangle
            bool exception1Thrown = false;
            try
            {
                // just need to make sure there is exception thrown. No assignment required
                calc.GetRightTriangleArea(1D, 3D, 1D);
            }
            catch
            {
                exception1Thrown = true;
            }

            // provided segments figure non-right triangle
            bool exception2Thrown = false;
            try
            {
                // just need to make sure there is exception thrown. No assignment required
                calc.GetRightTriangleArea(3D, 4D, 6D);
            }
            catch
            {
                exception2Thrown = true;
            }

            // provided segments figure non-right triangle
            bool exception3Thrown = false;
            try
            {
                // just need to make sure there is exception thrown. No assignment required
                calc.GetRightTriangleArea(3D, 0D, 6D);
            }
            catch
            {
                exception3Thrown = true;
            }

            // should work fine. Provided segments are right fit for right triangle
            bool result1 = calc.GetRightTriangleArea(3D, 4D, 5D) == 6D;
            bool result2 = calc.GetRightTriangleArea(8D, 6D, 10D) == 24D;
            bool result3 = calc.GetRightTriangleArea(0.8D, 0.6D, 1D) == 0.24D;

            // Assert everything went as expected
            Assert.IsTrue(exception1Thrown
                && exception2Thrown
                && exception3Thrown
                && result1
                && result2
                && result3);

            // PS: Never written tests of any sort. (except for the current and few simplier ones months before)
            // Dreaming to join right company in order to master the skill.
        }
    }
}