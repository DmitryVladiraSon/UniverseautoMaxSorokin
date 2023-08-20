using Microsoft.EntityFrameworkCore;

namespace Universeauto.Models
{
	public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
	{
		protected readonly DataContext _dbContext;
		public Repository(DataContext dbContext)
		{
			_dbContext = dbContext;
		}
		public void AddElement(TEntity entity)
		{
			_dbContext.Set<TEntity>().Add(entity);
			_dbContext.SaveChanges();
		}

		public void Delete(TEntity entity)
		{
			_dbContext.Set<TEntity>().Remove(entity);
			_dbContext.SaveChanges();
		}

		public void UpdateElement(TEntity entity)
		{
			_dbContext.Set<TEntity>().Update(entity);
			_dbContext.SaveChanges();
		}
	}
}
