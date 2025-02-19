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
    public class comentariosController : ControllerBase
    {
        private readonly blogDBContext _blogDBCcontext;

        public comentariosController(blogDBContext blogDBContext)
        {
            _blogDBCcontext = blogDBContext;
        }

        //Metodo para obtener todos los comentarios
        [HttpGet]
        [Route("GetAllComentarios")]
        public IActionResult GetAllComentarios()
        {
            List<comentarios> listadoComentarios = (from c in _blogDBCcontext.comentarios
                                                    select c).ToList();
            if (listadoComentarios.Count() == 0)
            {
                return NotFound();
            }
            return Ok(listadoComentarios);
        }

        //Metodo para crear comentario
        [HttpPost]
        [Route("AddComentarios")]
        public IActionResult AddComentarios([FromBody] comentarios comentario)
        {
            try
            {
                _blogDBCcontext.comentarios.Add(comentario);
                _blogDBCcontext.SaveChanges();
                return Ok(comentario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //Metodo para actualizar comentario
        [HttpPut]
        [Route("actualizar/{id}")]
        public IActionResult actualizar(int id, [FromBody] comentarios comentario)
        {
            comentarios? comentariosActual = (from c in _blogDBCcontext.comentarios
                                              where c.cometarioId == id
                                              select c).FirstOrDefault();
            
            if(comentariosActual == null)
            {
                return NotFound();
            }

            
            comentariosActual.comentario = comentario.comentario;
            

            _blogDBCcontext.Entry(comentariosActual).State = EntityState.Modified;
            _blogDBCcontext.SaveChanges();

            return Ok(comentariosActual);
        }

        //Metodo para eliminar comentario
        [HttpDelete]
        [Route("eliminar/{id}")]
        public IActionResult eliminar(int id)
        {
            comentarios? comentariosActual = (from c in _blogDBCcontext.comentarios
                                              where c.cometarioId == id
                                              select c).FirstOrDefault();


            if (comentariosActual == null)
            {
                return NotFound();
            }

            _blogDBCcontext.comentarios.Attach(comentariosActual);
            _blogDBCcontext.comentarios.Remove(comentariosActual);
            _blogDBCcontext.SaveChanges();

            return Ok("Comentario eliminado");
        }

        //Metodo para obtener comentario por idUsuario
        [HttpGet]
        [Route("GetComentarioById/{id}")]
        public IActionResult GetComentarioById(int idUsuario)
        {
            comentarios? comentariosActual = (from c in _blogDBCcontext.comentarios
                                              where c.usuarioId == idUsuario
                                              select c).FirstOrDefault();
            if (comentariosActual == null)
            {
                return NotFound();
            }

            return Ok(comentariosActual);
        }
    }
}
