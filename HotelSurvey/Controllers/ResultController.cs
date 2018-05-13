using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelSurvey.Data.Repository;
using Microsoft.AspNetCore.Mvc;

namespace HotelSurvey.Controllers
{
    public class ResultController : Controller
    {
        private readonly IResultRepository _resultRepository;

        public ResultController(IResultRepository resultRepository)
        {
            _resultRepository = resultRepository;
        }
        [Route("Result")]
        public IActionResult List()
        {
            var results = _resultRepository.GetAllWithQuestions();

            if(results.Count() == 0) return View("Empty");

            return View(results);
        }
    }
}