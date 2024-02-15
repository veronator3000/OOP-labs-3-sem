using Microsoft.Extensions.DependencyInjection;
using PresentationConsole.Scenarios;
using PresentationConsole.Scenarios.Balance.BalanceAdmin;
using PresentationConsole.Scenarios.Balance.BalanceUser;
using PresentationConsole.Scenarios.DecreaseMoney;
using PresentationConsole.Scenarios.IncreaseMoney;
using PresentationConsole.Scenarios.Login.AdminLogin;
using PresentationConsole.Scenarios.Login.UserLogin;
using PresentationConsole.Scenarios.Registration;
using PresentationConsole.Scenarios.TransactionHistoryAll.AdminTransactions.ConcreteTransaction;
using PresentationConsole.Scenarios.TransactionHistoryAll.AdminTransactions.EveryoneTransaction;
using PresentationConsole.Scenarios.TransactionHistoryAll.UserTransactions;

namespace PresentationConsole.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPresentationConsole(this IServiceCollection collection)
    {
        collection.AddScoped<ScenarioRunner>();
        collection.AddScoped<IScenarioProvider, LoginUserScenarioProvider>();
        collection.AddScoped<IScenarioProvider, LoginAdminScenarioProvider>();
        collection.AddScoped<IScenarioProvider, RegistrationScenarioProvider>();
        collection.AddScoped<IScenarioProvider, BalanceAdminScenarioProvider>();
        collection.AddScoped<IScenarioProvider, BalanceUserScenarioProvider>();
        collection.AddScoped<IScenarioProvider, DecreaseMoneyScenarioProvider>();
        collection.AddScoped<IScenarioProvider, IncreaseMoneyScenarioProvider>();
        collection.AddScoped<IScenarioProvider, ConcreteTransactionScenarioProvider>();
        collection.AddScoped<IScenarioProvider, EveryoneTransactionScenarioProvider>();
        collection.AddScoped<IScenarioProvider, UserHistoryTransactionScenarioProvider>();

        return collection;
    }
}