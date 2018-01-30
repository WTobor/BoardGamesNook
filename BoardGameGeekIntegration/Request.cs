using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace BoardGameGeekIntegration
{
    public static class Request
    {
        public static async Task<string> GetAsync(string url)
        {
            var result = string.Empty;
            var requestUrl = new Uri(url);
            var request = WebRequest.Create(requestUrl) as HttpWebRequest;

            using (var response = request.GetResponse() as HttpWebResponse)
            {
                var reader = new StreamReader(response.GetResponseStream());
                result = await reader.ReadToEndAsync();
            }

            return result;
        }
    }
}