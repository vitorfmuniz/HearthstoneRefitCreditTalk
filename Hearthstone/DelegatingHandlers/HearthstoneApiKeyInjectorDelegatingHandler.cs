namespace HearthstoneRefitCreditTalk.Hearthstone.DelegatingHandlers
{
    public class HearthstoneApiKeyInjectorDelegatingHandler : DelegatingHandler
    {
        private readonly IConfiguration _configuration;

        public HearthstoneApiKeyInjectorDelegatingHandler(IConfiguration configuration)
            => _configuration = configuration;

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            request.Headers.Add("X-RapidAPI-Key", _configuration.GetRequiredSection("X-RapidAPI-Key").Value);
            return await base.SendAsync(request, cancellationToken);
        }
    }
}
