using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BoardGames.Models;

namespace BoardGames.Models
{
    public class BoardGamesContext : DbContext
    {
        public BoardGamesContext (DbContextOptions<BoardGamesContext> options)
            : base(options)
        {
        }

        public DbSet<BoardGames.Models.BoardGamesList> BoardGamesList { get; set; }

        public DbSet<BoardGames.Models.BoardGameGenre> BoardGameGenre { get; set; }

        public DbSet<BoardGames.Models.Manufacturers> Manufacturers { get; set; }
    }
}
