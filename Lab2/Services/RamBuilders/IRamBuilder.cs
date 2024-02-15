using Itmo.ObjectOrientedProgramming.Lab2.Entities.GeneralAttributes;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.MotherboardComponent;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.RamComponent;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.RamBuilders;

public interface IRamBuilder
{
    IRamBuilder SetRamName(string ramName);
    IRamBuilder SetAvailableMemorySize(int availableMemorySize);
    IRamBuilder SetJedec(JedecAndVoltage jedec);
    IRamBuilder SetRamPowerConsumption(int ramPowerConsumption);
    IRamBuilder SetXmpProfile(XmpProfile xmpProfile);
    IRamBuilder SetRamFormFactor(RamFormFactor ramFormFactor);
    IRamBuilder SetDdrStandart(DdrStandart ddrStandart);
    Ram Build();
}