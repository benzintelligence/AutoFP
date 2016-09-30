using System.Collections.Generic;
using AutoFP.Infra.Data.Interface;
using AutoFP.Loja.Crud.Application.AppService.Base;
using AutoFP.Loja.Crud.Application.Interface.Veiculo;
using AutoFP.Loja.Crud.Domain.Interface.Factories.Veiculo;
using AutoFP.Loja.Crud.Domain.Interface.Services.Veiculo;
using AutoFP.SharedKernel.CQS.Query.Veiculo;

namespace AutoFP.Loja.Crud.Application.AppService.Veiculo
{
    public class CarroApplicationService : BaseApplicationService, ICarroApplicationService
    {
        private readonly ICarroService _carroService;
        private readonly ICarroFactory _carroFactory;
    
        public CarroApplicationService(IAppDatabase banco, ICarroService carroService, ICarroFactory carroFactory)
            : base(banco)
        {
            _carroService = carroService;
            _carroFactory = carroFactory;
        }

        public IEnumerable<CarroQuery> CarrosPorMontadora(int montadoraId)
        {
            var carro = _carroFactory.CreateInstance();
            carro.ValidarMontadoraId(montadoraId);

            return HasNotification() ? null : _carroService.CarrosPorMontadora(montadoraId);
        }
    
        public void Dispose()
        {
            _carroService.Dispose();
        }
    }
}