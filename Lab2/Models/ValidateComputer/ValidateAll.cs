using System.Collections.Generic;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Models.ValidateComputer.ComponentСompatibility;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.ValidateComputer;

public class ValidateAll
{
    private IReadOnlyCollection<IComputerValidator> _validators = new List<IComputerValidator>
    {
        new RequiredComponentsValidator(),
        new CaseAndCraphicsCardValidator(),
        new CaseAndMotherboardValidator(),
        new CpuAndCoolerGenerateHeatValidator(),
        new CpuAndCoolerSocketValidator(),
        new CpuAndMotherboardBiosValidator(),
        new CpuAndMotherboardSocketValidator(),
        new PciExpressAllValidator(),
        new PowerUnitAndAllValidator(),
        new RamAndMotherboardDdrStandartValidator(),
        new RamAndMotherboardFormFactorValidator(),
        new RamAndMotherboardFrequencyValidator(),
        new RamAndMotherboardSlotsValidator(),
        new StorageDevicesAndMotherboardValidator(),
    };

    public Collection<ValidateResult> Validate(Computer? computer)
    {
        var validationErrors = new Collection<ValidateResult>();
        var validationWithoutGuarantee = new Collection<ValidateResult>();
        var validationSuccses = new Collection<ValidateResult>();

        if (computer is null)
        {
            var result = new ValidateResult.IncompatibleСomponentsResult("incompatable components");

            validationErrors.Add(result);
            return validationErrors;
        }

        foreach (IComputerValidator validator in _validators)
        {
            ValidateResult validationResult = validator.Validate(computer);
            if (validationResult is ValidateResult.IncompatibleСomponentsResult)
            {
                validationErrors.Add(validationResult);
            }

            if (validationResult is ValidateResult.WarningWithoutGuaranteeResult)
            {
                validationWithoutGuarantee.Add(validationResult);
            }
        }

        if (validationErrors.Count == 0 && validationWithoutGuarantee.Count == 0)
        {
            ValidateResult sucValidate = new ValidateResult.SuccsesfulBuildResult(computer);
            validationSuccses.Add(sucValidate);
            return validationSuccses;
        }

        if (validationErrors.Count == 0 && validationWithoutGuarantee.Count != 0)
        {
            return validationWithoutGuarantee;
        }

        return validationErrors;
    }
}