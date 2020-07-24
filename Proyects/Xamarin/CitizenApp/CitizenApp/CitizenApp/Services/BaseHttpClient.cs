﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;

namespace CitizenApp.Services
{
    public class BaseHttpClient
    {
        private static readonly HttpClient _instance = new HttpClient();

        static string baseUrl = "http://10.0.0.47:44346/api/";

        static BaseHttpClient() 
        {
            Instance.BaseAddress = new Uri(baseUrl);
        }

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
