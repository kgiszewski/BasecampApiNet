using System.Net.Http;
using System.Threading.Tasks;
using BasecampApiNet.Core;

namespace BasecampApiNet.Helpers
{
    public static class WebHelper
    {
        public async static Task<string> Get(string url)
        {
            using (var client = new HttpClient(new HttpClientHandler() { Credentials = BasecampApi.Credentials }))
            {
                client.DefaultRequestHeaders.Add("User-Agent", "BasecampApiNet (" + BasecampApi.Username + ")");

                return await client.GetStringAsync(url).ConfigureAwait(false);
            }
        }

        public async static Task<string> Post(string url, HttpContent content)
        {
            using (var client = new HttpClient(new HttpClientHandler() { Credentials = BasecampApi.Credentials }))
            {
                client.DefaultRequestHeaders.Add("User-Agent", "BasecampApiNet (" + BasecampApi.Username + ")");

                var response = await client.PostAsync(url, content).ConfigureAwait(false);

                return await response.Content.ReadAsStringAsync();
            }
        }
    }
}
