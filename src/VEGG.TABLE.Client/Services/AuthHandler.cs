using System.Net.Http.Headers;

using Microsoft.JSInterop;

namespace VEGG.TABLE.Client.Services;

public class AuthHandler : DelegatingHandler
{
    private readonly IJSRuntime _js;
    public AuthHandler(IJSRuntime js) => _js = js;

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var token = await _js.InvokeAsync<string>("localStorage.getItem", "authToken");
        if (!string.IsNullOrEmpty(token))
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

        return await base.SendAsync(request, cancellationToken);
    }
}