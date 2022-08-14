namespace HearthstoneRefitCreditTalk.DelegatingHandlers;

public class CancellationTokenPrinterDelegatingHandler : DelegatingHandler
{
    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        while (!cancellationToken.IsCancellationRequested)
        {
            Console.WriteLine("Waiting");
            await Task.Delay(1000);
        }
        Console.WriteLine("Cancellation was requested");

        //Irá lançar uma exception pq não existe um innerMessageHandler
        return await base.SendAsync(request, cancellationToken);
    }
}
