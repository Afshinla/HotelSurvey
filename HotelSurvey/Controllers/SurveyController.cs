using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelSurvey.Data.Repository;
using HotelSurvey.Models;
using Microsoft.AspNetCore.Mvc;

namespace HotelSurvey.Controllers
{
    public class SurveyController : Controller
    {
        private readonly ISurveyRepository _surveyRepository;
        private readonly IQuestionRepository _questionRepository;

        public SurveyController(ISurveyRepository surveyRepository, IQuestionRepository questionRepository)
        {
            _surveyRepository = surveyRepository;
            _questionRepository = questionRepository;
        }

        //public IActionResult Index()
        //{
        //    return View();
        //}

        [Route("Survey")]
        public IActionResult List(int? questionId, int? surveyTakerId)
        {
            if(questionId == null && surveyTakerId == null)
            {
                //show all Surveys
                var surveys = _surveyRepository.GetAllWithQuestion();
                //check surveys


                return CheckSurveys(surveys);
            }
            else if (questionId != null)
            {
                //filter by question id
                var question = _questionRepository
                    .GetWihtSurveys((int)questionId);
                //check question surveys
                if (question.Surveys.Count() == 0)
                {
                    return View("QuestionEmpty", question);
                }
                else
                {
                    return View(question.Surveys);
                }
            }
            else if (surveyTakerId != null)
            {
                //filter surveyTaker id
                var surveys = _surveyRepository
                    .FindWithQuestionAndSurveyTaker(survey => survey.SurveyTakerId==surveyTakerId);

                return CheckSurveys(surveys);
            }
            else
            {
                //throw exeption
                throw new ArgumentException();
            }

        }

        public IActionResult CheckSurveys(IEnumerable<Survey> surveys)
        {
            if (surveys.Count() == 0)
            {
                return View("Empty");
            }
            else
            {
                return View(surveys);
            }
        }

        public IActionResult Create()
        {
            var surveyVM = new SurveyViewModel()
            {
                Questions = _questionRepository.GetAll()
            };
            return View(surveyVM);
        }
        
        [HttpPost]
        public IActionResult Create(SurveyViewModel surveyViewModel)
        {
            _surveyRepository.Create(surveyViewModel.Survey);

            return RedirectToAction("List");
        }

        public IActionResult Update(int id)
        {
            var surveyVM = new SurveyViewModel()
            {
                Survey = _surveyRepository.GetById(id),
                Questions = _questionRepository.GetAll()
            };
            return View(surveyVM);
        }

        [HttpPost]
        public IActionResult Update(SurveyViewModel surveyViewModel)
        {
            _surveyRepository.Update(surveyViewModel.Survey);

            return RedirectToAction("List");
        }

        public IActionResult Delete(int id)
        {
            var survey = _surveyRepository.GetById(id);

            _surveyRepository.Delete(survey);

            return RedirectToAction("List");
        }
    }
}