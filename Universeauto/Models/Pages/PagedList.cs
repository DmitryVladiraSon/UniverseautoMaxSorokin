using Microsoft.EntityFrameworkCore.Query.Internal;

namespace Universeauto.Models.Pages
{
    public class PagedList<T> : List<T>
    {
        public PagedList(IQueryable<T> query, QueryOptions  options = null) {
            CurrentPage = options.CurrentPage;
            PageSize = options.PageSize;
            TotalPages = (int)Math.Ceiling((double)query.Count() / PageSize);
            AddRange(query.Skip((CurrentPage - 1) * PageSize).Take(PageSize));

        }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public bool HasPreviousPage => CurrentPage > 1;
        public bool HasNextPage => CurrentPage < TotalPages;    
    }
}
