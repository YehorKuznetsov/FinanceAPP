using Microsoft.EntityFrameworkCore;
using FinanceAPP.Models;

namespace FinanceAPP.Data
{
    public class FinanceAppContext : DbContext
    {
        public FinanceAppContext(DbContextOptions<FinanceAppContext>options): base(options) { }

        DbSet<Expense> Expenses { get; set; }
    }
}
