using BankAPI.Application.Algorithms.CandleStick.Models;
using BankAPI.Application.Constants;
using BankAPI.Models;

namespace BankAPI.Application.Algorithms.CandleStick.DecisionAlgorithm
{
    public class PiercingLineDesicionAlgorithm : ICandleStickAlgorithm<Possibility[], Decision>
    {
        public Decision Calculate(Possibility[] possibilities)
        {
            return new Decision
            {
                Type = DecisionTypes.Buy,
                Description = "Piercing line pattern seen, %" + possibilities.Last().Percentage + " increase possibility.",
                Stock = possibilities.Last().Stock,
            };
        }
    }
}
