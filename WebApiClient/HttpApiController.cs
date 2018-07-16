using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Newtonsoft;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Resources;
using System.Net.Http.Headers;

namespace WebApiClient
{
    public static class HttpApiController
    {
        static HttpClient client;
        //public HttpApiController() { }
        static HttpApiController()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:13246/");
        }

        public static async Task<List<AlumnoModelView>> GetCall()
        {
            IEnumerable<AlumnoModelView> listaAlumnos = new List<AlumnoModelView>();
            try
            {
                HttpResponseMessage response = client.GetAsync(Resources.apiGet).Result;
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine(Resources.ReqMessageInfo + response.RequestMessage + "\n");
                    Console.WriteLine(Resources.ReqMessageHead + response.Content.Headers + "\n");
                    // Get the response
                    var alumnoJsonString = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(Resources.RespData + alumnoJsonString);

                    // Deserialise the data (include the Newtonsoft JSON Nuget package if you don't already have it)
                    var deserialized = JsonConvert.DeserializeObject<IEnumerable<AlumnoModelView>>(alumnoJsonString);
                    listaAlumnos = deserialized;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return listaAlumnos.ToList();
        }

        public static async Task<bool> PostCall(AlumnoModelView alumno)
        {
            try
            {
                var myContent = JsonConvert.SerializeObject(alumno);
                var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var result = await client.PostAsync(Resources.apiGet, byteContent);
                return result.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
