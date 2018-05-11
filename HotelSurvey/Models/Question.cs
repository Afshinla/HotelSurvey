using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelSurvey.Models
{
    public class Question
    {
        public int QuestionId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Survey> Surveys { get; set; }
    }
}
