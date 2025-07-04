﻿using FinanceAPP.Models;

namespace FinanceAPP.Data.Service
{
    public interface IExpensesService
    {
        Task<IEnumerable<Expense>> GetAll();
        Task Add(Expense expense);
        Task Delete(Expense expense);
        Task Edit(Expense expense);
        Task<Expense?> GetByID(int id);
    }
}
