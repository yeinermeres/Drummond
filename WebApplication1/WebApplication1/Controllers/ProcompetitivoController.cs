using BLL;
using Dal;
using Entity.VISTAS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication1.Controllers
{
    public class ProcompetitivoController : ApiController
    {
        ProcompetitivoBLL proc = new ProcompetitivoBLL();

        // GET: api/Procompetitivo
        public List<Vproyec_competitivo> Get()
        {
            return proc.VProyec_procompetitivos();
        }

        // GET: api/Procompetitivo/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Procompetitivo
        public void Post(Proceso_Competitivo p)
        {
            proc.ProcopetitivoAdd(p);
        }

        // PUT: api/Procompetitivo/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Procompetitivo/5
        public void Delete(int id)
        {
        }
    }
}
