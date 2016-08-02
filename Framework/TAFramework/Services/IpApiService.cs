using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using System.Net;
using TAFramework.Configs;

namespace TAFramework.Services
{
    public class IpApiService
    {
        public static string Protocol { get; set; } = ServiceInfo.Protocol;
        public static string HostName { get; set; } = ServiceInfo.HostName;
        public static string ResourcePath { get; set; } = ServiceInfo.ResourcePath;
        public static string HttpMethod { get; set; } = ServiceInfo.HttpMethod;

        public  static string GetCityFromIp(string ip)
        {
            string pathToResourceModified = ResourcePath.Replace("{ip}", ip);
            string requestUri = $@"{Protocol}://{HostName}/{pathToResourceModified}";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(requestUri);
            request.Method = HttpMethod;

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            string content = string.Empty;

            using (Stream stream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(stream, Encoding.UTF8);
                content = reader.ReadToEnd();
            }

            IpData data = JsonConvert.DeserializeObject<IpData>(content);
            return data.City;
        }

        private class IpData
        {
            [JsonProperty("city", Required = Required.Always)]
            public string City { get; set; }

            [JsonProperty("country", Required = Required.Always)]
            public string Country { get; set; }

            [JsonProperty("timezone", Required = Required.Always)]
            public string TimeZone { get; set; }
        }
    }
}
