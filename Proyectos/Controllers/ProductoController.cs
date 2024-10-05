using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proyectos.Models.Conex;
using Proyectos.Models;

namespace Proyectos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase

    {
        public DB db;
        public ProductoController()
        {
            db = new DB();
        }


        [HttpGet]
        [Route("GetProductos")]
        public List<Producto> GetProductos()
        {
            return db.LstProductos;
        }

        [HttpGet]
        [Route("GetProductoPrueba")]
        public Producto? GetProductoPrueba(int codigo)
        {
            try
            {
                for (int i = 0; i < db.LstProductos.Count; i++)
                {
                    if (db.LstProductos[i].Codigo == codigo)
                    {
                        return db.LstProductos[i];
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
        [Route("InsertProducto")]
        public string SetProducto([FromBody] Producto producto)
        {
            try
            {
                db.LstProductos.Add(producto);
                return "Guardado con exito";
            }

            catch (Exception ex)
            {
                return "Error:" + ex.Message;
            }
        }

        [HttpPut]
        [Route("UpdateProducto")]
        public string UpdateProducto([FromBody] Producto producto)
        {
            try
            {
                bool existe = false;
                int posicionEncontrado = 0;
                for (int i = 0; i < db.LstProductos.Count; i++)
                {
                    if (db.LstProductos[i].Codigo == producto.Codigo)
                    {
                        existe = true;
                        posicionEncontrado = i;
                    }
                }
                if (existe == true)
                {
                    db.LstProductos[posicionEncontrado] = producto;
                }

                else
                {
                    db.LstProductos.Add(producto);

                }
                return "Captando con exito";

            }
            catch (Exception ex)
            {
                return "Hubo un error" + ex.Message;
            }

        }
        [HttpPatch]
        [Route("ActualizaProducto")]
        public string ActualizaProducto(int codigo, [FromBody] Producto producto)
        {
            try
            {
                bool encontrado = false;
                int ubicacionEncontrada = 0;

                for (int i = 0; i < db.LstProductos.Count; i++)
                {
                    if (db.LstProductos[i].Codigo == codigo)
                    {
                        encontrado = true;
                        ubicacionEncontrada = i;
                        break; 
                    }
                }

                if (encontrado)
                {
                    db.LstProductos[ubicacionEncontrada] = producto;
                    return "Actualizado con éxito"; 
                }
                else
                {
                    return "Dato no encontrado"; 
                }
            }
            catch (Exception ex)
            {
                return "Hubo un error: " + ex.Message;
            }
        }


        [HttpDelete]
        [Route("EliminarProducto")]
        public string EliminarProducto(int codigo)
        {
            try
            {
                bool encontrado = false;
                int posicionEncontrado = 0;

                for (int i = 0; i < db.LstProductos.Count; i++)
                {
                    if (db.LstProductos[i].Codigo == codigo)
                    {          
                        encontrado = true;
                        posicionEncontrado = i;
                        break;  
                    }
                }
                if (encontrado)
                {
                    db.LstProductos.RemoveAt(posicionEncontrado);
                    return "Eliminado con éxito";
                }
                else
                {
                    
                    return "Dato no encontrado";
                }
            }
            catch (Exception ex)
            {
               
                return "Hubo un error: " + ex.Message;
            }
        }
    }
}
