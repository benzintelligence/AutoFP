using AutoFP.Infra.CrossCutting.Security.Entities;
using AutoFP.SharedKernel.ValueObjects.Resource.SharedContext;
using AutoFP.SharedKernel.ValueObjects.Validation;

namespace AutoFP.Infra.CrossCutting.Security.Scopes
{
    public static class UsuarioScopes
    {
        public static bool EmailScopeIsValid(this Usuario user, string email, string confirmEmail)
        {
            return AssertionConcern.IsSatisfiedBy (
                    EmailAssertionConcern.AssertIsValid(email, SecurityMessages.EmailInvalid),
                    EmailAssertionConcern.AssertIsValid(confirmEmail, SecurityMessages.EmailConfirmInvalid),
                    AssertionConcern.AssertArgumentEquals(email, confirmEmail, SecurityMessages.EmailNotEquals)
                );
        }

        public static bool PasswordScopeIsValid(this Usuario user, string password, string confirmPassword, int minLength, int maxLength)
        {
            return AssertionConcern.IsSatisfiedBy (
                    AssertionConcern.AssertArgumentLength(password, minLength, maxLength, SecurityMessages.PasswordLength),
                    AssertionConcern.AssertArgumentLength(confirmPassword, minLength, maxLength, SecurityMessages.ConfirmPasswordLength),
                    AssertionConcern.AssertArgumentEquals(password, confirmPassword, SecurityMessages.PasswordsNotEquals)
                );
        }

        public static bool LoginPasswordScopesIsValid(this Usuario usuario, string password)
        {
            return AssertionConcern.IsSatisfiedBy (
                    AssertionConcern.AssertArgumentEquals(usuario.Password, PasswordAssertionConcern.Encrypt(password), SecurityMessages.InvalidCredentials)
                );
        }

        public static bool RegisterUserFound(this Usuario usuario)
        {
            return AssertionConcern.IsSatisfiedBy (
                    AssertionConcern.AssertArgumentNull(usuario, SecurityMessages.DuplicateEmail)
                );
        }
    }
}