using FinanceAPP.Models;
using Microsoft.EntityFrameworkCore;

namespace FinanceAPP.Data.Service
{
    public class ExpensesService : IExpensesService
    {
        private readonly FinanceAppContext _context;
        public ExpensesService(FinanceAppContext context) 
        {
            _context = context;
        }
        
        public async Task Add(Expense expense)
        {
            _context.Expenses.Add(expense);
            await _context.SaveChangesAsync();
        }
        public async Task Delete(Expense expense)
        {
            await _context.Expenses.Where(e => e.Id == expense.Id).ExecuteDeleteAsync();
        }
        public async Task Edit(Expense expense)
        {
            _context.Expenses.Update(expense);
            await _context.SaveChangesAsync();
        }
        public async Task<IEnumerable<Expense>> GetAll()
        {
            var expenses = await _context.Expenses.ToListAsync();
            return expenses;
        }
        public async Task<Expense?> GetByID(int ID)
        {
            return await _context.Expenses.FirstOrDefaultAsync(e => e.Id == ID);
        }
    }
}