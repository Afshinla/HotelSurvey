using HotelSurvey.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelSurvey.Data.Repository
{
    public interface IResultRepository : IRepository <Result>
    {
        IEnumerable<Result> GetAllWithQuestions();
        Result GetAllWithQuestions(int id);
    }
}
