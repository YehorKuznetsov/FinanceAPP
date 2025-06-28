using Microsoft.AspNetCore.Mvc;

namespace FinanceAPP.Controllers
{
    public class ExpensesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
