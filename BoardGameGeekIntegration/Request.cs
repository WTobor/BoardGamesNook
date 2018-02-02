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

            if (WebRequest.Create(requestUrl) is HttpWebRequest request)
                using (var response = request.GetResponse() as HttpWebResponse)
                {
                    if (response != null)
                    {
                        var reader = new StreamReader(response.GetResponseStream());
                        result = await reader.ReadToEndAsync();
                    }
                }

            return result;
        }
    }
}