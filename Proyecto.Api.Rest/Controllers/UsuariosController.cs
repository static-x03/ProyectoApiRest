using ConeccionDataBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
namespace Proyecto.Api.Rest.Controllers
{
    public class UsuariosController : ApiController
    {
        UsuariosConections DB = new UsuariosConections();

        [HttpGet]
        public IEnumerable<usuario> GetUsuarios()
        {
            var listado = DB.usuario.ToList();
            return listado;
        }

        [HttpGet]
        public usuario GetUsuario(int id)
        {
            var getUsuarioId = DB.usuario.FirstOrDefault(x => x.int_id == id);
            return getUsuarioId;
        }

        [HttpPost]
        public IHttpActionResult AgregarUsuarios([FromBody]usuario usuario)
        {
            if (ModelState.IsValid)
            {
                DB.usuario.Add(usuario);
                DB.SaveChanges();
                return Ok(usuario);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public IHttpActionResult ActualizarUsuario(int id, [FromBody]usuario usuario)
        {
            if (ModelState.IsValid)
            {
                var usuarioEXiste = DB.usuario.Count(x => x.int_id == id) > 0;
                if (usuarioEXiste)
                {
                    DB.Entry(usuario).State = EntityState.Modified;
                    DB.SaveChanges();
                    return Ok("Usuario Actualizado...");
                }
                else
                {
                    return NotFound();
                }
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        public IHttpActionResult EliminarUsuario(int id)
        {
            var UsuarioEliminar = DB.usuario.Find(id);
            if(UsuarioEliminar != null)
            {
                DB.usuario.Remove(UsuarioEliminar);
                DB.SaveChanges();
                return Ok("Usuario Eliminado..");
            }
            else
            {
                return NotFound();
            }
        }
    }
}
