﻿using System;
using System.Collections.Generic;
using System.Text;

namespace NRGScoutingApp2020.Data
{
    public static class HideAPIKey
    {
        public static readonly string APIKey = Environment.GetEnvironmentVariable("SERVER_API_KEY", EnvironmentVariableTarget.User);
        public static string getAPIKey()
        {
            return Environment.GetEnvironmentVariable("SERVER_API_KEY", EnvironmentVariableTarget.User);
        }
    }
}
