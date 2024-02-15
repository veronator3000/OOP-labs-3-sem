using System.Diagnostics.CodeAnalysis;

namespace PresentationConsole.Scenarios;

public interface IScenarioProvider
{
    bool TryGetScenario([NotNullWhen(true)] out IScenario? scenario);
}