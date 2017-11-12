using System.Collections.Generic;

namespace AutoRespect.Infrastructure.Api
{
    public class HttpSettings
    {
        IEnumerable<KeyValuePair<string, string>> Headers { get; set; }
    }
}
