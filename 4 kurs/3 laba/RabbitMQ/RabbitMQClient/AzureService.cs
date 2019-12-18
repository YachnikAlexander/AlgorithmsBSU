using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQClient
{
    public class AzureService
    {
        private string securityCode = "Qq9CScUy/Iz7v1G9aFnWnWJuTp/fbaQQbqgh06z7RVWAGlaBKDiO5g==";
        public string CallAzureFunction()
        {
            string result = string.Empty;

            var urlFunction = "https://messagework.azurewebsites.net/api/Function1?code=qu1PIPYMa5iVKwODdT56YdxbzerhJHmNVrkvyL1/GVuvZXgwh1msnA==";
            var myObject = (dynamic)new JObject();
            myObject.name = "Sasha";

            var content = new StringContent(myObject.ToString(), Encoding.UTF8, "application/json");

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("x-functions-key", securityCode);
                using (HttpResponseMessage response = client.PostAsync(urlFunction, content).Result)
                using (HttpContent respContent = response.Content)
                {
                    var azureResponse = respContent.ReadAsStringAsync().Result;
                    result = azureResponse.ToString();
                }
            }
            return result;
        }
    }
}
