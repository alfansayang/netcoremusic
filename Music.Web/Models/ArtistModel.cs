using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Music.Web.Models
{
    public class ArtistModel
    {
        public int ArtistID { get; set; }

        [Required(ErrorMessage = "Please enter artist name"), MaxLength(200)]
        public string ArtistName { get; set; }

        [Required(ErrorMessage = "Please enter album name"), MaxLength(200)]
        public string AlbumName { get; set; }

        public string ImageURL { get; set; }

        [Required(ErrorMessage = "Please enter album release date")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        [Required(ErrorMessage = "Please enter album price")]
        [RegularExpression(@"\d+(\.\d{1,2})?", ErrorMessage = "Invalid price")]
        public decimal Price { get; set; }

        public string SampleURL { get; set; }
    }
}
