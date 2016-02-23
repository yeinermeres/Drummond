using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Dal
{
    public class Oferta_Mercantil
    {
        [Key]
        public int ID_OFERTA { get; set; }
        public string N_OFM { get; set; }
        public string FECHA_SUSCRIP_OFM { get; set; }
        public string FECHA_INIC_OFM { get; set; }
        public int VIGENCIA { get; set; }
        public string TITULO_OFM { get; set; }
        public int CONTRATISTA { get; set; }
        public string OBJETO_OFM { get; set; }
        public string LUGRA_EJECUCION_OFM { get; set; }
        public string TIPO_MONEDA { get; set; }
        public decimal VALOR_ESTIMAO_OFM { get; set; }
        public decimal VALOR_REAL_OFM { get; set; }

        [ForeignKey("OFERTAMERCANTIL")]
        private ICollection<Polizas> Polizas { get; set; }

    }
}
