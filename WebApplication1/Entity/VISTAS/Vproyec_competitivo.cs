using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.VISTAS
{
    public class Vproyec_competitivo
    {
        public string CONTRATO { get; set; }
        public string PROGRAMA { get; set; }
        public string PROYECTO { get; set; }
        public string AREA { get; set; }
        public string CATEGORIA { get; set; }
        public string TIPO { get; set; }
        public string ORIGEN { get; set; }
        public string FAMILIA { get; set; }
        public string COMP_ADQUISICION { get; set; }
        public string DESC_GENERAL { get; set; }
        public decimal PRESUPUESTO { get; set; }
        public int ID_COMPETITIVO { get; set; }
        public string PROCESO { get; set; }
        public string PROCESO_INICIO { get; set; }
        public int TIEMPO_PROCESO { get; set; }
        public string FECHA_INICO { get; set; }
        public string FECHA_INIC_SERVICE { get; set; }
        public int TIEMPO_EJECUCION { get; set; }
        public string DETALLE_PS { get; set; }
        public int CANTIDAD { get; set; }
        public string UNIDAD { get; set; }
        public string LUGAR_EJECUCION { get; set; }
        public decimal VALOR_ESTIMADO { get; set; }
        public decimal VALOR_TOTAL { get; set; }
    }
}
