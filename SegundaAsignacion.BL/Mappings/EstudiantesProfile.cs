using AutoMapper;
using SegundaAsignacion.BL.Dtos;
using SegundaAsignacion.Model.Entities;

namespace SegundaAsignacion.BL.Mappings
{
    public class EstudiantesProfile : Profile
    {
        public EstudiantesProfile()
        {
            CreateMap<EstudiantesDto, Estudiantes>();
            CreateMap<NotasDto, Notas>();
        }
    }
}
