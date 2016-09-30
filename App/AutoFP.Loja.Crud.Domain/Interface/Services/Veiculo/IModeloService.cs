using System;
using System.Collections.Generic;
using AutoFP.SharedKernel.CQS.Query.Veiculo;

namespace AutoFP.Loja.Crud.Domain.Interface.Services.Veiculo
{
    public interface IModeloService : IDisposable
    {
        IEnumerable<ModeloQuery> ModeloAnoPorCarro(int carroId);
    }
}