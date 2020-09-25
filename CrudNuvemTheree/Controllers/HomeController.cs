using CrudNuvemTheree.Models;
using CrudNuvemTheree.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CrudNuvemTheree.Controllers
{
    public class HomeController : Controller
    {
        #region Referencias

        private AgendaContatosService AgendaContatosService = new AgendaContatosService();

        #endregion

        #region Get 

        [HttpGet]
        public ActionResult Index()
        {
            var saida = new List<ListaContatosViewModel>();

            return View(saida);
        }

        [HttpGet]
        public ActionResult BuscarContatos()
        {
            var saida = new List<ListaContatosViewModel>();

            var listagemContatos = AgendaContatosService.GetAll();

            foreach (var item in listagemContatos)
            {
                var registro = new ListaContatosViewModel(item);
                saida.Add(registro);
            }

            return View("_Lista", saida);
        }

        [HttpGet]
        public ActionResult CadastrarContatos()
        {
            return View();
        }

        [HttpGet]
        public ActionResult EditarContatos(int id)
        {
            var dados = AgendaContatosService.GetById(id);

            var saida = new ListaContatosViewModel(dados);

            return View(saida);
        }
        #endregion

        #region Posts

        [HttpPost]
        public ActionResult CadastrarContatos(ListaContatosViewModel Itens)
        {
            try
            {
                Itens.Status = true;
                AgendaContatosService.Add(Itens.ToDomain());

                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Home");
            }

        }

        [HttpPost]
        public ActionResult EditarContatos(ListaContatosViewModel Itens)
        {
            try
            {
                Itens.Status = true;
                AgendaContatosService.Update(Itens.ToDomain());


                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public ActionResult DesabilitarContato(int Id)
        {
            try
            {
                var dados = AgendaContatosService.GetById(Id);

                if(dados.Status == true)
                {
                    dados.Status = false;
                    AgendaContatosService.Update(dados);

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    dados.Status = true;
                    AgendaContatosService.Update(dados);
                    return RedirectToAction("Index", "Home");
                }

            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public bool ExcluirAgendaContatos(int id)
        {
            try
            {
                var registro = AgendaContatosService.Find(xs => xs.Id == id).FirstOrDefault();
                AgendaContatosService.Remove(registro);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        #endregion
    }
}