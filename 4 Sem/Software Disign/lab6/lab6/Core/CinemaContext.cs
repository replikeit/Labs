using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lab6.Core.Models;

namespace lab6.Core
{
    class CinemaContext : DbContext
    {
        public static CinemaContext context;

        public static void InitDbContext()
        {
            context = new CinemaContext();
        }

        public CinemaContext() : base("DbConnection")
        {

        }

        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }
    }
}
