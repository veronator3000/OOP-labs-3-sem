using Itmo.ObjectOrientedProgramming.Lab2.Entities.CaseComponent;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.CaseBuilders;

public interface ICaseBuilder
{
    ICaseBuilder SetCaseTypeName(string caseTypeName);
    ICaseBuilder SetAvailableGraphicsCardLength(int availableGraphicsCardLength);
    ICaseBuilder SetAvailableGraphicsCardWidth(int availableGraphicsCardWidth);
    ICaseBuilder SetCaseFormFactorName(CaseFormFactor caseFormFactorName);
    ICaseBuilder SetCaseWidth(int caseWidth);
    ICaseBuilder SetCaseLength(int caseLength);
    ICaseBuilder SetCaseDepth(int caseDepth);
    CaseType Build();
}