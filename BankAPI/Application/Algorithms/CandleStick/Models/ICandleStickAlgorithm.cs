using BankAPI.Models;

namespace BankAPI.Application.Algorithms.CandleStick.Models
{
    public interface ICandleStickAlgorithm<T, TResult> where T : class
    {
        public TResult Calculate(T stock);
    }
}
