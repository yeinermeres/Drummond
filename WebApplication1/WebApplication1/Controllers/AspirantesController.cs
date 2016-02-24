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
    public class AspirantesController : ApiController
    {
        AspirantesBLL asp = new AspirantesBLL();

        // GET api/aspirantes
        public IList<AspirantesEntity> Get()
        {
            return asp.GetAllAspirantes();
        }

        // GET api/aspirantes/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/aspirantes
        public void Post(Aspirantes a)
        {
            asp.AddAspirante(a);
        }

        // PUT api/aspirantes/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/aspirantes/5
        public void Delete(int id)
        {
        }
    }
}
