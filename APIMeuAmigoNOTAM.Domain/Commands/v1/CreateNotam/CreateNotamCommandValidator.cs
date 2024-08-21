using FluentValidation;
using APIMeuAmigoNOTAM.Domain.Commands.v1;
using System;

namespace APIMeuAmigoNOTAM.Domain.Commands.v1.CreateNotam
{
    public class CreateNotamCommandValidator : AbstractValidator<CreateNotamCommand>
    {
        public CreateNotamCommandValidator()
        {
            RuleFor(command => command.Type)
                .NotEmpty().WithMessage("O campo 'Type' é obrigatório.")
                .Must(type => !string.IsNullOrEmpty(type)).WithMessage("O campo 'Type' não pode ser vazio.");

            RuleFor(command => command.IATA)
                .NotEmpty().WithMessage("O campo 'IATA' é obrigatório.")
                .Length(3).WithMessage("O campo 'IATA' deve ter exatamente 3 caracteres.");

            RuleFor(command => command.Runway)
                .NotEmpty().WithMessage("O campo 'Runway' é obrigatório.");

            RuleFor(command => command.ExpiryDate)
                .GreaterThan(DateTime.Now).WithMessage("A data de expiração deve ser futura.");

            RuleFor(command => command.StartTime)
                .LessThan(command => command.EndTime)
                .WithMessage("A 'StartTime' deve ser antes da 'EndTime'.");

            RuleFor(command => command.EndTime)
                .GreaterThan(command => command.StartTime)
                .WithMessage("A 'EndTime' deve ser após a 'StartTime'.");

        }
    }
}
