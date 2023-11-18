using BankAPI.Application.Algorithms.CandleStick.Distributors;
using BankAPI.Application.Algorithms.CandleStick.Models;
using BankAPI.Models;

namespace BankAPI.Application.Services.CandleStick
{
    public class CandleStickChartService
    {
        MainAlgorithmDistributor _distributor;
        public CandleStickChartService(MainAlgorithmDistributor algorithmDistributor)
        {
            _distributor = algorithmDistributor;
        }

        public IList<Decision> CalculatePossibilities(IList<Stock> stocks)
        {
            var result = _distributor.Distribute(stocks);
            return result;
        }
    }
}
