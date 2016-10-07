using Association.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Association.Controllers
{
    public class MembersController : Controller
    {

        MemberRepository repository = new MemberRepository();

        // GET: Members
        public ActionResult Index()
        {
            var members = repository.GetAll();
            return View(members);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Member member)
        {
            repository.Create(member);

            //return View();
           return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Member member = repository.SelectById(id);
            return View(member);
        }

        [HttpPost]
        public ActionResult Update(Member member)
        {
            repository.Update(member);
            return RedirectToAction("Index");
        }

        //Deletar Member
        public ActionResult Delete(int id)
        {
            repository.Delete(id);
            return RedirectToAction("Index");

        }


    }
}