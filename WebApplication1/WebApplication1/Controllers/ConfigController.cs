using BLL;
using Dal;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebDrummond.Controllers
{
    public class ConfigController : ApiController
    {
        ConfiguracionBLL confi = new ConfiguracionBLL();

        // GET: api/Config
        public List<ConfiguracionEntity> Get()
        {
            return confi.GetAllConfig();
            
        }

        // GET: api/Config/5
        public List<ConfiguracionEntity> Get(int id)
        {
            return confi.GetConfig(id);
        }

        // POST: api/Config
        public void Post(Configuraciones configuracion)
        {
            confi.Addconfig(configuracion);
        }

        // PUT: api/Config/5
        public void Put(int id, Configuraciones configuracion)
        {
            confi.UpdateConfig(id,configuracion);
        }

        // DELETE: api/Config/5
        public void Delete(int id)
        {
            confi.RemoveConfig(id);
        }
    }
}
