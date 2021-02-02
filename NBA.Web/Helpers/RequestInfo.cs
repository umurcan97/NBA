using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace NBA.Web.Helpers
{
    public class RequestInfo
    {
        public HttpMethod HttpMethod { get; set; }
        public string Url { get; set; }
        public object Data { get; set; }
        public Dictionary<string, string> Headers { get; set; }

        public RequestInfo()
        {
            Headers = new Dictionary<string, string>();
        }

        public RequestInfo AddHeader(string key, string value)
        {
            Headers.Add(key, value);
            return this;
        }
    }
}