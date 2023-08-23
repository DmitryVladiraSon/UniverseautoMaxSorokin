namespace Universeauto.Models.Categories
{
    public interface ICategoryRepository :IRepository<Category>
    {
        IEnumerable<Category> Categories { get; }

    }
}

