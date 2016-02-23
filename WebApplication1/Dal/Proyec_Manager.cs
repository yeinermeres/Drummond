using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class Proyec_Manager
    {
        [Key]
        public int ID_PROMANAGER { get; set; }
        public string DOCUMENTO { get; set; }
        public string NOMBRE { get; set; }
        public string P_APELLIDO { get; set; }
        public string S_APELLIDO { get; set; }
        public string CARGO { get; set; }
        [ForeignKey("PROYEC_MANAGER")]
        public virtual ICollection<Proyecto> proyecto { get; set; }
    }
}
