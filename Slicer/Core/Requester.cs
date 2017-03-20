using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Slicer.Utils.Exceptions;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;

namespace Slicer.Core
{
    public static class Requester
    {
        private static HttpClient GetHttpClientConfigured(Dictionary<string, string> headers)
        {
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", headers["authorization"]);
            client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return client;
        }
        public static string Get(string url, Dictionary<string, string> headers)
        {
            var client = GetHttpClientConfigured(headers);
            var responseString = client.GetStringAsync(new Uri(url)).Result;
            return responseString;
        }
        public static HttpResponseMessage Post(string url, Dictionary<string, dynamic> data, Dictionary<string, string> headers) {
            var client = GetHttpClientConfigured(headers);
            var content = new StringContent(JsonConvert.SerializeObject(data).ToString(), Encoding.UTF8, "application/json");
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var response = client.PostAsync(new Uri(url), content).Result;
            return response;
        }
        public static HttpResponseMessage Delete(string url, Dictionary<string, string> headers)
        {
            var client = GetHttpClientConfigured(headers);
            var response = client.DeleteAsync(new Uri(url)).Result;
            return response;
        }
        public static HttpResponseMessage Put(string url, Dictionary<string, object> data, Dictionary<string, string> headers)
        {
            var client = GetHttpClientConfigured(headers);
            var content = new StringContent(JsonConvert.SerializeObject(data).ToString(), Encoding.UTF8, "application/json");
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var response = client.PutAsync(new Uri(url), content).Result;
            
            return response;
        }
        private static bool RequestSuccessful(HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
            {
                throw new SlicingDiceHttpException("HTTP Error: " + response.ReasonPhrase);
            }
            return true;
        }
    }
}
