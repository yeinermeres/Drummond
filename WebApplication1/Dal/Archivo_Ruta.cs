using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class Archivo_Ruta
    {
        [Key]
        public int ID_RUTA { get; set; }
        public string RUTA { get; set; }
        public int PROCESO_ARCHIVO { get; set; }
    }
}
