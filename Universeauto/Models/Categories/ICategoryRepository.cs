namespace Universeauto.Models.Categories
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> Categories { get; }

    }
}

