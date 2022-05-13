using SegundaAsignacion.Model.Entities;
using SegundaAsignacion.Model.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegundaAsignacion.Services.GenericServices
{
    public class CrudNotas : ICrudNotas
    {
        private IRepository<Notas> _repository;

        public CrudNotas(IRepository<Notas> repository)
        {
            _repository = repository;
        }
        public IQueryable<Notas> GetAllNotas()
        {
            return _repository.GetAll();
        }

        public Notas GetNotas(int id)
        {
            return _repository.Get(id);
        }

        public void InsertNotas(Notas entity)
        {
            _repository.Insert(entity);
        }

        public void UpdateNotas(Notas entity)
        {
            _repository.Update(entity);
        }
        public void DeleteNotas(int id)
        {
            Notas entity = GetNotas(id);
            _repository.Remove(entity);
            _repository.SaveChanges();
        }
    }
}

