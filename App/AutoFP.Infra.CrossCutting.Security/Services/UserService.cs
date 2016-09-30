using AutoFP.Infra.CrossCutting.Security.Entities;
using AutoFP.Infra.CrossCutting.Security.Interfaces.Factories;
using AutoFP.Infra.CrossCutting.Security.Interfaces.Repositories;
using AutoFP.Infra.CrossCutting.Security.Interfaces.Services;
using AutoFP.Infra.CrossCutting.Security.Scopes;
using AutoFP.SharedKernel.CQS.Command.Usuario;
using AutoFP.SharedKernel.DomainEvents;
using AutoFP.SharedKernel.DomainEvents.Handles;
using AutoFP.SharedKernel.Notification.Event;
using AutoFP.SharedKernel.ValueObjects.Resource.SharedContext;
using AutoFP.SharedKernel.ValueObjects.Validation;

namespace AutoFP.Infra.CrossCutting.Security.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserFactory _userFactory;
        private readonly IHandler<DomainNotification> _notifications;

        public UserService(IUserRepository userRepository, IUserFactory userFactory)
        {
            _userRepository = userRepository;
            _userFactory = userFactory;

            _notifications = DomainEvent.Container.GetService<IHandler<DomainNotification>>();
        }

        public Usuario ObterPorEmail(string email)
        {
            EmailAssertionConcern.AssertIsValid(email, SecurityMessages.EmailInvalid);

            if (_notifications.HasNotifications())
                return null;

            return _userRepository.ObterPorEmail(email);
        }

        public Usuario Autenticar(string email, string senha)
        {
            var user = ObterPorEmail(email);

            if (_notifications.HasNotifications())
                return null;

            return user.LoginPasswordScopesIsValid(senha) ? user : null;
        }

        public void Registrar(RegistrarUsuarioCommand cmd)
        {
            var usuarioExiste = ObterPorEmail(cmd.Email);

            if (_notifications.HasNotifications())
                return;

            if (usuarioExiste != null)
            {
                usuarioExiste.RegisterUserFound();
                return;
            }

            var usuario = _userFactory.CreateInstance();
            usuario.RegistrarUsuario(cmd.Email, cmd.EmailConfirm, cmd.Password, cmd.PasswordConfirm);

            if (!_notifications.HasNotifications())
            {
                _userRepository.Registrar(usuario);
                // TODO: Enviar email (async) de confirmação de registro.
            }
        }

        public void AtualizarSenha(AtualizarSenhaCommand cmd)
        {
            var usuario = Autenticar(cmd.Email, cmd.OldPassword);

            if (_notifications.HasNotifications())
                return;

            usuario.SetPassword(cmd.NewPassword, cmd.ConfirmNewPassword);

            if (_notifications.HasNotifications())
                return;

            _userRepository.Atualizar(usuario);
            // TODO: Enviar email (async) confirmando nova senha trocada
        }

        public string ResetarSenha(string email)
        {
            var user = ObterPorEmail(email);

            if (_notifications.HasNotifications())
                return null;

            var novaSenha = user.ResetPassword();
            _userRepository.Atualizar(user);
            // TODO: Enviar email (async) com a nova senha
            return novaSenha;
        }

        public void Dispose()
        {
            _userRepository.Dispose();
        }
    }
}