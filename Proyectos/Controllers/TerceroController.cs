using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proyectos.Models.Conex;
using Proyectos.Models;

namespace Proyectos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TerceroController : ControllerBase
    {
        public DB db;
        public TerceroController()
        {
            db = new DB();
        }

        [HttpGet]
        [Route("GetTerceros")]
        public List<Tercero> GetTerceros()
        {
            DB db = new DB();
            return db.LstTerceros;
        }


        [HttpGet]
        [Route("GetTercerosPrueba")]
        public Tercero? GetTerceroPrueba(int id)
        {
            try
            {
                for (int i = 0; i < db.LstTerceros.Count; i++)
                {
                    if (db.LstTerceros[i].Id == id)
                    {
                        return db.LstTerceros[i];
                    }
                }
                return null;

            }
            catch (Exception)
            {
                throw;
            }
        }


        [HttpPost]
        [Route("InsertTercero")]
        public string SetTercero([FromBody]Tercero tercero)
        {
            try
            {
                db.LstTerceros.Add(tercero);
                return "Guardado con exito";
            }catch (Exception ex)
            {
                return "Error:" + ex.Message;
            }
        }

        [HttpPut]
        [Route("UpdateTercero")]
        public string UpdateTercero([FromBody] Tercero tercero)
        {
            try
            {
                bool existe = false;
                int posicionEncontrado = 0;
                for (int i = 0; i < db.LstTerceros.Count; i++)
                {
                    if (db.LstTerceros[i].Id == tercero.Id)
                    {
                        existe = true;
                        posicionEncontrado = i;
                    }
                }
                if (existe == true)
                {
                    db.LstTerceros[posicionEncontrado] = tercero;
                }

                    else
                    {
                    db.LstTerceros.Add(tercero);

                    }
                return "Captando con exito";
                
            } catch (Exception ex)
            {
                return "Hubo un error" + ex.Message;
            }
        }
        [HttpPatch]
        [Route("ActualizaTercero")]
        public string ActualizaTercero(int id,[FromBody] Tercero tercero)
        {
            try
            {
                bool encontrado = false;
                int ubicado = 0;

                // Recorremos la lista para encontrar el objeto con el ID especificado.
                for (int i = 0; i < db.LstTerceros.Count; i++)
                {
                    if (db.LstTerceros[i].Id == id)
                    {
                        encontrado = true;
                        ubicado = i;
                        break; // Salimos del bucle una vez que encontramos el objeto.
                    }
                }

                if (encontrado)
                {
                    // Actualizamos el objeto en la lista con el nuevo valor.
                    db.LstTerceros[ubicado] = tercero;
                    return "Actualizado con éxito"; // Mensaje de éxito.
                }
                else
                {
                    return "Dato no encontrado"; // Mensaje de error si no se encuentra el objeto.
                }
            }
            catch (Exception ex)
            {
                return "Hubo un error: " + ex.Message; 
            }
        }


        [HttpDelete]
        [Route("EliminarTercero")]
        public string EliminarTercero(int id)
        {
            try
            {
                bool encontrado = false;
                int posicionEncontrado = 0;

               
                for (int i = 0; i < db.LstTerceros.Count; i++)
                {
                    if (db.LstTerceros[i].Id == id)
                    {
                        encontrado = true;
                        posicionEncontrado = i;
                        break;  
                    }
                }

               
                if (encontrado)
                {
                    db.LstTerceros.RemoveAt(posicionEncontrado);
                    return "Elimminado con exito";
                }
                else
                { 
                    return "Dato no encontrdzzzzzo";
                }             
            }
            catch (Exception ex)
            {
                return "Hubo un error: " + ex.Message;
            }
        }




    }
}
