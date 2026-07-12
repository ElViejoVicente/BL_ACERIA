using System;
using System.Collections.Generic;
using System.Text;

namespace GPX.Negocio.Aceria
{
    public  class ListadoVersionVm
    {
        public string IdVersion { get; set; } = string.Empty;
        public string Version { get; set; } = string.Empty;
        public int TundishActivos { get; set; }
        public bool EstadoOk { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public string Autor { get; set; } = string.Empty;
        public int NumeroColadas { get; set; }
        public int NumeroBarras { get; set; }
        public List<string> Calidades { get; set; } = new();
        public List<DetalleVersionVm> Detalles { get; set; } = new();

        // Filtros (Calidad / Longitud)
        public List<string>? AllCalidades { get; set; }
        public List<int>? AllLongitudes { get; set; }
        public List<string>? FiltroCalidades { get; set; }
        public List<int>? FiltroLongitudes { get; set; }
    }
}
