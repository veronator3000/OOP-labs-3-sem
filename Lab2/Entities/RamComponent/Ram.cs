using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.GeneralAttributes;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.MotherboardComponent;
using Itmo.ObjectOrientedProgramming.Lab2.Services.RamBuilders;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.RamComponent;

public class Ram : ComponentBase
{
    public Ram(
        string ramName,
        int availableMemorySize,
        XmpProfile? ramXmpProfile,
        RamFormFactor ramFormFactorTYpe,
        DdrStandart ddrStandartVersion,
        JedecAndVoltage jedecAndVoltageRam,
        int powerConsumption)
    : base(ramName)
    {
        if (availableMemorySize < 0) throw new NegativeValueException();
        if (powerConsumption < 0) throw new NegativeValueException();
        AvailableMemorySize = availableMemorySize;
        RamXmpProfile = ramXmpProfile;
        RamFormFactorType = ramFormFactorTYpe;
        DdrStandartVersion = ddrStandartVersion;
        JedecAndVoltageRam = jedecAndVoltageRam;
        PowerConsumption = powerConsumption;
    }

    public int AvailableMemorySize { get; }
    public JedecAndVoltage JedecAndVoltageRam { get; }
    public XmpProfile? RamXmpProfile { get; }
    public RamFormFactor RamFormFactorType { get; }
    public DdrStandart DdrStandartVersion { get; }
    public int PowerConsumption { get; }

    public IRamBuilder Debuild(IRamBuilder builder)
    {
        builder = builder ?? throw new ArgumentNullException(nameof(builder));
        builder
            .SetRamName(Name)
            .SetAvailableMemorySize(AvailableMemorySize)
            .SetRamFormFactor(RamFormFactorType)
            .SetDdrStandart(DdrStandartVersion)
            .SetRamPowerConsumption(PowerConsumption);
        if (RamXmpProfile is not null)
        {
            builder.SetXmpProfile(RamXmpProfile);
        }

        return builder;
    }
}