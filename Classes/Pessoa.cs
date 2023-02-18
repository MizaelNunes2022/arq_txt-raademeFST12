using   CadastroPessoaFF12.Interfaces;
namespace CadastroPessoaFF12.Classes

{ 
    //A Classe Pesoa é abstrata e não pode ser instanciada
    //Abstração vem do conceito de tornar ela abstrata, Podendo ser criadas outras classes como pessoa fisica ou juridica
    //As Sub classes Herdarão métodos e atributos da classe mãe 
    public abstract class Pessoa : IPessoa 


    {
        public string? Nome {get; set;}
        public Endereco? Endereco {get; set;}
        public float Rendimento  {get; set;}

        //Método abstrato podendo ser aplciado ao polimorfismo quando o métido for herdado de maneira obrigatória nas subclasses
        
        public abstract float PagarImposto(float rendimento); 
    } 
}
