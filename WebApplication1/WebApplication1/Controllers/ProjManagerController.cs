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
    public class ProjManagerController : ApiController
    {
        PromanagerBLL prm = new PromanagerBLL();

        // GET: api/ProjManager
        public List<ProjerManagerEntity>Get()
        {
            return prm.GetAll();
        }

        // GET: api/ProjManager/5
        public List<ProjerManagerEntity>Get(int id)
        {
            return prm.GetAllPromanager(id);
        }

        // POST: api/ProjManager
        public void Post(Proyec_Manager promanager)
        {
            prm.ProManagerAdd(promanager);
        }

        // PUT: api/ProjManager/5
        public void Put(int id, Proyec_Manager promanager)
        {
            prm.UpdatePromanager(id, promanager);
        }

        // DELETE: api/ProjManager/5
        public void Delete(int id)
        {
            prm.RemovePromanager(id);
        }
    }
}
