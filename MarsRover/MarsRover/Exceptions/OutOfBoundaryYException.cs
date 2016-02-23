
namespace MarsRover.Exceptions
{
    public class OutOfBoundaryYException : OutOfBoundaryException
    {
        public OutOfBoundaryYException(int boundary, int actual)
            : base(boundary, actual, "Y")
        {

        }
        
    }
}
