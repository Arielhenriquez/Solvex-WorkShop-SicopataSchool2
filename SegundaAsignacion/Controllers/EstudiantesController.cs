using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SegundaAsignacion.BL.Dtos;
using SegundaAsignacion.Model.Entities;
using SegundaAsignacion.Services.GenericServices;

namespace SegundaAsignacion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstudiantesController : ControllerBase
    {
        private readonly ICrudService _estudiantesServices;
        private readonly IMapper _mapper;
        public static Estudiantes estudiantes = new Estudiantes();

        public EstudiantesController(ICrudService estudiantesServices, IMapper mapper)
        {
            _estudiantesServices = estudiantesServices;
            _mapper = mapper;
        }

        [HttpGet(nameof(GetEstudiantes))]
        public IActionResult GetEstudiantes(int id)
        {
            var result = _estudiantesServices.GetEstudiantes(id);
            if (result is not null)
            {
                return Ok(result);
            }
            return BadRequest("No records found");

        }

        [HttpGet(nameof(GetAllEstudiantes))]
        public IActionResult GetAllEstudiantes()
        {
            var result = _estudiantesServices.GetAllEstudiantes();
            if (result is not null)
            {
                return Ok(result);
            }
            return BadRequest("No records found");
        }

        [HttpPost(nameof(InsertEstudiantes))]
        public IActionResult InsertEstudiantes(EstudiantesDto estudiantesdto)
        {
            estudiantes = _mapper.Map<Estudiantes>(estudiantesdto);
            _estudiantesServices.InsertEstudiantes(estudiantes);
            return Ok("Data inserted");
        }

        //[HttpPut(nameof(UpdateEstudiantes))]
        //public IActionResult UpdateEstudiantes(EstudiantesDto estudiantes)
        //{
        //    _estudiantesServices.UpdateEstudiantes(estudiantes);
        //    return Ok("Updation done");

        //}

        [HttpDelete(nameof(DeleteEstudiantes))]
        public IActionResult DeleteEstudiantes(int Id)
        {
            _estudiantesServices.DeleteEstudiantes(Id);
            return Ok("Data Deleted");
        }
    }
}
