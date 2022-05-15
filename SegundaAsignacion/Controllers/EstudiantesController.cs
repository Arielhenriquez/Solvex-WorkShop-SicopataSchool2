using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SegundaAsignacion.BL.Dtos;
using SegundaAsignacion.Model.Entities;
using SegundaAsignacion.Services.GenericServices;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SegundaAsignacion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstudiantesController : ControllerBase
    {
        private readonly ICrudEstudiantes _estudiantesServices;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private Estudiantes estudiantes;

        public EstudiantesController(ICrudEstudiantes estudiantesServices, IMapper mapper, IConfiguration configuration)
        {
            _estudiantesServices = estudiantesServices;
            _mapper = mapper;
            _configuration = configuration;
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
            string token = CreateToken(estudiantesDto);
            return Ok(token);
        }
        private string CreateToken(EstudiantesDto estudiantesDto)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, estudiantesDto.Correo),
                new Claim(ClaimTypes.Role, "Admin")
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value));

            var credencials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: credencials);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
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
