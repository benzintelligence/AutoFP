using System.Collections.Generic;
using System.Net.Mail;

namespace AutoFP.Infra.CrossCutting.Email.Configuration
{
    public class EmailParameter
    {
        public string Corpo { get; set; }

        public string Destinatario { get; set; }

        public string Assunto { get; set; }

        public string Remetente { get; set; }

        public bool Prioridade { get; set; }

        public bool FormatoHTML { get; set; }

        public string Cc { get; set; }

        public string Smtp { get; set; }

        public int? Porta { get; set; }

        public string Usuario { get; set; }

        public string Senha { get; set; }

        public List<Attachment> ListaAnexos { get; set; }

        public List<LinkedResource> ListaLinkedResource { get; set; }

        public AlternateView View { get; set; }
    }
}