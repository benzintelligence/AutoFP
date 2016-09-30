using AutoFP.Infra.CrossCutting.Security.Entities;

namespace AutoFP.Infra.CrossCutting.Security.Interfaces.Factories
{
    public interface IUserFactory
    {
        Usuario CreateInstance();
        
        Usuario CreateInstance(int id, string email, string senha, bool verificado);
    }
}