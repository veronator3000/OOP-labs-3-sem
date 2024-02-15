using Itmo.ObjectOrientedProgramming.Lab2.Entities.GeneralAttributes;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.GraphicsCardComponent;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.GraphicsCardBuilders;

public interface IGraphicsCardBuilder
{
    IGraphicsCardBuilder SetGraphicsCardName(string graphicsCardName);
    IGraphicsCardBuilder SetGraphicsCardMemory(int graphicsCoreMemory);
    IGraphicsCardBuilder SetCraphicsCardPciExpress(PciExpress pciExpress);
    IGraphicsCardBuilder SetGraphicsCardChipFrequency(int graphicsCardChipFrequency);
    IGraphicsCardBuilder SetGraphicsCardPowerConsumption(int graphicsCardPowerConsumption);
    IGraphicsCardBuilder SetLenghtGraphicsCard(int lenghtGraphicsCore);
    IGraphicsCardBuilder SetWidthGraphicsCard(int widthGraphicsCore);
    GraphicsCard Build();
}