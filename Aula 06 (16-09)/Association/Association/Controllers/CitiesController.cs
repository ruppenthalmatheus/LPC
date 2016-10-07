using Association.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Association.Controllers
{
    public class CitiesController : Controller
    {

        //Cria um objeto da classe CityRepository, liberando acesso aos seus métodos
        CityRepository cityRepository = new CityRepository();

        // GET: Cities
        public ActionResult Index()
        {
            var cities = cityRepository.GetAll();
            return View(cities);
        }

        //Chama a view com o formulário para cadastro de cidades
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        //Chama e executa a função Create, do CityRepository
        //Recebe um objeto City por parâmetro
        [HttpPost]
        public ActionResult Create(City city)
        {
            cityRepository.Create(city);

            return RedirectToAction("Index");
        }

        //Chama a view com o formulário para edição de cadastro de uma cidade
        //Recebe por parâmetro o id da cidade a ser editada
        [HttpGet]
        public ActionResult Edit(int id)
        {
            City city = cityRepository.SelectById(id);
            return View(city);
        }

        //Chama e executa a função Update, do CityRepository
        //Recebe um objeto city por parâmetro
        [HttpPost]
        public ActionResult Update(City city)
        {
            cityRepository.Update(city);
            return RedirectToAction("Index");
        }

        //Chama e executa a função Delete, do CityRepository
        //Recebe por parâmetro o id da cidade a ser deletada
        public ActionResult Delete(int id)
        {
            cityRepository.Delete(id);
            return RedirectToAction("Index");

        }
    }
}