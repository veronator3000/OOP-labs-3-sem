using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.GeneralAttributes;
using Itmo.ObjectOrientedProgramming.Lab2.Services.CoolerBuilders;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.CoolerComponent;

public class CoolingSystem : ComponentBase
{
    public CoolingSystem(
        string coolingSystemName,
        IList<Socket> validSocketsForCooler,
        int tdp,
        CoolerDimensions dimensions)
        : base(coolingSystemName)
    {
        if (tdp < 0) throw new NegativeValueException();
        ValidSocketsForCooler = validSocketsForCooler;
        Tdp = tdp;
        Dimensions = dimensions;
    }

    public CoolerDimensions Dimensions { get; }
    public IList<Socket> ValidSocketsForCooler { get; }
    public int Tdp { get; }
    public ICoolingSystemBuilder Debuild(ICoolingSystemBuilder builder)
    {
        builder = builder ?? throw new ArgumentNullException(nameof(builder));
        builder
            .SetCoolingSystemName(Name)
            .SetDimensions(Dimensions)
            .SetValidSocketsForCooler(ValidSocketsForCooler)
            .SetTdp(Tdp);
        return builder;
    }
}