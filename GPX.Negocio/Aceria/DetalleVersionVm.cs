using System;
using System.Collections.Generic;
using System.Text;

namespace GPX.Negocio.Aceria
{
    public  class DetalleVersionVm
    {
        public string IdDetalle { get; set; } = string.Empty;
        public string TipoSemi { get; set; } = string.Empty;
        public int NumeroBarras { get; set; }
        public int Longitud { get; set; }
        public string Calidad { get; set; } = string.Empty;
        public DateTime FechaPrevIni { get; set; }
        public string? SemanaPrevIni { get; set; }

        public Boolean GAP { get; set; } = false;
    }
}
