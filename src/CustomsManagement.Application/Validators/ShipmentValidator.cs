using CustomsManagement.Application.Constants;
using CustomsManagement.Application.DTOs;
using FluentValidation;

namespace CustomsManagement.Application.Validators;

using FluentValidation;

public class ShipmentValidator : AbstractValidator<ShipmentDto>
{
    public ShipmentValidator()
    {
        RuleFor(s => s.ImporterExporterName)
            .NotEmpty()
            .WithMessage(ValidationMessages.ImporterExporterNameRequired);

        RuleFor(s => s.ProductType)
            .NotEmpty()
            .WithMessage(ValidationMessages.ProductTypeRequired);

        RuleFor(s => s.DeclaredValue)
            .GreaterThan(0)
            .WithMessage(ValidationMessages.DeclaredValueRequired);

        RuleFor(s => s.Tax)
            .GreaterThanOrEqualTo(0)
            .WithMessage(ValidationMessages.TaxRequired);

        RuleFor(s => s.Status)
            .NotEmpty()
            .WithMessage(ValidationMessages.StatusRequired);
    }
}
