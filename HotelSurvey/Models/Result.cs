using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelSurvey.Models
{
    public class Result
    {
        [Key]
        public int ResultId { get; set; }

        [Display(Name = "Answer name")]
        [Required, MaxLength(50)]
        public string ResultText { get; set; }

        [Display(Name = "Answer number")]
        [Required]
        public int ResultNummer { get; set; }

        public virtual ICollection<Question> Questions { get; set; }
    }
}
