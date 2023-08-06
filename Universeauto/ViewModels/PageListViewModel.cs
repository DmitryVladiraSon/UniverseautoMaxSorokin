using Universeauto.Models.Pages;

namespace Universeauto.ViewModels
{
    public class PagedViewModel<T>
    {
        public PagedList<T> PagedList { get; set; }
        public QueryOptions Options { get; set; }

    }

}
