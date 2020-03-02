using htapnurExercise.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace htapnurExercise.ServiceInterfaces
{
    public interface IAlbumService
    {
        Task<IEnumerable<Album>> GetAll(int? userId);
    }
}
