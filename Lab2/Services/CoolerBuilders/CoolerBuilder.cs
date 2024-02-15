using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.CoolerComponent;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.GeneralAttributes;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.CoolerBuilders;

public class CoolerBuilder : ICoolingSystemBuilder
{
    private string? coolingSystemName;
    private IList<Socket>? validSocketsForCooler;
    private int tdp;
    private CoolerDimensions? dimensions;

    public ICoolingSystemBuilder SetCoolingSystemName(string coolingSystemName)
    {
        this.coolingSystemName = coolingSystemName;
        return this;
    }

    public ICoolingSystemBuilder SetValidSocketsForCooler(IList<Socket> validSocketsForCooler)
    {
        this.validSocketsForCooler = validSocketsForCooler;
        return this;
    }

    public ICoolingSystemBuilder SetTdp(int tdp)
    {
        this.tdp = tdp;
        return this;
    }

    public ICoolingSystemBuilder SetDimensions(CoolerDimensions dimensions)
    {
        this.dimensions = dimensions;
        return this;
    }

    public CoolingSystem Build()
    {
        return new CoolingSystem(
            coolingSystemName ?? throw new ArgumentNullException(nameof(coolingSystemName)),
            validSocketsForCooler ?? throw new ArgumentNullException(nameof(validSocketsForCooler)),
            tdp,
            dimensions ?? throw new ArgumentNullException(nameof(dimensions)));
    }
}
