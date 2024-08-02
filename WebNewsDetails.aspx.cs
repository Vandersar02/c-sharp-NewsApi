using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DevoirAPI
{
    public partial class WebNewsDetails : System.Web.UI.Page
    {
        public static List<News> NewsInfo = new List<News>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (NewsInfo.Count > 0)
            {
                // si vous appuyez sur le titre il vous envoie sur le vrai site du News en question
                myHyperlink.Text = NewsInfo[0].title;
                myHyperlink.NavigateUrl = NewsInfo[0].url;

                byte[] imageData1 = NewsInfo[0].urlToImage;

                // convertir en image 
                string base64Image1 = Convert.ToBase64String(imageData1);
                imageNews.ImageUrl = "data:image/jpeg;base64," + base64Image1;

                // pour afficher la description du News a cote de l' image
                lblDescription.Text = "Description:" + "\n" + NewsInfo[0].description;

                // pour afficher le Nom de l' auteur qui a rediger ce news
                lblAuthor.Text = NewsInfo[0].author;

                // heure de publication
                lblPublishedAt.Text = NewsInfo[0].publishedAt.ToString();


                // le contenu du News
                lblContent.Text = NewsInfo[0].content;

            }
            else
            {
                lblMessage.Text = "No News";
            }

        }
    }
}