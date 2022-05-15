using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SegundaAsignacion.BL.Dtos;
using SegundaAsignacion.Model.Entities;
using SegundaAsignacion.Services.GenericServices;

namespace SegundaAsignacion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class NotasController : ControllerBase
    {
        private readonly ICrudNotas _notasServices;
        private readonly IMapper _mapper;
        public static Notas notas = new Notas();

        public NotasController(ICrudNotas notasService, IMapper mapper)
        {
            _notasServices = notasService;
            _mapper = mapper;
        }

        [HttpGet(nameof(GetNotasById))]
        [Authorize(Roles = "Admin")]
        public IActionResult GetNotasById(int id)
        {
            var result = _notasServices.GetNotas(id);
            if (result is not null)
            {
                return Ok(result);
            }
            return BadRequest("No records found");

        }

        [HttpGet(nameof(GetAllNotas))]
        public IActionResult GetAllNotas()
        {
            var result = _notasServices.GetAllNotas();
            if (result is not null)
            {
                return Ok(result);
            }
            return BadRequest("No records found");
        }

        [HttpPost(nameof(InsertNotas))]
        public IActionResult InsertNotas(NotasDto notasDto)
        {
            notas = _mapper.Map<Notas>(notasDto);
            _notasServices.InsertNotas(notas);
            return Ok(notasDto);
        }

        [HttpPut(nameof(UpdateNotas))]
        public IActionResult UpdateNotas(int id, NotasDto notasDto)
        {
            notas = _notasServices.GetNotas(id);
            if (notas is null)
                return null;

            _mapper.Map(notasDto, notas);

            _notasServices.UpdateNotas(notas);

            notas = _mapper.Map<Notas>(notasDto);

            return Ok(notasDto);
        }

        [HttpDelete(nameof(DeleteEstudiantes))]
        public IActionResult DeleteEstudiantes(int Id)
        {
            _notasServices.DeleteNotas(Id);
            return Ok("Data Deleted");
        }
    }
}

