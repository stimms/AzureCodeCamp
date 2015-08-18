using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using Nest;
using Newtonsoft.Json;
using PancakeProwler.Data.Common.Models;

namespace PancakeProwler.Search
{
    public class ElasticSearchProvider : ISearchProvider
    {
        public bool AddToIndex(Recipe recipe)
        {
            var client = GetClient();
            var response = client.Index(recipe);
            return response.Created;
        }

        public IEnumerable<SearchResult> Search(string term)
        {
            var client = GetClient();
            var results = client.Search<Recipe>(s => s.Query(q => q.QueryString(d => d.Query(term))));
            return results.Documents.Select(d => new SearchResult {Name = d.Name, Id = d.Id});
        }

        private ElasticClient GetClient( ) {
            var node = new Uri(System.Configuration.ConfigurationManager.AppSettings["ElasticSearchBaseURI"]);
            var settings = new ConnectionSettings(node, "recipes");
            return new ElasticClient(settings);
        }
    }
}