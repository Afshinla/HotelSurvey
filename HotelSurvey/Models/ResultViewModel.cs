using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelSurvey.Models
{
    public class ResultViewModel
    {
        public Result Result { get; set; }

        public IEnumerable<Result> Results { get; set; }
    }
}
