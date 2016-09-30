namespace AutoFP.SharedKernel.CQS.Command.Usuario
{
    public class AtualizarSenhaCommand
    {
        public string Email { get; set; }

        public string OldPassword { get; set; }

        public string NewPassword { get; set; }

        public string ConfirmNewPassword { get; set; }
    }
}