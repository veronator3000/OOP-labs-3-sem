using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Services.CaseBuilders;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.CaseComponent;

public class CaseType : ComponentBase
{
    public CaseType(
        string caseTypeName,
        int availableGraphicsCardLenght,
        int availableGraphicsCardWidth,
        CaseFormFactor caseFormFactorName,
        int caseWidth,
        int caseLenght,
        int caseDeep)
    : base(caseTypeName)
    {
        if (availableGraphicsCardLenght < 0) throw new NegativeValueException();
        if (availableGraphicsCardWidth < 0) throw new NegativeValueException();
        if (caseWidth < 0) throw new NegativeValueException();
        if (caseLenght < 0) throw new NegativeValueException();
        if (caseDeep < 0) throw new NegativeValueException();
        AvailableGraphicsCardLenght = availableGraphicsCardLenght;
        AvailableGraphicsCardWidth = availableGraphicsCardWidth;
        CaseFormFactorName = caseFormFactorName;
        CaseWidth = caseWidth;
        CaseLenght = caseLenght;
        CaseDeep = caseDeep;
    }

    public int AvailableGraphicsCardLenght { get; }
    public int AvailableGraphicsCardWidth { get; }
    public CaseFormFactor CaseFormFactorName { get; }
    public int CaseWidth { get; }
    public int CaseLenght { get; }
    public int CaseDeep { get; }
    public ICaseBuilder Debuild(ICaseBuilder builder)
    {
        builder = builder ?? throw new ArgumentNullException(nameof(builder));
        builder
            .SetCaseTypeName(Name)
            .SetAvailableGraphicsCardLength(AvailableGraphicsCardLenght)
            .SetAvailableGraphicsCardWidth(AvailableGraphicsCardWidth)
            .SetCaseFormFactorName(CaseFormFactorName)
            .SetCaseWidth(CaseWidth)
            .SetCaseLength(CaseLenght)
            .SetCaseDepth(CaseDeep);
        return builder;
    }
}