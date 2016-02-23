using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class ProcompetitivoEntity
    {
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
        public int PROYECTO_COMPETITIVO { get; set; }
    }
}
