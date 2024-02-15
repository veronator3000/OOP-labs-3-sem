using ApplicationMain.Extensions;
using DataAccess.Extensions;
using Microsoft.Extensions.DependencyInjection;
using PresentationConsole.Extensions;
using PresentationConsole.Scenarios;
using Spectre.Console;

namespace ProjectX;

public static class Program
{
    public static async Task Main()
    {
        var collection = new ServiceCollection();

        collection
            .AddPresentationConsole()
            .AddInfrastructureDataAccess()
            .AddApplication();

        using (ServiceProvider provider = collection.BuildServiceProvider())
        using (IServiceScope scope = provider.CreateScope())
        {
            ScenarioRunner scenarioRunner = scope.ServiceProvider
                .GetRequiredService<ScenarioRunner>();

            while (true)
            {
                await scenarioRunner.Run();
                AnsiConsole.Clear();
            }
        }
    }
}