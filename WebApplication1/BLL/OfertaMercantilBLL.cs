using Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
   public class OfertaMercantilBLL:PolizasBLL
    {
       ModelContex contex;
       /// <summary>
       /// Metodo para registrar una oferta mercantil
       /// </summary>
       /// <param name="ofm"></param>
       public void OFMadd(Oferta_Mercantil ofm, List<Polizas> pl) 
       {
           using (var contex = new ModelContex())
           {
               using (var Transaction = contex.Database.BeginTransaction())
               {
                   contex.Oferta_mercantil.Add(ofm);
                   Addpolizas(pl);
                   contex.SaveChanges();
                   Transaction.Commit();
               }
           }
       }
    }
}
