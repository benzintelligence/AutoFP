using AutoFP.Loja.Crud.Domain.Entities.Veiculo;

namespace AutoFP.Loja.Crud.Domain.Interface.Factories.Veiculo
{
    public interface ICarroFactory
    {
        Carro CreateInstance();
    }
}