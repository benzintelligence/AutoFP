namespace AutoFP.SharedKernel.CQS.Command.Usuario
{
    public class RegistrarUsuarioCommand
    {
        public string Email { get; set; }

        public string EmailConfirm { get; set; }

        public string Password { get; set; }

        public string PasswordConfirm { get; set; }
    }
}