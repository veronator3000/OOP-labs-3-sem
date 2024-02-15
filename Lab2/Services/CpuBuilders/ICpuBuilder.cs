using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.GeneralAttributes;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.CpuBuilders;

public interface ICpuBuilder
{
    ICpuBuilder SetCpuName(string cpuName);
    ICpuBuilder SetCoreFrequency(double coreFrequency);
    ICpuBuilder SetCpuCores(int cpuCores);
    ICpuBuilder SetCpuSocketName(Socket cpuSocketName);
    ICpuBuilder SetGenerateHeat(int generateHeat);
    ICpuBuilder SetPowerConsumption(int powerConsumption);
    ICpuBuilder SetGraphicsCore(bool graphicsCore);
    Cpu Build();
}