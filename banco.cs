using System;
using System.Collections.Generic;
using MySqlConnector;

namespace SistemaFelinos
{
    public class Banco
    {
        private string conexao =
            "Server=127.0.0;Database=petshop;User ID=root;Password=Senac2026;";

        public void Cadastrar(Felinos gato)
        {
            using (MySqlConnection connection = new MySqlConnection(conexao))
            {
                connection.Open();

                string sql = "INSERT INTO felinos (nome, raca, pelagem, idade) VALUES (@nome, @raca, @pelagem, @idade)";

                using (MySqlCommand command = new MySqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@nome", gato.Nome);
                    command.Parameters.AddWithValue("@raca", gato.Raça);
                    command.Parameters.AddWithValue("@pelagem", gato.Pelagem);
                    command.Parameters.AddWithValue("@idade", gato.Idade);

                    command.ExecuteNonQuery();
                }
            }
        }

        public List<Felinos> Listar()
        {
            List<Felinos> gatos = new List<Felinos>();

            using (MySqlConnection connection = new MySqlConnection(conexao))
            {
                connection.Open();

                string sql = "SELECT id, nome, raca, pelagem, idade FROM felinos";

                using (MySqlCommand command = new MySqlCommand(sql, connection))
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Felinos gato = new Felinos();

                        gato.Id = reader.GetInt32("id");
                        gato.Nome = reader.GetString("nome");
                        gato.Raça = reader.GetString("raca");
                        gato.Pelagem = reader.GetString("pelagem");
                        gato.Idade = reader.GetInt32("idade");

                        gatos.Add(gato);
                    }
                }
            }

            return gatos;
        }

        public Felinos Buscar(int id)
        {
            using (MySqlConnection connection = new MySqlConnection(conexao))
            {
                connection.Open();

                string sql = "SELECT id, nome, raca, pelagem, idade FROM felinos WHERE id = @id";

                using (MySqlCommand command = new MySqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@id", id);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Felinos gato = new Felinos();

                            gato.Id = reader.GetInt32("id");
                            gato.Nome = reader.GetString("nome");
                            gato.Raça = reader.GetString("raca");
                            gato.Pelagem = reader.GetString("pelagem");
                            gato.Idade = reader.GetInt32("idade");

                            return gato;
                        }
                    }
                }
            }

            return null;
        }

        public void Atualizar(Felinos gato)
        {
            using (MySqlConnection connection = new MySqlConnection(conexao))
            {
                connection.Open();

                string sql =
                    "UPDATE felinos SET nome = @nome, raca = @raca, pelagem = @pelagem, idade = @idade WHERE id = @id";

                using (MySqlCommand command = new MySqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@id", gato.Id);
                    command.Parameters.AddWithValue("@nome", gato.Nome);
                    command.Parameters.AddWithValue("@raca", gato.Raça);
                    command.Parameters.AddWithValue("@pelagem", gato.Pelagem);
                    command.Parameters.AddWithValue("@idade", gato.Idade);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void Excluir(int id)
        {
            using (MySqlConnection connection = new MySqlConnection(conexao))
            {
                connection.Open();

                string sql = "DELETE FROM felinos WHERE id = @id";

                using (MySqlCommand command = new MySqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@id", id);

                    command.ExecuteNonQuery();
                }
            }
        }
    }
}