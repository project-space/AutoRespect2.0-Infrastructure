using AutoRespect.Infrastructure.Errors.Design;

namespace AutoRespect.Infrastructure.Errors.DataTransfer
{
    public class ServerError : E
    {
        public ServerError() : base("3DD50389-301C-43CD-BB08-75B9D50D2AFE", "Server error") //TODO: make better description ...
        {
        }
    }
}
