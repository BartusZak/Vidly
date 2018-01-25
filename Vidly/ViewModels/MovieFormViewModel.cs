using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;
using System.ComponentModel.DataAnnotations;

namespace Vidly.ViewModels
{
    public class MovieFormViewModel
    {
        public int? Id { get; set; }

        [Required]
        [Display(Name = "Nazwa filmu")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Data wydania")]
        [DisplayFormat(DataFormatString = "{0:dddd, MMMM dd, yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? ReleaseDate { get; set; }

        [Required]
        [Range(1, 20)]
        [Display(Name = "Numer na stoku")]
        public byte? NumberInStock { get; set; }


        [Required]
        [Display(Name = "Rodzaj filmu")]
        public byte? GenreId { get; set; }

        public IEnumerable<Genre> Genres { get; set; }

        public string Title
         {
             get
             {
                 return  Id != 0 ? "Edytuj Film" : "Nowy Film";
             }
         }

        public MovieFormViewModel()
        {
            Id = 0;
        }

        public MovieFormViewModel(Movie movie)
        {
            Id = movie.Id;
            Name = movie.Name;
            ReleaseDate = movie.ReleaseDate;
            NumberInStock = movie.NumberInStock;
            GenreId = movie.GenreId;
        }

    }
}