using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.CaseComponent;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.CaseBuilders;

public class CaseBuilder : ICaseBuilder
{
    private string? _caseTypeName;
    private int _availableGraphicsCardLength;
    private int _availableGraphicsCardWidth;
    private CaseFormFactor? _caseFormFactorName;
    private int _caseWidth;
    private int _caseLength;
    private int _caseDepth;

    public ICaseBuilder SetCaseTypeName(string caseTypeName)
    {
        this._caseTypeName = caseTypeName;
        return this;
    }

    public ICaseBuilder SetAvailableGraphicsCardLength(int availableGraphicsCardLength)
    {
        this._availableGraphicsCardLength = availableGraphicsCardLength;
        return this;
    }

    public ICaseBuilder SetAvailableGraphicsCardWidth(int availableGraphicsCardWidth)
    {
        this._availableGraphicsCardWidth = availableGraphicsCardWidth;
        return this;
    }

    public ICaseBuilder SetCaseFormFactorName(CaseFormFactor caseFormFactorName)
    {
        this._caseFormFactorName = caseFormFactorName;
        return this;
    }

    public ICaseBuilder SetCaseWidth(int caseWidth)
    {
        this._caseWidth = caseWidth;
        return this;
    }

    public ICaseBuilder SetCaseLength(int caseLength)
    {
        this._caseLength = caseLength;
        return this;
    }

    public ICaseBuilder SetCaseDepth(int caseDepth)
    {
        this._caseDepth = caseDepth;
        return this;
    }

    public CaseType Build()
    {
        return new CaseType(
            _caseTypeName ?? throw new ArgumentNullException(nameof(_caseTypeName)),
            _availableGraphicsCardLength,
            _availableGraphicsCardWidth,
            _caseFormFactorName ?? throw new ArgumentNullException(nameof(_caseFormFactorName)),
            _caseWidth,
            _caseLength,
            _caseDepth);
    }
}