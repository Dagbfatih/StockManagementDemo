using BankAPI.Application.Algorithms.CandleStick.DecisionAlgorithm;
using BankAPI.Application.Constants;
using BankAPI.Models;

namespace BankAPI.Application.Algorithms.CandleStick.Distributors
{
    public class DecisionAlgorithmDistributor
    {
        private readonly HammerDesicionAlgorithm _hammerDesicionAlgorithm;
        private readonly InvertedHammerDesicionAlgorithm _invertedHammerDesicionAlgorithm;
        private readonly BullishEngulfingDecisionAlgorithm _bullishEngulfingDesicionAlgorithm;
        private readonly BearishEngulfingDecisionAlgorithm _bearishEngulfingDesicionAlgorithm;
        private readonly EveningStarDesicionAlgorithm _eveningStarDesicionAlgorithm;
        private readonly PiercingLineDesicionAlgorithm _piercingLineDesicionAlgorithm;
        private readonly ShootingStarDesicionAlgorithm _shootingStarDesicionAlgorithm;
        private readonly ThreeBlackCrowsDesicionAlgorithm _threeBlackCrowsDesicionAlgorithm;
        private readonly ThreeWhiteSoldiersDesicionAlgorithm _threeWhiteSoldiersDesicionAlgorithm;

        public DecisionAlgorithmDistributor(
            HammerDesicionAlgorithm hammerDesicionAlgorithm,
            InvertedHammerDesicionAlgorithm invertedHammerDesicionAlgorithm,
            BullishEngulfingDecisionAlgorithm bullishEngulfingDesicionAlgorithm,
            BearishEngulfingDecisionAlgorithm bearishEngulfingDesicionAlgorithm,
            EveningStarDesicionAlgorithm eveningStarDesicionAlgorithm,
            PiercingLineDesicionAlgorithm piercingLineDesicionAlgorithm,
            ShootingStarDesicionAlgorithm shootingStarDesicionAlgorithm,
            ThreeBlackCrowsDesicionAlgorithm threeBlackCrowsDesicionAlgorithm,
            ThreeWhiteSoldiersDesicionAlgorithm threeWhiteSoldiersDesicionAlgorithm)
        {
            _hammerDesicionAlgorithm = hammerDesicionAlgorithm;
            _invertedHammerDesicionAlgorithm = invertedHammerDesicionAlgorithm;
            _bullishEngulfingDesicionAlgorithm = bullishEngulfingDesicionAlgorithm;
            _bearishEngulfingDesicionAlgorithm = bearishEngulfingDesicionAlgorithm;
            _eveningStarDesicionAlgorithm = eveningStarDesicionAlgorithm;
            _piercingLineDesicionAlgorithm = piercingLineDesicionAlgorithm;
            _shootingStarDesicionAlgorithm = shootingStarDesicionAlgorithm;
            _threeBlackCrowsDesicionAlgorithm = threeBlackCrowsDesicionAlgorithm;
            _threeWhiteSoldiersDesicionAlgorithm = threeWhiteSoldiersDesicionAlgorithm;
        }

        public IList<Decision> Distribute(IList<Possibility> possibilities)
        {
            IList<Decision> result = new List<Decision>();

            foreach (Possibility possibility in possibilities)
            {
                // One Data Patterns
                if (possibilities.IndexOf(possibility) >= 0)
                {
                    bool calculated = CheckOneDataPatterns(possibility, ref result);
                    if (calculated)
                        continue;
                }
                // Two data Patterns
                if (possibilities.IndexOf(possibility) >= 1)
                {
                    bool calculated = CheckTwoDataPatterns(new[] {
                        possibilities[possibilities.IndexOf(possibility) - 1],
                        possibility }, ref result);
                    if (calculated)
                        continue;
                }
                // Three data Patterns
                if (possibilities.IndexOf(possibility) >= 2)
                {
                    bool calculated = CheckThreeDataPatterns(new[] {
                        possibilities[possibilities.IndexOf(possibility) - 2],
                        possibilities[possibilities.IndexOf(possibility) - 1],
                        possibility }, ref result);
                    if (calculated)
                        continue;
                }

                if (possibility.Stock.Type == CandleStickTypes.None)
                {
                    result.Add(new Decision
                    {
                        Description = "Can't seen any tip, keep stock",
                        Stock = possibility.Stock,
                        Type = DecisionTypes.Keep
                    });
                }
            }

            return result.OrderBy(d => d.Stock.Date).ToList();
        }

        private bool CheckOneDataPatterns(Possibility possibility, ref IList<Decision> decisions)
        {
            bool distributed = false;
            if (possibility.Stock.Type == CandleStickTypes.Hammer)
            {
                Decision decision = _hammerDesicionAlgorithm.Calculate(possibility);
                decisions.Add(decision);
                distributed = true;
            }
            else if (possibility.Stock.Type == CandleStickTypes.InvertedHammer)
            {
                Decision decision = _invertedHammerDesicionAlgorithm.Calculate(possibility);
                decisions.Add(decision);
                distributed = true;
            }
            else if (possibility.Stock.Type == CandleStickTypes.ShootingStar)
            {
                Decision decision = _shootingStarDesicionAlgorithm.Calculate(possibility);
                decisions.Add(decision);
                distributed = true;
            }
            return distributed;
        }

        private bool CheckTwoDataPatterns(Possibility[] possibilities, ref IList<Decision> decisions)
        {
            bool distributed = false;
            if (possibilities.Last().Stock.Type == CandleStickTypes.BearishEngulfing)
            {
                Decision decision = _bearishEngulfingDesicionAlgorithm.Calculate(possibilities);
                decisions.Add(decision);
                distributed = true;
            }
            else if (possibilities.Last().Stock.Type == CandleStickTypes.BullishEngulfing)
            {
                Decision decision = _bullishEngulfingDesicionAlgorithm.Calculate(possibilities);
                decisions.Add(decision);
                distributed = true;
            }
            else if (possibilities.Last().Stock.Type == CandleStickTypes.PiercingLine)
            {
                Decision decision = _piercingLineDesicionAlgorithm.Calculate(possibilities);
                decisions.Add(decision);
                distributed = true;
            }
            else if (possibilities.Last().Stock.Type == CandleStickTypes.EveningStar)
            {
                Decision decision = _eveningStarDesicionAlgorithm.Calculate(possibilities);
                decisions.Add(decision);
                distributed = true;
            }
            return distributed;
        }

        private bool CheckThreeDataPatterns(Possibility[] possibilities, ref IList<Decision> decisions)
        {
            bool distributed = false;
            if (possibilities.Last().Stock.Type == CandleStickTypes.ThreeBlackCrows)
            {
                Decision decision = _threeBlackCrowsDesicionAlgorithm.Calculate(possibilities);
                decisions.Add(decision);
                distributed = true;
            }
            else if (possibilities.Last().Stock.Type == CandleStickTypes.ThreeWhiteSoldiers)
            {
                Decision decision = _threeWhiteSoldiersDesicionAlgorithm.Calculate(possibilities);
                decisions.Add(decision);
                distributed = true;
            }
            return distributed;
        }
    }
}
