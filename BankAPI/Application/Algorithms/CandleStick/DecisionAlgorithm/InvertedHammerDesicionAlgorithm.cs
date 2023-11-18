using BankAPI.Application.Algorithms.CandleStick.Models;
using BankAPI.Application.Constants;
using BankAPI.Models;

namespace BankAPI.Application.Algorithms.CandleStick.DecisionAlgorithm
{
    public class InvertedHammerDesicionAlgorithm : ICandleStickAlgorithm<Possibility, Decision>
    {
        public Decision Calculate(Possibility possibility)
        {
            return new Decision
            {
                Type = DecisionTypes.Buy,
                Description = "Inverted hammer pattern seen, %" + possibility.Percentage + " increase possibility.",
                Stock = possibility.Stock,
            };
        }
    }
}
