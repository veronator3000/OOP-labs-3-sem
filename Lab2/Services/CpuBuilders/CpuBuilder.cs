using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.GeneralAttributes;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.CpuBuilders;

public class CpuBuilder : ICpuBuilder
{
    private string? _nameCpu;
    private double _coreFrequency;
    private int _cpuCores;
    private Socket? _cpuSocketName;
    private bool _graphicsCore;
    private int _generateHeat;
    private int _powerConsumption;

    public ICpuBuilder SetCpuName(string cpuName)
    {
        _nameCpu = cpuName;
        return this;
    }

    public ICpuBuilder SetCoreFrequency(double coreFrequency)
    {
        _coreFrequency = coreFrequency;
        return this;
    }

    public ICpuBuilder SetCpuCores(int cpuCores)
    {
        _cpuCores = cpuCores;
        return this;
    }

    public ICpuBuilder SetCpuSocketName(Socket cpuSocketName)
    {
        _cpuSocketName = cpuSocketName;
        return this;
    }

    public ICpuBuilder SetGenerateHeat(int generateHeat)
    {
        _generateHeat = generateHeat;
        return this;
    }

    public ICpuBuilder SetPowerConsumption(int powerConsumption)
    {
        _powerConsumption = powerConsumption;
        return this;
    }

    public ICpuBuilder SetGraphicsCore(bool graphicsCore)
    {
        _graphicsCore = graphicsCore;
        return this;
    }

    public Cpu Build()
    {
        return new Cpu(
            _nameCpu ?? throw new ArgumentNullException(nameof(_nameCpu)),
            _coreFrequency,
            _cpuCores,
            _cpuSocketName ?? throw new ArgumentNullException(nameof(_cpuSocketName)),
            _generateHeat,
            _powerConsumption,
            _graphicsCore);
    }
}