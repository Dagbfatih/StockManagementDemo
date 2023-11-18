using BankAPI.Application.Algorithms.CandleStick.Models;
using BankAPI.Application.Constants;
using BankAPI.Models;

namespace BankAPI.Application.Algorithms.CandleStick.PossibilityAlgorithm
{
    public class ShootingStarPossibilityAlgorithm : ICandleStickAlgorithm<Stock, Possibility>
    {
        public Possibility Calculate(Stock stock)
        {
            double ratioUpperShadowToBody = Math.Round(stock.UpperShadow / stock.Body, 3);
            double percentage = 51 + ratioUpperShadowToBody;

            return new()
            {
                Percentage = percentage,
                Stock = stock,
                Type = PossibilityType.Desc
            };
        }
    }
}
