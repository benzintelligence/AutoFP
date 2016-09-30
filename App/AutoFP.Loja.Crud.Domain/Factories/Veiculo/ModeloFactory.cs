using AutoFP.Loja.Crud.Domain.Entities.Veiculo;
using AutoFP.Loja.Crud.Domain.Interface.Factories.Veiculo;

namespace AutoFP.Loja.Crud.Domain.Factories.Veiculo
{
    public class ModeloFactory: IModeloFactory
    {
        public Modelo CreateInstance()
        {
            return new Modelo();
        }
    }
}