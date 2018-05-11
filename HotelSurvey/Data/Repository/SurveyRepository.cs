using HotelSurvey.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelSurvey.Data.Repository
{
    public class SurveyRepository : Repository<Survey>, ISurveyRepository
    {
        public SurveyRepository(SurveyDbContext context) : base(context)
        {
        }

        public IEnumerable<Survey> FindWithQuestion(Func<Survey, bool> predicate)
        {
            return _context.Surveys
                .Include(q => q.Question)
                .Where(predicate);
        }

        public IEnumerable<Survey> FindWithQuestionAndSurveyTaker(Func<Survey, bool> predicate)
        {
            return _context.Surveys
                .Include(q => q.Question)
                .Include(q=>q.SurveyTaker)
                .Where(predicate);
        }

        public IEnumerable<Survey> GetAllWithQuestion()
        {
            return _context.Surveys.Include(q => q.Question);
        }
    }
}
