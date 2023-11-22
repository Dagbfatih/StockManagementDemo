using BankAPI.Application.Algorithms.CandleStick.Distributors;
using BankAPI.Application.Algorithms.CandleStick.PossibilityAlgorithm;
using BankAPI.Application.Algorithms.CandleStick.SuggestionAlgorithm;
using BankAPI.Application.Algorithms.CandleStick.TypeDetermineAlgorithm;
using BankAPI.Application.Repositories;

namespace BankAPI.Application
{
    public static class AppServiceRegistration
    {
        public static IServiceCollection AddCustomServices(this IServiceCollection services)
        {
            services.AddSingleton<StockRepository>();

            // Possibilities
            services.AddSingleton<BearishEngulfingPossibilityAlgorithm>();
            services.AddSingleton<BullishEngulfingPossibilityAlgorithm>();
            services.AddSingleton<EveningStarPossibilityAlgorithm>();
            services.AddSingleton<HammerPossibilityAlgorithm>();
            services.AddSingleton<InvertedHammerPossibilityAlgorithm>();
            services.AddSingleton<PiercingLinePossibilityAlgorithm>();
            services.AddSingleton<ShootingStarPossibilityAlgorithm>();
            services.AddSingleton<ThreeBlackCrowsPossibilityAlgorithm>();
            services.AddSingleton<ThreeWhiteSoldiersPossibilityAlgorithm>();

            // Decisions
            services.AddSingleton<BearishEngulfingSuggestionAlgorithm>();
            services.AddSingleton<BullishEngulfingSuggestionAlgorithm>();
            services.AddSingleton<EveningStarSuggestionAlgorithm>();
            services.AddSingleton<HammerSuggestionAlgorithm>();
            services.AddSingleton<InvertedHammerSuggestionAlgorithm>();
            services.AddSingleton<PiercingLineSuggestionAlgorithm>();
            services.AddSingleton<ShootingStarSuggestionAlgorithm>();
            services.AddSingleton<ThreeBlackCrowsSuggestionAlgorithm>();
            services.AddSingleton<ThreeWhiteSoldiersSuggestionAlgorithm>();

            // Distributors
            services.AddSingleton<MainAlgorithmDistributor>();
            services.AddSingleton<PossibilityAlgorithmDistributor>();
            services.AddSingleton<SuggestionAlgorithmDistributor>();

            return services;
        }
    }
}
