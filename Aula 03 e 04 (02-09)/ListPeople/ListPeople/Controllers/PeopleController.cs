using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ListPeople.Models;

namespace ListPeople.Controllers
{
    public class PeopleController : Controller
    {

        PersonRepository _repository = new PersonRepository();
        
        // GET: People
        public ActionResult Index()
        {
            
            return View(PersonRepository._people);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Person person)
        {
            _repository.create(person);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var objPerson = _repository.getById(id);
            return View(objPerson);
        }

        [HttpPost]
        public ActionResult Edit(Person person)
        {
            _repository.edit(person);

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            _repository.delete(id);

            return RedirectToAction("Index");
        }

    }
}