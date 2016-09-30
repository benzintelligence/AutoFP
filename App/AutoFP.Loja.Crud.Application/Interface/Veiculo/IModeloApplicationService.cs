using System.Collections.Generic;
using AutoFP.SharedKernel.CQS.Query.Veiculo;

namespace AutoFP.Loja.Crud.Application.Interface.Veiculo
{
    public interface IModeloApplicationService
    {
        IEnumerable<ModeloQuery> ModeloAnoPorCarro(int carroId);
    }
}