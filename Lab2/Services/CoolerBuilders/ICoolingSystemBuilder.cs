using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.CoolerComponent;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.GeneralAttributes;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.CoolerBuilders;

public interface ICoolingSystemBuilder
{
    ICoolingSystemBuilder SetCoolingSystemName(string coolingSystemName);
    ICoolingSystemBuilder SetValidSocketsForCooler(IList<Socket> validSocketsForCooler);
    ICoolingSystemBuilder SetTdp(int tdp);
    ICoolingSystemBuilder SetDimensions(CoolerDimensions dimensions);
    CoolingSystem Build();
}