using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Dal
{
    public class AspiranteProceso
    {
        [Key]
        public int ID_ASPIRANTEPROCESO { get; set; }
        public int ID_ASPIRANTE { get; set; }
        public int ID_PROCESO { get; set; }
        public string RUTA { get; set; }

        //public virtual Aspirantes Aspirante { get; set; }
    }
}
