using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TesteAplicacaoNess.Models;

namespace TesteAplicacaoNess.Controllers
{
    public class DefaultController_Ness : Controller
    {
        private UsuarioRepositorio_Ness rep = null;

        public DefaultController_Ness()
        {
            this.rep = new UsuarioRepositorio_Ness();
        }


        public DefaultController_Ness(UsuarioRepositorio_Ness repositorio)
        {
            this.rep = repositorio;
        }
        

        public ActionResult Index()
        {
            var listarUsuariosNess = from usuario in rep.BuscarDetalhesUsuarios() select usuario;
            return View(listarUsuariosNess);
        }

        //Adicionando Usuario Ness
        public ActionResult AdicionarUsuario()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdicionarUsuario(Usuario usuario)
        {
            rep.AdicionarUsuario(usuario);
            return RedirectToAction("Index");
        }

        // Alterando dados do Usuario
        public ActionResult EditarUsuario(int id = 0)
        {
            Usuario usuario = rep.BuscarUsuarioPorID(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }
        [HttpPost]
        public ActionResult EditarUsario(Usuario usuario)
        {
            rep.AtualizaUsuario(usuario);
            return RedirectToAction("Index");
        }


        // Deletando dados do Usuario
        public ActionResult DeletarUsuario(int id = 0)
        {
            Usuario usuario = rep.BuscarUsuarioPorID(id);
            if (usuario == null )
            {
                return HttpNotFound();
            }
            return View(usuario);
        }
        [HttpPost]
        public ActionResult DeletarUsuario(Usuario usuario)
        {
            rep.DeletaUsuarioPorID(usuario.Id);
            return RedirectToAction("Index");
        }  
        
        public ActionResult Detalhes(int id = 0)
        {
            Usuario usuario = rep.Detalhes(id);
            return View(usuario);
        }
    }
}             