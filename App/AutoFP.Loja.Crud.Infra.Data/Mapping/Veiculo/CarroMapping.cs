using System.Collections.Generic;
using System.Data;
using AutoFP.SharedKernel.CQS.Query.Veiculo;

namespace AutoFP.Loja.Crud.Infra.Data.Mapping.Veiculo
{
    internal static class CarroMapping
    {
        internal static IEnumerable<CarroQuery> ListarCarros(IDataReader reader)
        {
            var listCarros = new List<CarroQuery>();

            while (reader.Read())
                listCarros.Add(new CarroQuery
                {
                    CarroId = reader.GetInt32(0), Carro = reader.GetString(1)
                });

            return listCarros;
        }
    }
}