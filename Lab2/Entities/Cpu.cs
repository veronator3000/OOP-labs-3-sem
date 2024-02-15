using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.GeneralAttributes;
using Itmo.ObjectOrientedProgramming.Lab2.Services.CpuBuilders;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class Cpu : ComponentBase
{
    public Cpu(
        string cpuName,
        double coreFrequency,
        int cpuCores,
        Socket cpuSocketName,
        int generateHeat,
        int powerConsumption,
        bool graphicsCore)
    : base(cpuName)
    {
        if (coreFrequency < 0) throw new NegativeValueException();
        if (cpuCores < 0) throw new NegativeValueException();
        if (generateHeat < 0) throw new NegativeValueException();
        if (powerConsumption < 0) throw new NegativeValueException();
        CoreFrequency = coreFrequency;
        CpuCores = cpuCores;
        CpuSocketName = cpuSocketName;
        GenerateHeat = generateHeat;
        PowerConsumption = powerConsumption;
        GraphicsCore = graphicsCore;
    }

    public double CoreFrequency { get; }
    public int CpuCores { get; }
    public Socket CpuSocketName { get; }
    public bool GraphicsCore { get; }
    public int GenerateHeat { get; }
    public int PowerConsumption { get; }
    public ICpuBuilder Debuild(ICpuBuilder builder)
    {
        builder = builder ?? throw new ArgumentNullException(nameof(builder));
        builder
            .SetCpuName(Name)
            .SetCoreFrequency(CoreFrequency)
            .SetCpuSocketName(CpuSocketName)
            .SetGraphicsCore(GraphicsCore)
            .SetGenerateHeat(GenerateHeat)
            .SetPowerConsumption(PowerConsumption);
        return builder;
    }
}