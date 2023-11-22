using BankAPI.Application.Algorithms.CandleStick.Models;
using BankAPI.Application.Algorithms.CandleStick.PossibilityAlgorithm;
using BankAPI.Application.Algorithms.CandleStick.TypeDetermineAlgorithm;
using BankAPI.Application.Constants;
using BankAPI.Models;

namespace BankAPI.Application.Algorithms.CandleStick.Distributors
{
    public class MainAlgorithmDistributor
    {
        private readonly PossibilityAlgorithmDistributor _possibilityAlgorithmDistributor;
        private readonly SuggestionAlgorithmDistributor _decisionAlgorithmDistributor;
        public MainAlgorithmDistributor(
            PossibilityAlgorithmDistributor possibilityAlgorithmDistributor,
            SuggestionAlgorithmDistributor decisionAlgorithmDistributor

            )
        {
            _possibilityAlgorithmDistributor = possibilityAlgorithmDistributor;
            _decisionAlgorithmDistributor = decisionAlgorithmDistributor;
        }

        public IList<Suggestion> Distribute(IList<Stock> stocks)
        {
            IList<Possibility> possibilities = _possibilityAlgorithmDistributor.Distribute(stocks);
            IList<Suggestion> decisions = _decisionAlgorithmDistributor.Distribute(
                possibilities.OrderBy(p => p.Stock.Date).ToList());
            return decisions;
        }
    }
}
