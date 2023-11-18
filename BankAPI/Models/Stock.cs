using BankAPI.Application.Algorithms.CandleStick.Models;
using BankAPI.Application.Constants;

namespace BankAPI.Models
{
    public class Stock
    {
        public double Open { get; set; }
        public double High { get; set; }
        public double Low { get; set; }
        public double Close { get; set; }
        public double Amount { get; set; }
        public double Volume { get; set; }
        public DateTime Date { get; set; }
        public bool IsGreen { get { return this.Open - this.Close > 0 ? false : true; } set { } }
        public virtual CandleStickTypes Type{  get; set; }
        public double Body { get { return Math.Abs(this.Open - this.Close); } set { } }
        public double UpperShadow { get { return Math.Abs(this.High - this.Open); } set { } }
        public double LowerShadow { get { return Math.Abs(this.Close - this.Low); } set { } }
    }
}
