namespace StarterTemplate.Application
{
    public class APIClientHttpFailure : System.Exception
    {
        ///<Summary>
        /// Parameter-less constructor
        ///</Summary>
        public APIClientHttpFailure() { }

        ///<Summary>
        /// Message only constructor
        ///</Summary>
        public APIClientHttpFailure(string message) : base(message) { }

        ///<Summary>
        /// Message and Exception constructor
        ///</Summary>
        public APIClientHttpFailure(string message, System.Exception inner) : base(message, inner) { }
    }
}