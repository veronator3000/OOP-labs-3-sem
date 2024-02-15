namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.WifiComponent;

public class WifiBase : ComponentBase
{
    public WifiBase(
        string wifiStandartVersion,
        bool bluetoothModule)
    : base(wifiStandartVersion)
    {
        BluetoothModule = bluetoothModule;
    }

    public bool BluetoothModule { get; }
}