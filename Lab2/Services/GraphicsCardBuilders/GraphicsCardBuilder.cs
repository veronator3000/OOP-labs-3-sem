using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.GeneralAttributes;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.GraphicsCardComponent;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.GraphicsCardBuilders;

public class GraphicsCardBuilder : IGraphicsCardBuilder
{
    private string? _graphicsCoreName;
    private int _graphicsCoreMemory;
    private PciExpress? _pciExpress;
    private int _graphicsCardChipFrequency;
    private int _graphicsCardPowerConsumption;
    private int _lenghtGraphicsCore;
    private int _widthGraphicsCore;
    public IGraphicsCardBuilder SetGraphicsCardName(string graphicsCardName)
    {
        _graphicsCoreName = graphicsCardName;
        return this;
    }

    public IGraphicsCardBuilder SetGraphicsCardMemory(int graphicsCoreMemory)
    {
        _graphicsCoreMemory = graphicsCoreMemory;
        return this;
    }

    public IGraphicsCardBuilder SetCraphicsCardPciExpress(PciExpress pciExpress)
    {
        _pciExpress = pciExpress;
        return this;
    }

    public IGraphicsCardBuilder SetGraphicsCardChipFrequency(int graphicsCardChipFrequency)
    {
        _graphicsCardChipFrequency = graphicsCardChipFrequency;
        return this;
    }

    public IGraphicsCardBuilder SetGraphicsCardPowerConsumption(int graphicsCardPowerConsumption)
    {
        _graphicsCardPowerConsumption = graphicsCardPowerConsumption;
        return this;
    }

    public IGraphicsCardBuilder SetLenghtGraphicsCard(int lenghtGraphicsCore)
    {
        _lenghtGraphicsCore = lenghtGraphicsCore;
        return this;
    }

    public IGraphicsCardBuilder SetWidthGraphicsCard(int widthGraphicsCore)
    {
        _widthGraphicsCore = widthGraphicsCore;
        return this;
    }

    public GraphicsCard Build()
    {
        return new GraphicsCard(
            _graphicsCoreName ?? throw new ArgumentNullException(nameof(_graphicsCoreName)),
            _graphicsCoreMemory,
            _pciExpress ?? throw new ArgumentNullException(nameof(_pciExpress)),
            _graphicsCardChipFrequency,
            _graphicsCardPowerConsumption,
            _lenghtGraphicsCore,
            _widthGraphicsCore);
    }
}