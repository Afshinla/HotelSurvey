using HotelSurvey.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelSurvey.Data.Repository
{
    public class ResultRepository : Repository<Result>, IResultRepository
    {
        public ResultRepository(SurveyDbContext context) : base(context)
        {

        }

        public IEnumerable<Result> GetAllWithQuestions()
        {
            return _context.Results.Include(r => r.Questions);
        }

        public Result GetAllWithQuestions(int id)
        {
            return _context.Results
                .Where(r => r.ResultId == id)
                .Include(r => r.Questions)
                .FirstOrDefault();
        }
    }
}
