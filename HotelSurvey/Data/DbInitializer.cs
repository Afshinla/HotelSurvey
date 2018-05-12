using HotelSurvey.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelSurvey.Data
{
    public class DbInitializer
    {
        public static void Seed(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<SurveyDbContext>();


                // Add Customers
                var justin = new Customer { Name = "Jens Madsen" };

                var willie = new Customer { Name = "Afshin Lakzadeh" };

                var leoma = new Customer { Name = "Hanne Larsen" };

                context.Customers.Add(justin);
                context.Customers.Add(willie);
                context.Customers.Add(leoma);

                // Add Questions
                var authorDeMarco = new Question
                {
                    Name = "Hvordan var værelset?", Surveys
                    = new List<Survey>()
                {
                    new Survey { Name = "Værelsets komfort" },
                    new Survey { Name = "Værelsets renlighed" },
                    new Survey { Name = "Udvalg i minibaren" }
                }
                };

                var authorCardone = new Question
                {
                    Name = "Grant Cardone",
                    Surveys = new List<Survey>()
                {
                    new Survey { Name = "The 10X Rule"},
                    new Survey { Name = "If You're Not First, You're Last"},
                    new Survey { Name = "Sell To Survive"}
                }
                };

                context.Questions.Add(authorDeMarco);
                context.Questions.Add(authorCardone);

                context.SaveChanges();
            }
        }
    }
}
