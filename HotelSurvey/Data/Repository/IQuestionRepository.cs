using HotelSurvey.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelSurvey.Data.Repository
{
    public interface IQuestionRepository : IRepository<Question>
    {
        IEnumerable<Question> GetAllWithSurveys();
        Question GetWihtSurveys(int id);
    }
}
