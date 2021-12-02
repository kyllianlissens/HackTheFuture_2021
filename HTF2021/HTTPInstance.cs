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
        private readonly string token = "eyJhbGciOiJIUzUxMiIsInR5cCI6IkpXVCJ9.eyJuYW1lIjoiMzciLCJuYmYiOjE2Mzg0MzQ4NjAsImV4cCI6MTYzODUyMTI2MCwiaWF0IjoxNjM4NDM0ODYwfQ.GaaDc8KZixdcTfRvz1BExY1D_qkvXtDmRYtNrc_jyC4g60O-mg763tKp4XQ6bn5DqVz76tSxOEm251nIc_Tkmg";

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
