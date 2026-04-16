using System;
using System.Collections.Generic;
using System.Text;

namespace MudBlazorCatalogoNaPratica.Shared.Recursos
{
    public class Paginacao
    {
        public int Pagina { get; set; } = 1;
        public int QuantidadePorPagina { get; set; } = 5;
        public string? TermoBusca { get; set; }
    }
}
