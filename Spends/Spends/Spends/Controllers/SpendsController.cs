using Spends.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Spends.Controllers
{
    public class SpendsController : Controller
    {

        //Cria um objeto da classe SpendRepository, liberando acesso aos seus métodos
        SpendRepository spendRepository = new SpendRepository();

        //Cria um objeto da classe CategoryRepository, liberando acesso aos seus métodos
        CategoryRepository categoryRepository = new CategoryRepository();

        //Cria um objeto da classe LocationRepository, liberando acesso aos seus métodos
        LocationRepository locationRepository = new LocationRepository();

        // GET: Spends
        public ActionResult Index()
        {
            ViewBag.Categories = categoryRepository.getAll();
            ViewBag.Locations = locationRepository.getAll();
            var spends = spendRepository.getAll();
            return View(spends);
        }

        // GET: SpendsbyPeriod
        [HttpGet]
        public ActionResult spendsByPeriod()
        {
            return View();
        }

        [HttpPost]
        public ActionResult spendsByPeriod(DateTime pStartDate, DateTime pFinalDate)
        {
            string startDate = pStartDate.ToString("yyyy-MM-dd");
            string finalDate = pFinalDate.ToString("yyyy-MM-dd");
            var spends = spendRepository.spendsByPeriod(startDate, finalDate);
            return View(spends);
        }

        // GET: SpendsCategorybyPeriod
        [HttpGet]
        public ActionResult spendsCategoryByPeriod()
        {
            return View();
        }

        [HttpPost]
        public ActionResult spendsCategoryByPeriod(DateTime pStartDate, DateTime pFinalDate, int id)
        {
            ViewBag.Categories = categoryRepository.getAll();
            string startDate = pStartDate.ToString("yyyy-MM-dd");
            string finalDate = pFinalDate.ToString("yyyy-MM-dd");
            var spends = spendRepository.spendsCategoryByPeriod(startDate, finalDate, id);
            return View(spends);
        }

        // GET: SpendsLocationbyPeriod
        [HttpGet]
        public ActionResult spendsLocationByPeriod()
        {
            return View();
        }

        [HttpPost]
        public ActionResult spendsLocationByPeriod(DateTime pStartDate, DateTime pFinalDate, int id)
        {
            ViewBag.Locations = locationRepository.getAll();
            string startDate = pStartDate.ToString("yyyy-MM-dd");
            string finalDate = pFinalDate.ToString("yyyy-MM-dd");
            var spends = spendRepository.spendsLocationByPeriod(startDate, finalDate, id);
            return View(spends);
        }

        //Chama a view com o formulário para cadastro de despesas
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Categories = categoryRepository.getAll();
            ViewBag.Locations = locationRepository.getAll();
            return View();
        }

        //Chama e executa a função Create, do SpendRepository
        //Recebe um objeto Spend por parâmetro
        [HttpPost]
        public ActionResult Create(Spend spend)
        {
            spendRepository.Create(spend);

            return RedirectToAction("Index");
        }

        //Chama a view com o formulário para edição de cadastro de uma despesa 
        //Recebe por parâmetro o id da despesa a ser editada
        [HttpGet]
        public ActionResult Edit(int id)
        {
            Spend spend = spendRepository.selectById(id);
            ViewBag.Categories = categoryRepository.getAll();
            ViewBag.Locations = locationRepository.getAll();
            return View(spend);
        }

        //Chama e executa a função Update, do SpendRepository
        //Recebe um objeto Spend por parâmetro
        [HttpPost]
        public ActionResult Update(Spend spend)
        {
            spendRepository.Update(spend);
            return RedirectToAction("Index");
        }

        //Chama e executa a função Delete, do SpendRepository
        //Recebe por parâmetro o id da despesa a ser deletada
        public ActionResult Delete(int id)
        {
            spendRepository.Delete(id);
            return RedirectToAction("Index");

        }

    }
}