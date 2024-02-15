using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.GeneralAttributes;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.MotherboardComponent;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.RamComponent;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.RamBuilders;

public class RamBuilder : IRamBuilder
{
    private int _availableMemorySize;
    private JedecAndVoltage? _jedec;
    private int _powerConsumption;
    private XmpProfile? _xmpProfile;
    private RamFormFactor? _ramFormFactor;
    private DdrStandart? _ddrStandart;
    private string? _ramName;

    public IRamBuilder SetRamName(string ramName)
    {
        _ramName = ramName;
        return this;
    }

    public IRamBuilder SetAvailableMemorySize(int availableMemorySize)
    {
        _availableMemorySize = availableMemorySize;
        return this;
    }

    public IRamBuilder SetJedec(JedecAndVoltage jedec)
    {
        _jedec = jedec;
        return this;
    }

    public IRamBuilder SetRamPowerConsumption(int ramPowerConsumption)
    {
        _powerConsumption = ramPowerConsumption;
        return this;
    }

    public IRamBuilder SetXmpProfile(XmpProfile xmpProfile)
    {
        _xmpProfile = xmpProfile;
        return this;
    }

    public IRamBuilder SetRamFormFactor(RamFormFactor ramFormFactor)
    {
        _ramFormFactor = ramFormFactor;
        return this;
    }

    public IRamBuilder SetDdrStandart(DdrStandart ddrStandart)
    {
        _ddrStandart = ddrStandart;
        return this;
    }

    public Ram Build()
    {
        return new Ram(
            _ramName ?? throw new ArgumentNullException(nameof(_ramName)),
            _availableMemorySize,
            _xmpProfile,
            _ramFormFactor ?? throw new ArgumentNullException(nameof(_ramFormFactor)),
            _ddrStandart ?? throw new ArgumentNullException(nameof(_ddrStandart)),
            _jedec ?? throw new ArgumentNullException(nameof(_jedec)),
            _powerConsumption);
    }
}