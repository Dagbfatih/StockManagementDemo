using BankAPI.Application.Constants;

namespace BankAPI.Models
{
    public class Suggestion
    {
        public SuggestionTypes Type { get; set; }
        public string Description { get; set; }
        public Stock Stock { get; set; }
    }
}
