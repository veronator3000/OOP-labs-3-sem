using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.GeneralAttributes;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.MotherboardComponent;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.WifiComponent;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.MotherBoardBuilders;

public class MotherboardBuilder : IMotherboardBuilder
{
    private string? _motherboardName;
    private MotherboardFormFactor? _motherboardFormFactor;
    private IReadOnlyCollection<PciExpress>? _pciExpressLines;
    private Socket? _cpuSocketName;
    private int _ramSlots;
    private Bios? _biosVersion;
    private Chipset? _chipsetMotherBoard;
    private DdrStandart? _ddrStandartVersion;
    private SataPorts? _sataPorts;
    private WifiBase? _wifi;

    public IMotherboardBuilder SetMotherboardName(string motherboardName)
    {
        _motherboardName = motherboardName;
        return this;
    }

    public IMotherboardBuilder SetMotherboardFormFactor(MotherboardFormFactor motherboardFormFactor)
    {
        _motherboardFormFactor = motherboardFormFactor;
        return this;
    }

    public IMotherboardBuilder SetPciExpressLines(IReadOnlyCollection<PciExpress> pciExpressLines)
    {
        _pciExpressLines = pciExpressLines;
        return this;
    }

    public IMotherboardBuilder SetCpuSocketName(Socket cpuSocketName)
    {
        _cpuSocketName = cpuSocketName;
        return this;
    }

    public IMotherboardBuilder SetRamSlots(int ramSlots)
    {
        _ramSlots = ramSlots;
        return this;
    }

    public IMotherboardBuilder SetBiosVersion(Bios biosVersion)
    {
        _biosVersion = biosVersion;
        return this;
    }

    public IMotherboardBuilder SetChipsetMotherboard(Chipset chipsetMotherboard)
    {
        _chipsetMotherBoard = chipsetMotherboard;
        return this;
    }

    public IMotherboardBuilder SetDdrStandartVersion(DdrStandart ddrStandartVersion)
    {
        _ddrStandartVersion = ddrStandartVersion;
        return this;
    }

    public IMotherboardBuilder SetSataPorts(SataPorts sataPorts)
    {
        _sataPorts = sataPorts;
        return this;
    }

    public IMotherboardBuilder SetWifiMotherboard(WifiBase wifiMotherboard)
    {
        _wifi = wifiMotherboard;
        return this;
    }

    public Motherboard Build()
    {
        return new Motherboard(
            _motherboardName ?? throw new ArgumentNullException(nameof(_motherboardName)),
            _motherboardFormFactor ?? throw new ArgumentNullException(nameof(_motherboardFormFactor)),
            _pciExpressLines ?? throw new ArgumentNullException(nameof(_pciExpressLines)),
            _cpuSocketName ?? throw new ArgumentNullException(nameof(_cpuSocketName)),
            _ramSlots,
            _biosVersion ?? throw new ArgumentNullException(nameof(_biosVersion)),
            _chipsetMotherBoard ?? throw new ArgumentNullException(nameof(_chipsetMotherBoard)),
            _ddrStandartVersion ?? throw new ArgumentNullException(nameof(_ddrStandartVersion)),
            _sataPorts ?? throw new ArgumentNullException(nameof(_sataPorts)),
            _wifi);
    }
}
