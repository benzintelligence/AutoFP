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
    public class ModeloRepository : IModeloRepository
    {
        private readonly IAppDatabase _banco;
        private List<DbParameter> _parameters;

        public ModeloRepository(IAppDatabase banco)
        {
            _banco = banco;
        }

        public IEnumerable<ModeloQuery> ModeloAnoPorCarro(int carroId)
        {
            _parameters = new List<DbParameter>();
            _parameters.AddParameter("@CarroId", carroId);

            var reader = _banco.GetDataReader(Procedure.ListarCarrosModelos, _parameters);
            return ModeloMapping.ListarModelos(reader);
        }

        public void Dispose()
        {
            _banco.Dispose();
        }
    }
}