using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proyectos.Models.Conex;
using Proyectos.Models;

namespace Proyectos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DBUsuarioController : ControllerBase
    {
        private DBUsuario db;

        public DBUsuarioController()
        {
            db = new DBUsuario();
        }

        [HttpGet]
        [Route("GetUsuario")]
        public Usuario? GetUsuario(int id)
        {
            try
            {
                return db.GetUsuario(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        [Route("GetlstUsuario")]
        public List<Usuario> GetlstUsuario()
        {
            try
            {
                return db.GetListaUsuarios();
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        [Route("SetDBUsuario")]
        public Boolean SetUsuario([FromBody] Usuario usuario)
        {
            try
            {
                return db.SetUsuario(usuario);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut]
        [Route("Updateusuario")]
        public Boolean Updatetercero([FromBody] Usuario usuario)
        {
            try
            {
                return db.UpdateUsuario(usuario);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpDelete]
        [Route("DeleteUsuario")]
        public Boolean DeleteUsuario(int id)
        {
            try
            {
                return db.DeleteUsuario(id);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
