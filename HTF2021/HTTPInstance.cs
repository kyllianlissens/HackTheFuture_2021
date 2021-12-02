using System;
using System.Net.Http.Headers;

namespace HTF2021
{
    internal class HTTPInstance
    {
        private readonly string token =
            "eyJhbGciOiJIUzUxMiIsInR5cCI6IkpXVCJ9.eyJuYW1lIjoiMzciLCJuYmYiOjE2Mzg0MzQ4NjAsImV4cCI6MTYzODUyMTI2MCwiaWF0IjoxNjM4NDM0ODYwfQ.GaaDc8KZixdcTfRvz1BExY1D_qkvXtDmRYtNrc_jyC4g60O-mg763tKp4XQ6bn5DqVz76tSxOEm251nIc_Tkmg";

        public HttpClient client;

        public HTTPInstance()
        {
            client = new HttpClient
            {
                BaseAddress = new Uri("http://involved-htf-challenge.azurewebsites.net")
            };
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }
    }
}