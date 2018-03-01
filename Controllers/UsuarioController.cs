using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductManager.Models;

namespace ProductManager.Controllers
{
    public class UsuarioController : Controller
    {
        static List<Usuario> listaDeUsuario = new List<Usuario>
        {
            new Usuario{Id = 1, Nome= "Alfredo", Cpf = "42542542542", Email = "alfredohtinha@gmail.com"},
            new Usuario{Id = 2, Nome= "Camila", Cpf = "77788899912", Email = "camilahtona@gmail.com"},
            new Usuario{Id = 3, Nome= "Fernanda", Cpf = "717171717171", Email = "fernandarainha@gmail.com"}

        };







        public ActionResult Index()
        {
            return View(listaDeUsuario);
        }

        // GET: Usuario/Details/5
        public ActionResult Details(int id)
        {
            var usuario = listaDeUsuario.FirstOrDefault(u => u.Id == id);
            return View(usuario);
        }

        // GET: Usuario/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Usuario/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Usuario usuario)
        {
            try
            {
                listaDeUsuario.Add(usuario);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Usuario/Edit/5
        public ActionResult Edit(int? id)
        {
            
            if (id == null)
            {
                return NotFound();
            }

            var usuario = listaDeUsuario.FirstOrDefault(u => u.Id == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);

        }

        // POST: Usuario/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [Bind("Id, Nome, Cpf, Email")] Usuario usuario)
        {
            try
            {
                if (id != usuario.Id)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    var usuarioTemp = listaDeUsuario.FirstOrDefault(u => u.Id == id);

                    if (usuarioTemp != null)
                    {
                        usuarioTemp.Nome = usuario.Nome;
                        usuarioTemp.Cpf = usuario.Cpf;
                        usuarioTemp.Email = usuario.Email;

                    }
                }

                return RedirectToAction(nameof(Index));
            }

            catch
            {
                return View(usuario);
            }
        }

        // GET: Usuario/Delete/5
        public ActionResult Delete(int id)
        {
            var usuario = listaDeUsuario.FirstOrDefault(u => u.Id == id);

            if (usuario == null)
            {
                return NotFound();

            }
            return View(usuario);


        }

        // POST: Produto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int id)
        {
            try
            {
                var usuario = listaDeUsuario.FirstOrDefault(u => u.Id == id);
                listaDeUsuario.Remove(usuario);

                return RedirectToAction(nameof(Index));

            }
            catch
            {
                return View();
            }
        }
    }
}