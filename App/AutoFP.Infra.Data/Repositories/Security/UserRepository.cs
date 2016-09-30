using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using AutoFP.Infra.CrossCutting.Security.Entities;
using AutoFP.Infra.CrossCutting.Security.Interfaces.Repositories;
using AutoFP.Infra.CrossCutting.Security.ValueObjects.StoredProcedure;
using AutoFP.Infra.Data.Extensions;
using AutoFP.Infra.Data.Interface;

namespace AutoFP.Infra.Data.Repositories.Security
{
    public class UserRepository : IUserRepository
    {
        private readonly IAppDatabase _banco;
        private List<DbParameter> _parameters;
    
        public UserRepository(IAppDatabase banco)
        {
            _banco = banco;
        }
    
        // TODO: Implementar métodos abaixo
        public Usuario ObterPorEmail(string email)
        {
            _parameters = new List<DbParameter>();
            _parameters.AddParameter("@Email", email);

            var reader = _banco.GetDataReader(SecurityProcedure.GetUserByEmail, _parameters);
            return reader.DataReaderMapToList<Usuario>().FirstOrDefault();
        }

        public void Registrar(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public void Atualizar(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _banco.Dispose();
        }
    }
}