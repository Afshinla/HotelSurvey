using HotelSurvey.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelSurvey.ViewComponents
{
    public class QuestionViewComponent : ViewComponent
    {
        private SurveyDbContext _context;
        public QuestionViewComponent(SurveyDbContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await _context.Questions.ToListAsync());
        }
    }
}
