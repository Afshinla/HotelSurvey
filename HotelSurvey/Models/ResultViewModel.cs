using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelSurvey.Models
{
    public class ResultViewModel
    {
        private List<Result> resultList { get; set; }
        public ResultViewModel()
        {
            resultList = new List<Result>();
        }
        public List<Result> GetResult()
        {
            return resultList;
        }
        public void AddAnswerItem(Result answerItem)
        {
            resultList.Add(answerItem);
        }

        public Result Result { get; set; }

        public IEnumerable<Result> Results { get; set; }
    }
}
