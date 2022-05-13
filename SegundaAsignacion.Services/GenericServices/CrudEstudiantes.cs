using SegundaAsignacion.Model.Entities;
using SegundaAsignacion.Model.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegundaAsignacion.Services.GenericServices
{
    public class CrudEstudiantes : ICrudEstudiantes
    {
        private IRepository<Estudiantes> _repository;

        public CrudEstudiantes(IRepository<Estudiantes> repository)
        {
            _repository = repository;
        }
        public IQueryable<Estudiantes> GetAllEstudiantes()
        {
            return _repository.GetAll();
        }

        public Estudiantes GetEstudiantes(int id)
        {
            return _repository.Get(id);
        }

        public void InsertEstudiantes(Estudiantes entity)
        {
            _repository.Insert(entity);
        }

        public void UpdateEstudiantes(Estudiantes entity)
        {
            _repository.Update(entity);
        }
        public void DeleteEstudiantes(int id)
        {
            Estudiantes entity = GetEstudiantes(id);
            _repository.Remove(entity);
            _repository.SaveChanges();
        }
    }
}
