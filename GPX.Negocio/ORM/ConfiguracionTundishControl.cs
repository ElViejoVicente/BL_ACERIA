
using GPX.Negocio.COP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPX.Negocio.ORM
{
    public class ConfiguracionTundishControl
    {
        public long IdVersion { get; set; } = 0;
        public string UsuarioAutor { get; set; } = "";
        public DateTime FechaCreacionVersion { get; set; } = Constantes.FechaGlobal;
        public DateTime FechaUltimaModificacion { get; set; } = Constantes.FechaGlobal;
        public DateTime NecesidadfechaInicio { get; set; } = Constantes.FechaGlobal;
        public DateTime NecesidadfechaFin { get; set; } = Constantes.FechaGlobal;
        public decimal NecesidadBB1 { get; set; } = 0;
        public decimal NecesidadBB2 { get; set; } = 0;
        public decimal NecesidadBB3 { get; set; } = 0;
        public decimal NecesidadTotal { get; set; } = 0;
        public string EstandarSeleccionado { get; set; }= "";
        public string ListaConfiguracionAceria { get; set; } = "";
        public string ListaNecesidadesBeamBlanks { get; set; } = "";
        public string ListaNecesidadesBeamBlanksAgrupago { get; set; } = "";
        public string ListaTundishReales { get; set; } = "";
        public string ListaNecesidadDetalleBB { get; set; } = "";
        public string ListaPropuestaDistribucionColadas { get; set; } = "";
        public int CantidadTundish { get; set; }= 0;
        public int NumColadasReales { get; set; } = 0;
        public int NumMinutosNeceReales { get; set; } = 0;
        public int Estatus { get; set; } = 0;
        public decimal NecesidadBB1Real { get; set; } = 0;
        public decimal NecesidadBB2Real { get; set; } = 0;
        public decimal NecesidadBB3Real { get; set; } = 0;
        public decimal NecesidadTotalReal { get; set; } = 0;

        // Campos calculados para mostrar en DxComboBox (Necesidad / Real)
        public string NecesidadBB1Display => $"{NecesidadBB1:N2} / {NecesidadBB1Real:N2}";
        public string NecesidadBB2Display => $"{NecesidadBB2:N2} / {NecesidadBB2Real:N2}";
        public string NecesidadBB3Display => $"{NecesidadBB3:N2} / {NecesidadBB3Real:N2}";
        public string NecesidadTotalDisplay => $"{NecesidadTotal:N2} / {NecesidadTotalReal:N2}";
    }
}
