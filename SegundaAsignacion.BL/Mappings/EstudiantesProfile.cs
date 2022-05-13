using AutoMapper;
using SegundaAsignacion.BL.Dtos;
using SegundaAsignacion.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
