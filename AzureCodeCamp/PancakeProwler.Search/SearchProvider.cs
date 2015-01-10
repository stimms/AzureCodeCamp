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
            //1. get client
            //2. craft url
            //3. send request
            throw new NotImplementedException();
        }

        public IEnumerable<SearchResult> Search(string term)
        {
            //1. get client
            //2. craft url
            //3. send request
            throw new NotImplementedException();
        }

        private static HttpClient GetClient()
        {
            //1. create http client
            //2. add api-key header
            
            var client = new HttpClient();

            client.DefaultRequestHeaders.Add("api-key", System.Configuration.ConfigurationManager.AppSettings["SearchAPIKey"]);
            return client;
        }
        private HttpRequestMessage BuildAddRequest(PancakeProwler.Data.Common.Models.Recipe recipe, Uri uri)
        {
            //1. create a new post request
            //2. create a new envelope
            //3. add items to envelope
            //4. set request content
            //5. return request

            throw new NotImplementedException();
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
