using AutoFP.Loja.Crud.Domain.Entities.Veiculo;
using AutoFP.Loja.Crud.Domain.Interface.Factories.Veiculo;

namespace AutoFP.Loja.Crud.Domain.Factories.Veiculo
{
    public class CarroFactory: ICarroFactory
    {
        public Carro CreateInstance()
        {
            return new Carro();
        }
    }
}