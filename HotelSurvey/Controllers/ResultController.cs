using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelSurvey.Data.Repository;
using HotelSurvey.Models;
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

        [HttpGet]
        public ViewResult Result()
        {
            return View();
        }

        [HttpPost]
        public ViewResult Result(Result guestResponse)
        {
            if (ModelState.IsValid)
            {
                ResultRepository.AddResponse(guestResponse);
                return View("Thanks", "Result");
            }
            else
            {
                //there is a validation error
                return View();
            }
        }

        [Route("ListResponses")]
        public ViewResult ListResponses()
        {
            return View(ResultRepository.Responses);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Result result)
        {
            _resultRepository.Create(result);

            return RedirectToAction("List");
        }

        public IActionResult Delete(int id)
        {
            var result = _resultRepository.GetById(id);

            _resultRepository.Delete(result);

            return RedirectToAction("List");
        }

        public IActionResult Update(int id)
        {
            var customer = _resultRepository.GetById(id);

            return View(customer);
        }

        [HttpPost]
        public IActionResult Update(Result result)
        {
            if (!ModelState.IsValid)
            {
                return View(result);
            }

            _resultRepository.Update(result);

            return RedirectToAction("List");
        }

    }
}