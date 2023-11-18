using BankAPI.Application.Algorithms.CandleStick.Models;
using BankAPI.Application.Constants;
using BankAPI.Models;

namespace BankAPI.Application.Algorithms.CandleStick.DecisionAlgorithm
{
    public class ThreeWhiteSoldiersDesicionAlgorithm : ICandleStickAlgorithm<Possibility[], Decision>
    {
        public Decision Calculate(Possibility[] possibilities)
        {
            return new Decision
            {
                Type = DecisionTypes.Buy,
                Description = "Three White Soldiers pattern seen, %" + possibilities.Last().Percentage
                + " increase possibility.",
                Stock = possibilities.Last().Stock,
            };
        }
    }
}
