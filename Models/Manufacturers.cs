using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BoardGames.Models
{
    public class Manufacturers
    {
        public int Id { get; set; }
        [StringLength(30, ErrorMessage = "Maximum of 30 letters!")]
        public string Name { get; set; }
        [Display(Name = "Year of Foundation")]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer number")]
        public int Year { get; set; }
        public virtual ICollection<BoardGamesList> BoardGameLists { get; set; }
    }
}
