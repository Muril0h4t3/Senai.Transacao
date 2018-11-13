using System;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Financas.web.Mvc.Models;

namespace Senai.Financas.web.Mvc.Controllers
{
    public class TransacaoController : Controller
    {
        [HttpGet]
        public IActionResult Cadastrar(){
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("emailusuario")))
            {
                return RedirectToAction("Login", "Usuario");
            }
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(IFormCollection form){
            TransacaoModel transacao = new TransacaoModel();
            transacao.Id = 1;
            transacao.Descricao = form["descricao"];
            transacao.Valor = decimal.Parse(form["valor"]);
            transacao.Tipo = form["tipo"];
            transacao.Data = DateTime.Parse(form["data"]);

            using(StreamWriter sw = new StreamWriter("trasacao.csv", true)){
                sw.WriteLine($"{transacao.Id};{transacao.Descricao};{transacao.Valor};{transacao.Tipo};{transacao.Data}");
            }
            ViewBag.Mensagem = "Trasação Cadastrada";
            return View();
        }
    }
}