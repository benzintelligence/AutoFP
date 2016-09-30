using AutoFP.Loja.Crud.Domain.Entities.Veiculo;
using AutoFP.SharedKernel.ValueObjects.Resource.Loja.CRUD;
using AutoFP.SharedKernel.ValueObjects.Validation;

namespace AutoFP.Loja.Crud.Domain.Scopes.Veiculo
{
    public static class CarroScopes
    {
        public static bool CarrosPorMontadora(this Carro carro)
        {
            return AssertionConcern.IsSatisfiedBy
                (
                    AssertionConcern.AssertArgumentGreater(carro.MontadoraId, 0, Loja_CRUD_Errors.InvalidManufacturerToCarCodeGreaterThanZero)
                );
        }
    }
}