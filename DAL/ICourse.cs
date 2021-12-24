using Evaluasi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Evaluasi.DAL
{
    public interface ICourse : ICrud<Course>
    {
        Task<IEnumerable<Course>> GetByTitle(string title);
    }
}
