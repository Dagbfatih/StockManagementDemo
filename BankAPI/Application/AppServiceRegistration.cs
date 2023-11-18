using BankAPI.Application.Algorithms.CandleStick.DecisionAlgorithm;
using BankAPI.Application.Algorithms.CandleStick.Distributors;
using BankAPI.Application.Algorithms.CandleStick.PossibilityAlgorithm;
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
            services.AddSingleton<BearishEngulfingDecisionAlgorithm>();
            services.AddSingleton<BullishEngulfingDecisionAlgorithm>();
            services.AddSingleton<EveningStarDesicionAlgorithm>();
            services.AddSingleton<HammerDesicionAlgorithm>();
            services.AddSingleton<InvertedHammerDesicionAlgorithm>();
            services.AddSingleton<PiercingLineDesicionAlgorithm>();
            services.AddSingleton<ShootingStarDesicionAlgorithm>();
            services.AddSingleton<ThreeBlackCrowsDesicionAlgorithm>();
            services.AddSingleton<ThreeWhiteSoldiersDesicionAlgorithm>();

            // Distributors
            services.AddSingleton<MainAlgorithmDistributor>();
            services.AddSingleton<PossibilityAlgorithmDistributor>();
            services.AddSingleton<DecisionAlgorithmDistributor>();

            return services;
        }
    }
}
