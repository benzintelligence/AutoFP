using AutoFP.Infra.CrossCutting.Security.Entities;
using AutoFP.Infra.CrossCutting.Security.Interfaces.Factories;

namespace AutoFP.Infra.CrossCutting.Security.Factories
{
    public class UserFactory : IUserFactory
    {
        public Usuario CreateInstance()
        {
            return new Usuario();
        }

        public Usuario CreateInstance(int id, string email, string senha, bool verificado)
        {
            return new Usuario { UserId = id, Email = email, Password = senha, Verified = verificado };
        }
    }
}