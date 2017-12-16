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
            string result = string.Empty;
            var requestUrl = new Uri(url);

            if (WebRequest.Create(requestUrl) is HttpWebRequest request)
                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    if (response != null)
                    {
                        StreamReader reader = new StreamReader(response.GetResponseStream() ?? throw new InvalidOperationException());
                        result = await reader.ReadToEndAsync();
                    }
                }

            return result;
        }
    }
}
