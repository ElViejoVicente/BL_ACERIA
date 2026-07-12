using System;
using System.Collections.Generic;
using System.Text;

namespace GPX.Negocio.Aceria
{
    public class ListDetalleNecesidadBB
    {
        public int OrdenFab { get; set; } = 0;
        public string Calidad { get; set; } = "";
        public string TipoBB { get; set; } = "";
        public decimal TnNecesidad { get; set; } = 0;
        public decimal ColadasNecesarias { get; set; } = 0;
        public decimal ColadasReales { get; set; } = 0;
        public decimal TnReales { get; set; } = 0;

        public decimal DiferenciaColadas
        {
            get
            {
                return ColadasReales - ColadasNecesarias;
            }
        }

    }
}
