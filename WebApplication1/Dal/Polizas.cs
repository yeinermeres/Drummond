using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Dal
{
    public class Polizas
    {
        [Key]
        public int NO_POLIZAS { get; set; }
        public string COD_POLIZA { get; set; }
        public string FECHA_INI_POL { get; set; }
        public string FECHA_FINAL_POL { get; set; }
        public string ASEGURADORA { get; set; }
        public decimal VALOR_POLIZA { get; set; }
        public string TIPO_POLIZA { get; set; }
        public decimal VALOR_ASEGURADO { get; set; }

        /// <summary>
        /// Relacion oferta mercantil polizas
        /// </summary>
        public int OFERTAMERCANTIL { get; set; }
    }
}
