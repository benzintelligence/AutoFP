using System;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using AutoFP.Infra.CrossCutting.Email.Configuration;
using AutoFP.SharedKernel.ValueObjects.Validation;

namespace AutoFP.Infra.CrossCutting.Email
{
    public static class Email
    {
        public static bool Enviar(EmailParameter emailParameter)
        {
            return EnviarEmail(emailParameter);
        }

        public static void EnviarAsync(EmailParameter emailParameter)
        {
            new Task(() =>
            {
                EnviarEmail(emailParameter);
            }).Start();
        }

        private static bool EnviarEmail(EmailParameter param)
        {
            var client = new SmtpClient();

            if (!string.IsNullOrEmpty(param.Usuario))
            {
                var credentials = new NetworkCredential(param.Usuario, param.Senha);
                client.Credentials = credentials;
                client.UseDefaultCredentials = true;
                client.EnableSsl = false; // TODO: Editar para TRUE quando subir para o server
            }

            var remetente = new MailAddress(param.Remetente);

            if (!param.Destinatario.Contains(';'))
                param.Destinatario += ";";

            try
            {
                foreach (var email in param.Destinatario.Split(';'))
                {
                    if (string.IsNullOrEmpty(email) || !EmailAssertionConcern.AssertIsValid(email))
                        continue;

                    var destinatario = new MailAddress(email, email, Encoding.UTF8);
                    var mensagem = new MailMessage(remetente, destinatario);

                    if (!string.IsNullOrWhiteSpace(param.Cc))
                    {
                        if (!param.Cc.Contains(';'))
                            param.Cc += ";";

                        foreach (var item in param.Cc.Split(';'))
                        {
                            if (!string.IsNullOrEmpty(item))
                                mensagem.CC.Add(new MailAddress(item));
                        }
                    }

                    mensagem.Priority = param.Prioridade ? MailPriority.High : MailPriority.Normal;
                    mensagem.IsBodyHtml = param.FormatoHTML;
                    mensagem.Body = param.Corpo;
                    mensagem.Subject = param.Assunto;
                    mensagem.SubjectEncoding = Encoding.UTF8;
                    mensagem.HeadersEncoding = Encoding.UTF8;
                    mensagem.BodyEncoding = Encoding.UTF8;

                    if (param.ListaAnexos != null)
                        param.ListaAnexos.ForEach(a => { mensagem.Attachments.Add(a); } );

                    if (param.View != null)
                    {
                        mensagem.AlternateViews.Add(param.View);

                        foreach (var linkedResource in param.ListaLinkedResource)
                            mensagem.AlternateViews[0].LinkedResources.Add(linkedResource);
                    }

                    client.Send(mensagem);
                }

                return true;
            }
            catch (Exception)
            {
                // TODO: Inserir log aqui!!!
                return false;
            }
        }
    }
}