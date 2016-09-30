using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using AutoFP.Infra.Data.Constants;
using AutoFP.Infra.Data.Interface;

namespace AutoFP.Infra.Data.Connection.App
{
    public class SqlServerAppConnection : IAppDatabase
    {
        private readonly string _connectionString;
        private SqlConnection _connection;
        private SqlCommand _command;
        private DbTransaction _transaction;

        public SqlServerAppConnection()
        {
            _connectionString = ConfigurationManager.ConnectionStrings[ConnectionName.AutoFP].ConnectionString;
        }

        public void Open()
        {
            try
            {
                _connection = new SqlConnection(_connectionString);
            }
            catch (Exception e)
            {
                // TODO: Inserir log aqui...
            }

            _connection.Open();
        }

        public bool IsOpen()
        {
            return _connection != null && _connection.State == ConnectionState.Open;
        }

        public int ExecuteCommand(string query, List<DbParameter> parameters, CommandType commandType = CommandType.StoredProcedure)
        {
            if (!IsOpen()) Open();

            _command = new SqlCommand(query, _connection)
            {
                CommandType = commandType,
                Transaction = _transaction as SqlTransaction
            };
            _command.Parameters.Clear();
            _command.Parameters.AddRange(parameters.ToArray());

            return _command.ExecuteNonQuery();
        }

        public IDataReader GetDataReader(string query, List<DbParameter> parameters, CommandType commandType = CommandType.StoredProcedure)
        {
            if (!IsOpen()) Open();

            _command = new SqlCommand(query, _connection)
            {
                CommandType = commandType
            };
            _command.Parameters.Clear();
            _command.Parameters.AddRange(parameters.ToArray());

            var dataReader = _command.ExecuteReader();
            return dataReader;
        }

        public void BeginTransaction()
        {
            if (!IsOpen())
                Open();

            _transaction = _connection.BeginTransaction();
        }

        public void Commit()
        {
            if (IsOpen() && _transaction != null)
                _transaction.Commit();
        }

        public void RollBack()
        {
            if (!IsOpen() && _transaction != null)
                _transaction.Rollback();
        }

        public void Dispose()
        {
            if (!IsOpen()) return;

            _connection.Close();
            _connection.Dispose();
        }
    }
}