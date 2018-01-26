using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BoardGames.Models
{
    public class BoardGameGenre
    {
        public int Id { get; set; }
        [StringLength(20, ErrorMessage = "Maximum of 20 letters!")]
        public string Name { get; set; }
        public virtual ICollection<BoardGamesList> BoardGameLists { get; set; }
    }
}
