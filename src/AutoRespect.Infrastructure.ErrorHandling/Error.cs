namespace AutoRespect.Infrastructure.ErrorHandling
{
    public abstract class Error
    {
        public int Code { get; set; }
        public int Description { get; set; }

        public Error (int code, string description)
        {

        }
    }
}