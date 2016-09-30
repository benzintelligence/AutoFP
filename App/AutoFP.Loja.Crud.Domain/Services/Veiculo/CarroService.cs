using System.Collections.Generic;
using AutoFP.Loja.Crud.Domain.Interface.Repositories.Veiculo;
using AutoFP.Loja.Crud.Domain.Interface.Services.Veiculo;
using AutoFP.SharedKernel.CQS.Query.Veiculo;

namespace AutoFP.Loja.Crud.Domain.Services.Veiculo
{
    public class CarroService : ICarroService
    {
        private readonly ICarroRepository _carroRepository;

        public CarroService(ICarroRepository carroRepository)
        {
            _carroRepository = carroRepository;
        }

        public IEnumerable<CarroQuery> CarrosPorMontadora(int montadoraId)
        {
            return _carroRepository.CarrosPorMontadora(montadoraId);
        }

        public void Dispose()
        {
            _carroRepository.Dispose();
        }
    }
}