using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class Configuraciones
    {
        [Key]
        public int CONFIG_ID { get; set; }
        public string NOMBRE_CONFIG { get; set; }
        public int TIPO_CONFIG { get; set; }
    }
}
