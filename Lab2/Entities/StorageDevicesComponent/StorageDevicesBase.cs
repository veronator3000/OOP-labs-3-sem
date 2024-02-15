using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.StorageDevicesComponent;

public abstract class StorageDevicesBase : ComponentBase
{
    protected StorageDevicesBase(
        string storageDevicesName,
        int powerConsumption,
        int capacity,
        string connectionType)
    : base(storageDevicesName)
    {
        connectionType = connectionType ?? throw new ArgumentNullException(nameof(connectionType));
        if (powerConsumption < 0) throw new NegativeValueException();
        if (capacity < 0) throw new NegativeValueException();
        PowerConsumption = powerConsumption;
        Capacity = capacity;
        ConnectionType = connectionType;
    }

    public int PowerConsumption { get; }
    public int Capacity { get; }
    public string ConnectionType { get; }
}