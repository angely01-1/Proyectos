using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proyectos.Models.Conex;
using Proyectos.Models;

namespace Proyectos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DBTerceroController : ControllerBase
    {
        private DBTercero db;
        private DBTercero db_tercero;

        public DBTerceroController()
        {
            db = new DBTercero();
            db_tercero = new DBTercero();
        }

        [HttpGet]
        [Route("GetTercero")]
        public Tercero GetTercero(int id)
        {
            DBUsuario dbUsuario = new DBUsuario();
            Tercero terceroResponse = db_tercero.GetTercero(id);
            Usuario usuario= dbUsuario.GetUsuarioPorIdTercero(terceroResponse.Id);
            terceroResponse.Usuario = usuario;
            return terceroResponse;

            //try
            //{
               // return db.GetTercero(id);
            //}
            //catch (Exception)
            //{
              //  throw;
           // }
        }

        [HttpGet]
        [Route("GetlstTercero")]
        public List<Tercero> GetlstTercero()
        {
            try
            {
                return db.GetListaTerceros();
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        [Route("SetDBTercero")]
        public Boolean SetTercero([FromBody] Tercero tercero)
        {
            try
            {
                return db.SetTercero(tercero);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut]
        [Route("Updatetercero")]
        public Boolean Updatetercero([FromBody] Tercero tercero)
        {
            try
            {
                return db.UpdateTercero(tercero);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpDelete]
        [Route("DeleteTercero")]
        public Boolean DeleteTercero(int id)
        {
            try
            {
                return db.DeleteTercero(id);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
   