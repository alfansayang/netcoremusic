using Music.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Music.Web.Repository
{
    public interface IArtistRepository
    {
        Task<List<Artists>> Get();
        Task<List<ArtistModel>> GetById(int id);
        Task<int> Insert(Artists data);
        Task<int> Delete(int? id);
        Task Update(Artists data);
    }
}
