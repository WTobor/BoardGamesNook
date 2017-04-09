using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace BoardGameGeekIntegration
{
    public static class Request
    {
        public static async Task<string> GetAsync(string url)
        {
            string result = string.Empty;
            var requestUrl = new Uri(url);
            HttpWebRequest request = WebRequest.Create(requestUrl) as HttpWebRequest;

            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
                StreamReader reader = new StreamReader(response.GetResponseStream());
                result = await reader.ReadToEndAsync();
            }

            return result;
        }
    }
}
