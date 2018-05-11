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
        private readonly ISurveyRepository _surveyRepository;

        public QuestionController(IQuestionRepository questionRepository, ISurveyRepository surveyRepository)
        {
            _questionRepository = questionRepository;
            _surveyRepository = surveyRepository;
        }

        public IActionResult List()
        {
            var questionVM = new List<QuestionViewModel>();
            var questions = _questionRepository.GetAll();

            if (questions.Count() == 0)
            {
                return View("Empty");
            }

            foreach(var question in questions)
            {
                questionVM.Add(new QuestionViewModel
                {
                    Question = question,
                    SurveyCount=_surveyRepository.Count()
                });
            }
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}