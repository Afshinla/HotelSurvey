using HotelSurvey.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelSurvey.Data
{
    public class SurveyDbContext : DbContext
    {
        public SurveyDbContext(DbContextOptions<SurveyDbContext> options) : base (options)
        {

        }

        public DbSet<Survey> Surveys { get; set; }
        public DbSet<Question> Questions { get; set; } 
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Result> Results { get; set; }
    }
}
