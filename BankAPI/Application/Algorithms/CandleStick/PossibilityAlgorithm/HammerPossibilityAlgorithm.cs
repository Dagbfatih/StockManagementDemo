using BankAPI.Application.Algorithms.CandleStick.Models;
using BankAPI.Application.Constants;
using BankAPI.Models;

namespace BankAPI.Application.Algorithms.CandleStick.PossibilityAlgorithm
{
    public class HammerPossibilityAlgorithm : ICandleStickAlgorithm<Stock, Possibility>
    {
        public Possibility Calculate(Stock stock)
        {
            double ratioLowerShadowToBody = Math.Round(stock.LowerShadow / stock.Body, 3);
            double percentage = 60 + ratioLowerShadowToBody;

            return new()
            {
                Percentage = percentage,
                Stock = stock,
                Type = PossibilityType.Asc
            };
        }
    }
}
