using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading.Tasks;
using System.Net;
using System.Net.NetworkInformation;

namespace DevoirAPI
{
    public partial class SplashScreen : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlClass.CreateTableIfNotExists();

            if (CheckInternet())
            {
                SqlClass.InsertDatabase(JsonClass.GetNewsList());
            }

        }

        protected bool CheckInternet()
        {
            if (NetworkInterface.GetIsNetworkAvailable())
            {
                try
                {
                    using (WebClient client = new WebClient())
                    {
                        using (client.OpenRead("http://client3.google.com/generate_204"))
                        {
                            return true;
                        }
                    }

                }
                catch (WebException)
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
