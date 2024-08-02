using System;

namespace DevoirAPI
{
    public class News
    {
        public string name { get; set; }
        public string author { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string url { get; set; }
        public byte[] urlToImage { get; set; }
        public DateTime publishedAt { get; set; }
        public string content { get; set; }

        public News() { }

        public News(string name, string author, string title, string description, string url, byte[] urlToImage, DateTime publishedAt, string content)
        {
            this.name = name;
            this.author = author;
            this.title = title;
            this.description = description;
            this.url = url;
            this.urlToImage = urlToImage;
            this.publishedAt = publishedAt;
            this.content = content;
        }
    }
}