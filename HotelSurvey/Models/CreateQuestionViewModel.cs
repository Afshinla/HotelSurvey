using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelSurvey.Models;
namespace HotelSurvey.Models
{
    public class CreateQuestionViewModel
    {
        public Question Question { get; set; }
        public string Referer { get; set; }
    }
}
