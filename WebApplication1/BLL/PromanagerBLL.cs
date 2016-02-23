using Dal;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class PromanagerBLL
    {
        ModelContex contex;

        public void ProManagerAdd(Proyec_Manager promager)
        {
            using (var contex = new ModelContex())
            {
                contex.Pro_Manager.Add(promager);
                contex.SaveChanges();
            }
        }


        public List<ProjerManagerEntity> GetAll()
        {

            using (var contex = new ModelContex())
            {
                var dto = contex.Pro_Manager.ToList();
                List<ProjerManagerEntity> lisp = new List<ProjerManagerEntity>();

                if (dto != null)
                {
                    foreach (var item in dto)
                    {
                        ProjerManagerEntity promanger = new ProjerManagerEntity();
                        promanger.ID_PROMANAGER = item.ID_PROMANAGER;
                        promanger.DOCUMENTO = item.DOCUMENTO;
                        promanger.NOMBRE = item.NOMBRE;
                        promanger.P_APELLIDO = item.P_APELLIDO;
                        promanger.S_APELLIDO = item.S_APELLIDO;
                        promanger.CARGO = item.CARGO;
                        lisp.Add(promanger);
                    }
                    return lisp;
                }
                return lisp;
            }
        }

        public List<ProjerManagerEntity> GetAllPromanager(int id)
        {

            using (var contex = new ModelContex())
            {
                var dto = contex.Pro_Manager.Where(t => t.ID_PROMANAGER == id).ToList();
                List<ProjerManagerEntity> lisp = new List<ProjerManagerEntity>();

                if (dto != null)
                {
                    foreach (var item in dto)
                    {
                        ProjerManagerEntity promanger = new ProjerManagerEntity();
                        promanger.ID_PROMANAGER = item.ID_PROMANAGER;
                        promanger.DOCUMENTO = item.DOCUMENTO;
                        promanger.NOMBRE = item.NOMBRE;
                        promanger.P_APELLIDO = item.P_APELLIDO;
                        promanger.S_APELLIDO = item.S_APELLIDO;
                        promanger.CARGO = item.CARGO;
                        lisp.Add(promanger);
                    }
                    return lisp;
                }
                return lisp;
            }
        }

        public void UpdatePromanager(int id, Proyec_Manager promanager)
        {
            using (var contex = new ModelContex())
            {
                var dto = contex.Pro_Manager.Where(t => t.ID_PROMANAGER == id).First();
                if (dto != null)
                {
                    dto.NOMBRE = promanager.NOMBRE;
                    dto.P_APELLIDO = promanager.P_APELLIDO;
                    dto.S_APELLIDO = promanager.S_APELLIDO;
                    dto.CARGO = promanager.CARGO;
                    contex.SaveChanges();
                }
            }
        }

        public void RemovePromanager(int id)
        {
            using (var contex = new ModelContex())
            {
                var dto = contex.Pro_Manager.Where(t => t.ID_PROMANAGER == id).First();
                if (dto != null)
                {
                    contex.Pro_Manager.Remove(dto);
                    contex.SaveChanges();
                }
            }
        }

    }
}
