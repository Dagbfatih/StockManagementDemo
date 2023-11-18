﻿using BankAPI.Application.Algorithms.CandleStick.Models;
using BankAPI.Application.Constants;
using BankAPI.Models;

namespace BankAPI.Application.Algorithms.CandleStick.DecisionAlgorithm
{
    public class ShootingStarDesicionAlgorithm : ICandleStickAlgorithm<Possibility, Decision>
    {
        public Decision Calculate(Possibility possibility)
        {
            return new Decision
            {
                Type = DecisionTypes.Sell,
                Description = "Shooting Star pattern seen, %" + possibility.Percentage + " decrease possibility.",
                Stock = possibility.Stock,
            };
        }
    }
}
