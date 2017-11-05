namespace AutoRespect.Infrastructure.Errors.Design
{
    public class E
    {
        public string Id { get; set; }
        public string Description { get; set; }

        public E(string id, string description)
        {
            Id = id;
            Description = description;
        }
    }
}
