using Microsoft.EntityFrameworkCore;
using FinanceAPP.Models;

namespace FinanceAPP.Data
{
    public class FinanceAppContext : DbContext
    {
        public FinanceAppContext(DbContextOptions<FinanceAppContext>options): base(options) { }

         public DbSet<Expense> Expenses { get; set; }
    }
}
