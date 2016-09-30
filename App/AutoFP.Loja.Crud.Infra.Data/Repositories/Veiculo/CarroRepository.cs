using System.Collections.Generic;
using System.Data.Common;
using AutoFP.Infra.Data.Extensions;
using AutoFP.Infra.Data.Interface;
using AutoFP.Loja.Crud.Domain.Interface.Repositories.Veiculo;
using AutoFP.Loja.Crud.Infra.Data.Mapping.Veiculo;
using AutoFP.Loja.Crud.Infra.Data.StoredProcedure;
using AutoFP.SharedKernel.CQS.Query.Veiculo;

namespace AutoFP.Loja.Crud.Infra.Data.Repositories.Veiculo
{
    public class CarroRepository : ICarroRepository
    {
        private readonly IAppDatabase _banco;
        private List<DbParameter> _parameters;

        public CarroRepository(IAppDatabase banco)
        {
            _banco = banco;
        }

        public IEnumerable<CarroQuery> CarrosPorMontadora(int montadoraId)
        {
            _parameters = new List<DbParameter>();
            _parameters.AddParameter("@MontadoraId", montadoraId);

            var reader = _banco.GetDataReader(Procedure.ListarCarros, _parameters);
            return CarroMapping.ListarCarros(reader);
        }

        public void Dispose()
        {
            _banco.Dispose();
        }
    }
}