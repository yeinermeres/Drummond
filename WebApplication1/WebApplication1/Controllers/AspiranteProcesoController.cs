using BLL;
using Dal;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication1.Controllers
{
    public class AspiranteProcesoController : ApiController
    {
        AspiranteProcesoBLL ap = new AspiranteProcesoBLL();
        // GET api/aspiranteproceso
        public IList<AspiranteProcesoEntity> Get()
        {
            return ap.GetAll();
        }

        // GET api/aspiranteproceso/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/aspiranteproceso
        public void Post(AspiranteProceso a)
        {
            ap.AddAspiranteProceso(a);
        }

        // PUT api/aspiranteproceso/5
        public void Put(int id, [FromBody]string value)
        {

        }

        // DELETE api/aspiranteproceso/5
        public void Delete(int id)
        {
        }
    }
}
