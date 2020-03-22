namespace HttpClientTheRightWay.Infrastructure.Handlers
{
    using Microsoft.Extensions.Logging;
    using System.Net;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;

    using static ApiConstants;

    public class ValidateHeaderHandler : DelegatingHandler
    {
        private readonly ILogger<ValidateHeaderHandler> logger;

        public ValidateHeaderHandler(ILogger<ValidateHeaderHandler> logger)
            => this.logger = logger;

        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            if (!request.Headers.Contains(API_HEADERS_EXAMPLE))
            {
                logger.LogError("Invalid headers collection.");

                return new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent(
                        $"You must supply an API key header called {API_HEADERS_EXAMPLE}.")
                };
            }

            return await base.SendAsync(request, cancellationToken);
        }
    }
}
