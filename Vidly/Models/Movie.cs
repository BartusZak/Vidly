using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        [Display(Name="Nazwa filmu")]
        public string Name { get; set; }

        [Required]
        [Display(Name="Data wydania")]
        [DisplayFormat(DataFormatString = "{0:dddd, MMMM dd, yyyy}", ApplyFormatInEditMode = true)]
        public DateTime ReleaseDate { get; set; }

        public DateTime AddedDate { get; set; }

        [Required]
        [Range(1,20)]
        [Display(Name="Numer na stoku")]
        public byte NumberInStock { get; set; }


        public Genre Genre { get; set; }

        [Required]
        [Display(Name="Rodzaj filmu")]
        public byte GenreId { get; set; }

    }
}