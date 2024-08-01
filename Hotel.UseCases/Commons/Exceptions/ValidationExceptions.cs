using Hotel.UseCases.Commons.Bases;

namespace Hotel.UseCases.Commons.Exceptions
{
    public class ValidationExceptions : Exception
    {
        public IEnumerable<BaseError>? Errors { get; }
        public ValidationExceptions() : base()
        {
            Errors = new List<BaseError>();
        }

        public ValidationExceptions(IEnumerable<BaseError>? errors) : this()
        {
            Errors = errors;
        }
    }
}
