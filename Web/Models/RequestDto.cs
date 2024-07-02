﻿using static Web.Utility.SD;

namespace Web.Models
{
    public class RequestDto
    {
        //public string ApiType { get; set; } = "GET";
        public ApiType ApiType { get; set; } = ApiType.GET;
        public string Url { get; set; }
        public object Data { get; set; }
        public string AccessToken { get; set; }
    }
}
