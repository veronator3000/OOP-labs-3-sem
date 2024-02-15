using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.GeneralAttributes;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.WifiComponent;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.ValidateComputer.ComponentСompatibility;

public class PciExpressAllValidator : IComputerValidator
{
    private const string Message = "incompatible components. normal connection is impossible pciE\n";

    public ValidateResult Validate(Computer computer)
    {
        computer = computer ?? throw new ArgumentNullException(nameof(computer));
        IList<int> listForComponent = new List<int>();
        if (computer.GpuComponent is not null)
        {
            listForComponent.Add(computer.GpuComponent.GraphicsCardPciExpress.PciExpressPins);
        }

        if (computer.WifiComponent is WifiAdapter wifiAdapter)
        {
            listForComponent.Add(wifiAdapter.WifiPciExpress.PciExpressPins);
        }

        IList<int> listForMotherboard = new List<int>();
        foreach (PciExpress pciExpress in computer.MotherboardComponent.PciExpressLines)
        {
            listForMotherboard.Add(pciExpress.PciExpressPins);
        }

        listForComponent = listForComponent.OrderByDescending(n => n).ToList();
        listForMotherboard = listForMotherboard.OrderByDescending(n => n).ToList();
        if (listForComponent.Count > listForMotherboard.Count)
        {
            return new ValidateResult.IncompatibleСomponentsResult(Message);
        }

        if (listForComponent.Where((t, i) => t > listForMotherboard[i]).Any())
        {
            return new ValidateResult.IncompatibleСomponentsResult(Message);
        }

        return new ValidateResult.SuccsesfulBuildResult(computer);
    }
}