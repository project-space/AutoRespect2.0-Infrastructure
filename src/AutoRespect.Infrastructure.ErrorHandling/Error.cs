namespace AutoRespect.Infrastructure.ErrorHandling
{
    public class Error
    {
        public string Id { get; set; }
        public string Description { get; set; }

        public Error (string id, string description)
        {
            Id = id;
            Description = description;
        }
    }
}