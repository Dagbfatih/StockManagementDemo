using BankAPI.Application.Algorithms.CandleStick.Models;
using BankAPI.Application.Constants;
using BankAPI.Models;

namespace BankAPI.Application.Algorithms.CandleStick.SuggestionAlgorithm
{
    public class HammerSuggestionAlgorithm : ICandleStickAlgorithm<Possibility, Suggestion>
    {
        public Suggestion Calculate(Possibility possibility)
        {
            return new Suggestion
            {
                Type = SuggestionTypes.Buy,
                Description = "Hammer pattern seen, %" + possibility.Percentage + " success possibility.",
                Stock = possibility.Stock,
            };
        }
    }
}
