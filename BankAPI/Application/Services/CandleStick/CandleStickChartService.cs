using BankAPI.Application.Algorithms.CandleStick.Distributors;
using BankAPI.Application.Algorithms.CandleStick.Models;
using BankAPI.Models;

namespace BankAPI.Application.Services.CandleStick
{
    public class CandleStickChartService
    {
        private readonly MainAlgorithmDistributor _distributor;

        public CandleStickChartService(MainAlgorithmDistributor algorithmDistributor)
        {
            _distributor = algorithmDistributor;
        }

        public IList<Suggestion> CalculateDecisionsWithVirtualMoney(IList<Stock> stocks)
        {
            var result = _distributor.Distribute(stocks);
            return result;
        }

        public IList<Suggestion> CalculateDecisions(IList<Stock> stocks)
        {
            var result = _distributor.Distribute(stocks);
            return result;
        }
    }
}
