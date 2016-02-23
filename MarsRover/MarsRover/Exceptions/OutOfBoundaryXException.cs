
namespace MarsRover.Exceptions
{
    public class OutOfBoundaryXException : OutOfBoundaryException
    {
        public OutOfBoundaryXException(int boundary, int actual)
            : base(boundary, actual, "X")
        {

        }
        
    }
}
