using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 

namespace Dal
{
    public class ModelContex : DbContext
    {
        public DbSet<Configuraciones> Configuracion { get; set; }
        public DbSet<Proyec_Manager> Pro_Manager { get; set; }
        public DbSet<Proyecto> Proyecto { get; set; }
        public DbSet<Proceso_Competitivo> Proceso_Competitivo { get; set; }
        public DbSet<Archivo_Ruta> Archivo_Ruta { get; set; }

         
    }
}
