using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelSurvey.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelSurvey.Data.Repository
{
    public class QuestionRepository : Repository<Question>, IQuestionRepository
    {
        public QuestionRepository(SurveyDbContext context) : base(context)
        {

        }

        public IEnumerable<Question> GetAllWithSurvey()
        {
            return _context.Questions.Include(q => q.Surveys);
        }

        public Question GetWihtSurveys(int id)
        {
            return _context.Questions
                .Where(q => q.QuestionId == id)
                .Include(q => q.Surveys)
                .FirstOrDefault();
        }
    }
}
