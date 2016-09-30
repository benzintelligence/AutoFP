using System;
using AutoFP.Infra.CrossCutting.Security.Entities;
using AutoFP.SharedKernel.CQS.Command.Usuario;

namespace AutoFP.Infra.CrossCutting.Security.Interfaces.Services
{
    public interface IUserService : IDisposable
    {
        Usuario ObterPorEmail(string email);
        
        Usuario Autenticar(string email, string senha);

        void Registrar(RegistrarUsuarioCommand cmd);

        void AtualizarSenha(AtualizarSenhaCommand cmd);

        string ResetarSenha(string email);
    }
}