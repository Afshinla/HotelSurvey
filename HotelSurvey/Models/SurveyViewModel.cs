using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelSurvey.Models
{
    public class SurveyViewModel
    {
        private List<Survey> SurveyList { get; set; }
        
        public SurveyViewModel()
        {
            SurveyList = new List<Survey>();
        }

        public List<Survey> GetSurveyList()
        {
            return SurveyList;
        }
        
        public Survey Survey { get; set; }

        public IEnumerable<Question> Questions { get; set; }
        
    }
}
