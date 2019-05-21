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
        /// Generic method to GET a specific type, from its ID, from the Database through the REST-service.
        /// </summary>
        /// <typeparam name="T">The specific type</typeparam>
        /// <param name="type">The specific type </param>
        /// <param name="id">The ID of the type</param>
        /// <returns></returns>
        public static T GetById<T>(T type, int id)
        {
            int typeNamePosistionInNamespace = 3;
            String[] typeName = type.ToString().Split('.');
            string httpUrl = URI + typeName[typeNamePosistionInNamespace] + "/" + id;
            
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
        /// Generic method to GET all of a specific type from the Database through the REST-service.
        /// </summary>
        /// <typeparam name="T">The specific type</typeparam>
        /// <param name="type">The type name</param>
        /// <returns></returns>
        public static async Task<ObservableCollection<T>> GetAll<T>(T type)
        {
            int typeNamePosistionInNamespace = 3;
            String[] typeName = type.ToString().Split('.');
            string httpUrl = URI + typeName[typeNamePosistionInNamespace];
            Task<string> resTask = null;
            
            ObservableCollection<T> ifFailed = new ObservableCollection<T>();

            try
            {
                resTask = client.GetStringAsync(httpUrl);
                return JsonConvert.DeserializeObject<ObservableCollection<T>>(resTask.Result);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }

            return ifFailed;
        }

        /// <summary>
        /// Generic method to GET the latest ten of a specific type from the Database through the REST-service.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="type"></param>
        /// <returns></returns>
        public static async Task<ObservableCollection<T>> GetLastTenInDatabase<T>(T type)
        {
            int typeNamePosistionInNamespace = 3;
            String[] typeName = type.ToString().Split('.');
            string httpUrl = URI + typeName[typeNamePosistionInNamespace] + "/range/";

            ObservableCollection<T> result = new ObservableCollection<T>();

            try
            {
                var resTask = client.GetStringAsync(httpUrl);
                result = JsonConvert.DeserializeObject<ObservableCollection<T>>(resTask.Result);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }

            return result;
        }

        /// <summary>
        /// /// Generic method to delete a specific type, from its ID, from the Database through the REST-service.
        /// </summary>
        /// <typeparam name="T">The specific type</typeparam>
        /// <param name="type">The type name</param>
        /// <param name="id">The ID of the type</param>
        /// <returns></returns>
        public static bool DeleteById<T>(T type, int id)
        {
            int typeNamePosistionInNamespace = 3;
            String[] typeName = type.ToString().Split('.');
            string httpUrl = URI + typeName[typeNamePosistionInNamespace] + "/" + id;

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
        /// Generic method to create a specific type through the REST-service to add to the Database.
        /// </summary>
        /// <typeparam name="T">The specific type</typeparam>
        /// <param name="type">The object of the type you want to create</param>
        /// <returns></returns>
        public static bool CreateByObject<T>(T type)
        {
            int typeNamePosistionInNamespace = 3;
            String[] typeName = type.ToString().Split('.');
            string httpUrl = URI + typeName[typeNamePosistionInNamespace];

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
        /// Generic method to update a specific type, by its ID, in the Database through the REST-service.
        /// </summary>
        /// <typeparam name="T">The specific type</typeparam>
        /// <param name="id">The ID of the type</param>
        /// <param name="type">The object of the type you want to create</param>
        /// <returns></returns>
        public static bool UpdateByObjectAndId<T>(int id, T type)
        {
            int typeNamePosistionInNamespace = 3;
            String[] typeName = type.ToString().Split('.');
            string httpUrl = URI + typeName[typeNamePosistionInNamespace] + "/" + id;

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
