using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BoardGames.Models
{
    public class BoardGamesList
    {
        public int Id { get; set; }
        [StringLength(50, ErrorMessage = "Maximum of 50 letters!")]
        public string Title { get; set; }

        public decimal Price { get; set; }
        public bool IsAvailable { get; set; }
        [Range(0,int.MaxValue, ErrorMessage = "Please enter valid integer number")]
        public int Available { get; set; }

        public virtual Manufacturers Manufacturer { get; set; }
        public int? ManufacturerId;

        public virtual BoardGameGenre Genre { get; set; }
        public int? GenreId;
    }
}
