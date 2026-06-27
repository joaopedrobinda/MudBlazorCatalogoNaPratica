namespace MudBlazorCatalogoNaPratica.Client.Auth
{
    public interface IAuthorizeService
    {
        Task Login (string token);
        Task Logout();
    }
}
