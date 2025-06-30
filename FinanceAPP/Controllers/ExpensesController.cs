using FinanceAPP.Data;
using FinanceAPP.Data.Service;
using FinanceAPP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace FinanceAPP.Controllers
{
    public class ExpensesController : Controller
    {
        private readonly IExpensesService _expensesService;

        public ExpensesController(IExpensesService expensesService)
        {
            _expensesService = expensesService;
        }
        public async Task<IActionResult> Index()
        {
            var expenses = await _expensesService.GetAll();
            return View(expenses);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Expense expense)
        {
            if (ModelState.IsValid)
            {
                await _expensesService.Add(expense);

                return RedirectToAction("Index");
            }
            return View(expense);
        }
        public async Task<IActionResult> Delete(int id)
        {
            var expense = await _expensesService.GetByID(id);
            if (expense == null)
            {
                return NotFound();
            }
            return View(expense);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var expense = await _expensesService.GetByID(id);
            if (expense == null) 
            {
                return NotFound();
            }
            
            await _expensesService.Delete(expense);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Edit(int id)
        {
            var expense = await _expensesService.GetByID(id);
            if (expense == null)
            {
                return NotFound();
            }
            return View(expense);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Expense expense)
        {
            if (!ModelState.IsValid)
            {
                return View(expense);
            }
            var existingExpense = await _expensesService.GetByID(expense.Id);
            if (existingExpense == null)
            {
                return NotFound();
            }

            existingExpense.Description = expense.Description;
            existingExpense.Amount = expense.Amount;
            existingExpense.Category = expense.Category;
            existingExpense.Date = expense.Date;

            await _expensesService.Edit(existingExpense);
            return RedirectToAction("Index");
        }
        }
}
