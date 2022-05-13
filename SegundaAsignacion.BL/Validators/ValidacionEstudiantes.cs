using FluentValidation;
using SegundaAsignacion.BL.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegundaAsignacion.BL.Validators
{
    public class ValidacionEstudiantes : AbstractValidator<EstudiantesDto>
    {
        public ValidacionEstudiantes()
        {
            RuleFor(correo => correo.Correo).EmailAddress() 
                .WithMessage("Inserte un correo valido, que contenga un @.");
            RuleFor(clave => clave.Contraseña).NotEmpty().MaximumLength(6);
            RuleFor(nombre => nombre.Nombre).NotEmpty();
        }
    }
}
