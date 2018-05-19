using HotelSurvey.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelSurvey.ViewComponents
{
    public class ResultViewComponent : ViewComponent
    {
        private SurveyDbContext _context;
        public ResultViewComponent(SurveyDbContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await _context.Results.ToListAsync());
        }
    }
}
