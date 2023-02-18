using CadastroPessoaFF12.Classes;
using System.Text.RegularExpressions; //Import da classe Regex


PessoaJuridica MetodosPj = new PessoaJuridica();


List<PessoaJuridica> listaPj = new List<PessoaJuridica>();
List<PessoaFisica> listaPf = new List<PessoaFisica>();

PessoaFisica MetodosPf = new PessoaFisica();// Instanciando um obejto para chamar os métodos.
PessoaFisica pf1 = new PessoaFisica(); //Instancia a classe pessoa Fisica e cria um objeto 





//Cabeçalho
Console.WriteLine(@$"
===========================================
|    Bem vindo ao sistema cadastro        |
|             de pessoas                  |
|         Fisica & Juridicas              |
===========================================
");
Utils.Loading("Inicializando Sitema ", 3, 500);

Console.ResetColor(); // Reseta cor


string? opcao; //Variavel vazia

do //Estrutura de repetição
{
    Console.WriteLine(@$"
===========================================
|       Escolha uma das opções abaixo     |
|_________________________________________|
|       1 - Pessoa Física                 |              
|       2 - Pessoa Juridica               |
|                                         |
|       0 - Sair                          |               
===========================================
");

    opcao = Console.ReadLine();
    switch (opcao) // Escolhe a opção, estrutura de condição
    {
        case "2":
            string opcaoPj;
            do
            {
                //SUB - MENU
                Console.WriteLine(@$"
===========================================
|       Escolha uma das opções abaixo     |
|_________________________________________|
|       1 - Cadastrar pessoa júridica     |              
|       2 - Listar Pessoa Júridica        |
|                                         |
|       0 - Voltar ao menu principal      |               
===========================================
            ");
                opcaoPj = Console.ReadLine();

                switch (opcaoPj)
                {
                    case "1": //Cadastrando pessoa júridica 
                        Console.Clear();
                        // //************Cadastro de pessoa Júridica, preenchimento dos dados**********\\ 

                        /// Instanciando classse (que é uma composição) endereço e colocando valor nas variaveis. 
                        Endereco endPj = new Endereco();  /// Instanciando a classe Endereço//
                        PessoaJuridica novaPj = new PessoaJuridica();


                        Console.WriteLine($"Digite o endereço:");
                        endPj.Logradouro = Console.ReadLine();
                        Console.Clear();
                        Console.WriteLine($"Digite o número:");
                        endPj.Numero = int.Parse(Console.ReadLine());
                        Console.Clear();
                        Console.WriteLine($"Endereço é comercial ? S/N");
                        string comercial = Console.ReadLine();
                        if (comercial == "S")
                        {
                            endPj.Comercial = true;
                        }
                        else
                            endPj.Comercial = false;

                        Console.WriteLine($"Digite o Nome:");
                        novaPj.Nome = Console.ReadLine();
                        // Instanciano classe PessoaJuridica e colocando valor em sua variaveis.
                        // Instanciando um obejto para chamar os métodos.


                        using (StreamWriter sw = new StreamWriter($"{novaPj.Nome}.txt"))
                        {
                            sw.WriteLine(novaPj.Nome);
                        }


                        Utils.ParandoConsole("Pessoa Júridica cadastrada com sucesso!");
                        break;
                    case "2": // listando pessoa júridica
                        // *******Exibir dados*******\\
                        Console.Clear();
                        Console.WriteLine("****Listagem de Pessoa Júridica****");

                       
                        //Leitura dos dados txt
                        using (StreamReader sr = new StreamReader("Anonimo.txt"))
                        {
                            string linha;
                            while ((linha = sr.ReadLine()) != null)
                            {
                                Console.WriteLine(linha);
                            }
                            Console.WriteLine($"Tecle enter para continuar");
                            Console.ReadLine();
                        }

                        Console.WriteLine();
                        Utils.ParandoConsole("Fim da listagem");
                        break;

                    case "0":// voltando ao menu
                        Console.Clear();
                        Utils.ParandoConsole("Opção Voltando ao menu");
                        break;
                    default:// Opção inválida!
                        Console.Clear();
                        Utils.ParandoConsole("Opção inválida!");
                        break;

                }

            } while (opcaoPj != "0");

            Console.Clear();

            break;

        case "1":
            //***********Cadastro de Pessoa Fisica************\\
            string? opcaoPf;
            do
            {
                Console.WriteLine(@$"
===========================================
|       Escolha uma das opções abaixo     |
|_________________________________________|
|       1 - Cadastrar pessoa Fisica       |              
|       2 - Listar Pessoa Fisica          |
|                                         |
|       0 - Voltar ao menu principal      |               
===========================================
            ");
                opcaoPf = Console.ReadLine();
                switch (opcaoPf)
                {
                    case "1":
                        Console.Clear();

                        Endereco endfpf1 = new Endereco();// Instanciando Classe endereço New Endereço()
                        endfpf1.Logradouro = "Endereço 2";
                        endfpf1.Numero = 50;
                        endfpf1.Comercial = false;




                        //declara o valor do objeto 
                        pf1.Cpf = "555.555.555-00";//declara o valor do objeto(Atributo )
                        pf1.DataNascimento = new DateTime(2000, 05, 14);
                        pf1.Rendimento = 1300.00f;
                        pf1.Nome = "Anonimo";
                        pf1.Endereco = endfpf1;// Indicando que endereço  é igual a instanacia e endpf1 da classe Endereco
                        Utils.ParandoConsole("Pessoa Fisica cadastrada com sucesso!");
                        break;

                    case "2":
                        //Insere dados No Database
                        MetodosPf.Inserir(pf1);
                        List<PessoaFisica> ListaExibicaoPf = MetodosPf.LerArquivo();

                        foreach (PessoaFisica PessoaDaLista in ListaExibicaoPf)
                        {
                            // Exibição dos dados\\
                            Console.Clear();

                            Console.WriteLine($"Nome: {PessoaDaLista.Nome}");// objetos e seus valores
                            Console.WriteLine($"CPF: {PessoaDaLista.Cpf}");// objetos e seus valores
                                                                           // Console.WriteLine($"Data de nascimento: {PessoaDaLista.DataNascimento}");// objetos e seus valores
                                                                           // Console.WriteLine($"Rendimento: {PessoaDaLista.Rendimento}");
                                                                           // Console.WriteLine($"Rendimento liquido: {MetodosPf.PagarImposto(PessoaDaLista.Rendimento)}");//Rendimento liquido
                                                                           // objetos e seus valores
                                                                           // Console.WriteLine($"Logradouro: {PessoaDaLista.Endereco.Logradouro}");// objetos e seus valores
                                                                           // Console.WriteLine($"Número: {PessoaDaLista.Endereco.Numero}");// objetos e seus valores
                                                                           // Console.WriteLine($"Endereço comercial ? {PessoaDaLista.Endereco.Comercial}");// objetos e seus valores
                                                                           // Console.WriteLine($"Maior de Idade? {PessoaDaLista.ValidarDataNascimento(PessoaDaLista.DataNascimento)}");// Pega a data de nascimento Usa o método para calcular e retorna se é maior de idade.
                                                                           //                                                                                       //Console.WriteLine($"Maior de Idade? {pf1.ValidarDataNascimento(14/05/2000)}") // Do método String de ValidarDataDeNascimento
                            DateTime data = new DateTime(2000, 5, 14);

                            Console.WriteLine($"");
                            Console.WriteLine($"Digite enter para continuar");
                            Console.ReadLine();


                        }

                        // Console.Write(ListaExibicaoPf);
                        Console.WriteLine($""); //Quebra do texto
                        Utils.ParandoConsole("Pessoa física Exibida com sucesso!");
                        Console.Clear();
                        break;
                    case "0":
                        Utils.ParandoConsole("Obrigado por usar o nosso sistema!");
                        Console.Clear();
                        break;
                    default:
                        Utils.ParandoConsole("Opção inválida!", ConsoleColor.Red); // Cor opcional Como parametro //Estudo de caso
                        Console.ResetColor(); // Reseta cor
                        break;
                }

            } while (opcaoPf != "0");


            break;

        case "0":

            Utils.ParandoConsole("Obrigado por usar o nosso sistema!");
            Console.Clear();
            break;

        default:
            Utils.ParandoConsole("Opção inválida!", ConsoleColor.Red); // Cor opcional Como parametro //Estudo de caso
            Console.ResetColor(); // Reseta cor

            break;
    }


} while (opcao != "0"); //Enquanto for diferente de 0 ele ira repetir o código 


Utils.Loading("Finalizando Sitema ", 3, 500);
Console.ResetColor(); // Reseta cor
Console.WriteLine($"");///Quebra de linha
Console.WriteLine($"Fim do Progama!");

