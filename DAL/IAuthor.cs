using Evaluasi.Dtos;
using Evaluasi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Evaluasi.DAL
{
    public interface IAuthor : ICrud<Author>
    {
        Task<IEnumerable<Author>> GetByFirstName(string FirstName);
    }
}
