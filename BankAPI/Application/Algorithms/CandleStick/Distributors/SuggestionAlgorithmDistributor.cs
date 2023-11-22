using BankAPI.Application.Algorithms.CandleStick.SuggestionAlgorithm;
using BankAPI.Application.Constants;
using BankAPI.Models;

namespace BankAPI.Application.Algorithms.CandleStick.Distributors
{
    public class SuggestionAlgorithmDistributor
    {
        private readonly HammerSuggestionAlgorithm _hammerSuggestionAlgorithm;
        private readonly InvertedHammerSuggestionAlgorithm _invertedHammerSuggestionAlgorithm;
        private readonly BullishEngulfingSuggestionAlgorithm _bullishEngulfingSuggestionAlgorithm;
        private readonly BearishEngulfingSuggestionAlgorithm _bearishEngulfingSuggestionAlgorithm;
        private readonly EveningStarSuggestionAlgorithm _eveningStarSuggestionAlgorithm;
        private readonly PiercingLineSuggestionAlgorithm _piercingLineSuggestionAlgorithm;
        private readonly ShootingStarSuggestionAlgorithm _shootingStarSuggestionAlgorithm;
        private readonly ThreeBlackCrowsSuggestionAlgorithm _threeBlackCrowsSuggestionAlgorithm;
        private readonly ThreeWhiteSoldiersSuggestionAlgorithm _threeWhiteSoldiersSuggestionAlgorithm;

        public SuggestionAlgorithmDistributor(
            HammerSuggestionAlgorithm hammerSuggestionAlgorithm,
            InvertedHammerSuggestionAlgorithm invertedHammerSuggestionAlgorithm,
            BullishEngulfingSuggestionAlgorithm bullishEngulfingSuggestionAlgorithm,
            BearishEngulfingSuggestionAlgorithm bearishEngulfingSuggestionAlgorithm,
            EveningStarSuggestionAlgorithm eveningStarSuggestionAlgorithm,
            PiercingLineSuggestionAlgorithm piercingLineSuggestionAlgorithm,
            ShootingStarSuggestionAlgorithm shootingStarSuggestionAlgorithm,
            ThreeBlackCrowsSuggestionAlgorithm threeBlackCrowsSuggestionAlgorithm,
            ThreeWhiteSoldiersSuggestionAlgorithm threeWhiteSoldiersSuggestionAlgorithm)
        {
            _hammerSuggestionAlgorithm = hammerSuggestionAlgorithm;
            _invertedHammerSuggestionAlgorithm = invertedHammerSuggestionAlgorithm;
            _bullishEngulfingSuggestionAlgorithm = bullishEngulfingSuggestionAlgorithm;
            _bearishEngulfingSuggestionAlgorithm = bearishEngulfingSuggestionAlgorithm;
            _eveningStarSuggestionAlgorithm = eveningStarSuggestionAlgorithm;
            _piercingLineSuggestionAlgorithm = piercingLineSuggestionAlgorithm;
            _shootingStarSuggestionAlgorithm = shootingStarSuggestionAlgorithm;
            _threeBlackCrowsSuggestionAlgorithm = threeBlackCrowsSuggestionAlgorithm;
            _threeWhiteSoldiersSuggestionAlgorithm = threeWhiteSoldiersSuggestionAlgorithm;
        }

        public IList<Suggestion> Distribute(IList<Possibility> possibilities)
        {
            IList<Suggestion> result = new List<Suggestion>();

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
                    result.Add(new Suggestion
                    {
                        Description = "Can't seen any tip, keep stock",
                        Stock = possibility.Stock,
                        Type = SuggestionTypes.Keep
                    });
                }
            }

            return result.OrderBy(d => d.Stock.Date).ToList();
        }

        private bool CheckOneDataPatterns(Possibility possibility, ref IList<Suggestion> suggestions)
        {
            bool distributed = false;
            if (possibility.Stock.Type == CandleStickTypes.Hammer)
            {
                Suggestion suggestion = _hammerSuggestionAlgorithm.Calculate(possibility);
                suggestions.Add(suggestion);
                distributed = true;
            }
            else if (possibility.Stock.Type == CandleStickTypes.InvertedHammer)
            {
                Suggestion suggestion = _invertedHammerSuggestionAlgorithm.Calculate(possibility);
                suggestions.Add(suggestion);
                distributed = true;
            }
            else if (possibility.Stock.Type == CandleStickTypes.ShootingStar)
            {
                Suggestion suggestion = _shootingStarSuggestionAlgorithm.Calculate(possibility);
                suggestions.Add(suggestion);
                distributed = true;
            }
            return distributed;
        }

        private bool CheckTwoDataPatterns(Possibility[] possibilities, ref IList<Suggestion> suggestions)
        {
            bool distributed = false;
            if (possibilities.Last().Stock.Type == CandleStickTypes.BearishEngulfing)
            {
                Suggestion suggestion = _bearishEngulfingSuggestionAlgorithm.Calculate(possibilities);
                suggestions.Add(suggestion);
                distributed = true;
            }
            else if (possibilities.Last().Stock.Type == CandleStickTypes.BullishEngulfing)
            {
                Suggestion suggestion = _bullishEngulfingSuggestionAlgorithm.Calculate(possibilities);
                suggestions.Add(suggestion);
                distributed = true;
            }
            else if (possibilities.Last().Stock.Type == CandleStickTypes.PiercingLine)
            {
                Suggestion suggestion = _piercingLineSuggestionAlgorithm.Calculate(possibilities);
                suggestions.Add(suggestion);
                distributed = true;
            }
            else if (possibilities.Last().Stock.Type == CandleStickTypes.EveningStar)
            {
                Suggestion suggestion = _eveningStarSuggestionAlgorithm.Calculate(possibilities);
                suggestions.Add(suggestion);
                distributed = true;
            }
            return distributed;
        }

        private bool CheckThreeDataPatterns(Possibility[] possibilities, ref IList<Suggestion> suggestions)
        {
            bool distributed = false;
            if (possibilities.Last().Stock.Type == CandleStickTypes.ThreeBlackCrows)
            {
                Suggestion suggestion = _threeBlackCrowsSuggestionAlgorithm.Calculate(possibilities);
                suggestions.Add(suggestion);
                distributed = true;
            }
            else if (possibilities.Last().Stock.Type == CandleStickTypes.ThreeWhiteSoldiers)
            {
                Suggestion suggestion = _threeWhiteSoldiersSuggestionAlgorithm.Calculate(possibilities);
                suggestions.Add(suggestion);
                distributed = true;
            }
            return distributed;
        }
    }
}
