using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.MotherboardComponent;

public class Bios : ComponentBase
{
    public Bios(
        string biosTypeName,
        IList<Cpu> cpuBiosSupport)
    : base(biosTypeName)
    {
        CpuBiosSupport = cpuBiosSupport;
    }

    public IList<Cpu> CpuBiosSupport { get; }
}