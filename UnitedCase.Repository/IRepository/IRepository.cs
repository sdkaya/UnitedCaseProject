using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using UnitedCase.Entity.Entities;

namespace UnitedCaseProject.Repository.IRepository
{
    public interface IRepository<TEntity> where TEntity : AbstractEntity
    {

        Task Update(TEntity entityToUpdate);
        Task InsertAsync(TEntity entity);
        IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes);
        IQueryable<TEntity> GetAllAsync();
    }
}

