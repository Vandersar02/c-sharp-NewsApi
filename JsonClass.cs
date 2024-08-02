using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json;
using System.Text.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;
using System.Xml.Linq;
using System;

namespace DevoirAPI
{
    public class JsonClass
    {
        public static List<News> GetNewsList()
        {
            List<News> listNews = new List<News>();

            using (WebClient client = new WebClient())
            {
                string api_key = "empty";
                // si l'internet est trop lent utiliser ce lien car il ne contient que 10 News
                string jsonString = client.DownloadString("https://newsapi.org/v2/top-headlines?sources=techcrunch&apiKey=" + api_key);

                // ce lien marche aussi mais il faut une tres bonne connection pour pouvoir prendre les donnees 
                //string jsonString = client.DownloadString("https://newsapi.org/v2/everything?domains=wsj.com&apiKey=" + api_key);


                // Parse JSON response
                var jsonDocument = JsonDocument.Parse(jsonString);
                var root = jsonDocument.RootElement;

                // Access specific properties in the JSON response
                if (root.TryGetProperty("articles", out JsonElement articlesElement) && articlesElement.ValueKind == JsonValueKind.Array)
                {
                    foreach (var article in articlesElement.EnumerateArray())
                    {
                        // Access properties of each article
                        string name = article.GetProperty("source").GetProperty("name").GetString();
                        string author = article.GetProperty("author").GetString();
                        string title = article.GetProperty("title").GetString();
                        string description = article.GetProperty("description").GetString();
                        string url = article.GetProperty("url").GetString();
                        string urlToImage = article.GetProperty("urlToImage").GetString();
                        DateTime publishedAt = article.GetProperty("publishedAt").GetDateTime();
                        string content = article.GetProperty("content").GetString();


                        byte[] imageData;
                        using (WebClient webClient = new WebClient())
                        {
                            imageData = webClient.DownloadData(urlToImage);
                        }

                        // Create a News object or perform any desired operations with the retrieved data
                        News news = new News(name, author, title, description, url, imageData, publishedAt, content);

                        // Add the News object to a list or use it as needed
                        listNews.Add(news);
                    }
                }
            }
            return listNews;
        }

    }

}