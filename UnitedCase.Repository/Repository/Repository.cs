using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using UnitedCase.Entity.Entities;
using UnitedCaseProject.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace UnitedCase.Repository.Repository
{
    using Microsoft.EntityFrameworkCore;
    public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : AbstractEntity
    {
        protected readonly DbContext DbContext;
        protected readonly DbSet<TEntity> DbSet;

        protected GenericRepository(UnitedCaseProjectDbContext context)
        {
            DbContext = context;
            DbSet = DbContext.Set<TEntity>();
        }


        public async Task Update(TEntity entityToUpdate)
        {
            entityToUpdate.UpdateDate = DateTime.Now;
            DbSet.Update(entityToUpdate);
            await DbContext.SaveChangesAsync();

        }

        public async Task InsertAsync(TEntity entity)
        {
            entity.CreateDate = DateTime.Now;
            entity.IsActive = true;
            await DbSet.AddAsync(entity);
            await DbContext.SaveChangesAsync();
        }
        public IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes)
        {
            var query = GetAllAsync().Where(predicate);
            return includes.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        }

        public IQueryable<TEntity> GetAllAsync()
        {
            try
            {
                return DbSet;
            }
            catch (Exception ex)
            {

                throw;
            }
        }


    }
}
