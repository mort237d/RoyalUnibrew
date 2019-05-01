using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace UniBase.Model
{
    public static class ModelGenerics
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

            var endResult = type;
            try
            {
                Task<string> resTask = client.GetStringAsync(httpUrl);
                string result = resTask.Result;
                endResult = JsonConvert.DeserializeObject<T>(result);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }

            return endResult;
        }

        /// <summary>
        /// Generic method to call a specific type from its ID
        /// </summary>
        /// <typeparam name="T">The specific type</typeparam>
        /// <param name="type">The type name</param>
        /// <returns></returns>
        public static ObservableCollection<T> GetAll<T>(T type)
        {
            String[] typeName = type.ToString().Split('.');
            string httpUrl = URI + "/" + typeName[1];
            Task<string> resTask = null;

            try
            {
                resTask = client.GetStringAsync(httpUrl);
                return JsonConvert.DeserializeObject<ObservableCollection<T>>(resTask.Result);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }

          return JsonConvert.DeserializeObject<ObservableCollection<T>>(resTask.Result);
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

            try
            {
                Task<HttpResponseMessage> deleteAsync = client.DeleteAsync(httpUrl);

                HttpResponseMessage resp = deleteAsync.Result;
                if (resp.IsSuccessStatusCode)
                {
                    return true; 
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
            return false;
        }

        /// <summary>
        /// Generic method to create a specific type
        /// </summary>
        /// <typeparam name="T">The specific type</typeparam>
        /// <param name="type">The object of the type you want to create</param>
        /// <returns></returns>
        public static bool CreateByObject<T>(T type)
        {
            String[] typeName = type.ToString().Split('.');
            string httpUrl = URI + "/" + typeName[1];

            try
            {
                String jsonStr = JsonConvert.SerializeObject(type);
                StringContent content = new StringContent(jsonStr, Encoding.ASCII, "application/json");

                Task<HttpResponseMessage> postAsync = client.PostAsync(httpUrl, content);

                HttpResponseMessage resp = postAsync.Result;
                if (resp.IsSuccessStatusCode)
                {
                    return true;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return false;
            }
            return false;
        }

        /// <summary>
        /// Generic method to update a specific type by its ID
        /// </summary>
        /// <typeparam name="T">The specific type</typeparam>
        /// <param name="id">The ID of the type</param>
        /// <param name="type">The object of the type you want to create</param>
        /// <returns></returns>
        public static bool UpdateByObjectAndId<T>(int id, T type)
        {
            String[] typeName = type.ToString().Split('.');
            string httpUrl = URI + "/" + typeName[1] + "/" + id;

            try
            {
                String jsonStr = JsonConvert.SerializeObject(type);
                StringContent content = new StringContent(jsonStr, Encoding.UTF8, "application/json");

                Task<HttpResponseMessage> putAsync = client.PutAsync(httpUrl, content);

                HttpResponseMessage resp = putAsync.Result;
                if (resp.IsSuccessStatusCode)
                {
                    return true;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return false;
            }
            return false;
        }
    }
}
