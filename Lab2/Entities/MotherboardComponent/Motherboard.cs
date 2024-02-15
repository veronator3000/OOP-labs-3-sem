using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.GeneralAttributes;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.WifiComponent;
using Itmo.ObjectOrientedProgramming.Lab2.Services.MotherBoardBuilders;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.MotherboardComponent;

public class Motherboard : ComponentBase
{
    public Motherboard(
        string motherboardName,
        MotherboardFormFactor motherboardFormFactorType,
        IReadOnlyCollection<PciExpress> pciExpressLines,
        Socket cpuSocketName,
        int ramSlots,
        Bios biosVersion,
        Chipset chipsetMptherBoard,
        DdrStandart ddrStandartVersion,
        SataPorts sataPortsMotherboard,
        WifiBase? wifiMotherboard)
    : base(motherboardName)
    {
        if (ramSlots < 0) throw new NegativeValueException();
        MotherboardFormFactorType = motherboardFormFactorType;
        PciExpressLines = pciExpressLines;
        CpuSocketName = cpuSocketName;
        RamSlots = ramSlots;
        BiosVersion = biosVersion;
        ChipsetMotherBoard = chipsetMptherBoard;
        DdrStandartVersion = ddrStandartVersion;
        SataPortsMotherboard = sataPortsMotherboard;
        WifiMotherboard = wifiMotherboard;
    }

    public MotherboardFormFactor MotherboardFormFactorType { get; }
    public IReadOnlyCollection<PciExpress> PciExpressLines { get; }
    public SataPorts SataPortsMotherboard { get; }
    public Socket CpuSocketName { get; }
    public int RamSlots { get; }
    public Bios BiosVersion { get; }
    public Chipset ChipsetMotherBoard { get; }
    public DdrStandart DdrStandartVersion { get; }
    public WifiBase? WifiMotherboard { get; }

    public IMotherboardBuilder Debuild(IMotherboardBuilder builder)
    {
        builder = builder ?? throw new ArgumentNullException(nameof(builder));
        builder
            .SetMotherboardName(Name)
            .SetMotherboardFormFactor(MotherboardFormFactorType)
            .SetPciExpressLines(PciExpressLines)
            .SetSataPorts(SataPortsMotherboard)
            .SetCpuSocketName(CpuSocketName)
            .SetRamSlots(RamSlots)
            .SetBiosVersion(BiosVersion)
            .SetChipsetMotherboard(ChipsetMotherBoard)
            .SetDdrStandartVersion(DdrStandartVersion);
        if (WifiMotherboard is not null)
        {
            builder.SetWifiMotherboard(WifiMotherboard);
        }

        return builder;
    }
}