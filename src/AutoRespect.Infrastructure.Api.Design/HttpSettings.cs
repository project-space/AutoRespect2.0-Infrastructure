using System.Collections.Generic;

namespace AutoRespect.Infrastructure.Api.Design
{
    public class HttpSettings
    {
        public IEnumerable<KeyValuePair<string, string>> Headers { get; set; }
    }
}
