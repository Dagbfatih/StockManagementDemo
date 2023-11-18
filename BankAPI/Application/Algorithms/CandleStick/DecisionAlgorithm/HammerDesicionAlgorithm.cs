using BankAPI.Application.Algorithms.CandleStick.Models;
using BankAPI.Application.Constants;
using BankAPI.Models;

namespace BankAPI.Application.Algorithms.CandleStick.DecisionAlgorithm
{
    public class HammerDesicionAlgorithm : ICandleStickAlgorithm<Possibility, Decision>
    {
        public Decision Calculate(Possibility possibility)
        {
            return new Decision
            {
                Type = DecisionTypes.Buy,
                Description = "Hammer pattern seen, %" + possibility.Percentage + " success possibility.",
                Stock = possibility.Stock,
            };
        }
    }
}
