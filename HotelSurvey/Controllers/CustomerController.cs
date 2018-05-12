using HotelSurvey.Data.Repository;
using HotelSurvey.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace HotelSurvey.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ISurveyRepository _surveyRepository;

        public CustomerController(ICustomerRepository cusomerRepository, ISurveyRepository surveyRepository)
        {
            _customerRepository = cusomerRepository;
            _surveyRepository = surveyRepository;
        }

        [Route("Customer")]
        public IActionResult List()
        {
            var customerVM = new List<CustomerViewModel>();

            var customers = _customerRepository.GetAll();

            if (customers.Count() == 0)
            {
                return View("Empty");
            }

            foreach (var customer in customers)
            {
                customerVM.Add(new CustomerViewModel
                {
                    Customer = customer,
                    SurveyCount = _surveyRepository.Count(x => x.SurveyTakerId == customer.CustomerId)
                });
            }

            return View(customerVM);

        }

        public IActionResult Delete(int id)
        {
            var customer = _customerRepository.GetById(id);

            _customerRepository.Delete(customer);

            return RedirectToAction("List");
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Customer customer)
        {
            _customerRepository.Create(customer);

            return RedirectToAction("List");
        }

        public IActionResult Update(int id)
        {
            var customer = _customerRepository.GetById(id);

            return View(customer);
        }

        [HttpPost]
        public IActionResult Update(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return View(customer);
            }

            _customerRepository.Update(customer);

            return RedirectToAction("List");
        }
    }
}