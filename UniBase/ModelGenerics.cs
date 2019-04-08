using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace UniBase
{
    static class ModelGenerics
    {
        private const string URI = "http://localhost:12736/api/";
        private static HttpClient client = new HttpClient();

        public static T GetById<T>(T type, int id)
        {
            String[] typeName = type.ToString().Split('.');

            Task<string> resTask = client.GetStringAsync(URI + "/" + typeName[1] + "/" + id);

            return JsonConvert.DeserializeObject<T>(resTask.Result);
        }

        private static bool DeleteFacility<T>(T type, int id)
        {
            String[] typeName = type.ToString().Split('.');

            Task<HttpResponseMessage> deleteAsync = client.DeleteAsync(URI + "/" + typeName[1] + "/" + id);

            HttpResponseMessage resp = deleteAsync.Result;
            if (resp.IsSuccessStatusCode)
            {
                String jsonStr = resp.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<bool>(jsonStr);
            }
            return false;
        }

        private bool CreateFacility(Facility facility)
        {
            String jsonStr = JsonConvert.SerializeObject(facility);
            StringContent content = new StringContent(jsonStr, Encoding.ASCII, "application/json");

            Task<HttpResponseMessage> postAsync = client.PostAsync(URI, content);

            HttpResponseMessage resp = postAsync.Result;
            if (resp.IsSuccessStatusCode)
            {
                String jsonResStr = resp.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<bool>(jsonResStr);
            }
            return false;
        }

        private bool UpdateFacility(int id, Facility facility)
        {
            String jsonStr = JsonConvert.SerializeObject(facility);
            StringContent content = new StringContent(jsonStr, Encoding.UTF8, "application/json");

            Task<HttpResponseMessage> putAsync = client.PutAsync(URI + "/" + id, content);

            HttpResponseMessage resp = putAsync.Result;
            if (resp.IsSuccessStatusCode)
            {
                String jsonResStr = resp.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<bool>(jsonResStr);
            }
            return false;
        }

    }
}
