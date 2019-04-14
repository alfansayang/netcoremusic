using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Music.Web.Models;

namespace Music.Web.Repository
{
    public class ArtistRepository : IArtistRepository
    {
        DbMusicContext _db;

        public ArtistRepository(DbMusicContext db)
        {
            this._db = db;
        }

        public async Task<List<Artists>> Get()
        {
            if (_db != null)
            {
                return await _db.Artists.ToListAsync();
            }

            return null;
        }

        public async Task<List<ArtistModel>> GetById(int id)
        {
            if (_db != null)
            {
                return await (from a in _db.Artists
                              where a.ArtistId.Equals(id)
                              select new ArtistModel
                              {
                                 ArtistID = a.ArtistId,
                                 AlbumName = a.AlbumName,
                                 ArtistName = a.ArtistName,
                                 ImageURL = a.ImageUrl,
                                 Price = a.Price,
                                 ReleaseDate = a.ReleaseDate,
                                 SampleURL = a.SampleUrl
                              }).ToListAsync();
            }

            return null;
        }

        public async Task<int> Insert(Artists data)
        {
            if (_db != null)
            {
                await _db.Artists.AddAsync(data);
                await _db.SaveChangesAsync();
                return data.ArtistId;
            }

            return 0;
        }

        public async Task Update(Artists data)
        {
            if (_db != null)
            {
                _db.Artists.Update(data);
                //Commit the transaction
                await _db.SaveChangesAsync();
            }
        }

        public async Task<int> Delete(int? id)
        {
            int result = 0;

            if (_db != null)
            {
                //Find data artist by id
                var data = await _db.Artists.FirstOrDefaultAsync(x => x.ArtistId == id);
                if (data != null)
                {
                    _db.Artists.Remove(data);
                    //commit data
                    result = await _db.SaveChangesAsync();
                }
                return result;
            }

            return result;
        }


    }
}
