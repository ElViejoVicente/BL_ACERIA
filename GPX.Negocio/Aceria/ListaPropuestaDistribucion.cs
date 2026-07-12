using GPX.Negocio.COP;
using System;
using System.Collections.Generic;
using System.Text;

namespace GPX.Negocio.Aceria
{
    public class ListaPropuestaDistribucion
    {
        public int NumTRegistro { get; set; } = 0;
        public int NumTundish { get; set; } = 0;
        public DateTime FechaInicioTundis { get; set; } = Constantes.FechaGlobal;
        public DateTime FechaFinTundis { get; set; } = Constantes.FechaGlobal;

        public decimal NumColadas { get; set; } = 0;

        public int VidaUtil { get; set; } = 0;

        public int S275H { get; set; } = 0;
        public int S355TI { get; set; } = 0;
        public int S355V { get; set; } = 0;
        public int S355W { get; set; } = 0;
        public int S460A { get; set; } = 0;
        public int S275TI { get; set; } = 0;
    }
}
