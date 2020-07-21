using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace CitizenApp.Services
{
    public class BaseHttpClient
    {
        private static readonly HttpClient _instance = new HttpClient();

        static BaseHttpClient() { }

        internal BaseHttpClient(): base() { }

        public static HttpClient Instance
        {
            get
            {
                return _instance;
            }
        }
    }
}
