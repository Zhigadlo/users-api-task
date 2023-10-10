namespace Entities.Exceptions
{
    public class EmailIsNotUniqueException : BadRequestException
    {
        public EmailIsNotUniqueException()
            : base("User with the same Email exist in the database.")
        {
        }
    }
}
