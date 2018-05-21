using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelSurvey.Models
{
    public class Survey
    {
        [Key]
        public int SurveyId { get; set; }

        [Display(Name = "Survey name")]
        [Required()]
        public String Name { get; set; }

        public virtual Question Question { get; set; }
        public int QuestionId { get; set; }

        public virtual Customer SurveyTaker { get; set; }
        public int SurveyTakerId { get; set; }

        public virtual Result Result { get; set; }
        public int ResultId { get; set; }
    }
}
