using System.Collections.Generic;
using System.Data;
using AutoFP.SharedKernel.CQS.Query.Veiculo;

namespace AutoFP.Loja.Crud.Infra.Data.Mapping.Veiculo
{
    internal static class ModeloMapping
    {
        internal static IEnumerable<ModeloQuery> ListarModelos(IDataReader reader)
        {
            var listCarros = new List<ModeloQuery>();

            while (reader.Read())
                listCarros.Add(new ModeloQuery
                {
                    ModeloId = reader.GetInt32(0), Ano = reader.GetInt32(1)
                });

            return listCarros;
        }
    }
}