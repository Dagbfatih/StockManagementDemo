using BankAPI.Application.Algorithms.CandleStick.Models;
using BankAPI.Application.Constants;
using BankAPI.Models;

namespace BankAPI.Application.Algorithms.CandleStick.PossibilityAlgorithm
{
    public class BullishEngulfingPossibilityAlgorithm : ICandleStickAlgorithm<Stock[], Possibility>
    {
        public Possibility Calculate(Stock[] stocks)
        {
            double percentage = 55;

            return new()
            {
                Percentage = percentage,
                Stock = stocks.Last(),
                Type = PossibilityType.Asc
            };
        }
    }
}
