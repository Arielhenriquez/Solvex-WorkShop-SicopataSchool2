using FluentValidation;
using SegundaAsignacion.BL.Dtos;

namespace SegundaAsignacion.BL.Validators
{
    public class ValidacionNotas : AbstractValidator<NotasDto>
    {
        public ValidacionNotas()
        {
            RuleFor(titulo => titulo.Titulo).NotEmpty().WithMessage("No puede estar vacio");
            RuleFor(descripcion => descripcion.Descripcion).NotEmpty().WithMessage("No puede estar vacio");
            RuleFor(nombre => nombre.Nombre).NotEmpty().WithMessage("No puede estar vacio");
        }
    }
}
