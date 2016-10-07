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
        //Cria um objeto da classe MemberRepository, liberando acesso aos seus métodos
        MemberRepository memberRepository = new MemberRepository();

        //Cria um objeto da classe CityRepository, liberando acesso aos seus métodos
        CityRepository cityRepository = new CityRepository();

        // GET: Members
        public ActionResult Index()
        {
            var members = memberRepository.GetAll();
            return View(members);
        }

        //Chama a view com o formulário para cadastro de membros
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Cities = cityRepository.GetAll();
            return View();
        }

        //Chama e executa a função Create, do MemberRepository
        //Recebe um objeto Member por parâmetro
        [HttpPost]
        public ActionResult Create(Member member)
        {
            memberRepository.Create(member);

           return RedirectToAction("Index");
        }

        //Chama a view com o formulário para edição de cadastro de um membro 
        //Recebe por parâmetro o id do membro a ser editado
        [HttpGet]
        public ActionResult Edit(int id)
        {
            Member member = memberRepository.SelectById(id);
            ViewBag.Cities = cityRepository.GetAll();
            return View(member);
        }

        //Chama e executa a função Update, do MemberRepository
        //Recebe um objeto Member por parâmetro
        [HttpPost]
        public ActionResult Update(Member member)
        {
            memberRepository.Update(member);
            return RedirectToAction("Index");
        }

        //Chama e executa a função Delete, do MemberRepository
        //Recebe por parâmetro o id do membro a ser deletado
        public ActionResult Delete(int id)
        {
            memberRepository.Delete(id);
            return RedirectToAction("Index");

        }
    }
}