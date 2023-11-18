using BankAPI.Application.Constants;
using BankAPI.Models;
using System;
using System.Reflection;
using System.Threading;

namespace BankAPI.Application.Algorithms.CandleStick.TypeDetermineAlgorithm
{
    public static class DetermineCandleStickTypeAlgorithm
    {
        public static IList<Stock> DetermineStockTypes(IList<Stock> oldStocks)
        {
            IList<Stock> stocks = oldStocks.OrderBy(s => s.Date).ToList();

            foreach (var stock in stocks)
            {
                if (CheckHammerType(stock))
                {
                    stock.Type = CandleStickTypes.Hammer;
                    continue;
                }
                if (CheckInvertedHammerType(stock))
                {
                    stock.Type = CandleStickTypes.InvertedHammer;
                    continue;
                }
                if (CheckBullishEngulfingType(stocks.ToArray(), stocks.IndexOf(stock)))
                {
                    stock.Type = CandleStickTypes.BullishEngulfing;
                    continue;
                }
                if (CheckPiercingLineType(stocks.ToArray(), stocks.IndexOf(stock)))
                {
                    stock.Type = CandleStickTypes.PiercingLine;
                    continue;
                }
                if (CheckShootingStarType(stock))
                {
                    stock.Type = CandleStickTypes.ShootingStar;
                    continue;
                }
                if (CheckBearishEngulfingType(stocks.ToArray(), stocks.IndexOf(stock)))
                {
                    stock.Type = CandleStickTypes.BearishEngulfing;
                    continue;
                }
                if (CheckThreeWhiteSoldiersType(stocks.ToArray(), stocks.IndexOf(stock)))
                {
                    stock.Type = CandleStickTypes.ThreeWhiteSoldiers;
                    continue;
                }
                if (CheckThreeBlackCrowsType(stocks.ToArray(), stocks.IndexOf(stock)))
                {
                    stock.Type = CandleStickTypes.ThreeBlackCrows;
                    continue;
                }
                if (CheckEveningStarType(stocks.ToArray(), stocks.IndexOf(stock)))
                {
                    stock.Type = CandleStickTypes.EveningStar;
                    continue;
                }

                // Else
                stock.Type = CandleStickTypes.None;
            }

            return stocks;
        }

        private static bool CheckHammerType(Stock stock)
        {
            if (stock.Body > stock.UpperShadow
                && stock.LowerShadow > stock.Body
                && stock.LowerShadow > stock.UpperShadow
                && stock.IsGreen)
            {
                return true;
            }
            return false;
        }

        private static bool CheckInvertedHammerType(Stock stock)
        {
            if (stock.Body < stock.UpperShadow
                && stock.Body > stock.LowerShadow
                && stock.UpperShadow > stock.LowerShadow
                && stock.IsGreen)
            {
                return true;
            }
            return false;
        }

        private static bool CheckBullishEngulfingType(Stock[] allStocks, int index)
        {
            if (index < 1)
                return false;
            Stock[] stocks = new[] { allStocks[index - 1], allStocks[index] };

            if (stocks[0].Body < stocks[1].Body
                && stocks[1].IsGreen
                && !stocks[0].IsGreen)
            {
                return true;
            }
            return false;
        }
        private static bool CheckPiercingLineType(Stock[] allStocks, int index)
        {
            if (index < 1)
                return false;
            Stock[] stocks = new[] { allStocks[index - 1], allStocks[index] };

            if (!stocks[0].IsGreen
                && (stocks[0].Close + (stocks[0].Body / 2)) < stocks[1].Close
                && stocks[1].IsGreen)
            {
                return true;
            }
            return false;
        }
        private static bool CheckShootingStarType(Stock stock)
        {
            if (stock.Body < stock.UpperShadow
                && stock.Body > stock.LowerShadow
                && stock.UpperShadow > stock.LowerShadow
                && !stock.IsGreen)
            {
                return true;
            }
            return false;
        }
        private static bool CheckBearishEngulfingType(Stock[] allStocks, int index)
        {
            if (index < 1)
                return false;
            Stock[] stocks = new[] { allStocks[index - 1], allStocks[index] };

            if (stocks[0].Body < stocks[1].Body
                && !stocks[1].IsGreen
                && stocks[0].IsGreen)
            {
                return true;
            }
            return false;
        }
        private static bool CheckThreeWhiteSoldiersType(Stock[] allStocks, int index)
        {
            if (index < 2)
                return false;
            Stock[] stocks = new[] { allStocks[index - 2], allStocks[index - 1], allStocks[index] };

            if (stocks[2].IsGreen
                && stocks[1].IsGreen
                && stocks[0].IsGreen
                && stocks[1].Close < stocks[2].Close
                && stocks[0].Close < stocks[1].Close)
            {
                return true;
            }
            return false;
        }
        private static bool CheckThreeBlackCrowsType(Stock[] allStocks, int index)
        {
            if (index < 2)
                return false;
            Stock[] stocks = new[] { allStocks[index - 2], allStocks[index - 1], allStocks[index] };

            if (!stocks[2].IsGreen
                && !stocks[1].IsGreen
                && !stocks[0].IsGreen
                && stocks[1].Open > stocks[2].Open
                && stocks[0].Open > stocks[1].Open)
            {
                return true;
            }
            return false;
        }
        private static bool CheckEveningStarType(Stock[] allStocks, int index)
        {
            if (index < 2)
                return false;
            Stock[] stocks = new[] { allStocks[index - 2], allStocks[index - 1], allStocks[index] };

            if (!stocks[2].IsGreen
                && !stocks[0].IsGreen
                && stocks[1].Body < stocks[2].Body
                && stocks[1].Body < stocks[0].Body)
            {
                return true;
            }
            return false;
        }
    }
}
