using System;
using System.Collections.Generic;
using System.Text;

namespace MudBlazorCatalogoNaPratica.Shared.Models
{
    public class UserToken
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
        public string Message { get; set; }
    }
}
