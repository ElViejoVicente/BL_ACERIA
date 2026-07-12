using System;
using System.Collections.Generic;
using System.Text;

namespace GPX.Negocio.Aceria
{
    public class ListaCalidadesXColada
    {
        public int OrdenCalidad { get; set; } = 0;
        public string Calidad { get; set; } = string.Empty;
        public int ColadasRequeridas { get; set; } = 0;
        public int ColadasRepartidas { get; set; } = 0;
        public bool EsCalidadEstandar { get; set; } = false;
        public int ColadasRestantes
        {
            get
            {
                return ColadasRequeridas - ColadasRepartidas;
            }
        }
    }
}
