using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proyectos.Models.Conex;
using Proyectos.Models;

namespace Proyectos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DBProductoController : ControllerBase
    {
        private DBProducto db;
        private DBProducto db_producto;

        public DBProductoController()
        {
            db = new DBProducto();
            db_producto = new DBProducto();
        }

        [HttpGet]
        [Route("GetDBProducto")]
        public Producto GetDBProducto(int codigo)
        {
             try
            {
             return db.GetProducto(codigo);
            }
            catch (Exception)
            {
               throw;
            }
        }

        [HttpGet]
        [Route("GetlstProducto")]
        public Usuario GetlstProductos(int codigo)
        {
            DBUsuario dbUsuario = new DBUsuario();
            Usuario usuario = new Usuario();
            usuario = dbUsuario.GetUsuario(codigo);

            DBProducto dbProducto = new DBProducto();
            List<Producto> productos = dbProducto.GetUsuarioPorProductoCodigo(codigo);
            usuario.Producto = productos;
            return usuario;
            // try
            // {
            //     return db.GetListaProductos();
            // }
            // catch (Exception)
            //{
            //    throw;
            // }
        }
      
        [HttpPost]
        [Route("SetProducto")]
        public Boolean SetProducto([FromBody] Producto producto)
        {
            try
            {
                return db.SetProducto(producto);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut]
        [Route("UpdateProducto")]
        public Boolean UpdateProducto([FromBody] Producto producto)
        {
            try
            {
                return db.UpdateProducto(producto);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpDelete]
        [Route("DeleteProducto")]
        public Boolean DeleteProducto(int codigo)
        {
            try
            {
                return db.DeleteProducto(codigo);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
