using Dal;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ConfiguracionBLL
    {
        /// <summary>
        /// Metodo para crear un elemento de la configuracion
        /// </summary>
        /// <returns></returns>
        public void Addconfig(Configuraciones configuracion) {
            using (var contex = new ModelContex())
            {
                contex.Configuracion.Add(configuracion);
                contex.SaveChanges();
            }

        }

        /// <summary>
        /// Meotodo para modificar datos de la configuracion
        /// </summary>
        /// <param name="c"></param>
        public void UpdateConfig(int id,Configuraciones configuracion) {
            using (var contex = new ModelContex())
            {
                var dto =contex.Configuracion.Where(t => t.CONFIG_ID == id).First();
                if (dto!=null)
                {
                    dto.NOMBRE_CONFIG = configuracion.NOMBRE_CONFIG;
                    dto.TIPO_CONFIG = configuracion.TIPO_CONFIG;
                    contex.SaveChanges();
                }
            }
        }

        /// <summary>
        /// Meotodo para remover elemento de la configuracion
        /// </summary>
        /// <param name="id"></param>
        public void RemoveConfig(int id){
            using (var contex = new ModelContex())
	        {
		       var dto =contex.Configuracion.SingleOrDefault(r => r.CONFIG_ID == id);
               if (dto != null)
	            {
		          contex.Configuracion.Remove(dto);
                  contex.SaveChanges();
	            }
               
	        }
        }

        /// <summary>
        /// Metodo para buascar un elemento almacenado en la tabla
        /// configuracion
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<ConfiguracionEntity> GetConfig(int id) {
            using (var contex = new ModelContex())
            {
                var dto = contex.Configuracion.Where(x => x.CONFIG_ID == id).ToList();
                List<ConfiguracionEntity> listc = new List<ConfiguracionEntity>();
                if (dto != null)
                {
                    foreach (var item in dto)
                    {
                        ConfiguracionEntity config = new ConfiguracionEntity();
                        config.CONFIG_ID = item.CONFIG_ID;
                        config.NOMBRE_CONFIG = item.NOMBRE_CONFIG;
                        config.TIPO_CONFIG = item.TIPO_CONFIG;
                        listc.Add(config);
                    }
                    return listc;
                }
                else {return listc;}
            }
        }

        /// <summary>
        /// Meotodo para obtener una lista total de los elementos almacenados
        /// en la tabla Configuracion
        /// </summary>
        /// <returns></returns>
        public List<ConfiguracionEntity> GetAllConfig() {
            using (var contex = new ModelContex())
            {
                var dto = contex.Configuracion.ToList();
                List<ConfiguracionEntity> Lisconf = new List<ConfiguracionEntity>();
                if (dto != null)
                {
                    
                    foreach (var item in dto)
                    {
                        ConfiguracionEntity confi = new ConfiguracionEntity();
                        confi.CONFIG_ID = item.CONFIG_ID;
                        confi.NOMBRE_CONFIG = item.NOMBRE_CONFIG;
                        confi.TIPO_CONFIG = item.TIPO_CONFIG;
                        Lisconf.Add(confi);
                    }
                    return Lisconf;
                }
                else
                {
                    return Lisconf;
                }
            }
        }
        
    }
}
