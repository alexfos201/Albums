using htapnurExercise.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace htapnurExercise.ServiceInterfaces
{
    public interface IPhotoService
    {
        Task<IEnumerable<Photo>> GetAll();
    }
}
