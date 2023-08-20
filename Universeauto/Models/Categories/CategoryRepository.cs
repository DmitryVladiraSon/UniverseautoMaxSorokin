namespace Universeauto.Models.Categories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private DataContext context;
        public CategoryRepository(DataContext cnt) : base(cnt) => context = cnt;
        public IEnumerable<Category> Categories => context.Categories;
    }
}
