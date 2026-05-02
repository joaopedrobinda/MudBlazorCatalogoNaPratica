using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace MudBlazorCatalogoNaPratica.Client.Auth
{
    public class AuthStateProvider : AuthenticationStateProvider
    {
        public async override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var usuario = new ClaimsIdentity(new List<Claim>()
            {
                new Claim("Chave", "Valor"),
                new Claim(ClaimTypes.Name, "Joao Pedro"),
                new Claim(ClaimTypes.Role, "Admin")
            }, "Demo");

            return await Task.FromResult(new AuthenticationState(new ClaimsPrincipal(usuario)));
        }
    }
}
