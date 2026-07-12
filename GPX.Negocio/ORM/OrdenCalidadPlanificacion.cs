using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPX.Negocio.ORM
{
    public class OrdenCalidadPlanificacion
    {
        public string ocpCalidad { get; set; } = string.Empty;
        public string ocpColor { get; set; } = string.Empty;
        public string ocpColorFuente { get; set; } = string.Empty;
        public int ocpOrden { get; set; } = 0;
    }
}
