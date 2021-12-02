using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace HTF2021
{
    internal class HTTPInstance
    {

        public HttpClient client;
        private readonly string token = "token";

        public HTTPInstance()
        {
            client = new HttpClient
            {
                BaseAddress = new Uri("http://involved-htf-challenge.azurewebsites.net"),
            };
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

        }



    }
}
