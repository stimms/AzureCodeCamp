using System.Collections.Generic;

namespace PancakeProwler.Search
{
    public interface ISearchProvider
    {
        bool AddToIndex(PancakeProwler.Data.Common.Models.Recipe recipe);
        IEnumerable<SearchResult> Search(string term);
    }
}