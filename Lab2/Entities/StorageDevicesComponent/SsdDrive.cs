using Itmo.ObjectOrientedProgramming.Lab2.Entities.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.StorageDevicesComponent;

public class SsdDrive : StorageDevicesBase
{
    public SsdDrive(
        string ssdDriveName,
        int powerConsumptionSsd,
        int capacitySsd,
        string connectionType,
        int ssdOperatingSpeed)
        : base(ssdDriveName, powerConsumptionSsd, capacitySsd,  connectionType)
    {
        if (powerConsumptionSsd < 0) throw new NegativeValueException();
        if (capacitySsd < 0) throw new NegativeValueException();
        if (ssdOperatingSpeed < 0) throw new NegativeValueException();
        SsdOperatingSpeed = ssdOperatingSpeed;
    }

    public int SsdOperatingSpeed { get; }
}