using BankAPI.Application.Constants;

namespace BankAPI.Models
{
    public class Decision
    {
        public DecisionTypes Type { get; set; }
        public string Description { get; set; }
        public Stock Stock { get; set; }
    }
}
