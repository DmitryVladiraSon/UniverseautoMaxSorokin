namespace Universeauto.Models.Categories
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> Categories { get; }

        void AddCategory(Category category);
        void UpdateCategory(Category category);
        void DeleteCategory(Category category);
    }
}

