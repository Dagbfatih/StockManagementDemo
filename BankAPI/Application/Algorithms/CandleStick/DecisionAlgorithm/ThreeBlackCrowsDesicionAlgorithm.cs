using BankAPI.Application.Algorithms.CandleStick.Models;
using BankAPI.Application.Constants;
using BankAPI.Models;

namespace BankAPI.Application.Algorithms.CandleStick.DecisionAlgorithm
{
    public class ThreeBlackCrowsDesicionAlgorithm : ICandleStickAlgorithm<Possibility[], Decision>
    {
        public Decision Calculate(Possibility[] possibilities)
        {
            return new Decision
            {
                Type = DecisionTypes.Sell,
                Description = "Three Black Crows pattern seen, %" + possibilities.Last().Percentage
                + " decrease possibility.",
                Stock = possibilities.Last().Stock,
            };
        }
    }
}
