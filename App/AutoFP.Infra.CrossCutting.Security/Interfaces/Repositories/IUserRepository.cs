using System;
using AutoFP.Infra.CrossCutting.Security.Entities;

namespace AutoFP.Infra.CrossCutting.Security.Interfaces.Repositories
{
    public interface IUserRepository : IDisposable
    {
        Usuario ObterPorEmail(string email);

        void Registrar(Usuario usuario);

        void Atualizar(Usuario usuario);
    }
}