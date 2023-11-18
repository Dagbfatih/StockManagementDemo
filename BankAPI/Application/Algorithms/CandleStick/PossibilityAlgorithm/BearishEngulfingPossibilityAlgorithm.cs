using BankAPI.Application.Algorithms.CandleStick.Models;
using BankAPI.Application.Constants;
using BankAPI.Models;

namespace BankAPI.Application.Algorithms.CandleStick.PossibilityAlgorithm
{
    public class BearishEngulfingPossibilityAlgorithm : ICandleStickAlgorithm<Stock[], Possibility>
    {
        public Possibility Calculate(Stock[] stocks)
        {
            double percentage = 57.3;

            return new()
            {
                Percentage = percentage,
                Stock = stocks.Last(),
                Type = PossibilityType.Desc
            };
        }
    }
}
