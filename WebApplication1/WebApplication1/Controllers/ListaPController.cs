using Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace WebApplication1.Controllers
{
    public class ListaPController : ApiController
    {
        // GET api/listap
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/listap/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/listap
        public IHttpActionResult Post()
        {
            using (var contex = new ModelContex())
            {
                AspiranteProceso ap = new AspiranteProceso();
                var ctx = contex.Aspirantes.Max(c => c.ASPIRANTE_ID);

                var request = HttpContext.Current.Request;
                if (request.Files.Count > 0)
                {
                    foreach (string file in request.Files)
                    {
                        var postedFile = request.Files[file];
                        var filePath = HttpContext.Current.Server.MapPath(string.Format("~/Documentos/{0}", postedFile.FileName));
                        ap.ID_ASPIRANTE = ctx;
                        ap.RUTA = filePath;
                        contex.AspiranteProceso.Add(ap);
                        contex.SaveChanges();
                        postedFile.SaveAs(filePath);
                    }
                    return Ok(true);
                }
                else
                {
                    return BadRequest();
                }
            }
        }

        // PUT api/listap/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/listap/5
        public void Delete(int id)
        {
        }
    }
}
