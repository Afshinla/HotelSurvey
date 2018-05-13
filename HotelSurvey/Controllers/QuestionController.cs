using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelSurvey.Data.Repository;
using HotelSurvey.Models;
using Microsoft.AspNetCore.Mvc;

namespace HotelSurvey.Controllers
{
    public class QuestionController : Controller
    {
        private readonly IQuestionRepository _questionRepository;

        public QuestionController(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }

        [Route("Question")]
        public IActionResult List()
        {
            var questions = _questionRepository.GetAllWithSurveys();

            if (questions.Count() == 0) return View("Empty");

            return View(questions);
        }

        public IActionResult Update(int id)
        {
            var question = _questionRepository.GetById(id);

            if (question == null) return NotFound();

            return View(question);
        }

        [HttpPost]
        public IActionResult Update(Question question)
        {
            if (!ModelState.IsValid)
            {
                return View(question);
            }
            _questionRepository.Update(question);

            return RedirectToAction("List");
        }

        public IActionResult Create()
        {
            var viewModel = new CreateQuestionViewModel
            { Referer = Request.Headers["Referer"].ToString() };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Create(CreateQuestionViewModel questionVM)
        {
            if (!ModelState.IsValid)
            {
                return View(questionVM);
            }
            _questionRepository.Create(questionVM.Question);

            if (!String.IsNullOrEmpty(questionVM.Referer))
            {
                return Redirect(questionVM.Referer);
            }

            return RedirectToAction("List");
        }

        public IActionResult Delete(int id)
        {
            var question = _questionRepository.GetById(id);

            _questionRepository.Delete(question);

            return RedirectToAction("List");
        }
    }
}