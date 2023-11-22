using BankAPI.Application.Algorithms.CandleStick.Models;
using BankAPI.Application.Constants;
using BankAPI.Models;

namespace BankAPI.Application.Algorithms.CandleStick.SuggestionAlgorithm
{
    public class InvertedHammerSuggestionAlgorithm : ICandleStickAlgorithm<Possibility, Suggestion>
    {
        public Suggestion Calculate(Possibility possibility)
        {
            return new Suggestion
            {
                Type = SuggestionTypes.Buy,
                Description = "Inverted hammer pattern seen, %" + possibility.Percentage + " increase possibility.",
                Stock = possibility.Stock,
            };
        }
    }
}
