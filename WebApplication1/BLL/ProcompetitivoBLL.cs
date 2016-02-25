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
    public class ProcompetitivoBLL
    {
        /// <summary>
        /// Meotodo para la creacion de nuevo proceso competitivo
        /// </summary>
        /// <param name="prc"></param>
        public void ProcopetitivoAdd(Proceso_Competitivo prc)
        {
            using (var contex = new ModelContex())
            {
                contex.Proceso_Competitivo.Add(prc);
                contex.SaveChanges();

            }
        }


        /// <summary>
        /// metodo retorna una lista de procesos competitivos asociandos a un proyecto
        /// </summary>
        /// <returns></returns>
        public List<Vproyec_competitivo> VProyec_procompetitivos()
        {
            using (var contex = new ModelContex())
            {
                List<Vproyec_competitivo> proc = new List<Vproyec_competitivo>();

                var result = from proce in contex.Proceso_Competitivo
                             join
                              proye in contex.Proyecto on proce.PROYECTO_COMPETITIVO equals proye.PROYEC_ID
                             select new
                             {
                                 ID_COMPETITIVO = proce.ID_COMPETITIVO,
                                 PROCESO = proce.PROCESO,
                                 TIEMPO_EJECUCION = proce.TIEMPO_EJECUCION,
                                 TIEMPO_PROCESO = proce.TIEMPO_PROCESO,
                                 FECHA_INICIO = proce.FECHA_INICO,
                                 FECHA_INIC_SERVICE = proce.FECHA_INIC_SERVICE,
                                 DETALLE_PS = proce.DETALLE_PS,
                                 CANTIDAD = proce.CANTIDAD,
                                 VALOR_ESTIMADO = proce.VALOR_ESTIMADO,
                                 PROYECTO = proye.PROYECTO,
                                 LUGAR_EJECUCION = proce.LUGAR_EJECUCION,
                             };
                if (result != null)
                {
                    foreach (var item in result)
                    {
                        Vproyec_competitivo proceso = new Vproyec_competitivo();
                        proceso.ID_COMPETITIVO = item.ID_COMPETITIVO;
                        proceso.PROCESO = item.PROCESO;
                        proceso.TIEMPO_PROCESO = item.TIEMPO_PROCESO;
                        proceso.FECHA_INICO = item.FECHA_INICIO;
                        proceso.FECHA_INIC_SERVICE = item.FECHA_INIC_SERVICE;
                        proceso.TIEMPO_EJECUCION = item.TIEMPO_EJECUCION;
                        proceso.DETALLE_PS = item.DETALLE_PS;
                        proceso.CANTIDAD = item.CANTIDAD;
                        proceso.LUGAR_EJECUCION = item.LUGAR_EJECUCION;
                        proceso.VALOR_ESTIMADO = item.VALOR_ESTIMADO;
                        proceso.PROYECTO = item.PROYECTO;
                        proc.Add(proceso);

                    }
                    return proc;
                }

                return proc;
            }

        }

        /// <summary>
        /// metodo para consultar listado actual de procesos competitivos
        /// </summary>
        /// <returns></returns>
        public List<ProcompetitivoEntity> GetAllPcompetitivo()
        {
            using (var contex = new ModelContex())
            {
                List<Proceso_Competitivo> lprc = contex.Proceso_Competitivo.ToList();
                List<ProcompetitivoEntity> proc = new List<ProcompetitivoEntity>();
                if (lprc != null)
                {
                    foreach (var item in lprc)
                    {
                        ProcompetitivoEntity proceso = new ProcompetitivoEntity();
                        proceso.ID_COMPETITIVO = item.ID_COMPETITIVO;
                        proceso.PROCESO = item.PROCESO;
                        proceso.PROCESO_INICIO = item.PROCESO_INICIO;
                        proceso.TIEMPO_PROCESO = item.TIEMPO_PROCESO;
                        proceso.FECHA_INICO = item.FECHA_INICO;
                        proceso.FECHA_INIC_SERVICE = item.FECHA_INIC_SERVICE;
                        proceso.TIEMPO_EJECUCION = item.TIEMPO_EJECUCION;
                        proceso.DETALLE_PS = item.DETALLE_PS;
                        proceso.CANTIDAD = item.CANTIDAD;
                        proceso.UNIDAD = item.UNIDAD;
                        proceso.LUGAR_EJECUCION = item.LUGAR_EJECUCION;
                        proceso.VALOR_ESTIMADO = item.VALOR_ESTIMADO;
                        proceso.VALOR_TOTAL = item.VALOR_TOTAL;
                        proc.Add(proceso);

                    }
                    return proc;
                }
                return proc;
            }
        }

        public List<ProcompetitivoEntity> GetProceso(int id)
        {
            using (var contex = new ModelContex())
            {
                var dto = contex.Proceso_Competitivo.Where(t => t.ID_COMPETITIVO == id).ToList();
                List<ProcompetitivoEntity> Lisproceso = new List<ProcompetitivoEntity>();

                if (dto != null)
                {
                    foreach (var item in dto)
                    {
                        ProcompetitivoEntity proceso = new ProcompetitivoEntity();
                        proceso.ID_COMPETITIVO = item.ID_COMPETITIVO;
                        proceso.PROCESO = item.PROCESO;
                        proceso.PROCESO_INICIO = item.PROCESO_INICIO;
                        proceso.TIEMPO_PROCESO = item.TIEMPO_PROCESO;
                        proceso.FECHA_INICO = item.FECHA_INICO;
                        proceso.FECHA_INIC_SERVICE = item.FECHA_INIC_SERVICE;
                        proceso.TIEMPO_EJECUCION = item.TIEMPO_EJECUCION;
                        proceso.DETALLE_PS = item.DETALLE_PS;
                        proceso.CANTIDAD = item.CANTIDAD;
                        proceso.UNIDAD = item.UNIDAD;
                        proceso.LUGAR_EJECUCION = item.LUGAR_EJECUCION;
                        proceso.VALOR_ESTIMADO = item.VALOR_ESTIMADO;
                        proceso.VALOR_TOTAL = item.VALOR_TOTAL;
                        Lisproceso.Add(proceso);
                    }
                    return Lisproceso;
                }

                return Lisproceso;
            }
        }

        /*

        public List<AspirantesEntity> GetAspirantes(int id)
        {
            using (var contex = new ModelContex())
            {
                var Lisp = contex.Aspirantes.Where(a => a.ASPIRANTE_ID == id).ToList();
                List<AspirantesEntity> resul = new List<AspirantesEntity>();
                if (Lisp.Count != 0)
                {
                    foreach (var item in Lisp)
                    {
                        AspirantesEntity aspirante = new AspirantesEntity();                        
                        aspirante.ASPIRANTE_ID = item.ASPIRANTE_ID;
                        aspirante.NIT_CEDULA = item.NIT_CEDULA;
                        aspirante.NOM_RAZONSOCIAL = item.NOM_RAZONSOCIAL;
                        aspirante.CORREO = item.CORREO;
                        aspirante.DIRECCION = item.DIRECCION;
                        aspirante.CIUDAD = item.CIUDAD;
                        aspirante.DEPARTAMENTO = item.DEPARTAMENTO;
                        aspirante.TELEFONO = item.TELEFONO;
                        resul.Add(aspirante);
                    }

                    return resul;
                }
                return resul;
            }
        }
        */
        public List<AspirantesEntity> GetAspirantes(int idProceso)
        {
            using (var contex = new ModelContex())
            {
                var query = contex.Aspirantes.Where(t => t.AspiranteProceso.Where(tt => tt.ID_PROCESO == idProceso).Count() > 0).ToList();

                 /*
                  var query = from ap in contex.AspiranteProceso
                            join asp in contex.Aspirantes on ap.ID_ASPIRANTE equals asp.ASPIRANTE_ID
                            join pc in contex.Proceso_Competitivo on ap.ID_PROCESO equals idProceso
                            select new { asp.ASPIRANTE_ID, asp.NIT_CEDULA,asp.NOM_RAZONSOCIAL,
                                asp.CORREO,asp.DIRECCION,asp.CIUDAD,asp.DEPARTAMENTO,asp.TELEFONO };
                 
                 */
                List<AspirantesEntity> resul = new List<AspirantesEntity>();
                if (query != null)
                {
                    foreach (var item in query)
                    {
                        AspirantesEntity aspirante = new AspirantesEntity();
                        aspirante.ASPIRANTE_ID = item.ASPIRANTE_ID;
                        aspirante.NIT_CEDULA = item.NIT_CEDULA;
                        aspirante.NOM_RAZONSOCIAL = item.NOM_RAZONSOCIAL;
                        aspirante.CORREO = item.CORREO;
                        aspirante.DIRECCION = item.DIRECCION;
                        aspirante.CIUDAD = item.CIUDAD;
                        aspirante.DEPARTAMENTO = item.DEPARTAMENTO;
                        aspirante.TELEFONO = item.TELEFONO;
                        resul.Add(aspirante);
                    }

                    return resul;
                }
                return resul;
            }
        }
    }
}
