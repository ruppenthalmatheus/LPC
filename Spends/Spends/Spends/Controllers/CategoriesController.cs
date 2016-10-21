using Spends.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Spends.Controllers
{
    public class CategoriesController : Controller
    {

        //Cria um objeto da classe CategoryRepository, liberando acesso aos seus métodos
        CategoryRepository categoryRepository = new CategoryRepository();

        // GET: Categories
        public ActionResult Index()
        {
            var categories = categoryRepository.getAll();
            return View(categories);
        }

        //Chama a view com o formulário para cadastro de categorias
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        //Chama e executa a função Create, do CategoryRepository
        //Recebe um objeto Category por parâmetro
        [HttpPost]
        public ActionResult Create(Category category)
        {
            categoryRepository.Create(category);

            return RedirectToAction("Index");
        }

        //Chama a view com o formulário para edição de cadastro de uma categoria
        //Recebe por parâmetro o id da categoria a ser editada
        [HttpGet]
        public ActionResult Edit(int id)
        {
            Category category = categoryRepository.selectById(id);
            return View(category);
        }

        //Chama e executa a função Update, do CategoryRepository
        //Recebe um objeto category por parâmetro
        [HttpPost]
        public ActionResult Update(Category category)
        {
            categoryRepository.Update(category);
            return RedirectToAction("Index");
        }

        //Chama e executa a função Delete, do CategoryRepository
        //Recebe por parâmetro o id da categoria a ser deletada
        public ActionResult Delete(int id)
        {
            categoryRepository.Delete(id);
            return RedirectToAction("Index");

        }

    }
}