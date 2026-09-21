using System;

namespace SistemaFelinos
{
    class Program
    {//aqui ja começamos a juntar o msql no c#
        static Banco banco = new Banco();//ponto de entrada do programa
        static void Main(string[] args)
        {
            int opcao = -1;
//Enquanto a opção for diferente de 0, continue executando
            while (opcao != 0)
            {
                ExibirMenu();
// serve +ou- como um true e false, todos eles juntos vão basicamente pegar o numero, converter ele pra...numero e jogar no menu
                if (int.TryParse(Console.ReadLine(), out opcao))
                {
                    switch (opcao)//serve pra verificar o o que esta dentro da (opção) 
                    {
                        case 1:
                            CadastrarGato();
                            break;

                        case 2:
                            ListarGatos();
                            break;

                        case 3:
                            BuscarGato();
                            break;

                        case 4:
                            AtualizarGato();
                            break;

                        case 5:
                            ExcluirGato();
                            break;

                        case 0:
                            Console.WriteLine("Saindo do sistema...");
                            break;

                        default:
                            Console.WriteLine("Opção inválida!");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Digite um número válido.");
                    opcao = -1;
                }

                if (opcao != 0)
                {
                    Console.WriteLine("\nPressione qualquer tecla para continuar...");
                    Console.ReadKey();//vai ler e execultar no  menu
                    Console.Clear();
                }
            }
        }
// ceciiii
        // Essa função mostra o menu principal do Petshop
        static void ExibirMenu()
        {
            // Mostra o nome do sistema na tela
            Console.WriteLine("  PETSHOP RONRONS  ");
            Console.WriteLine();
            Console.WriteLine("1 - Cadastrar gato");
            Console.WriteLine("2 - Listar gatos");
            Console.WriteLine("3 - Buscar gato");
            Console.WriteLine("4 - Atualizar gato");
            Console.WriteLine("5 - Excluir gato");
            Console.WriteLine("0 - Sair");
            Console.WriteLine();
            // Pede para o usuário escolher uma opção
            Console.Write("Escolha uma opção: ");
        }
// Essa função serve para cadastrar um novo gato
        static void CadastrarGato()
        {
            Console.WriteLine("\n o:< Cadastrar Gato >:o");
// Pede o nome do gato
            Console.Write("Nome: ");
            // Guarda o nome que o usuário digitou na variável nome
            string nome = Console.ReadLine();
// Pede a raça
            Console.Write("Raça: ");
            string raça = Console.ReadLine();
// Pede a pelagem
            Console.Write("Pelagem: ");
            string pelagem = Console.ReadLine();
// Pede a idade do gato
            Console.Write("Idade: ");
// Aqui o programa verifica se a idade digitada é um número válido
            if (int.TryParse(Console.ReadLine(), out int idade))
            {
                // Aqui cria um objeto com as informações do gato
                Felinos gato = new Felinos(nome, raça, pelagem, idade);

                banco.Cadastrar(gato);
// Mostra uma mensagem dizendo que o cadastro deu certo
                Console.WriteLine("\nGato cadastrado com sucesso!");
            }
            else
            {
                // Mostra que o cadastro foi cancelado
                Console.WriteLine("\nIdade inválida. Cadastro cancelado.");
            }
        }
// Essa função serve para mostrar todos os gatos cadastrados
        static void ListarGatos()
        {
            Console.WriteLine("\n-_- Lista de Gatos -_-");

            var gatos = banco.Listar();

            if (gatos.Count == 0)
            {
                Console.WriteLine("Nenhum gato cadastrado.");
                return;
            }

            foreach (Felinos gato in gatos)
            {
                Console.WriteLine(gato);
            }
        }

        static void BuscarGato()
        {
            Console.WriteLine("\n d:< Buscar Gato >:P");

            Console.Write("Digite o ID do gato: ");

            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("ID inválido.");
                return;
            }

            Felinos gato = banco.Buscar(id);

            if (gato == null)
            {
                Console.WriteLine("Gato não encontrado.");
                return;
            }

            Console.WriteLine("\nGato encontrado:");
            Console.WriteLine(gato);
        }

        static void AtualizarGato()
        {
            Console.WriteLine("\n -_- Atualizar Gato -_-");

            Console.Write("Digite o ID do gato que deseja atualizar: ");

            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("ID inválido.");
                return;
            }

            Felinos gato = banco.Buscar(id);

            if (gato == null)
            {
                Console.WriteLine("Gato não encontrado.");
                return;
            }

            Console.WriteLine("\nGato atual:");
            Console.WriteLine(gato);

            Console.Write("\nNovo nome: ");
            string nome = Console.ReadLine();

            Console.Write("Nova raça: ");
            string raça = Console.ReadLine();

            Console.Write("Nova pelagem: ");
            string pelagem = Console.ReadLine();

            Console.Write("Nova idade: ");

            if (!int.TryParse(Console.ReadLine(), out int idade))
            {
                Console.WriteLine("Idade inválida. Atualização cancelada.");
                return;
            }

            gato.Nome = nome;
            gato.Raça = raça;
            gato.Pelagem = pelagem;
            gato.Idade = idade;

            banco.Atualizar(gato);

            Console.WriteLine("\nGato atualizado com sucesso eeeeeee >:D");
        }

        static void ExcluirGato()
        {
            Console.WriteLine("\n d: Excluir Gato :P");

            Console.Write("Digite o ID do gato que deseja excluir: ");

            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("ID inválido.");
                return;
            }

            Felinos gato = banco.Buscar(id);

            if (gato == null)
            {
                Console.WriteLine("Gato não achado");
                return;
            }

            Console.WriteLine("\nGato encontrado:");
            Console.WriteLine(gato);

            Console.Write("\nTem certeza que deseja excluir? (s/n): ");
            string resposta = Console.ReadLine();

            if (resposta.ToLower() == "s")
            {
                banco.Excluir(id);

                Console.WriteLine("Gato excluído com sucesso!");
            }
            else
            {
                Console.WriteLine("Exclusão cancelada.");
            }
        }
    }
}
