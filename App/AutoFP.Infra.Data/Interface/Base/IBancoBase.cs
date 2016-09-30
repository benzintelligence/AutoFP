using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace AutoFP.Infra.Data.Interface.Base
{
    public interface IBancoBase : IDisposable
    {
        void Open();

        bool IsOpen();

        int ExecuteCommand(string query, List<DbParameter> parameters, CommandType commandType = CommandType.StoredProcedure);

        IDataReader GetDataReader(string query, List<DbParameter> parameters, CommandType commandType = CommandType.StoredProcedure);

        void BeginTransaction();

        void Commit();

        void RollBack();
    }
}