using BankAPI.Application.Algorithms.CandleStick.PossibilityAlgorithm;
using BankAPI.Application.Algorithms.CandleStick.TypeDetermineAlgorithm;
using BankAPI.Application.Constants;
using BankAPI.Models;

namespace BankAPI.Application.Algorithms.CandleStick.Distributors
{
    public class PossibilityAlgorithmDistributor
    {
        private readonly HammerPossibilityAlgorithm _hammerAlgorithmCalculator;
        private readonly InvertedHammerPossibilityAlgorithm _invertedHammerAlgorithmCalculator;
        private readonly BullishEngulfingPossibilityAlgorithm _bullishEngulfingAlgorithmCalculator;
        private readonly PiercingLinePossibilityAlgorithm _piercingLineAlgorithmCalculator;
        private readonly ThreeWhiteSoldiersPossibilityAlgorithm _threeWhiteSoldiersAlgorithmCalculator;
        private readonly ShootingStarPossibilityAlgorithm _shootingStarAlgorithmCalculator;
        private readonly ThreeBlackCrowsPossibilityAlgorithm _threeBlackCrowsAlgorithmCalculator;
        private readonly BearishEngulfingPossibilityAlgorithm _bearishEngulfingAlgorithmCalculator;
        private readonly EveningStarPossibilityAlgorithm _eveningStarAlgorithmCalculator;

        public PossibilityAlgorithmDistributor(
            HammerPossibilityAlgorithm hammerAlgorithmCalculator,
            InvertedHammerPossibilityAlgorithm invertedHammerAlgorithmCalculator,
            BullishEngulfingPossibilityAlgorithm bullishEngulfingAlgorithmCalculator,
            PiercingLinePossibilityAlgorithm piercingLineAlgorithmCalculator,
            ThreeWhiteSoldiersPossibilityAlgorithm threeWhiteSoldiersAlgorithmCalculator,
            ShootingStarPossibilityAlgorithm shootingStarAlgorithmCalculator,
            ThreeBlackCrowsPossibilityAlgorithm threeBlackCrowsAlgorithmCalculator,
            BearishEngulfingPossibilityAlgorithm bearishEngulfingAlgorithmCalculator,
            EveningStarPossibilityAlgorithm eveningStarAlgorithmCalculator
            )
        {
            _hammerAlgorithmCalculator = hammerAlgorithmCalculator;
            _invertedHammerAlgorithmCalculator = invertedHammerAlgorithmCalculator;
            _bullishEngulfingAlgorithmCalculator = bullishEngulfingAlgorithmCalculator;
            _piercingLineAlgorithmCalculator = piercingLineAlgorithmCalculator;
            _threeWhiteSoldiersAlgorithmCalculator = threeWhiteSoldiersAlgorithmCalculator;
            _shootingStarAlgorithmCalculator = shootingStarAlgorithmCalculator;
            _threeBlackCrowsAlgorithmCalculator = threeBlackCrowsAlgorithmCalculator;
            _bearishEngulfingAlgorithmCalculator = bearishEngulfingAlgorithmCalculator;
            _eveningStarAlgorithmCalculator = eveningStarAlgorithmCalculator;
        }

        public IList<Possibility> Distribute(IList<Stock> stocks)
        {
            IList<Possibility> possibilities = new List<Possibility>();
            IList<Stock> determinedStocks = DetermineCandleStickTypeAlgorithm.DetermineStockTypes(stocks);

            foreach (var stock in determinedStocks)
            {
                if (stock.Type == CandleStickTypes.Hammer)
                {
                    Possibility result = _hammerAlgorithmCalculator.Calculate(stock);
                    possibilities.Add(result);
                }
                else if (stock.Type == CandleStickTypes.InvertedHammer)
                {
                    Possibility result = _invertedHammerAlgorithmCalculator.Calculate(stock);
                    possibilities.Add(result);
                }
                else if (stock.Type == CandleStickTypes.PiercingLine)
                {
                    Stock[] data = new[] { determinedStocks[determinedStocks.IndexOf(stock) - 1], stock };
                    Possibility result = _piercingLineAlgorithmCalculator.Calculate(data);
                    possibilities.Add(result);
                }
                else if (stock.Type == CandleStickTypes.BullishEngulfing)
                {
                    Stock[] data = new[] { determinedStocks[determinedStocks.IndexOf(stock) - 1], stock };
                    Possibility result = _bullishEngulfingAlgorithmCalculator.Calculate(data);
                    possibilities.Add(result);
                }
                else if (stock.Type == CandleStickTypes.BearishEngulfing)
                {
                    Stock[] data = new[] { determinedStocks[determinedStocks.IndexOf(stock) - 1], stock };
                    Possibility result = _bearishEngulfingAlgorithmCalculator.Calculate(data);
                    possibilities.Add(result);
                }
                else if (stock.Type == CandleStickTypes.EveningStar)
                {
                    Stock[] data = new[] {
                        determinedStocks[determinedStocks.IndexOf(stock) - 2],
                        determinedStocks[determinedStocks.IndexOf(stock)-1],
                        stock };
                    Possibility result = _eveningStarAlgorithmCalculator.Calculate(data);
                    possibilities.Add(result);
                }
                else if (stock.Type == CandleStickTypes.ShootingStar)
                {
                    Possibility result = _shootingStarAlgorithmCalculator.Calculate(stock);
                    possibilities.Add(result);
                }
                else if (stock.Type == CandleStickTypes.ThreeBlackCrows)
                {
                    Stock[] data = new[] {
                        determinedStocks[determinedStocks.IndexOf(stock) - 2],
                        determinedStocks[determinedStocks.IndexOf(stock)-1],
                        stock };
                    Possibility result = _threeBlackCrowsAlgorithmCalculator.Calculate(data);
                    possibilities.Add(result);
                }
                else if (stock.Type == CandleStickTypes.ThreeWhiteSoldiers)
                {
                    Stock[] data = new[] {
                        determinedStocks[determinedStocks.IndexOf(stock) - 2],
                        determinedStocks[determinedStocks.IndexOf(stock)-1],
                        stock };
                    Possibility result = _threeWhiteSoldiersAlgorithmCalculator.Calculate(data);
                    possibilities.Add(result);
                }
                else if (stock.Type == CandleStickTypes.None)
                {
                    possibilities.Add(new() { 
                        Percentage = 50,
                        Stock = stock,
                        Type = PossibilityType.Stable
                    });
                }
            }
            possibilities = possibilities.OrderBy(p => p.Stock.Date).ToList();

            return possibilities;
        }
    }
}
