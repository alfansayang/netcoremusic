using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Music.Web.Models
{
    public static class ArtistMapper
    {
        #region mapper data to model
        public static ArtistModel ConvertToModel(this Artists data)
        {
            var model = new ArtistModel()
            {
                ArtistID = data.ArtistId,
                AlbumName = data.AlbumName,
                ArtistName = data.ArtistName,
                ImageURL = data.ImageUrl,
                ReleaseDate = data.ReleaseDate,
                Price = data.Price,
                SampleURL = data.SampleUrl
            };

            return model;
        }

        public static List<ArtistModel> ConvertToListModel(this IEnumerable<Artists> listData)
        {
            return listData.Select(art => art.ConvertToModel()).ToList();
        }

        #endregion

        #region mapper model to data
        public static Artists ConvertToData(this ArtistModel model)
        {
            var data = new Artists()
            {
                ArtistId = model.ArtistID,
                AlbumName = model.AlbumName,
                ArtistName = model.ArtistName,
                ImageUrl = model.ImageURL,
                ReleaseDate = model.ReleaseDate,
                Price = model.Price,
                SampleUrl = model.SampleURL
            };

            return data;
        }

        public static List<Artists> ConvertToListModel(this IEnumerable<ArtistModel> listModel)
        {
            return listModel.Select(art => art.ConvertToData()).ToList();
        }
        #endregion
    }
}
