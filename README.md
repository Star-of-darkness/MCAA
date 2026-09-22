Nome do projeto: MCAA 

Integrantes: Cecília, Maria Julia e Ana Laura

Banco de dados utilizado: MYSQL

Biblioteca/driver utilizado: MySqlConnector (ADO.NET)

Como instalar as dependências: só rodar no terminal 'dotnet add package MySqlConnector'

Como configurar o banco: É só colar o script do SQL desse projeto no Banco de dados

Como executar o projeto:É só abrir o terminal e digitar 'dotnet run'

Breve explicação de como funciona a conexão: A conexão entre o C# e o MySQL é gerenciada pela classe MySqlConnection, que utiliza uma string de conexão contendo o endereço do servidor, o nome do banco de dados (petshop), o usuário (root) e a senha. Toda vez que uma operação do CRUD é acionada no menu (como cadastrar ou listar), a conexão é aberta via connection.Open(). Os comandos SQL são executados de forma segura através do MySqlCommand, utilizando parâmetros (@nome, @idade, etc.) para impedir ataques de SQL Injection. Todo o bloco de código fica envelopado em uma estrutura using, o que garante que a conexão com o banco seja fechada e limpa da memória automaticamente assim que a tarefa termina.
