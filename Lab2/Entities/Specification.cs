using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class Specification
{
    public Specification(
        string motherboardName,
        string cpuName,
        IReadOnlyCollection<string> ramName,
        string caseName,
        string powerUnitName,
        string coolingSystemName,
        IReadOnlyCollection<string> storageDevicesName,
        string graphicsCardName,
        string wifiName,
        string computerName)
    {
        MotherboardName = motherboardName;
        CpuName = cpuName;
        RamName = ramName;
        CaseName = caseName;
        PowerUnitName = powerUnitName;
        CoolingSystemName = coolingSystemName;
        StorageDevicesName = storageDevicesName;
        GraphicsCardName = graphicsCardName;
        WifiName = wifiName;
        ComputerName = computerName;
    }

    public string MotherboardName { get; set; }
    public string CpuName { get; set; }
    public IReadOnlyCollection<string> RamName { get; set; }
    public string CaseName { get; set; }
    public string PowerUnitName { get; set; }
    public string CoolingSystemName { get; set; }
    public IReadOnlyCollection<string> StorageDevicesName { get; set; }
    public string GraphicsCardName { get; set; }
    public string WifiName { get; set; }
    public string? ComputerName { get; set; }
}