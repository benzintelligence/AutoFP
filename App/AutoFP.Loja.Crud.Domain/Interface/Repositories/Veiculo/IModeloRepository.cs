using System;
using System.Collections.Generic;
using AutoFP.SharedKernel.CQS.Query.Veiculo;

namespace AutoFP.Loja.Crud.Domain.Interface.Repositories.Veiculo
{
    public interface IModeloRepository : IDisposable
    {
        IEnumerable<ModeloQuery> ModeloAnoPorCarro(int carroId);
    }
}