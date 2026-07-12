using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPX.Negocio.ORM
{
    public  class StockBBColada
    {

        public string st_sociedad { get; set; } = string.Empty;
        public string st_tipo_semi { get; set; } = string.Empty;
        public string st_calidad { get; set; } = string.Empty;
        public int st_longitud { get; set; } = 0;
        public int st_idColada { get; set; } = 0;
        public int st_stock_uds { get; set; } = 0;
        public decimal st_stock_tn { get; set; } = 0;

        public string st_Ubicacion { get; set; } = string.Empty;
        public int st_uds_Asignadas { get; set; } = 0;


    }
}
