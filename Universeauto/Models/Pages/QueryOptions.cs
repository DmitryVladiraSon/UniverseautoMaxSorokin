namespace Universeauto.Models.Pages
{
    public class QueryOptions
    {
        public int CurrentPage { get; set; } = 1;
        public int PageSize { get; set; } = 10;

        public string OrderPropertyName { get; set; }   
        public bool DescendingOrder { get; set; } // descending - нисходящий

        public string SearchPropertyName { get; set; }
        public string SearchTerm{ get; set; }
    }
}
