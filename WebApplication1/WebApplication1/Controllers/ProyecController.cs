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
    public class ProyecController : ApiController
    {
        ProyecBLL proyec = new ProyecBLL();

        // GET: api/Proyec
        public IList<ProyectosEntity> Get()
        {
            return proyec.GetAllProyect();
        }

        // GET: api/Proyec/5
        public List<ProcompetitivoEntity> Get(int id)
        {
            return proyec.GetCompetitivo_proyectos(id);
        }

        // POST: api/Proyec
        public void Post(Proyecto proyecto)
        {
            proyec.AddProyecto(proyecto);
        }

        // PUT: api/Proyec/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Proyec/5
        public void Delete(int id)
        {
            proyec.RemoveProyecto(id);
        }
    }
}
