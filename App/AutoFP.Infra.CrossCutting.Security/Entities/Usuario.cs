using System;
using AutoFP.Infra.CrossCutting.Security.Scopes;
using AutoFP.SharedKernel.ValueObjects.Validation;

namespace AutoFP.Infra.CrossCutting.Security.Entities
{
    public class Usuario
    {
        internal Usuario() { }

        public int UserId { get; internal set; }

        public string Email { get; internal set; }

        public string Password { get; internal set; }

        public bool Verified { get; internal set; }

        #region Métodos
        public void RegistrarUsuario(string email, string emailConfirm, string password, string passwordConfirm)
        {
            if (this.EmailScopeIsValid(email, emailConfirm))
                Email = email;

            SetPassword(password, passwordConfirm);
            Verified = false;
        }

        public void SetPassword(string password, string confirmPassword)
        {
            if (this.PasswordScopeIsValid(Password, confirmPassword, 8, 20))
                Password = PasswordAssertionConcern.Encrypt(password);
        }

        public string GenerateAuthorizationCode()
        {
            return Guid.NewGuid().ToString().Substring(0, 4).ToUpper();
        }

        public string ResetPassword()
        {
            var newPassword = Guid.NewGuid().ToString().Substring(0, 8);
            Password = PasswordAssertionConcern.Encrypt(newPassword);
            return newPassword;
        }
        #endregion
    }
}