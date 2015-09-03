using System;
using System.Net.Http;
using System.Threading.Tasks;
using BasecampApiNet.Core;

namespace BasecampApiNet.Helpers
{
    public static class WebHelper
    {
        public async static Task<HttpResponseMessage> Get(string url, string eTag)
        {
            using (var client = new HttpClient(new HttpClientHandler() { Credentials = BasecampApiBase.Credentials }))
            {
                client.DefaultRequestHeaders.Add("User-Agent", "BasecampApiNet (" + BasecampApiBase.Username + ")");
                
                if (!string.IsNullOrEmpty(eTag))
                {
                    client.DefaultRequestHeaders.Add("If-None-Match", eTag);
                    //client.DefaultRequestHeaders.Add("If-Modified-Since", eTag);
                }

                return await client.GetAsync(url).ConfigureAwait(false);
            }
        }

        public async static Task<string> Post(string url, HttpContent content)
        {
            using (var client = new HttpClient(new HttpClientHandler() { Credentials = BasecampApiBase.Credentials }))
            {
                client.DefaultRequestHeaders.Add("User-Agent", "BasecampApiNet (" + BasecampApiBase.Username + ")");

                var response = await client.PostAsync(url, content).ConfigureAwait(false);

                return await response.Content.ReadAsStringAsync();
            }
        }
    }
}
