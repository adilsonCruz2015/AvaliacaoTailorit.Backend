using AvaliacaoTailorit.BackEnd.Cadastro.Dominio.Entidades;
using FluentValidation;

namespace AvaliacaoTailorit.BackEnd.Cadastro.Dominio.Comandos.UsuarioCmd.Validacao
{
    public class UsuarioValidacao : AbstractValidator<InserirCmd>
    {
        public UsuarioValidacao()
        {
            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(3, 200).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(c => c.DataNascimento)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");

            RuleFor(c => c.Sexo)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .GreaterThan(0).WithMessage("O campo {PropertyName} precisa ser maior que {ComparisonValue}");  
        }
    }
}
