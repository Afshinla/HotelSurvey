using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelSurvey.Models
{
    public class SurveyNewViewModel
    {
        public int Id { get; set; }
        public string SurveyName { get; set; }
        public Survey Survey { get; set; }

        public IEnumerable<Question> Questions { get; set; }
    }
}
