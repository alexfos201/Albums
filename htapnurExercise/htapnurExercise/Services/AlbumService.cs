using Newtonsoft.Json;
using htapnurExercise.Models;
using htapnurExercise.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace htapnurExercise.Services
{
    public class AlbumService : IAlbumService
    {
        private readonly string api = "http://jsonplaceholder.typicode.com/albums";

        public async Task<IEnumerable<Album>> GetAll(int? userId)
        {
            try
            {
                var albums = new List<Album>();
                using (var client = new HttpClient())
                using (var request = new HttpRequestMessage(HttpMethod.Get, api))
                using (var response = await client.SendAsync(request))
                {
                    var content = await response.Content.ReadAsStringAsync();
                    albums = JsonConvert.DeserializeObject<List<Album>>(content);
                    if (userId.HasValue)
                    {
                        return albums.Where(p => p.UserId == userId);
                    }
                    return albums;
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
