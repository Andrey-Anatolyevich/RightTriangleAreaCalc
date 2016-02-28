using System;
using System.Collections.Generic;
using System.Linq;

namespace AreaCalc.Objects
{
    /// <summary>
    /// Triangle class =)
    /// </summary>
    internal class Triangle
    {
        /// <summary>
        /// Side A
        /// </summary>
        private double SideA;

        /// <summary>
        /// Side B
        /// </summary>
        private double SideB;

        /// <summary>
        /// Side C
        /// </summary>
        private double SideC;

        /// <summary>
        /// Get all Sides
        /// </summary>
        private List<double> GetSides
        {
            get
            {
                return new List<double>() { SideA, SideB, SideC };
            }
        }

        /// <summary>
        /// Get Hypotenuse of the triangle
        /// </summary>
        private double Hypotenuse
        {
            get
            {
                return this.GetSides.Max();
            }
        }

        /// <summary>
        /// Get legs of the triangle
        /// </summary>
        private Legs GetLegs
        {
            get
            {
                List<double> sides = this.GetSides;
                if (sides == null || sides.Count != 3)
                    throw new Exception("Logics fail! Code & logic review is required.");

                // find max value
                double max = sides.Max();
                // remove max from list
                sides.RemoveAt(sides.IndexOf(max));
                return new Legs() { LegA = sides[0], LegB = sides[1] };
            }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="sideA">Side A length</param>
        /// <param name="sideB">Side B length</param>
        /// <param name="sideC">Side B length</param>
        internal Triangle(double sideA, double sideB, double sideC)
        {
            if (sideA <= 0D)
                throw new ArgumentException("sideA <= 0");
            if (sideB <= 0D)
                throw new ArgumentException("sideB <= 0");
            if (sideC <= 0D)
                throw new ArgumentException("sideC <= 0");


            // make sure, the sides are vaid for creation of a triangle
            Triangle.SegmentsAreValidForTriangle(sideA, sideB, sideC, true);

            // save sides
            this.SideA = sideA;
            this.SideB = sideB;
            this.SideC = sideC;
        }

        /// <summary>
        /// Check if segments are valid for a triangle
        /// </summary>
        /// <param name="segmentA">Segment A</param>
        /// <param name="segmentB">Segment B</param>
        /// <param name="segmentC">Segment C</param>
        /// <returns>Segments are valid for a triangle</returns>
        internal static bool SegmentsAreValidForTriangle(double segmentA, double segmentB, double segmentC, bool throwExceptionIfNotValid = false)
        {
            // if any two sides are longer than third one
            if (segmentA > 0D
                && segmentB > 0D
                && segmentC > 0D
                && ((segmentA + segmentB) > segmentC)
                && ((segmentB + segmentC) > segmentA)
                && ((segmentC + segmentA) > segmentB))
                return true;
            else if (throwExceptionIfNotValid)
            {
                string message = string.Format("It is impossible to get a triangle from provided segments: ({0}, {1}, {2})."
                    , segmentA, segmentB, segmentC);
                throw new Exception(message);
            }

            return false;
        }

        /// <summary>
        /// Get area of the triangle
        /// </summary>
        /// <returns>Area of the triangle</returns>
        internal double GetArea()
        {
            // if the triangle is right
            if (this.IsRight())
            {
                // in this case, the following is right: Area = 1/2 * A * B
                Legs legs = this.GetLegs;
                return legs.LegA * legs.LegB / 2;
            }
            else
                throw new NotImplementedException("The assembly supposed to support only right triangles");
        }

        /// <summary>
        /// The triangle is right
        /// </summary>
        /// <returns></returns>
        private bool IsRight()
        {
            double hypotenuse = this.Hypotenuse;
            Legs legs = this.GetLegs;

            // for a triangle the following is right: c^2 = a^2 b^2
            // have no Idea about accuracy of .net compution, but will use is for now.
            return hypotenuse * hypotenuse == ((legs.LegA * legs.LegA) + (legs.LegB * legs.LegB));
        }
    }
}
