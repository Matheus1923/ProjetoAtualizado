using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ProjetoTreinamentoG160.DataApplicator.Logic.Northwind;
using ProjetoTreinamentoG160.ModelData.Logic.Northwind.Model;

namespace ProjetoTreinamentoG160.API.Controllers
{
    public class EmployeesController : ApiController
    {
        private NorthwindEntities db = new NorthwindEntities();
        private readonly EmployeesDataApplicator employeesDataAplicator;

        public EmployeesController()
        {
            employeesDataAplicator = new EmployeesDataApplicator(db);  
        }
        // GET: api/Employees
        public IQueryable<Employees> GetEmployees()
        {
            return employeesDataAplicator.ConsultarTodos();
        }

        // GET: api/Employees/5
        [ResponseType(typeof(Employees))]
        public IHttpActionResult GetEmployees(int id)
        {
            Employees employees = employeesDataAplicator.ObterUnico(e =>e.EmployeeID == id);
            if (employees == null)
            {
                return NotFound();
            }

            return Ok(employees);
        }

        // PUT: api/Employees/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEmployees(int id, Employees employees)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != employees.EmployeeID)
            {
                return BadRequest();
            }

            employeesDataAplicator.Atualizar(employees);
           
            try
            {
                employeesDataAplicator.Salvar();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeesExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Employees
        [ResponseType(typeof(Employees))]
        public IHttpActionResult PostEmployees(Employees employees)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            employeesDataAplicator.Inserir(employees);
            employeesDataAplicator.Salvar();

            return CreatedAtRoute("DefaultApi", new { id = employees.EmployeeID }, employees);
        }

        // DELETE: api/Employees/5
        [ResponseType(typeof(Employees))]
        public IHttpActionResult DeleteEmployees(int id)
        {
            Employees employees = employeesDataAplicator.ObterUnico(e => e.EmployeeID == id);
            if (employees == null)
            {
                return NotFound();
            }

            employeesDataAplicator.Excluir(employees);
            employeesDataAplicator.Salvar();

            return Ok(employees);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EmployeesExists(int id)
        {
            return db.Employees.Count(e => e.EmployeeID == id) > 0;
        }
    }
}