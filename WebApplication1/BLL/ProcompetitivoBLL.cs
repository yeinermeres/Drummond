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


    }
}
