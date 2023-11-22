using BankAPI.Application.Constants;

namespace BankAPI.Models
{
    public class Decision
    {
        public double ProfitAmount { get; set; }
        public double PurchasePrice { get; set; }
        public double SalePrice { get; set; }
        public DecisionTypes Type { get; set; }
    }
}
