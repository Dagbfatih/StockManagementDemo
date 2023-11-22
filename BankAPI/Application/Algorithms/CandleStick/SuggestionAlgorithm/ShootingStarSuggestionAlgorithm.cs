using BankAPI.Application.Algorithms.CandleStick.Models;
using BankAPI.Application.Constants;
using BankAPI.Models;

namespace BankAPI.Application.Algorithms.CandleStick.SuggestionAlgorithm
{
    public class ShootingStarSuggestionAlgorithm : ICandleStickAlgorithm<Possibility, Suggestion>
    {
        public Suggestion Calculate(Possibility possibility)
        {
            return new Suggestion
            {
                Type = SuggestionTypes.Sell,
                Description = "Shooting Star pattern seen, %" + possibility.Percentage + " decrease possibility.",
                Stock = possibility.Stock,
            };
        }
    }
}
