using AutoFP.Loja.Crud.Domain.Entities.Veiculo;
using AutoFP.SharedKernel.ValueObjects.Resource.Loja.CRUD;
using AutoFP.SharedKernel.ValueObjects.Validation;

namespace AutoFP.Loja.Crud.Domain.Scopes.Veiculo
{
    public static class ModeloScopes
    {
        public static bool ModelosAnoPorCarro(this Modelo modelo)
        {
            return AssertionConcern.IsSatisfiedBy
                (
                    AssertionConcern.AssertArgumentGreater(modelo.CarroId, 0, Loja_CRUD_Errors.InvalidCodeCarGreaterThanZero)
                );
        }
    }
}