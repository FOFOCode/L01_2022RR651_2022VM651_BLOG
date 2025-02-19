using L01_2022RR651_2022VM651.Models;
using laboratorioWebActivas.Models;
using Microsoft.AspNetCore.Mvc;

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


	}
}
