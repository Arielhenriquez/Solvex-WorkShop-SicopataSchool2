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
        private readonly ICrudEstudiantes _estudiantesServices;
        private readonly IMapper _mapper;
        public static Estudiantes estudiantes = new Estudiantes();

        public EstudiantesController(ICrudEstudiantes estudiantesServices, IMapper mapper)
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
        public IActionResult InsertEstudiantes(EstudiantesDto estudiantesDto)
        {
            estudiantes = _mapper.Map<Estudiantes>(estudiantesDto);
            _estudiantesServices.InsertEstudiantes(estudiantes);
            return Ok(estudiantesDto);
        }

        [HttpPut(nameof(UpdateEstudiantes))]
        public IActionResult UpdateEstudiantes(int id, EstudiantesDto estudiantesDto)
        {
            estudiantes = _estudiantesServices.GetEstudiantes(id);
            if (estudiantes is null)
                return null;

            _mapper.Map(estudiantesDto, estudiantes);

            _estudiantesServices.UpdateEstudiantes(estudiantes);

            estudiantes = _mapper.Map<Estudiantes>(estudiantesDto);

            return Ok(estudiantesDto);
        }

        [HttpDelete(nameof(DeleteEstudiantes))]
        public IActionResult DeleteEstudiantes(int Id)
        {
            _estudiantesServices.DeleteEstudiantes(Id);
            return Ok("Data Deleted");
        }
    }
}
