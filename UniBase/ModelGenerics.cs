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


        /// <summary>
        /// Generic method to call a specific type from its ID
        /// </summary>
        /// <typeparam name="T">The specific type</typeparam>
        /// <param name="type">The type name</param>
        /// <param name="id">The ID of the type</param>
        /// <returns></returns>
        public static T GetById<T>(T type, int id)
        {
            String[] typeName = type.ToString().Split('.');
            string httpUrl = URI + "/" + typeName[1] + "/" + id;

            Task<string> resTask = client.GetStringAsync(httpUrl);

            return JsonConvert.DeserializeObject<T>(resTask.Result);
        }

        /// <summary>
        /// /// Generic method to delete a specific type from its ID
        /// </summary>
        /// <typeparam name="T">The specific type</typeparam>
        /// <param name="type">The type name</param>
        /// <param name="id">The ID of the type</param>
        /// <returns></returns>
        public static bool DeleteById<T>(T type, int id)
        {
            String[] typeName = type.ToString().Split('.');
            string httpUrl = URI + "/" + typeName[1] + "/" + id;

            Task<HttpResponseMessage> deleteAsync = client.DeleteAsync(httpUrl);

            HttpResponseMessage resp = deleteAsync.Result;
            if (resp.IsSuccessStatusCode)
            {
                String jsonStr = resp.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<bool>(jsonStr);
            }
            return false;
        }

        /// <summary>
        /// Generic method to create a specific type
        /// </summary>
        /// <typeparam name="T">The specific type</typeparam>
        /// <param name="obj">The object of the type you want to create</param>
        /// <returns></returns>
        public static bool CreateByObject<T>(T obj)
        {
            String jsonStr = JsonConvert.SerializeObject(obj);
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

        /// <summary>
        /// Generic method to update a specific type by its ID
        /// </summary>
        /// <typeparam name="T">The specific type</typeparam>
        /// <param name="id">The ID of the type</param>
        /// <param name="obj">The object of the type you want to create</param>
        /// <returns></returns>
        public static bool UpdateByObjectAndId<T>(int id, T obj)
        {
            String jsonStr = JsonConvert.SerializeObject(obj);
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
