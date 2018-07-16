using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Newtonsoft;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Resources;

namespace WebApiClient
{
    public class HttpApiController
    {
        static HttpClient client;
        public HttpApiController() { }
        static HttpApiController()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:13246/");
        }

        public async Task<List<AlumnoModelView>> GetCall()
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

    }
}
