using AutoFP.Loja.Crud.Domain.Scopes.Veiculo;

namespace AutoFP.Loja.Crud.Domain.Entities.Veiculo
{
    public class Modelo
    {
        public int AnoModeloId { get; internal set; }

        public int Ano { get; internal set; }

        public int CarroId { get; internal set; }

        public void ValidarCarroId(int carroId)
        {
            CarroId = carroId;
            this.ModelosAnoPorCarro();
        }
    }
}