using System;
using AreaCalc.Objects;

namespace AreaCalc
{
    /// <summary>
    /// Calculator of a triangle space
    /// </summary>
    public class TriangleAreaCalc
    {
        /// <summary>
        /// Get space of a right triangle
        /// </summary>
        /// <param name="sideA">Side A length</param>
        /// <param name="sideB">Side B length</param>
        /// <param name="sideC">Side B length</param>
        /// <returns>Space of a right triangle</returns>
        public double GetRightTriangleArea(double sideA, double sideB, double sideC)
        {
            if (sideA <= 0D)
                throw new ArgumentException("sideA <= 0");
            if (sideB <= 0D)
                throw new ArgumentException("sideB <= 0");
            if (sideC <= 0D)
                throw new ArgumentException("sideC <= 0");


            Triangle.SegmentsAreValidForTriangle(sideA, sideB, sideC, true);

            Triangle theTriangle = new Triangle(sideA, sideB, sideC);
            double result = theTriangle.GetArea();
            return result;
        }
    }
}
