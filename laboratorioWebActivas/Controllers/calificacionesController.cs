using L01_2022RR651_2022VM651.Models;
using laboratorioWebActivas.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace L01_2022RR651_2022VM651.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class calificacionesController : Controller
	{
		private readonly blogDBContext _calificacionesContexto;

		public calificacionesController(blogDBContext blogDBContexto)
		{
			_calificacionesContexto = blogDBContexto;
		}

		[HttpGet]
		[Route("GetAll")]
		public IActionResult Get()
		{
			List<calificaciones> listadoCalificaciones = (from e in _calificacionesContexto.calificaciones select e).ToList();

			if (listadoCalificaciones.Count() == 0)
			{
				return NotFound();
			}
			return Ok(listadoCalificaciones);
		}

		//Método de guardar
		[HttpPost]
		[Route("Add")]
		public IActionResult GuardarCalificacion([FromBody] calificaciones calificacionesAdd)
		{
			try
			{
				_calificacionesContexto.calificaciones.Add(calificacionesAdd);
				_calificacionesContexto.SaveChanges();
				return Ok(calificacionesAdd);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		//Para modificar
		[HttpPut]
		[Route("actualizar/{id}")]
		public IActionResult ActualizarCalificacion(int id, [FromBody] calificaciones calificacionesModificar)
		{
			// Para actualizar un registro, se obtiene el registro original de la base de datos
			// al cual alteraremos alguna propiedad
			calificaciones? calificacionActual = (from a in _calificacionesContexto.calificaciones
								  where a.calificacionId == id
								  select a).FirstOrDefault();

			// Verificamos que exista el registro según su ID
			if (calificacionActual == null)
			{
				return NotFound();
			}

			// Si se encuentra el registro, se alteran los campos modificables
			
			calificacionActual.calificacion = calificacionesModificar.calificacion;


			// Se marca el registro como modificado en el contexto
			// y se envía la modificación a la base de datos
			_calificacionesContexto.Entry(calificacionActual).State = EntityState.Modified;
			_calificacionesContexto.SaveChanges();

			return Ok(calificacionesModificar);
		}



		[HttpDelete]
		[Route("eliminar/{id}")]
		public IActionResult EliminarCalificacion(int id)
		{
			calificaciones? calificacionActual = (from a in _calificacionesContexto.calificaciones where a.calificacionId == id select a).FirstOrDefault();

			if (calificacionActual == null)
				return NotFound();

			_calificacionesContexto.calificaciones.Attach(calificacionActual);
			_calificacionesContexto.calificaciones.Remove(calificacionActual);
			_calificacionesContexto.SaveChanges();
			return Ok(calificacionActual);
		}

		[HttpGet]
		[Route("GetByPublicacion/{id}")]
		public IActionResult GetCalificacionesPorPublicacion(int id)
		{
			List<calificaciones> listadoCalificaciones = _calificacionesContexto.calificaciones
				.Where(c => c.publicacionId == id)
				.ToList();

			if (listadoCalificaciones.Count == 0)
			{
				return NotFound("No hay calificaciones para esta publicación.");
			}
			return Ok(listadoCalificaciones);
		}



	}
}
