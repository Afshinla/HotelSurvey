﻿using HotelSurvey.Models;
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
                var jens = new Customer { Name = "Jens Madsen" };

                var afshin = new Customer { Name = "Afshin Lakzadeh" };

                var hanne = new Customer { Name = "Hanne Larsen" };

                context.Customers.Add(jens);
                context.Customers.Add(afshin);
                context.Customers.Add(hanne);

                // Add Results

                //var utilfreds = new Result
                //{
                //    ResultText = "Utilfreds",
                //    ResultNummer = 1,

                //    Questions = new List<Question>()
                //    {
                //        new Question { Name = "Var personelet i receptionen venlige?" }
                //    }

                //};

                var utilfreds = new Result { ResultNummer = 1, ResultText = "Utilfreds" };
                var acceptable = new Result { ResultNummer = 2, ResultText = "Acceptabel" };
                var vedikke = new Result { ResultNummer = 3, ResultText = "Ved ikke" };
                var tilfreds = new Result { ResultNummer = 4, ResultText = "Tilfreds" };
                var megettilfreds = new Result { ResultNummer = 5, ResultText = "Meget tilfreds" };

                context.Results.Add(utilfreds);
                context.Results.Add(acceptable);
                context.Results.Add(vedikke);
                context.Results.Add(tilfreds);
                context.Results.Add(megettilfreds);


                // Add Questions
                var checkIn = new Question
                {
                    Name = "Var personelet i receptionen venlige?",
                    
                    Surveys = new List<Survey>()
                {
                    new Survey { Name = "Check-in processen" }
                }
                };
                var fast = new Question
                {
                    Name = "Hvor tilfreds er du med personalets hurtighed?",

                    Surveys = new List<Survey>()
                {
                    new Survey { Name = "Check-in processen" }
                }
                };
                var clean = new Question
                {
                    Name = "Hvor tilfreds er du med renligheden i værelset",

                    Surveys = new List<Survey>()
                {
                    new Survey { Name = "Rengøring" }
                }
                };

                context.Questions.Add(checkIn);
                context.Questions.Add(fast);
                context.Questions.Add(clean);

                context.SaveChanges();
            }
        }
    }
}
