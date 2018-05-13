using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelSurvey.Models
{
    public class Result
    {
        public int ResultId { get; set; }
        public string ResultText { get; set; }
        public int ResultNummer { get; set; }

        public virtual ICollection<Question> Questions { get; set; }
    }
}
