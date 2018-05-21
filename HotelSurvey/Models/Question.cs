using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelSurvey.Models
{
    public class Question
    {
        [Key]
        public int QuestionId { get; set; }

        [Display(Name = "Question name")]
        [Required()]
        public string Name { get; set; }

        public virtual ICollection<Survey> Surveys { get; set; }
    }
}
