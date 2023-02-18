using CadastroPessoaFF12.Interfaces;
namespace CadastroPessoaFF12.Classes

{

    //Herdando Atributos e métodos Da classe Pai "Pessoa" 
    // herdando em segundo A interface IPessoaFisica com A Obrigadotoriedade da Assinatura do método 
    public class PessoaFisica : Pessoa, IPessoaFisica

    {
        public PessoaFisica()
        { //Conceito de método Sobrecarga // Quando tem mais de 1 método costrutor

        }
        public PessoaFisica(string parCpf)
        {// Método COnstrutor com a propiedade cpf 
            this.Cpf = parCpf; //Método Construtor : Ele tem o mesmo nome da classe , Uma classe especial
        }

        public string? Cpf { get; set; }
        public DateTime DataNascimento { get; set; }

        public string Caminho { get; private set; } = "Database/PessoaFisica.csv";

        //Conceito de "OVERRIDE" Vem do fato de o pagamento ser de maneira difereten , Ex: IRpf de 3% para PF E 10% PJ
        // Aqui podemos aplciar o conceito de polimorfismo
        public override float PagarImposto(float rendimento)

        {
            if (rendimento <= 1500)//Isento
            {
                return rendimento;
            }
            else if (rendimento <= 5000)
            { //3% de denconto
                return rendimento -  (rendimento / 100) * 3;
            }else
            { //Desconto de 5%
                return rendimento -  (rendimento / 100)* 5;
            }
            //Rendimento até 1500,00 isento(0%)Desconto
            //para rendimento entre 15001,00 - 5000,00 (3%)Desconto
            //para rendimento acima de 5000,01 (5%)Desconto
        }
        public bool ValidarDataNascimento(DateTime dataNasc)
        {
            DateTime DataAtual = DateTime.Today;
            double Idade = (DataAtual - dataNasc).TotalDays / 365;

            if (Idade >= 18)
            {
                return true;
            }
            return false;
        }
        public bool ValidarDataNascimento(string dataNasc)
        {

            DateTime dataConvertida;


            if (DateTime.TryParse(dataNasc, out dataConvertida))//Converte a String Data de Nascimento(dataNasc)
            {                                                   //E armaazenei em dataConvertida
                //Console.WriteLine(dataConvertida);
                DateTime DataAtual = DateTime.Today; // DateTime, Pega a data de hoje e armazena na DataAtual
                double Idade = (DataAtual - dataConvertida).TotalDays / 365; // Idade = Data Atual 
                //Console.WriteLine(DataAtual);
                //Console.WriteLine(idade);

                if (Idade >= 18)
                {
                    return true;
                }
            }
            return false;

        }

        public void Inserir(PessoaFisica pf)
        {
            Utils.VerificarPastaArquivo(Caminho);
            //Criando uma sleção de dados string 
            string[] PfValores = {$"{pf.Nome},{pf.Cpf},{pf.Rendimento}"};
            File.AppendAllLines(Caminho, PfValores);

        }

        public List<PessoaFisica> LerArquivo()
        {
            List<PessoaFisica> ListaPf =  new List<PessoaFisica>();

            string[] Linhas = File.ReadAllLines(Caminho);

            /// nome , cpf e  rendimento
            foreach (string CadaLinha in Linhas)
            {
                string [] atributo = CadaLinha.Split(",");
                PessoaFisica novaPf = new PessoaFisica();

                novaPf.Nome = atributo[0];
                novaPf.Cpf = atributo[1];
            
                
                ListaPf.Add(novaPf);
            }
            return ListaPf;
        }
    }
}