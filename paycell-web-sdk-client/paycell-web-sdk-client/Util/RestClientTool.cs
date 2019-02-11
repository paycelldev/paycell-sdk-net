using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using RestSharp;
using System;

namespace paycell_web_sdk_client.Util
{
    class RestClientTool<T, M>
    {

        public M RestClientRequest(string url, T requestObject)
        {
            try
            {
                var client = new RestClient(url);
                var request = new RestRequest(Method.POST);
                var serializerSettings = new JsonSerializerSettings();
                serializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                string json = JsonConvert.SerializeObject(requestObject, serializerSettings);
                request.AddParameter("application/json", json, ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);
                M responseObject = JsonConvert.DeserializeObject<M>(response.Content);

                return responseObject;

            } catch (Exception e)
            {
                Console.WriteLine(e.Message + "Service Connection Fail");
                throw;
            }
        }
    }
}