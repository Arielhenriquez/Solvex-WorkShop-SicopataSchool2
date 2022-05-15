using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using SegundaAsignacion.BL.Dtos;
using SegundaAsignacion.Model.Entities;
using SegundaAsignacion.Services.GenericServices;
using SegundaAsignacion.Services.JWT;

namespace SegundaAsignacion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstudiantesController : ControllerBase
    {
        private readonly ICrudEstudiantes _estudiantesServices;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private IGenerateToken _generateToken;
        private Estudiantes estudiantes;

        public EstudiantesController(ICrudEstudiantes estudiantesServices, IMapper mapper, IConfiguration configuration, IGenerateToken generateToken)
        {
            _estudiantesServices = estudiantesServices;
            _mapper = mapper;
            _configuration = configuration;
            _generateToken = generateToken;
            estudiantes = new Estudiantes();
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

        [EnableQuery]
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
            string token = _generateToken.CreateToken(estudiantesDto);
            return Ok(token);
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
        public IActionResult DeleteEstudiantes(int id)
        {
            _estudiantesServices.DeleteEstudiantes(id);
            return Ok("Data Deleted");
        }
    }
}
