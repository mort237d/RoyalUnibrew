using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Net;
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
            string resTask = null;
            
            ObservableCollection<T> ifFailed = new ObservableCollection<T>();

            try
            {
                resTask = await client.GetStringAsync(httpUrl);
                return JsonConvert.DeserializeObject<ObservableCollection<T>>(resTask);
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
        public static async Task<ObservableCollection<T>> GetLastTenInDatabase<T>(T type, string primaryKeyName, string primaryKeyNameDanish)
        {
            int typeNamePosistionInNamespace = 3;
            String[] typeName = type.ToString().Split('.');
            string httpUrl = URI + typeName[typeNamePosistionInNamespace] + "/range/";

            ObservableCollection<T> result = new ObservableCollection<T>();

            try
            {
                var resTask = await client.GetStringAsync(httpUrl);
                result = JsonConvert.DeserializeObject<ObservableCollection<T>>(resTask);

                Task<HttpResponseMessage> deleteAsync = client.GetAsync(httpUrl);

                HttpResponseMessage resp = deleteAsync.Result;

                ErrorMessage(type, primaryKeyName, primaryKeyNameDanish, typeNamePosistionInNamespace, typeName, resp);
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
        public static bool DeleteById<T>(T type, int id, string primaryKeyName, string primaryKeyNameDanish)
        {
            int typeNamePosistionInNamespace = 3;
            String[] typeName = type.ToString().Split('.');
            string httpUrl = URI + typeName[typeNamePosistionInNamespace] + "/" + id;

            try
            {
                Task<HttpResponseMessage> deleteAsync = client.DeleteAsync(httpUrl);
                
                HttpResponseMessage resp = deleteAsync.Result;
                
                return ErrorMessage(type, primaryKeyName, primaryKeyNameDanish, typeNamePosistionInNamespace, typeName, resp);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        /// <summary>
        /// Generic method to create a specific type through the REST-service to add to the Database.
        /// </summary>
        /// <typeparam name="T">The specific type</typeparam>
        /// <param name="type">The object of the type you want to create</param>
        /// <param name="primaryKeyName">The name of the primary key in the database</param>
        /// <param name="primaryKeyNameDanish">The name of the primary key in the database in danish</param>
        /// <returns></returns>
        public static bool CreateByObject<T>(T type, string primaryKeyName, string primaryKeyNameDanish)
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

                return ErrorMessage(type, primaryKeyName, primaryKeyNameDanish, typeNamePosistionInNamespace, typeName, resp);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return false;
            }
        }


        /// <summary>
        /// Generic method to update a specific type, by its ID, in the Database through the REST-service.
        /// </summary>
        /// <typeparam name="T">The specific type</typeparam>
        /// <param name="id">The ID of the type</param>
        /// <param name="type">The object of the type you want to create</param>
        /// <param name="primaryKeyName"></param>
        /// <param name="primaryKeyNameDanish"></param>
        /// <returns></returns>
        public static bool UpdateByObjectAndId<T>(int id, T type, string primaryKeyName, string primaryKeyNameDanish)
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

                return ErrorMessage(type, primaryKeyName, primaryKeyNameDanish, typeNamePosistionInNamespace, typeName, resp);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return false;
            }
        }

        /// <summary>
        /// Checks status code, provides message and returns whether or not the Httprequrest was succesfull.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="type"></param>
        /// <param name="primaryKeyName"></param>
        /// <param name="primaryKeyNameDanish"></param>
        /// <param name="typeNamePosistionInNamespace"></param>
        /// <param name="typeName"></param>
        /// <param name="resp"></param>
        /// <returns></returns>
        private static bool ErrorMessage<T>(T type, string primaryKeyName, string primaryKeyNameDanish, int typeNamePosistionInNamespace, string[] typeName, HttpResponseMessage resp)
        {
            var primaryKeyId = typeof(T).GetProperty(primaryKeyName).GetValue(type);

            switch (resp.StatusCode)
            {
                case HttpStatusCode.OK:
                    return true;
                case HttpStatusCode.Created:
                    Message.Instance.ShowToastNotification(typeName[typeNamePosistionInNamespace] + " oprettet", "Succes");
                    return true;
                case HttpStatusCode.Conflict:
                    Message.Instance.ShowToastNotification("Konflikt", typeName[typeNamePosistionInNamespace] + " med " + primaryKeyNameDanish + " " + primaryKeyId + " eksistere allerede (409)");
                    return false;
                case HttpStatusCode.BadRequest:
                    Message.Instance.ShowToastNotification("Forkert syntakst", "Syntaksten er ikke rigtig (400)");
                    return false;
                case HttpStatusCode.BadGateway:
                    Message.Instance.ShowToastNotification("Mislykket forbindelse", "Der kan ikke forbindes til data basen (404)");
                    return false;
                case HttpStatusCode.InternalServerError:
                    Message.Instance.ShowToastNotification("Noget gik galt", "Prøv igen lidt senere, eller kontakt IT afdelingen (500)");
                    return false;
                case HttpStatusCode.ServiceUnavailable:
                    Message.Instance.ShowToastNotification("Kan ikke få adgang til serveren", "Tjek internet forbindelsen eller kontakt IT afdelingen (503)");
                    return false;
                default:
                    return false;
            }
        }
    }
}
