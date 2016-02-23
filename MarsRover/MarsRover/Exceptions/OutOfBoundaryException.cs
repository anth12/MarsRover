using System;

namespace MarsRover.Exceptions
{
    public class OutOfBoundaryException : Exception
    {
        public OutOfBoundaryException(int boundary, int actual, string axis)
            : base($"Out of Boundary on axis {axis}. (Boundary limit: {boundary}, Actual: {actual})")
        {
            Boundary = boundary;
            Actual = actual;
            Axis = axis;
        }

        public int Boundary { get; set; }
        public int Actual { get; set; }
        public string Axis { get; set; }
    }
}
