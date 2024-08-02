<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebNewsDetails.aspx.cs" Inherits="DevoirAPI.WebNewsDetails" Async="true"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-KK94CHFLLe+nY2dmCWGMq91rCGa5gtU4mk92HdvYe+M/SXH301p5ILy+dN9+nJOZ" crossorigin="anonymous"/>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <link rel="Website Icon" type="jpg" href="imaj.jpg"/>
    <title>Web News Details</title>
    <style>
        body{
            background: #d8d8d8;
        }
        .colored-label {
          color: dodgerblue;
        }
        .no-underline {
            text-decoration: none;
        }
        .left-element {
            float: left;
        }

        .right-element {
            float: right;
        }
    </style>

</head>
<body>
    <form id="form1" runat="server">

        <div class="container-fluid">
                <nav id="NewsNavbar" class="navbar bg-body-tertiary px-3 mb-3">
                  <a class="navbar-brand" href="#">
                      <asp:HyperLink ID="myHyperlink" runat="server" CssClass="no-underline" style="font-size: 16px; text-align: right;" Target="_blank"></asp:HyperLink>

                      <asp:Label ID="lblMessage" runat="server" Text="" CssClass="colored-label"></asp:Label>
                  </a>
                  <ul class="nav nav-pills">
                    <li class="nav-item">
                      <a class="nav-link" href="#image">Image & Description</a>
                    </li>
                    <li class="nav-item">
                      <a class="nav-link" href="#content">content</a>
                    </li>
                  </ul>

                </nav>

                <div data-bs-spy="scroll" data-bs-target="#NewsNavbar" data-bs-root-margin="0px 0px -40%" data-bs-smooth-scroll="true" class="scrollspy-example bg-body-tertiary p-3 rounded-2" tabindex="0">
                  
                    <div class="row">
                        <div class="col-md-8" id="image">
                            <div class="car h-100">
                                <asp:Image ID="imageNews" runat="server"  CssClass="card-img-bottom"/>
                            </div>
                        </div>
                    
                        <div class="col-md-4">
                           <h4 id="description">
                               <asp:Label ID="lblDescription" runat="server" Text=""></asp:Label>
                           </h4>
                        </div>
                  </div>

                    <div class="row">
                        <h4>
                            <asp:Label ID="lblAuthor" runat="server" Text="" CssClass="left-element"></asp:Label>
                            <asp:Label ID="lblPublishedAt" runat="server" Text="" CssClass="right-element"></asp:Label>
                        </h4>
                    </div>

                    <div style="width: 100%; height: 1px; background-color: black;"></div>

                    <div class="row">
                          <h4 id="content">
                              <asp:Label ID="lblContent" runat="server" Text=""></asp:Label>
                          </h4>
                    </div>

                    <div class="row">

                    </div>


                </div>

        </div>

    </form>
    <script src="Scripts/bootstrap.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
</body>
</html>
