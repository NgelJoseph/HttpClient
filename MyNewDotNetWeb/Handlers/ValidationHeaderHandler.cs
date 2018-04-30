using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace MyNewDotNetWeb.Handlers
{
    public class ValidationHeaderHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            if (!request.Headers.Contains("X-Api-Key"))
            {
                return new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    Content = new StringContent("You must supply API key X-Api-Key")
                };
            }

            return await base.SendAsync(request, cancellationToken);
        } 
    }
}
