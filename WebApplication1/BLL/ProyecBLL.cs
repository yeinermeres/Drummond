
using Dal;
using Entity;
using Entity.VISTAS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ProyecBLL
    {
        ModelContex contex;

        /// <summary>
        /// Metodo para registrar un proyecto
        /// </summary>
        /// <param name="p"></param>
        public void AddProyecto(Proyecto p)
        {
            using (var contex = new ModelContex())
            {
                p.ESTADO_PROYEC = "C";
                contex.Proyecto.Add(p);
                contex.SaveChanges();
            }
        }

        /// <summary>
        /// Metodo para actualizar un proyecto
        /// </summary>
        /// <param name="p"></param>
        public void UpdateProyecto(Proyecto p)
        {
            using (var contex = new ModelContex())
            {
                var dto = contex.Proyecto.Where(t => t.PROYEC_ID == p.PROYEC_ID).First();
                if (dto != null)
                {

                    dto.B_U = p.B_U;
                    dto.GL_UNIT = p.GL_UNIT;
                    dto.AFE = p.AFE;
                    dto.CONTRATO = p.CONTRATO;
                    dto.PROGRAMA = p.PROGRAMA;
                    dto.PROYECTO = p.PROYECTO;
                    dto.AREA = p.AREA;
                    dto.CATEGORIA = p.CATEGORIA;
                    dto.TIPO = p.TIPO;
                    dto.ORIGEN = p.ORIGEN;
                    dto.FAMILIA = p.FAMILIA;
                    dto.COMP_ADQUISICION = p.COMP_ADQUISICION;
                    dto.DESC_GENERAL = p.DESC_GENERAL;
                    dto.PRESUPUESTO = p.PRESUPUESTO;
                    contex.SaveChanges();
                }
            }
        }

        /// <summary>
        /// Metodo para remover un proyecto
        /// </summary>
        /// <param name="id"></param>
        public void RemoveProyecto(int id)
        {
            using (var contex = new ModelContex())
            {
                var dto = contex.Proyecto.SingleOrDefault(p => p.PROYEC_ID == id);
                if (dto != null)
                {
                    dto.ESTADO_PROYEC = "A";
                    contex.SaveChanges();
                }
            }
        }

        /// <summary>
        /// Metodo retorna una el detalle de proyecto en especifico
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<ProyectosEntity> GetProyect(int id)
        {
            using (var contex = new ModelContex())
            {
                var dto = contex.Proyecto.Where(t => t.PROYEC_ID == id).ToList();
                List<ProyectosEntity> Lisproyec = new List<ProyectosEntity>();

                if (dto != null)
                {
                    foreach (var item in dto)
                    {
                        ProyectosEntity proyec = new ProyectosEntity();
                        proyec.B_U = item.B_U;
                        proyec.GL_UNIT = item.GL_UNIT;
                        proyec.AFE = item.AFE;
                        proyec.CONTRATO = item.CONTRATO;
                        proyec.PROGRAMA = item.PROGRAMA;
                        proyec.PROYECTO = item.PROYECTO;
                        proyec.AREA = item.AREA;
                        proyec.CATEGORIA = item.CATEGORIA;
                        proyec.TIPO = item.TIPO;
                        proyec.ORIGEN = item.ORIGEN;
                        proyec.FAMILIA = item.FAMILIA;
                        proyec.COMP_ADQUISICION = item.COMP_ADQUISICION;
                        proyec.DESC_GENERAL = item.DESC_GENERAL;
                        proyec.PRESUPUESTO = item.PRESUPUESTO;
                        Lisproyec.Add(proyec);
                    }
                    return Lisproyec;
                }

                return Lisproyec;
            }
        }

        /// <summary>
        /// Metodo Retorna una lista general de Proyectos,
        /// almacenados en el sistema
        /// </summary>
        public List<ProyectosEntity> GetAllProyect()
        {
            using (var contex = new ModelContex())
            {
                var result = from proyec in contex.Proyecto
                             where proyec.ESTADO_PROYEC != "A"
                             join Prom in contex.Pro_Manager on proyec.PROYEC_MANAGER equals Prom.ID_PROMANAGER
                             select new
                             {
                                 PROYEC_ID = proyec.PROYEC_ID,
                                 B_U = proyec.B_U,
                                 GL_UNIT = proyec.GL_UNIT,
                                 AFE = proyec.AFE,
                                 CONTRATO = proyec.CONTRATO,
                                 PROGRAMA = proyec.PROGRAMA,
                                 PROYECTO = proyec.PROYECTO,
                                 AREA = proyec.AREA,
                                 CATEGORIA = proyec.CATEGORIA,
                                 TIPO = proyec.TIPO,
                                 ORIGEN = proyec.ORIGEN,
                                 FAMILIA = proyec.FAMILIA,
                                 COMP_ADQUISICION = proyec.COMP_ADQUISICION,
                                 DESC_GENERAL = proyec.DESC_GENERAL,
                                 PRESUPUESTO = proyec.PRESUPUESTO,
                                 PROYEC_MANAGER = proyec.PROYEC_MANAGER,
                                 MANAGER = Prom.NOMBRE + " " + Prom.P_APELLIDO,
                             };
                List<ProyectosEntity> Lisproyec = new List<ProyectosEntity>();

                if (result != null)
                {
                    foreach (var item in result)
                    {
                        ProyectosEntity proyec = new ProyectosEntity();
                        proyec.PROYEC_ID = item.PROYEC_ID;
                        proyec.B_U = item.B_U;
                        proyec.GL_UNIT = item.GL_UNIT;
                        proyec.AFE = item.AFE;
                        proyec.CONTRATO = item.CONTRATO;
                        proyec.PROGRAMA = item.PROGRAMA;
                        proyec.PROYECTO = item.PROYECTO;
                        proyec.AREA = item.AREA;
                        proyec.CATEGORIA = item.CATEGORIA;
                        proyec.TIPO = item.TIPO;
                        proyec.ORIGEN = item.ORIGEN;
                        proyec.FAMILIA = item.FAMILIA;
                        proyec.COMP_ADQUISICION = item.COMP_ADQUISICION;
                        proyec.DESC_GENERAL = item.DESC_GENERAL;
                        proyec.PRESUPUESTO = item.PRESUPUESTO;
                        proyec.PROYEC_MANAGER = item.PROYEC_MANAGER;
                        proyec.MANAGER = item.MANAGER;
                        Lisproyec.Add(proyec);
                    }
                    return Lisproyec;
                }

                return Lisproyec;
            }
        }

        /// <summary>
        /// Metodo restorna todos los Procesos competitivos,
        /// asociados a un proyecto en especifico
        /// </summary>
        /// <returns></returns>
        public List<ProcompetitivoEntity> GetCompetitivo_proyectos(int id)
        {
            using (var contex = new ModelContex())
            {
                List<Proceso_Competitivo> Lisp = contex.Proceso_Competitivo.Where(p => p.PROYECTO_COMPETITIVO == id).ToList();
                List<ProcompetitivoEntity> resul = new List<ProcompetitivoEntity>();
                if (Lisp.Count != 0)
                {
                    foreach (var item in Lisp)
                    {
                        ProcompetitivoEntity proceso = new ProcompetitivoEntity();
                        proceso.LUGAR_EJECUCION = item.LUGAR_EJECUCION;
                        proceso.FECHA_INICO = item.FECHA_INICO;
                        proceso.FECHA_INIC_SERVICE = item.FECHA_INIC_SERVICE;
                        proceso.DETALLE_PS = item.DETALLE_PS;
                        proceso.VALOR_ESTIMADO = item.VALOR_ESTIMADO;
                        proceso.TIEMPO_EJECUCION = item.TIEMPO_EJECUCION;
                        proceso.TIEMPO_PROCESO = item.TIEMPO_PROCESO;
                        resul.Add(proceso);
                    }

                    return resul;
                }
                return resul;
            }
        }
    }
}
