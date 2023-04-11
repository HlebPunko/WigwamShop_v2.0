namespace Catalog.Application.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string messege) : base(messege)
        {

        }
    }
}
