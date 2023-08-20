namespace Universeauto.Models
{
	public interface IRepository<TEntity> where TEntity : class
	{
		void AddElement(TEntity entity);
		void UpdateElement(TEntity entity);
		void Delete(TEntity entity);
	}
}
