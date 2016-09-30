using System.Collections.Generic;
using AutoFP.Infra.Data.Interface;
using AutoFP.Loja.Crud.Application.AppService.Base;
using AutoFP.Loja.Crud.Application.Interface.Veiculo;
using AutoFP.Loja.Crud.Domain.Interface.Factories.Veiculo;
using AutoFP.Loja.Crud.Domain.Interface.Services.Veiculo;
using AutoFP.SharedKernel.CQS.Query.Veiculo;

namespace AutoFP.Loja.Crud.Application.AppService.Veiculo
{
    public class ModeloApplicationService : BaseApplicationService, IModeloApplicationService
    {
        private readonly IModeloService _modeloService;
        private readonly IModeloFactory _modeloFactory;
    
        public ModeloApplicationService(IAppDatabase banco, IModeloService modeloService, IModeloFactory modeloFactory)
            : base(banco)
        {
            _modeloService = modeloService;
            _modeloFactory = modeloFactory;
        }

        public IEnumerable<ModeloQuery> ModeloAnoPorCarro(int carroId)
        {
            var modelo = _modeloFactory.CreateInstance();
            modelo.ValidarCarroId(carroId);

            return HasNotification() ? null : _modeloService.ModeloAnoPorCarro(carroId);
        }
    
        public void Dispose()
        {
            _modeloService.Dispose();
        }
    }
}