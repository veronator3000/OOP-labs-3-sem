using Itmo.ObjectOrientedProgramming.Lab2.Entities.CaseComponent;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.CoolerComponent;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.GraphicsCardComponent;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.MotherboardComponent;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.RamComponent;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.StorageDevicesComponent;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.WifiComponent;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Storage;

public class AllRepository
{
    public AllRepository(
        IRepository<Cpu> cpuRepository,
        IRepository<CaseType> caseRepository,
        IRepository<Motherboard> motherboardRepository,
        IRepository<CoolingSystem> coolingSystemRepository,
        IRepository<GraphicsCard> graphicsCardRepository,
        IRepository<PowerUnit> powerUnitRepository,
        IRepository<Ram> ramRepository,
        IRepository<StorageDevicesBase> storageDevicesRepository,
        IRepository<WifiBase> wifiRepository,
        IRepository<Computer> computer)
    {
        CpuComponent = cpuRepository;
        CaseComponent = caseRepository;
        MotherboardComponent = motherboardRepository;
        CoolingSystemComponent = coolingSystemRepository;
        GraphicsCardRepository = graphicsCardRepository;
        PowerUnitRepository = powerUnitRepository;
        RamRepository = ramRepository;
        StorageDevicesRepository = storageDevicesRepository;
        WifiComponentRepository = wifiRepository;
        ComputerName = computer;
    }

    public IRepository<Cpu> CpuComponent { get; }
    public IRepository<CaseType> CaseComponent { get; }
    public IRepository<Motherboard> MotherboardComponent { get; }
    public IRepository<CoolingSystem> CoolingSystemComponent { get; }
    public IRepository<GraphicsCard> GraphicsCardRepository { get; }
    public IRepository<PowerUnit> PowerUnitRepository { get; }
    public IRepository<Ram> RamRepository { get; }
    public IRepository<StorageDevicesBase> StorageDevicesRepository { get; }
    public IRepository<WifiBase> WifiComponentRepository { get; }
    public IRepository<Computer> ComputerName { get; }
}