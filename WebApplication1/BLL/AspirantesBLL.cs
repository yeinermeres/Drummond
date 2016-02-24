using Dal;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class AspirantesBLL
    {
        public void AddAspirante(Aspirantes a)
        {
            using (var contex = new ModelContex())
            {
                contex.Aspirantes.Add(a);
                contex.SaveChanges();
            }
        }

        public List<AspirantesEntity> GetAllAspirantes()
        {
            using (var contex = new ModelContex())
            {
                var dto = contex.Aspirantes.ToList();
                List<AspirantesEntity> LisAsp = new List<AspirantesEntity>();

                if (dto != null)
                {
                    foreach (var item in dto)
                    {
                        AspirantesEntity aspirante = new AspirantesEntity();
                        aspirante.ASPIRANTE_ID= item.ASPIRANTE_ID;
                        aspirante.NIT_CEDULA = item.NIT_CEDULA;
                        aspirante.NOM_RAZONSOCIAL = item.NOM_RAZONSOCIAL;
                        aspirante.CORREO = item.CORREO;
                        aspirante.DIRECCION = item.DIRECCION;
                        aspirante.CIUDAD = item.CIUDAD;
                        aspirante.DEPARTAMENTO = item.DEPARTAMENTO;
                        aspirante.TELEFONO = item.TELEFONO;
                        LisAsp.Add(aspirante);
                    }
                    return LisAsp;
                }

                return LisAsp;
            }
        }
    }
}
