using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using System.Net;
using System.Xml.Linq;


namespace DevoirAPI
{
    public class SqlClass
    {

        public static void CreateTableIfNotExists()
        {
            // Vérifier si la table existe déjà dans la base de données
            bool tableExists = CheckIfTableExists();
            string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

            // Si la table n'existe pas, la créer
            if (!tableExists)
            {
                // Code pour créer la table ici
                // ...
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Création de la table News
                    string createTableQuery = @"CREATE TABLE News (
                                    NewsId INT IDENTITY(1,1) PRIMARY KEY,
                                    Name NVARCHAR(100),
                                    Author NVARCHAR(100),
                                    Title NVARCHAR(100),
                                    Description NVARCHAR(MAX),
                                    Url NVARCHAR(500),
                                    UrlToImage VARBINARY(MAX),
                                    PublishedAt DATETIME,
                                    Content NVARCHAR(MAX)
                                )";

                    using (SqlCommand createTableCommand = new SqlCommand(createTableQuery, connection))
                    {
                        createTableCommand.ExecuteNonQuery();
                    }
                }
            }
        }

        public static bool CheckIfTableExists()
        {
            // Code pour vérifier si la table existe déjà dans la base de données
            // Vous pouvez utiliser les méthodes ou les requêtes spécifiques à votre système de gestion de base de données (SGBD)
            // Par exemple, pour un SGBD relationnel comme SQL Server, vous pouvez utiliser une requête SQL pour vérifier l'existence de la table
            string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

            // Exemple pour SQL Server :
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'News'", connection);
                int count = (int)command.ExecuteScalar();
                return count > 0;
            }
        }

        public static void InsertDatabase(List<News> newsList)
        {
            //List<News> newsList = JsonClass.GetNewsList();
            string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                // Ouvrir la connexion à la base de données
                conn.Open();
                // Insert each news item into the News table
                foreach (News news in newsList)
                {

                    string query = "INSERT INTO News (Name, Author, Title, Description, Url, UrlToImage, PublishedAt, Content) VALUES (@Name, @Author, @Title, @Description, @Url, @UrlToImage, @PublishedAt, @Content)";

                        string queryIfExist = "SELECT COUNT(*) FROM News WHERE Name = @Name AND Author = @Author AND Title = @Title AND Description = @Description AND Url = @Url AND UrlToImage = @UrlToImage AND PublishedAt = @PublishedAt AND Content = @Content";

                    using (SqlCommand command1 = new SqlCommand(queryIfExist, conn))
                    {
                        // Set the parameter values for the person's name
                        command1.Parameters.AddWithValue("@Name", news.name);
                        command1.Parameters.AddWithValue("@Author", news.author);
                        command1.Parameters.AddWithValue("@Title", news.title);
                        command1.Parameters.AddWithValue("@Description", news.description);
                        command1.Parameters.AddWithValue("@Url", news.url);
                        command1.Parameters.AddWithValue("@UrlToImage", news.urlToImage);
                        command1.Parameters.AddWithValue("@PublishedAt", news.publishedAt);
                        command1.Parameters.AddWithValue("@Content", news.content);

                        int count = (int)command1.ExecuteScalar();
                        if (count == 0)
                        {
                            // Créer une commande SQL pour l' ajout des personnes
                            SqlCommand insertCommand = new SqlCommand(query, conn);
                            insertCommand.Parameters.AddWithValue("@Name", news.name);
                            insertCommand.Parameters.AddWithValue("@Author", news.author);
                            insertCommand.Parameters.AddWithValue("@Title", news.title);
                            insertCommand.Parameters.AddWithValue("@Description", news.description);
                            insertCommand.Parameters.AddWithValue("@Url", news.url);
                            insertCommand.Parameters.AddWithValue("@UrlToImage", news.urlToImage);
                            insertCommand.Parameters.AddWithValue("@PublishedAt", news.publishedAt);
                            insertCommand.Parameters.AddWithValue("@Content", news.content);
                            insertCommand.ExecuteNonQuery();

                        }
                        else
                        {
                            return;
                        }
                    }
                }

            }

        }

        public static List<News> GetAllNews()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

            List<News> newsList = new List<News>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string selectQuery = "SELECT * FROM News";
                SqlCommand selectCommand = new SqlCommand(selectQuery, connection);

                using (SqlDataReader reader = selectCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string name = reader.GetString(1);
                        string author = reader.GetString(2);
                        string title = reader.GetString(3);
                        string description = reader.GetString(4);
                        string url = reader.GetString(5);
                        byte[] urlToImage = (byte[])reader["urlToImage"];
                        DateTime publishedAt = reader.GetDateTime(7);
                        string content = reader.GetString(8);


                        News news = new News(name, author, title, description, url, urlToImage, publishedAt, content);
                        newsList.Add(news);
                    }
                }
            }

            return newsList;
        }

    }
}

