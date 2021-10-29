using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjetoTreinamentoG160.Business.Logic.Northwind;
using ProjetoTreinamentoG160.DataApplicator.Logic.Northwind;
using ProjetoTreinamentoG160.ModelData.Logic.Northwind.Model;
using ProjetoTreinamentoG160.MVC.Architecture;

namespace ProjetoTreinamentoG160.MVC.Controllers
{
    public class EmployeesController : BaseController
    {
        private NorthwindEntities db = new NorthwindEntities();
        private readonly EmployeesDataApplicator employeesDataApplicator;
        public EmployeesController()
        {
            employeesDataApplicator = new EmployeesDataApplicator(db);
        }

        // GET: Employees
        public ActionResult Index()
        {

            var employees = employeesDataApplicator.ConsultarTodos();               
            return View(employees.ToList());
        }

        // GET: Employees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employees employees = employeesDataApplicator.ObterUnico(e => e.EmployeeID == id);
        
            if (employees == null)
            {
                return HttpNotFound();
            }
            return View(employees);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            ViewBag.ReportsTo = new SelectList(db.Employees, "EmployeeID", "LastName");
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmployeeID,LastName,FirstName,Title,TitleOfCourtesy,BirthDate,HireDate,Address,City,Region,PostalCode,Country,HomePhone,Extension,Photo,Notes,ReportsTo,PhotoPath")] Employees employees)
        {
            if (ModelState.IsValid)
            {
                var validarRegra = new RV_EmployeesBusiness(db, employees);
                if (!validarRegra.Consistir())
                {

                    foreach (var item in validarRegra.Mensagens)
                    {
                        mensagens.Add(item.FullMessageString);
                    }
                    this.EmitirMensagem(mensagens, Architecture.Enuns.ETipoMensagem.Erro);
                }
                else
                {
                    employeesDataApplicator.Inserir(employees);
                    employeesDataApplicator.Salvar();
                    this.EmitirMensagem("Employees incluido com sucesso", Architecture.Enuns.ETipoMensagem.Sucesso);
                }

                             
                return RedirectToAction("Index");
            }

            ViewBag.ReportsTo = new SelectList(db.Employees, "EmployeeID", "LastName", employees.ReportsTo);
            return View(employees);
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employees employees = employeesDataApplicator.ObterUnico(e => e.EmployeeID == id);
            if (employees == null)
            {
                return HttpNotFound();
            }
            ViewBag.ReportsTo = new SelectList(db.Employees, "EmployeeID", "LastName", employees.ReportsTo);
            return View(employees);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmployeeID,LastName,FirstName,Title,TitleOfCourtesy,BirthDate,HireDate,Address,City,Region,PostalCode,Country,HomePhone,Extension,Photo,Notes,ReportsTo,PhotoPath")] Employees employees)
        {
            if (ModelState.IsValid)
            {
                var validarRegra = new RV_EmployeesBusiness(db, employees);
                if (!validarRegra.Consistir())
                {

                    foreach (var item in validarRegra.Mensagens)
                    {
                        mensagens.Add(item.FullMessageString);
                    }
                    this.EmitirMensagem(mensagens, Architecture.Enuns.ETipoMensagem.Erro);
                }
                else
                {
                    employeesDataApplicator.Atualizar(employees);
                    employeesDataApplicator.Salvar();
                    this.EmitirMensagem("Employees alterado com sucesso", Architecture.Enuns.ETipoMensagem.Sucesso);
                }

                
                return RedirectToAction("Index");
            }
            ViewBag.ReportsTo = new SelectList(db.Employees, "EmployeeID", "LastName", employees.ReportsTo);
            return View(employees);
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employees employees = employeesDataApplicator.ObterUnico(e => e.EmployeeID == id);
            if (employees == null)
            {
                return HttpNotFound();
            }
            return View(employees);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employees employees = employeesDataApplicator.ObterUnico(e => e.EmployeeID == id);
            employeesDataApplicator.Excluir(employees);
            employeesDataApplicator.Salvar();
            this.EmitirMensagem("Employees excluido com sucesso", Architecture.Enuns.ETipoMensagem.Sucesso);
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
