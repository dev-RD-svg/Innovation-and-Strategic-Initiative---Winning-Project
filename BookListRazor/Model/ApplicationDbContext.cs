using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookListRazor.Model
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {

        }

        public DbSet<Book> Book { get; set; }
        public DbSet<Person> Person { get; set; }
        public DbSet<SurveyEwaste> SurveyEwaste { get; set; }

        public DbSet<FoodTravelCalculatorCO> FoodTravelCalculatorCO { get; set; }
        public DbSet<ImageRepository> ImageRepository { get; set; }
        public DbSet<SelectEwaste> SelectEwaste { get; set; }
        //public DbSet<TravelCategory> TravelCategory { get; set; }

    }
}
