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
    public class FilesController : ApiController
    {
        // GET: api/Files
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Files/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Files
        public IHttpActionResult Post()
        {
            using (var contex = new ModelContex())
            {
                Archivo_Ruta archi = new Archivo_Ruta();
                var ctx = contex.Proceso_Competitivo.Max(c => c.ID_COMPETITIVO);
            
            var request = HttpContext.Current.Request;
            if (request.Files.Count > 0)
            {
                foreach (string file in request.Files)
                {
                    var postedFile = request.Files[file];
                    var filePath = HttpContext.Current.Server.MapPath(string.Format("~/Documentos/{0}", postedFile.FileName));
                    archi.PROCESO_ARCHIVO = ctx;
                    archi.RUTA = filePath;
                    contex.Archivo_Ruta.Add(archi);
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
        // PUT: api/Files/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Files/5
        public void Delete(int id)
        {
        }
    }
}
