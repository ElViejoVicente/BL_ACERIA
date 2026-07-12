using GPX.Negocio.ORM;
using System;
using System.Collections.Generic;
using System.Text;

namespace GPX.Negocio.Aceria
{
    public class ListaStockBeamBlank: StockBeamBlank
    {
        public int st_NunCortes { get; set; } = 0;
        public decimal st_Merma { get; set; } = 0;
    }
}
