using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.GeneralAttributes;
using Itmo.ObjectOrientedProgramming.Lab2.Services.GraphicsCardBuilders;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.GraphicsCardComponent;

public class GraphicsCard : ComponentBase
{
    public GraphicsCard(
        string graphicsCardName,
        int graphicsCardMemory,
        PciExpress graphicsCardPciExpress,
        int graphicsCardChipFrequency,
        int graphicsCardPowerConsumption,
        int lenghtGraphicsCard,
        int widthGraphicsCard)
    : base(graphicsCardName)
    {
        if (graphicsCardMemory < 0) throw new NegativeValueException();
        if (graphicsCardChipFrequency < 0) throw new NegativeValueException();
        if (graphicsCardPowerConsumption < 0) throw new NegativeValueException();
        if (lenghtGraphicsCard < 0) throw new NegativeValueException();
        if (widthGraphicsCard < 0) throw new NegativeValueException();
        GraphicsCardMemory = graphicsCardMemory;
        GraphicsCardPciExpress = graphicsCardPciExpress;
        GraphicsCardChipFrequency = graphicsCardChipFrequency;
        GraphicsCardPowerConsumption = graphicsCardPowerConsumption;
        LenghtGraphicsCard = lenghtGraphicsCard;
        WidthGraphicsCard = widthGraphicsCard;
    }

    public int GraphicsCardMemory { get; }
    public PciExpress GraphicsCardPciExpress { get; }
    public int GraphicsCardChipFrequency { get; }
    public int GraphicsCardPowerConsumption { get; }
    public int LenghtGraphicsCard { get; }
    public int WidthGraphicsCard { get; }

    public IGraphicsCardBuilder Debuild(IGraphicsCardBuilder builder)
    {
        builder = builder ?? throw new ArgumentNullException(nameof(builder));
        builder
            .SetGraphicsCardName(Name)
            .SetGraphicsCardMemory(GraphicsCardMemory)
            .SetCraphicsCardPciExpress(GraphicsCardPciExpress)
            .SetGraphicsCardChipFrequency(GraphicsCardChipFrequency)
            .SetGraphicsCardPowerConsumption(GraphicsCardPowerConsumption)
            .SetLenghtGraphicsCard(LenghtGraphicsCard)
            .SetWidthGraphicsCard(WidthGraphicsCard);
        return builder;
    }
}