namespace CadastroPessoaFF12.Interfaces
{
    public interface IPessoaFisica
    {
         //nome do método será ValidarDataNascimento
         //Argumento de entrada desse método 
         //Retorna Booleano
         //float PagarImposto ( float rendimento);

         public bool ValidarDataNascimento(DateTime dataNasc);

    }
}