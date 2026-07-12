using GPX.Negocio.COP;
using System;
using System.Collections.Generic;
using System.Text;

namespace GPX.Negocio.Aceria
{
    public class ListaCargaMasivaCalendario
    {
        public ListaCargaMasivaCalendario(DateTime fecha, int valor)
        {
            this.fecha = fecha;
            this.valor = valor;
        }

        public DateTime fecha { get; set; } = Constantes.FechaGlobal;
        public int valor { get; set; } = 0;
    }
}
