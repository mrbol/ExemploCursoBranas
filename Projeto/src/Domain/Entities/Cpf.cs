using System.Numerics;
using System.Text.RegularExpressions;

namespace Domain.Entities
{

    public class Cpf
    {
        private string _value;
        const int DIGIT_1_FACTOR = 10;
        const int DIGIT_2_FACTOR = 11;

        public Cpf(string value)
        {
            if (!this.validate(value)) throw new Exception("Cpf Inválido");
            _value = value;
        }

        private bool validate(string cpf)
        {
            if (string.IsNullOrEmpty(cpf)) return false;
            cpf = this.removeNonDigits(cpf);
            if (!this.isValidLength(cpf)) return false;
            if (this.allDigitsTheSame(cpf)) return false;
            int digit1 = this.calculateDigit(cpf,DIGIT_1_FACTOR);
            int digit2 = this.calculateDigit(cpf,DIGIT_2_FACTOR);
            string checkDigit = this.extractCheckDigit(cpf);
            string calculatedCheckDigit = string.Concat(digit1,digit2);
            return checkDigit == calculatedCheckDigit;
        }

        private string removeNonDigits(string cpf)
        {
            return cpf.Replace(".", "").Replace("-", "");
        }

        private bool isValidLength(string cpf)
        {
            return cpf.Length == 11;
        }

        private bool allDigitsTheSame(string cpf)
        {
            return cpf.ToArray().Where(
                p => p == cpf.ToArray().FirstOrDefault())
                .Count() == cpf.Length;
        }

        private int calculateDigit(string cpf, int factor)
        {
            var total = 0;
            foreach (var digit in cpf)
            {
                if (factor > 1)
                {
                    total += Convert.ToInt32(Convert.ToString(digit)) * factor--;
                }
            }    
            var rest = total % 11;
            return (rest < 2) ? 0 : 11 - rest;
        }

        private string extractCheckDigit(string cpf)
        {
            return cpf.Substring(9);
        }

        public string GetValue()
        {
            return this._value;
        }
    }
}