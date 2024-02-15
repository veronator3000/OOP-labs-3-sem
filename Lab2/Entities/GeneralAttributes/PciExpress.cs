using Itmo.ObjectOrientedProgramming.Lab2.Entities.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.GeneralAttributes;

public class PciExpress : ComponentBase
{
    public PciExpress(
        int quantityLines,
        int pciExpressPins,
        string namePciExpress)
    : base(namePciExpress)
    {
        if (quantityLines < 0) throw new NegativeValueException();
        if (pciExpressPins < 0) throw new NegativeValueException();
        QuantityLines = quantityLines;
        PciExpressPins = pciExpressPins;
    }

    public int PciExpressPins { get; }
    public int QuantityLines { get; }
}