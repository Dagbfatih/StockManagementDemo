using BankAPI.Application.Algorithms.CandleStick.Models;
using BankAPI.Application.Constants;
using BankAPI.Models;

namespace BankAPI.Application.Algorithms.CandleStick.SuggestionAlgorithm
{
    public class EveningStarSuggestionAlgorithm : ICandleStickAlgorithm<Possibility[], Suggestion>
    {
        public Suggestion Calculate(Possibility[] possibilities)
        {
            return new Suggestion
            {
                Type = SuggestionTypes.Sell,
                Description = "Evening Star pattern seen, %" + possibilities.Last().Percentage
                + " decrease possibility. End of uptrend",
                Stock = possibilities.Last().Stock,
            };
        }
    }
}
