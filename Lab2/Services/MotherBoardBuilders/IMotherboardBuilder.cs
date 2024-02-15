using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.GeneralAttributes;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.MotherboardComponent;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.WifiComponent;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.MotherBoardBuilders;

public interface IMotherboardBuilder
{
    IMotherboardBuilder SetMotherboardName(string motherboardName);
    IMotherboardBuilder SetMotherboardFormFactor(MotherboardFormFactor motherboardFormFactor);
    IMotherboardBuilder SetPciExpressLines(IReadOnlyCollection<PciExpress> pciExpressLines);
    IMotherboardBuilder SetCpuSocketName(Socket cpuSocketName);
    IMotherboardBuilder SetRamSlots(int ramSlots);
    IMotherboardBuilder SetBiosVersion(Bios biosVersion);
    IMotherboardBuilder SetChipsetMotherboard(Chipset chipsetMotherboard);
    IMotherboardBuilder SetDdrStandartVersion(DdrStandart ddrStandartVersion);
    IMotherboardBuilder SetSataPorts(SataPorts sataPorts);
    IMotherboardBuilder SetWifiMotherboard(WifiBase wifiMotherboard);
    Motherboard Build();
}