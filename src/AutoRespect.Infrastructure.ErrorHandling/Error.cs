namespace AutoRespect.Infrastructure.ErrorHandling
{
    public class Error
    {
        public int Code { get; set; }
        public string Description { get; set; }

        public Error (int code, string description)
        {
            Code = code;
            Description = description;
        }
    }
}