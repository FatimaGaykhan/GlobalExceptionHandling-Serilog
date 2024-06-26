using System;
using System.Linq.Expressions;
using Domain.Common;

namespace Repository.Repositories.Interfaces
{
	public interface IBaseRepository<T> where T:BaseEntity
	{
		Task CreateAsync(T entity);
		Task EditAsync(T entity);
		Task DeleteAsync(T entity);
		Task<IEnumerable<T>> GetAllAsync();
		Task<T> GetById(int id);
		Task<T> GetAsync(int id);
		IQueryable<T> FindBy(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes);

    }
}

