using Itmo.ObjectOrientedProgramming.Lab2.Entities.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.GeneralAttributes;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.WifiComponent;

public class WifiAdapter : WifiBase
{
    public WifiAdapter(
        string wifiStandartVersion,
        bool bluetoothModule,
        PciExpress wifiPciExpress,
        int powerConsumption)
    : base(wifiStandartVersion, bluetoothModule)
    {
        if (powerConsumption < 0) throw new NegativeValueException();
        WifiPciExpress = wifiPciExpress;
        PowerConsumption = powerConsumption;
    }

    public PciExpress WifiPciExpress { get; }
    public int PowerConsumption { get; }
}