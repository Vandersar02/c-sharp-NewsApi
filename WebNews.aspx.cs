using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace DevoirAPI
{
    public partial class WebNews : System.Web.UI.Page
    {
        protected static int startIndex = 0;
        protected static int endIndex = 2;
        protected static int nPages= 1;
        List<News> newsList = SqlClass.GetAllNews();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }

        }

        #region Button
        protected void btnFirst_Click(object sender, EventArgs e)
        {
            startIndex = 0;
            endIndex = Math.Min(2, newsList.Count - 1);
            nPages = 1;

            // Mettre à jour les éléments affichés
            BindData();
        }

        protected void btnLast_Click(object sender, EventArgs e)
        {
            endIndex = newsList.Count - 1;
            startIndex = endIndex - ((newsList.Count - 1) % 3);
            nPages = (newsList.Count + 2) / 3;

            // Mettre à jour les éléments affichés
            BindData();
        }
        #endregion

        #region image action
        // click sur l'image 1
        protected void Image1_Click(object sender, EventArgs e)
        {
            WebNewsDetails.NewsInfo.Clear();
            WebNewsDetails.NewsInfo.Add(newsList[startIndex]);
            Response.Redirect("WebNewsDetails.aspx");
        }


        // click sur l'image 2
        protected void Image2_Click(object sender, EventArgs e)
        {
            WebNewsDetails.NewsInfo.Clear();
            WebNewsDetails.NewsInfo.Add(newsList[startIndex + 1]);
            Response.Redirect("WebNewsDetails.aspx");
        }


        // click sur l'image 3
        protected void Image3_Click(object sender, EventArgs e)
        {
            WebNewsDetails.NewsInfo.Clear();
            WebNewsDetails.NewsInfo.Add(newsList[endIndex]);
            Response.Redirect("WebNewsDetails.aspx");
        }
        #endregion


        #region Next & Previous
        protected void btnPrevious_Click(object sender, EventArgs e)
        {
            // Décrémenter les indices de début et de fin
            endIndex = startIndex - 1;
            startIndex = endIndex - 2;

            nPages--;

            // Mettre à jour les éléments affichés
            BindData();
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            // Incrémenter les indices de début et de fin
            startIndex += 3;
            endIndex += 3;
            nPages++;

            // Mettre à jour les éléments affichés
            BindData();
        }
        #endregion


        #region Afficher les News
        private void BindData()
        {
            if (newsList.Count > 0)
            {
                // Vérifier les limites des indices pour activer/désactiver les boutons Précédent et Suivant
                btnPrevious.Enabled = startIndex > 0;
                btnFirst.Enabled = startIndex > 0;

                btnNext.Enabled = endIndex < newsList.Count - 1;
                btnLast.Enabled = endIndex < newsList.Count - 1;

                // Vérifier la validité de startIndex
                if (startIndex >= newsList.Count)
                {
                    startIndex = newsList.Count - 1;
                }

                lblNotice.Text = $"Page :{nPages} of {newsList.Count / 3 + 1}";


                // Récupérer les éléments à afficher dans la plage des indices
                var elementsToShow = newsList.GetRange(startIndex, Math.Min(3, newsList.Count - startIndex));

                if (elementsToShow.Count == 3)
                {
                    /// la premiere carte
                    /// avec les informstions sur le News
                    
                    byte[] imageData1 = elementsToShow[0].urlToImage;
                    // convertir en image 
                    string base64Image1 = Convert.ToBase64String(imageData1);

                    lblAuthor1.Text = elementsToShow[0].author;
                    cardImage1.ImageUrl = "data:image/jpeg;base64," + base64Image1;
                    cardTitle1.Text = maxCharacters(30, elementsToShow[0].title);
                    cardDescription1.Text = maxCharacters(200, elementsToShow[0].description);
                    cardFooter1.Text = elementsToShow[0].publishedAt.ToString();

                    // ==============================================================
                    /// la deuxieme carte
                    /// mettre visible
                    /// 
                    cardImage2.Visible = true;
                    cardTitle2.Visible = true;
                    cardFooter2.Visible = true;
                    cardDescription2.Visible = true;
                    lblAuthor2.Visible = true;

                    /// la troisieme carte
                    /// mettre visible
                    /// 
                    cardImage3.Visible = true;
                    cardTitle3.Visible = true;
                    cardFooter3.Visible = true;
                    cardDescription3.Visible = true;
                    lblAuthor3.Visible = true;
                    // ==============================================================



                    /// la deuxieme carte
                    /// avec les informstions sur le News

                    byte[] imageData2 = elementsToShow[1].urlToImage;
                    // convertir en image 
                    string base64Image2 = Convert.ToBase64String(imageData2);

                    lblAuthor2.Text = elementsToShow[1].author;
                    cardImage2.ImageUrl = "data:image/jpeg;base64," + base64Image2;
                    cardTitle2.Text = maxCharacters(30, elementsToShow[1].title);
                    cardDescription2.Text = maxCharacters(200, elementsToShow[1].description);
                    cardFooter2.Text = elementsToShow[1].publishedAt.ToString();

                    /// la deuxieme carte
                    /// avec les informstions sur le News

                    byte[] imageData3 = elementsToShow[2].urlToImage;
                    // convertir en image 
                    string base64Image3 = Convert.ToBase64String(imageData3);

                    lblAuthor3.Text = elementsToShow[2].author;
                    cardImage3.ImageUrl = "data:image/jpeg;base64," + base64Image3;
                    cardTitle3.Text = maxCharacters(30, elementsToShow[2].title);
                    cardDescription3.Text = maxCharacters(200, elementsToShow[2].description);
                    cardFooter3.Text = elementsToShow[2].publishedAt.ToString();
                }
                if (elementsToShow.Count == 2)
                {
                    /// la premiere carte
                    /// avec les informstions sur le News

                    byte[] imageData1 = elementsToShow[0].urlToImage;
                    // convertir en image 
                    string base64Image1 = Convert.ToBase64String(imageData1);

                    lblAuthor1.Text = elementsToShow[0].author;
                    cardImage1.ImageUrl = "data:image/jpeg;base64," + base64Image1;
                    cardTitle1.Text = maxCharacters(30, elementsToShow[0].title);
                    cardDescription1.Text = maxCharacters(200, elementsToShow[0].description);
                    cardFooter1.Text = elementsToShow[0].publishedAt.ToString();

                    // ==============================================================
                    /// la deuxieme carte
                    /// mettre visible
                    /// 
                    cardImage2.Visible = true;
                    cardTitle2.Visible = true;
                    cardFooter2.Visible = true;
                    cardDescription2.Visible = true;
                    lblAuthor2.Visible = true;
                    // ==============================================================


                    /// la deuxieme carte
                    /// avec les informstions sur le News

                    byte[] imageData2 = elementsToShow[1].urlToImage;
                    // convertir en image 
                    string base64Image2 = Convert.ToBase64String(imageData2);

                    lblAuthor2.Text = elementsToShow[1].author;
                    cardImage2.ImageUrl = "data:image/jpeg;base64," + base64Image2;
                    cardTitle2.Text = maxCharacters(30, elementsToShow[1].title);
                    cardDescription2.Text = maxCharacters(200, elementsToShow[1].description);
                    cardFooter2.Text = elementsToShow[1].publishedAt.ToString();

                    /// la troisieme carte
                    /// ne rien afficher
                    /// 
                    cardImage3.Visible = false;
                    cardTitle3.Visible = false;
                    cardFooter3.Visible = false;
                    cardDescription3.Visible = false;
                    lblAuthor3.Visible = false;
                }
                if(elementsToShow.Count == 1)
                {
                    /// la premiere carte
                    /// avec les informstions sur le News

                    byte[] imageData1 = elementsToShow[0].urlToImage;
                    // convertir en image 
                    string base64Image1 = Convert.ToBase64String(imageData1);

                    lblAuthor1.Text = elementsToShow[0].author;
                    cardImage1.ImageUrl = "data:image/jpeg;base64," + base64Image1;
                    cardTitle1.Text = maxCharacters(30, elementsToShow[0].title);
                    cardDescription1.Text = maxCharacters(200, elementsToShow[0].description);
                    cardFooter1.Text = elementsToShow[0].publishedAt.ToString();


                    /// la deuxieme carte
                    /// ne rien afficher
                    /// 
                    cardImage2.Visible = false;
                    cardTitle2.Visible = false;
                    cardFooter2.Visible = false;
                    cardDescription2.Visible = false;
                    lblAuthor2.Visible = false;



                    /// la troisieme carte
                    /// ne rien afficher
                    /// 
                    cardImage3.Visible = false;
                    cardTitle3.Visible = false;
                    cardFooter3.Visible = false;
                    cardDescription3.Visible = false;
                    lblAuthor3.Visible = false;
                }


            }
            else
            {
                // Gérer le cas où la liste newsList est vide
                lblNotice.Text = "No news available";
            }


        }
        #endregion
        

        // fonction pour definir les caracteres a afficher
        protected string maxCharacters(int n, string text)
        {
            string truncatedText = null;
            if (text.Length > n)
            {
                truncatedText = text.Substring(0, n) + " ...";
            }
            else
            {
                truncatedText = text;
            }
            return truncatedText;
        }
    
    }
}
