using Microsoft.EntityFrameworkCore;
using SegundaAsignacion.Core.BaseEntity;
using SegundaAsignacion.Model.Context;

namespace SegundaAsignacion.Model.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly SegundaAsignacionDbContext? _segundaAsignacionDbContext;
        private DbSet<TEntity> entities;

        public Repository(SegundaAsignacionDbContext segundaAsignacionDbContext)
        {
            _segundaAsignacionDbContext = segundaAsignacionDbContext;
            entities = segundaAsignacionDbContext.Set<TEntity>();
        }
        public IQueryable<TEntity> GetAll()
        {
            return entities.AsQueryable();
        }
        public TEntity Get(int Id)
        {
            return entities.SingleOrDefault(c => c.Id == Id);
        }

        public void Insert(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entity.FechaCreada = DateTime.Now;
            entity.Eliminado = false;
            entities.Add(entity);
            _segundaAsignacionDbContext.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Update(entity);
            _segundaAsignacionDbContext.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
            _segundaAsignacionDbContext.SaveChanges();
        }

        public void Remove(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
        }

        public void SaveChanges()
        {
            _segundaAsignacionDbContext.SaveChanges();
        }


    }
}
