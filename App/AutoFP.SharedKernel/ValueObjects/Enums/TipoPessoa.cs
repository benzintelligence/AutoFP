using System.ComponentModel;

namespace AutoFP.SharedKernel.ValueObjects.Enums
{
    public enum TipoPessoa
    {
        [Description("Pessoa Física")]
        PersonPhysical = 1,

        [Description("Pessoa Jurídica")]
        PersonJuridical = 2
    }
}