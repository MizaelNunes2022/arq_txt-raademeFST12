using CadastroPessoaFF12.Interfaces;
using System.Text.RegularExpressions;
namespace CadastroPessoaFF12.Classes
{
    public class PessoaJuridica : Pessoa, IPessoaJuridica
    {
        public string? Cnpj { get; set; }
        public string? NomeFantasia { get; set; }
        public string? RazaoSocial { get; set; }
        public bool ValidarCnpj(string cnpj) // Método que foi herdado da "INTERFACE" 
        {
            //"02.023.134/0001-31"; 18 
            // "02023134000131"; 14
            // Veriifcar se tem 001
            if (Regex.IsMatch(cnpj, @"^\d{2}.\d{3}.\d{3}/\d{4}-\d{2}|(\d{14})$"))
            {

                if (cnpj.Length == 18)
                {// se for igual a 18 caracteres 

                    if (cnpj.Substring(11, 4) == "0001") // A PARTIR DO CARACTE 11 NA NUMERAÇÃO, PEGAR OS PRÓXIMOS 4 DIGITOS
                    {// Verificar se tem 0001
                        return true;
                    }

                }
                else if (cnpj.Length == 14)
                {// Verificar se for igual a 14 caracteres.
                    if (cnpj.Substring(8, 4) == "0001")// A PARTIR DO CARACTE 8  NA NUMERAÇÃO, PEGAR OS PRÓXIMOS 4 DIGITOS
                    {// Verificar se tem 0001
                        return true;
                    }

                }

                return true;
            }

            return false;
        }

        //Conceito de "OVERRIDE" Vem do fato de o pagamento(método) ser de maneira diferete , Ex: IRpf de 3% para PF E 10% PJ
        // Aqui podemos aplciar o conceito de polimorfismo
        public override float PagarImposto(float rendimento)
        {
            //Para rendimento até 5000(6%)Desconto
            //Para rendimentos entre entre 5001 e 10.000( 8%)Desconto
            //Acima de 10.001 (10%)Desconto
             if (rendimento <= 5000)//6% de desconto
            {
                return rendimento - (rendimento / 100) * 6;
            }
            else if (rendimento <= 10000)
            { //8% de denconto
                return rendimento - (rendimento / 100) * 8;
            }else
            { //Desconto de 10%
                return rendimento - (rendimento / 100)* 10;
            }
        }
    }
}