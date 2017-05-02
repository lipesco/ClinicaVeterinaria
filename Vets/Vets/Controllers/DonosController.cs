using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Vets.Models;

namespace Vets.Controllers
{
    public class DonosController : Controller
    {
        private VetsDB db = new VetsDB();

        // GET: Donos
        public ActionResult Index()
        {
            return View(db.Donos.ToList().OrderBy(d => d.Nome));
        }

        // GET: Donos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                //redireciona para o inicio
                return RedirectToAction("Index");
            }
            //Pesquisar na BD pelo dono cujo id é fornecido
            Donos donos = db.Donos.Find(id);
            //se o dono não é encontrado...
            if (donos == null)
            {
                //return HttpNotFound();
                //redireciona para o inicio
                return RedirectToAction("Index");
            }
            //mostra os dados do dono
            return View(donos);
        }

        // GET: Donos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Donos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DonoID,Nome,NIF")] Donos donos)
        {
            if (ModelState.IsValid)
            {
                db.Donos.Add(donos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(donos);
        }

        // GET: Donos/Edit/5
        public ActionResult Edit(int? id)
        {
            //avalia se o parametro é nulo
            if (id == null)
            {
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                //retorna para o inicio
                return RedirectToAction("Index");
            }
            Donos dono = db.Donos.Find(id);
            if (dono == null)
            {
                //return HttpNotFound();
                //retorna para o inicio
                return RedirectToAction("Index");
            }
            //mostra os dados do dono
            return View(dono);
        }

        // POST: Donos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DonoID,Nome,NIF")] Donos donos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(donos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(donos);
        }

        // GET: Donos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                //retorna para o inicio
                return RedirectToAction("Index");
            }
            Donos donos = db.Donos.Find(id);
            if (donos == null)
            {
                //return HttpNotFound();
                //retorna para o inicio
                return RedirectToAction("Index");
            }
            return View(donos);
        }

        // POST: Donos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //procurar o dono na base de dados cuja chave primária corresponde ao parâmetro fornecido -> id
            Donos dono = db.Donos.Find(id);

            try
            {
                //remove do objecto 'db' o 'dono' encontrado na linha anterior
                db.Donos.Remove(dono);
                //torna definitivo as instruções  anteriores
                db.SaveChanges();
            }
            catch (Exception)
            {
                //throw;
                //gerar uma mensagem de erro a ser entregue ao utilizador
                ModelState.AddModelError("",
                    string.Format("Ocorreu um erro na operação de eliminar o 'dono' com ID {0} - {1}", id, dono.Nome)
                );
                //regressar à view 'Delete'
                return View(dono);
            }
            //devolve o controlo do programa, apresentado a view Index
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
