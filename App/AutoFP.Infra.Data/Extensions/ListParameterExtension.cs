using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace AutoFP.Infra.Data.Extensions
{
    public static class ListParameterExtension
    {
        public static SqlParameter AddParameter(this List<DbParameter> list, string name, object value, ParameterDirection direction = ParameterDirection.Input)
        {
            var parameter = new SqlParameter
            {
                ParameterName = name,
                Direction = direction,
                Value = value
            };
            list.Add(parameter);
            return parameter;
        }
    }
}