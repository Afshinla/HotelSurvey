using HotelSurvey.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelSurvey.Data.Repository
{
    public interface ISurveyRepository : IRepository<Survey>
    {
        IEnumerable<Survey> GetAllWithQuestion();
        IEnumerable<Survey> FindWithQuestion(Func<Survey, bool> predicate);
        IEnumerable<Survey> FindWithQuestionAndSurveyTaker(Func<Survey, bool> predicate);
    }
}
