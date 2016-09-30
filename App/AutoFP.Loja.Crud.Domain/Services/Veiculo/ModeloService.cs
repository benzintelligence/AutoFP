using System.Collections.Generic;
using AutoFP.Loja.Crud.Domain.Interface.Repositories.Veiculo;
using AutoFP.Loja.Crud.Domain.Interface.Services.Veiculo;
using AutoFP.SharedKernel.CQS.Query.Veiculo;

namespace AutoFP.Loja.Crud.Domain.Services.Veiculo
{
    public class ModeloService : IModeloService
    {
        private readonly IModeloRepository _modeloRepository;

        public ModeloService(IModeloRepository modeloRepository)
        {
            _modeloRepository = modeloRepository;
        }

        public IEnumerable<ModeloQuery> ModeloAnoPorCarro(int carroId)
        {
            return _modeloRepository.ModeloAnoPorCarro(carroId);
        }

        public void Dispose()
        {
            _modeloRepository.Dispose();
        }
    }
}