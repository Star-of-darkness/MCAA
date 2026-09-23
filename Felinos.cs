using System;

namespace SistemaFelinos// aqui a gente ja começa organizando o nome do coiso aqui
{
    public class Felinos
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Raça { get; set; }                          
        public string Pelagem { get; set; }
        public int Idade { get; set; }

        public Felinos()
        {
        }
//parametros do construtor
        public Felinos(string nome, string raça, string pelagem, int idade)
        {
            Nome = nome;
            Raça = raça;
            Pelagem = pelagem;
            Idade = idade;
        }

        public override string ToString()
        {
            return $"ID: {Id} | Nome: {Nome} | Raça: {Raça} | Pelagem: {Pelagem} | Idade: {Idade} anos";
        }
    }
}
