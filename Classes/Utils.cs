
namespace  CadastroPessoaFF12.Classes
{
    public static class Utils
    {
        public static void Loading(string text, int qtdPontos, int tempo)
        {
            Console.BackgroundColor = ConsoleColor.Green; // Cor de fundo do console
            Console.ForegroundColor = ConsoleColor.Black;// cor da fonte

            Console.Write(text); //Console sem pular linhas
            for (int i = 1; i <= qtdPontos; i++)
            {

            Thread.Sleep(tempo); //Função para leve atraso
            Console.Write($".");

            }
        }

        public static void ParandoConsole(string texto, ConsoleColor Cor = ConsoleColor.White) //Por padrão se não tiver paramentro irá ser white
        {
            Console.ForegroundColor = Cor;
            Console.WriteLine(texto);
            Console.WriteLine($"");//Quebra de linha
            Console.WriteLine($"Tecle <Enter> Para continuar");
            Console.ReadLine();
        
        }

        //Caminho é public string Caminho { get; private set; } = "Database/PessoaFisica.csv";
        public static void VerificarPastaArquivo(string Caminho)
        {
            string pasta =  Caminho.Split("/")[0]; //Divide a string em um array separado por " / "

            //Validação de diretório, se a pastar não existir 
            if (!Directory.Exists(pasta))
            {
                //Criar pasta
                Directory.CreateDirectory(pasta);
            }

            if (!File.Exists(Caminho))
            {
                using(File.Create(Caminho)){}
                
            }
        }
    }

    
}