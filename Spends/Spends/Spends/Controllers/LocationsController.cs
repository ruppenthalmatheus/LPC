using Spends.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Spends.Controllers
{
    public class LocationsController : Controller
    {
        //Cria um objeto da classe LocationRepository, liberando acesso aos seus métodos
        LocationRepository locationRepository = new LocationRepository();

        // GET: Locations
        public ActionResult Index()
        {
            var locations = locationRepository.getAll();
            return View(locations);
        }

        //Chama a view com o formulário para cadastro de localidades
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        //Chama e executa a função Create, do LocationRepository
        //Recebe um objeto Location por parâmetro
        [HttpPost]
        public ActionResult Create(Location location)
        {
            locationRepository.Create(location);

            return RedirectToAction("Index");
        }

        //Chama a view com o formulário para edição de cadastro de uma localidade
        //Recebe por parâmetro o id da localidade a ser editada
        [HttpGet]
        public ActionResult Edit(int id)
        {
            Location location = locationRepository.selectById(id);
            return View(location);
        }

        //Chama e executa a função Update, do LocationRepository
        //Recebe um objeto location por parâmetro
        [HttpPost]
        public ActionResult Update(Location location)
        {
            locationRepository.Update(location);
            return RedirectToAction("Index");
        }

        //Chama e executa a função Delete, do LocationRepository
        //Recebe por parâmetro o id da localidade a ser deletada
        public ActionResult Delete(int id)
        {
            locationRepository.Delete(id);
            return RedirectToAction("Index");
        }

    }
}