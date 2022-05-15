using SegundaAsignacion.BL.Dtos;

namespace SegundaAsignacion.Services.JWT
{
    public interface IGenerateToken
    {
        string CreateToken(EstudiantesDto estudiantesDto);
    }
}
