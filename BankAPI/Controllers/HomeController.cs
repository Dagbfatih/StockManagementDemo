using BankAPI.Application.Algorithms.CandleStick.Distributors;
using BankAPI.Application.Repositories;
using BankAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace BankAPI.Controllers
{
    public class HomeController : Controller
    {
        private readonly StockRepository _stockRepository;
        private readonly MainAlgorithmDistributor _algorithmDistributor;
        private IList<Stock> _stocks;
        public HomeController(StockRepository stockRepository, MainAlgorithmDistributor algorithmDistributor)
        {
            _stockRepository = stockRepository;
            _algorithmDistributor = algorithmDistributor;
            _stocks = _stockRepository.GetAll();
        }
        public IActionResult Index()
        {
            IList<Suggestion> decisions = _algorithmDistributor.Distribute(
                    _stocks.Take(100).ToList());
            ViewBag.Index = 0;
            //ViewBag.Possibilities = possibilities;
            ViewBag.Stocks = _stocks;
            return View("Home", decisions);
        }

        [HttpGet("[Action]/{index}")]
        public IActionResult GetAll(int index = 0, int first = 100)
        {
            IList<Suggestion> decisions = _algorithmDistributor.Distribute(
                    _stocks.Skip(index * first).Take(first).ToList());
            ViewBag.Index = index;
            return View("Home", decisions); 
        }
    }
}
