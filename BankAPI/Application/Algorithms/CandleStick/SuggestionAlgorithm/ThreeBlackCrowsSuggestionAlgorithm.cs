using BankAPI.Application.Algorithms.CandleStick.Models;
using BankAPI.Application.Constants;
using BankAPI.Models;

namespace BankAPI.Application.Algorithms.CandleStick.SuggestionAlgorithm
{
    public class ThreeBlackCrowsSuggestionAlgorithm : ICandleStickAlgorithm<Possibility[], Suggestion>
    {
        public Suggestion Calculate(Possibility[] possibilities)
        {
            return new Suggestion
            {
                Type = SuggestionTypes.Sell,
                Description = "Three Black Crows pattern seen, %" + possibilities.Last().Percentage
                + " decrease possibility.",
                Stock = possibilities.Last().Stock,
            };
        }
    }
}
