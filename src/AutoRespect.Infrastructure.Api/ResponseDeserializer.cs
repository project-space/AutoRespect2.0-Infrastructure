using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using AutoRespect.Infrastructure.Api.Design;
using AutoRespect.Infrastructure.DI.Design;
using AutoRespect.Infrastructure.DI.Design.Attributes;
using AutoRespect.Shared.Errors.DataTransfer;
using AutoRespect.Shared.Errors.Design;
using Newtonsoft.Json;

namespace AutoRespect.Infrastructure.Api
{
    [DI(LifeCycle.Singleton)]
    public class ResponseDeserializer : IResponseDeserializer
    {
        public async Task<R<T>> Deserialize<T>(HttpResponseMessage response)
        {
            var statusCode = response.StatusCode;
            var content = await response.Content.ReadAsStringAsync();

            if (statusCode >= HttpStatusCode.OK && statusCode < HttpStatusCode.Ambiguous)
            {
                return JsonConvert.DeserializeObject<T>(content);
            }
            else if (statusCode >= HttpStatusCode.BadRequest && statusCode < HttpStatusCode.InternalServerError)
            {
                return JsonConvert.DeserializeObject<List<Error>>(content);
            }
            else if (statusCode >= HttpStatusCode.InternalServerError)
            {
                return new ServerError();
            }

            throw new NotImplementedException("Unsupported status code");

        }
    }
}
