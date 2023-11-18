using BankAPI.Application.Algorithms.CandleStick.Models;
using BankAPI.Application.Constants;
using BankAPI.Models;

namespace BankAPI.Application.Algorithms.CandleStick.DecisionAlgorithm
{
    public class EveningStarDesicionAlgorithm : ICandleStickAlgorithm<Possibility[], Decision>
    {
        public Decision Calculate(Possibility[] possibilities)
        {
            return new Decision
            {
                Type = DecisionTypes.Sell,
                Description = "Evening Star pattern seen, %" + possibilities.Last().Percentage
                + " decrease possibility. End of uptrend",
                Stock = possibilities.Last().Stock,
            };
        }
    }
}
