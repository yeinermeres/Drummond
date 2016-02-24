using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Dal
{
    public class Aspirantes
    {
        [Key]
        public int ASPIRANTE_ID { get; set; }
        public string NIT_CEDULA { get; set; }
        public string NOM_RAZONSOCIAL { get; set; }
        public string CORREO { get; set; }
        public string DIRECCION { get; set; }
        public string CIUDAD { get; set; }
        public string DEPARTAMENTO { get; set; }
        public string TELEFONO { get; set; }

        [ForeignKey("ID_ASPIRANTE")]
        public virtual ICollection<AspiranteProceso> AspiranteProceso { get; set; }
    }
}
