using System;

namespace SistemaFelinos
{
    class Program
    {
        static Banco banco = new Banco();

        static void Main(string[] args)
        {
            int opcao = -1;

            while (opcao != 0)
            {
                ExibirMenu();

                if (int.TryParse(Console.ReadLine(), out opcao))
                {
                    switch (opcao)
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
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }

        static void ExibirMenu()
        {
            Console.WriteLine("           PETSHOP RONRONS");
            Console.WriteLine();
            Console.WriteLine("1 - Cadastrar gato");
            Console.WriteLine("2 - Listar gatos");
            Console.WriteLine("3 - Buscar gato");
            Console.WriteLine("4 - Atualizar gato");
            Console.WriteLine("5 - Excluir gato");
            Console.WriteLine("0 - Sair");
            Console.WriteLine();
            Console.Write("Escolha uma opção: ");
        }

        static void CadastrarGato()
        {
            Console.WriteLine("\n o:< Cadastrar Gato >:o");

            Console.Write("Nome: ");
            string nome = Console.ReadLine();

            Console.Write("Raça: ");
            string raça = Console.ReadLine();

            Console.Write("Pelagem: ");
            string pelagem = Console.ReadLine();

            Console.Write("Idade: ");

            if (int.TryParse(Console.ReadLine(), out int idade))
            {
                Felinos gato = new Felinos(nome, raça, pelagem, idade);

                banco.Cadastrar(gato);

                Console.WriteLine("\nGato cadastrado com sucesso!");
            }
            else
            {
                Console.WriteLine("\nIdade inválida. Cadastro cancelado.");
            }
        }

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