using Itmo.ObjectOrientedProgramming.Lab2.Entities.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.StorageDevicesComponent;

public class HddDrive : StorageDevicesBase
{
    private const string SataConnectionType = "SATA";
    public HddDrive(
        string hddDriveName,
        int hddCapacityHdd,
        int powerConsumptionHdd,
        int spindleSpeed)
    : base(hddDriveName, powerConsumptionHdd, hddCapacityHdd, SataConnectionType)
    {
        if (hddCapacityHdd < 0) throw new NegativeValueException();
        if (powerConsumptionHdd < 0) throw new NegativeValueException();
        if (spindleSpeed < 0) throw new NegativeValueException();
        SpindleSpeed = spindleSpeed;
    }

    public int SpindleSpeed { get; }
}