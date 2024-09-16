using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowProjectDragan.StepDefinitions
{
    public static class PathPlace
    {
        public static string  jsondata = "{\r\n  \"id\": 11912223922,\r\n  \"category\": {\r\n    \"id\": 0,\r\n    \"name\": \"string\"\r\n  },\r\n  \"name\": \"doggie dragan\",\r\n  \"photoUrls\": [\r\n    \"string\"\r\n  ],\r\n  \"tags\": [\r\n    {\r\n      \"id\": 0,\r\n      \"name\": \"string\"\r\n    }\r\n  ],\r\n  \"status\": \"available\"\r\n}";
        public static string jsonupdate = "{\r\n  \"id\": 11912223923,\r\n  \"category\": {\r\n    \"id\": 1,\r\n    \"name\": \"string\"\r\n  },\r\n  \"name\": \"doggie dragan update\",\r\n  \"photoUrls\": [\r\n    \"string\"\r\n  ],\r\n  \"tags\": [\r\n    {\r\n      \"id\": 1,\r\n      \"name\": \"string\"\r\n    }\r\n  ],\r\n  \"status\": \"available\"\r\n}";
        public static string wrongjsondata = "{\r\n  \"id\": ,\r\n  \"cat\": {\r\n    \"i\": 0,\r\n    \"nam\": \"string\"\r\n  },\r\n  \"name\": \"doggie dragan\",\r\n  \"photoUrls\": [\r\n    \"string\"\r\n  ],\r\n  \"tags\": [\r\n    {\r\n      \"id\": 0,\r\n      \"name\": \"string\"\r\n    }\r\n  ],\r\n  \"status\": \"available\"\r\n}";
        public static string value = "11912223922";
        public static string valueDelete = "1191222393";
    }
}
