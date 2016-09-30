using System.Collections.Generic;
using AutoFP.SharedKernel.CQS.Query.Veiculo;

namespace AutoFP.Loja.Crud.Application.Interface.Veiculo
{
    public interface ICarroApplicationService
    {
        IEnumerable<CarroQuery> CarrosPorMontadora(int montadoraId);
    }
}