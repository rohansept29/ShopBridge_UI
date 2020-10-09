using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace ShopBridge_UI.Services
{
    public class ApiService
    {
        public static readonly string url = "http://localhost:54844/";
        public HttpResponseMessage GetMethod(string action)
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // New code:
                HttpResponseMessage response = client.GetAsync(action).Result;
                if (response.IsSuccessStatusCode)
                {
                    var product = response.Content.ReadAsStringAsync();
                }
                return response;
            }
        }
        public HttpResponseMessage PostMethod(string action, HttpContent contentPost)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = client.PostAsync(action, contentPost).Result;
                return response;

            }
        }
        public HttpResponseMessage DeleteMethod(string action)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.DeleteAsync(action).Result;
                return response;
            }
        }
    }
}