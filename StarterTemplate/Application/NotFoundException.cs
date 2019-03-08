namespace StarterTemplate.Application
{
    public class NotFoundException : System.Exception
    {
        ///<Summary>
        /// Parameter-less constructor
        ///</Summary>
        public NotFoundException() { }

        ///<Summary>
        /// Message only constructor
        ///</Summary>
        public NotFoundException(string message) : base(message) { }

        ///<Summary>
        /// Message and Exception constructor
        ///</Summary>
        public NotFoundException(string message, System.Exception inner) : base(message, inner) { }
    }
}