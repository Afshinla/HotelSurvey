using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelSurvey.Models
{
    public class SurveyViewModel
    {
        public Survey Survey { get; set; }

        public IEnumerable<Question> Questions { get; set; }
        
    }
}
