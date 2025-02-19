using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using L01_2022RR651_2022VM651.Models;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore;
using laboratorioWebActivas.Models;

namespace L01_2022RR651_2022VM651.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class usuariosController : ControllerBase
    {
        private readonly blogDBContext _blogDBCcontext;

        public usuariosController(blogDBContext blogDBContext)
        {
            _blogDBCcontext = blogDBContext;
        }

        //Metodo para obtener todos los usuarios
        [HttpGet]
        [Route("GetAllUsuarios")]
        public IActionResult GetAllUsuarios()
        {
            List<usuarios> listadoUsuarios = (from u in _blogDBCcontext.usuarios
                                              select u).ToList();
            if (listadoUsuarios.Count() == 0)
            {
                return NotFound();
            }

            return Ok(listadoUsuarios);
        }

        //Metodo para crear usuario
        [HttpPost]
        [Route("AddUsuarios")]
        public IActionResult AddUsuarios([FromBody] usuarios usuario)
        {
            try
            {
                _blogDBCcontext.usuarios.Add(usuario);
                _blogDBCcontext.SaveChanges();
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //Metodo para actualizar usuario
        [HttpPut]
        [Route("actualizar/{id}")]
        public IActionResult actualizar(int id, [FromBody] usuarios usuario)
        {
            usuarios? usuarioActual = (from u in _blogDBCcontext.usuarios
                                       where u.usuarioId == id
                                       select u).FirstOrDefault();

            if (usuarioActual == null)
            {
                return NotFound();
            }


            
            usuarioActual.nombreUsuario = usuario.nombreUsuario;
            usuarioActual.clave = usuario.clave;
            usuarioActual.nombre = usuario.nombre;
            usuarioActual.apellido = usuario.apellido;

            _blogDBCcontext.Entry(usuarioActual).State = EntityState.Modified;
            _blogDBCcontext.SaveChanges();

            return Ok(usuarioActual);
        }

        //Metodo para eliminar usuario
        [HttpDelete]
        [Route("eliminar/{id}")]
        public IActionResult eliminarUsuario(int id)
        {
            usuarios? usuario = (from u in _blogDBCcontext.usuarios
                                 where u.usuarioId == id
                                 select u).FirstOrDefault();

            if (usuario == null)
            {
                return NotFound();
            }

            _blogDBCcontext.usuarios.Attach(usuario);
            _blogDBCcontext.usuarios.Remove(usuario);
            _blogDBCcontext.SaveChanges();

            return Ok(usuario);
        }

        //Metodo de mostrar un listado filtrado por nombre y apellido
        [HttpGet]
        [Route("Find/{nombre}/{apellido}")]
        public IActionResult FindByNombreAndApellido(string nombre,string apellido)
        {
            usuarios? usuarios = (from u in _blogDBCcontext.usuarios
                                  where u.nombre == nombre && u.apellido == apellido
                                  select u).FirstOrDefault();

            if (usuarios == null)
            {
                return NotFound();
            }

            return Ok(usuarios);
        }
    }
}
