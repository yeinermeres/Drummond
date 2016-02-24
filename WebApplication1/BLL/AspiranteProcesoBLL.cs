using Dal;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class AspiranteProcesoBLL
    {
        public void AddAspiranteProceso(AspiranteProceso ap)
        {
            using (var contex = new ModelContex())
            {

                if (ap.ID_ASPIRANTE.Equals(0))
                {
                    var CTX = contex.Aspirantes.Max(p=> p.ASPIRANTE_ID);
                    ap.ID_ASPIRANTE = CTX;
                    contex.AspiranteProceso.Add(ap);
                    contex.SaveChanges();
                }
                else
                {
                  contex.AspiranteProceso.Add(ap);
                  contex.SaveChanges();
                }
                
            }
        }
        public List<AspiranteProcesoEntity> GetAll()
        {
            using (var contex = new ModelContex())
            {
                var dto = contex.AspiranteProceso.ToList();
                List<AspiranteProcesoEntity> LisAspPro = new List<AspiranteProcesoEntity>();

                if (dto != null)
                {
                    foreach (var item in dto)
                    {
                        AspiranteProcesoEntity aspro = new AspiranteProcesoEntity();
                        aspro.ID_ASPIRANTEPROCESO = item.ID_ASPIRANTEPROCESO;
                        aspro.ID_ASPIRANTE = item.ID_ASPIRANTE;
                        aspro.ID_PROCESO = item.ID_PROCESO;
                        LisAspPro.Add(aspro);
                    }
                    return LisAspPro;
                }

                return LisAspPro;
            }
        }
    }
}
