using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;

namespace VEGG.TABLE.Client.Services;

public class AuthStateProvider : AuthenticationStateProvider
{
    private readonly IJSRuntime _js;
    public AuthStateProvider(IJSRuntime js) => _js = js;

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var token = await _js.InvokeAsync<string>("localStorage.getItem", "authToken");

        if (string.IsNullOrEmpty(token))
            return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));

        var handler = new JwtSecurityTokenHandler();
        var jwtToken = handler.ReadJwtToken(token);
        var identity = new ClaimsIdentity(jwtToken.Claims, "jwt");

        return new AuthenticationState(new ClaimsPrincipal(identity));
    }

    public void NotifyUserAuthentication(string token)
    {
        NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
    }
}