using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PancakeProwler.Search
{
    public class SearchProvider
    {
        public bool AddToIndex(PancakeProwler.Data.Common.Models.Recipe recipe)
        {
            var client = GetClient();
            var uri = new Uri(new Uri(System.Configuration.ConfigurationManager.AppSettings["SearchBaseURI"]), "indexes/recipes/docs/index?api-version=2014-10-20-Preview");

            HttpRequestMessage request = BuildAddRequest(recipe, uri);

            return client.SendAsync(request).Result.StatusCode == System.Net.HttpStatusCode.OK;
        }

        public IEnumerable<SearchResult> Search(string term)
        {
            var client = GetClient();
            var uri = new Uri(new Uri(System.Configuration.ConfigurationManager.AppSettings["SearchBaseURI"]), "indexes/recipes/docs?api-version=2014-10-20-Preview&search=" + term);

            var request = new HttpRequestMessage(HttpMethod.Get, uri);
            var result = client.SendAsync(request).Result;
            var content = result.Content.ReadAsStringAsync().Result;

            return Newtonsoft.Json.JsonConvert.DeserializeObject<SearchResultEnvelope>(content).value;
        }

        private static HttpClient GetClient()
        {
            var client = new HttpClient();

            client.DefaultRequestHeaders.Add("api-key", System.Configuration.ConfigurationManager.AppSettings["SearchAPIKey"]);
            return client;
        }
        private HttpRequestMessage BuildAddRequest(PancakeProwler.Data.Common.Models.Recipe recipe, Uri uri)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, uri);

            var model = new SendToSearchEnvelope();
            model.value.Add(new SendToSearchItem { Action = "upload", id = recipe.Id.ToString(), ingredients = recipe.Ingredients, name = recipe.Name, steps = recipe.Steps });

            request.Content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            return request;
        }

        
    }

    public class SearchResultEnvelope
    {
        public IEnumerable<SearchResult> value { get; set; }
        
    }
    public class SearchResult
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
