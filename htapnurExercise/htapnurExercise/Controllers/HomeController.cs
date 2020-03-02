using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using htapnurExercise.ServiceInterfaces;

namespace htapnurExercise.Controllers
{
    [Route("api/[controller]")]
    public class HomeController : Controller
    {
        private readonly IAlbumService albumService;
        private readonly IPhotoService photoService;

        public HomeController(IAlbumService albumService, IPhotoService photoService)
        {
            this.albumService = albumService;
            this.photoService = photoService;
        }

        // can use a logger to help log information
        //private readonly Logger<AlbumController> logger;

        [HttpGet("{userID?}")]
        public async Task<IActionResult> GetAll(string userId)
        {
            int recievedUserId = 0;
            int? specfiedUserId = null;
            if (!String.IsNullOrEmpty(userId))
            {
                if (Int32.TryParse(userId, out recievedUserId))
                {
                    specfiedUserId = recievedUserId;
                }
                else
                {
                    return BadRequest("Invalid userId");
                }
            }

            // What happens if photo doesn't belong to a valid existing album
            var albumsTask = albumService.GetAll(specfiedUserId);
            var photosTask = photoService.GetAll();

            var albums = (await albumsTask).ToList();
            var photos = await photosTask;

            foreach (var photo in photos)
            {
                var albumIndex = albums.FindIndex(a => a.Id == photo.AlbumId);
                if (albumIndex > -1)
                {
                    albums[albumIndex].Photos.Add(photo);
                }
            }

            return new ObjectResult(albums);
        }
    }
}
