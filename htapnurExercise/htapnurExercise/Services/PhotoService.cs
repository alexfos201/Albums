using Newtonsoft.Json;
using htapnurExercise.Models;
using htapnurExercise.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace htapnurExercise.Services
{
    public class PhotoService : IPhotoService
    {
        private readonly string photoApiUrl = "http://jsonplaceholder.typicode.com/photos";

        public async Task<IEnumerable<Photo>> GetAll()
        {
            try
            {
                using (var client = new HttpClient())
                using (var request = new HttpRequestMessage(HttpMethod.Get, photoApiUrl))
                using (var response = await client.SendAsync(request))
                {
                    var content = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<Photo>>(content);
                }
            }
            catch (Exception ex)
            {
                //logger.LogError("Error Creating Import Job: \n{e}", e);
                throw ex;
            }
        }
    }
}
