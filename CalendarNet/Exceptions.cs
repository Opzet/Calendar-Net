using System;

namespace CalendarNet
{
    public class IdAlreadyExistsException : Exception
    {
        public IdAlreadyExistsException() : base("This key already exists in the collection!")
        {
            
        }

        public IdAlreadyExistsException(string message) : base(message)
        {
            
        }

        public IdAlreadyExistsException(string message, Exception inner) : base(message, inner)
        {
            
        }
    }

    public class IdNotFoundException : Exception
    {
        public IdNotFoundException() : base("The key was not found in the collection!")
        {
            
        }

        public IdNotFoundException(string message) : base(message)
        {
            
        }

        public IdNotFoundException(string message, Exception inner) : base(message, inner)
        {
            
        }
    }
}
