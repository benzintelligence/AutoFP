using AutoFP.Loja.Crud.Domain.Scopes.Veiculo;

namespace AutoFP.Loja.Crud.Domain.Entities.Veiculo
{
    public class Carro
    {
        public int CarroId { get; internal set; }

        public string Nome { get; internal set; }

        public int MontadoraId { get; internal set; }

        public void ValidarMontadoraId(int montadoraId)
        {
            MontadoraId = montadoraId;
            this.CarrosPorMontadora();
        }
    }
}