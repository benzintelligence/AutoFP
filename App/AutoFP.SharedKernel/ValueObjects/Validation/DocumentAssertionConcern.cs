using System.Text.RegularExpressions;
using AutoFP.SharedKernel.Notification.Event;

namespace AutoFP.SharedKernel.ValueObjects.Validation
{
    public static class DocumentAssertionConcern
    {
        public static DomainNotification AssertArgumentCpf(string cpf, string message)
        {
            return IsCpf(cpf)
                ? null
                : new DomainNotification("AssertCpfIsInvalid", message);
        }

        public static DomainNotification AssertArgumentCnpj(string cnpj, string message)
        {
            return IsCnpj(cnpj)
                ? null
                : new DomainNotification("AssertCnpjIsInvalid", message);
        }

        public static DomainNotification AssertArgumentCep(string cep, string message)
        {
            return ValidateCep(cep)
                ? null
                : new DomainNotification("AssertCepIsInvalid", message);
        }

        private static bool IsCnpj(string cnpj)
        {
            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            int soma, resto;
            string digito, tempCnpj;

            cnpj = cnpj.Trim();
            cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");

            if (cnpj.Length != 14)
                return false;

            tempCnpj = cnpj.Substring(0, 12);
            soma = 0;

            for (int i = 0; i < 12; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];

            resto = (soma % 11);

            if (resto < 2) resto = 0;
            else resto = 11 - resto;

            digito = resto.ToString();
            tempCnpj = tempCnpj + digito;
            soma = 0;

            for (int i = 0; i < 13; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];

            resto = (soma % 11);

            if (resto < 2) resto = 0;
            else resto = 11 - resto;

            digito = digito + resto;
            return cnpj.EndsWith(digito);
        }

        private static bool IsCpf(string cpf)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            string tempCpf, digito;
            int soma, resto;

            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");

            if (cpf.Length != 11)
                return false;

            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

            resto = soma % 11;

            if (resto < 2) resto = 0;
            else resto = 11 - resto;

            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;

            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

            resto = soma % 11;

            if (resto < 2) resto = 0;
            else resto = 11 - resto;

            digito = digito + resto;
            return cpf.EndsWith(digito);
        }

        private static bool ValidateCep(string cep)
        {
            return Regex.IsMatch(cep, "[0-9]{5}[0-9]{3}");
        }
    }
}