namespace AutoRespect.Infrastructure.OAuth.Design
{
    public interface IAccountContext
    {
        bool IsAuthorized { get; }

        int Id { get; }
        string Login { get; }
    }
}
