using BankAPI.Application.Constants;

namespace BankAPI.Models
{
    public class Possibility
    {
        public double Percentage { get; set; }
        public PossibilityType Type { get; set; }
        public virtual Stock Stock { get; set; }
    }
}
