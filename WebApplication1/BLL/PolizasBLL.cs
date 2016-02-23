using Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class PolizasBLL
    {

        public void Addpolizas(List<Polizas> p )
        {
            using (var contex = new  ModelContex())
            {
               foreach (var item in p)
               {
                Polizas pl = new Polizas();
                pl.ASEGURADORA = item.ASEGURADORA;
                pl.NO_POLIZAS = item.NO_POLIZAS;
                pl.FECHA_FINAL_POL = item.FECHA_FINAL_POL;
                pl.FECHA_INI_POL = item.FECHA_INI_POL;
                contex.Polizas.Add(pl);
                
                }
               contex.SaveChanges();
            } 
        }
    }
}
