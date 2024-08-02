<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebNews.aspx.cs" Inherits="DevoirAPI.WebNews" Async="true"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-KK94CHFLLe+nY2dmCWGMq91rCGa5gtU4mk92HdvYe+M/SXH301p5ILy+dN9+nJOZ" crossorigin="anonymous"/>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <link rel="Website Icon" type="jpg" href="imaj.jpg"/>

    <title>Web News</title>
    <style>
        body {
            background-color: #d8d8d8;
        }

        .card-body {
            position: relative;
        }

        .card-text::before {
            content: "";
            position: absolute;
            bottom: 0;
            left: 0;
            right: 0;
            border-bottom: 1px solid #ccc;
        }
        .card-custom {
            width: 300px;
            height: 200px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">


        <div class="container-fluid">

            <%--la premiere ligne--%>
            <div class="row justify-content-center"style="height: 50px">
                 <div class="col">
                    <div class="d-flex justify-content-between">
                        <div class="d-flex align-items-center">
                            <div>
                                <asp:Button ID="btnFirst" runat="server" CssClass="accordion-body" Text="First Page" OnClick="btnFirst_Click" Enabled="false" />
                            </div>
                        </div>


                        <div class="d-flex align-items-center">
                            <h1 class="text-center">
                                Popular News
                            </h1>
                        </div>


                        <div class="d-flex align-items-center">
                            <div>
                                <asp:Button ID="btnLast" runat="server" CssClass="accordion-body" OnClick="btnLast_Click" Text="Last Page"/>
                            </div>
                        </div>


                    </div>
                </div>
            </div>



            <%--la deuxieme ligne--%>
            <div class="row" style="height: 600px">

                <div class="col-md-1">
                    <!-- First section content here -->
                </div>


                <div class="col-md-10">
                    <!-- Second section content here -->

                     <div class="row row-cols-1 row-cols-md-3 g-4 justify-content-center">

                         <%--premier card avec news--%>
                          <div class="col">
                            <div class="card h-100">
                                    <asp:ImageButton ID="cardImage1" runat="server" CssClass="card-img-top" AlternateText="Card Image" OnClick="Image1_Click" />
                                <div class="card-body">

                                      <h5 class="card-title">
                                            <asp:Label ID="cardTitle1" runat="server" AssociatedControlID="cardDescription1" Text=""></asp:Label>
                                      </h5>

                                      <label for="card-description-1" class="card-text">
                                            <asp:Label ID="cardDescription1" runat="server" Text=""></asp:Label>
                                      </label>
                                     
                                    <div>
                                        <h6>
                                            <asp:Label ID="lblAuthor1" runat="server" style="position: absolute; bottom: 0; right: 0;"></asp:Label>
                                        </h6>
                                    </div>
                                </div>

                                <div class="card-footer">

                                  <small class="text-muted">
                                    <asp:Label ID="cardFooter1" runat="server" Text=""></asp:Label>
                                  </small>
                              
                                </div>
                            
                            </div>

                          </div>
                         <%-- end --%>



                         <%--deuxieme card avec news--%>
                          <div class="col">
                            <div class="card h-100">
                                    <asp:ImageButton ID="cardImage2" runat="server" CssClass="card-img-top" AlternateText="Card Image" OnClick="Image2_Click"/>
                                <div class="card-body">

                                      <h5 class="card-title">
                                            <asp:Label ID="cardTitle2" runat="server" AssociatedControlID="cardDescription2" Text=""></asp:Label>
                                      </h5>

                                      <label for="card-description-1" class="card-text">
                                            <asp:Label ID="cardDescription2" runat="server" Text=""></asp:Label>
                                      </label>
                                     
                                    <div>
                                        <h6>
                                            <asp:Label ID="lblAuthor2" runat="server" style="position: absolute; bottom: 0; right: 0;"></asp:Label>
                                        </h6>
                                    </div>

                                </div>

                                <div class="card-footer">

                                  <small class="text-muted">
                                    <asp:Label ID="cardFooter2" runat="server" Text=""></asp:Label>
                                  </small>
                              
                                </div>
                            
                            </div>

                          </div>
                         <%-- end --%>



                         <%--troisieme card avec news--%>
                          <div class="col">
                            <div class="card h-100">
                                    <asp:ImageButton ID="cardImage3" runat="server" CssClass="card-img-top" AlternateText="Card Image" OnClick="Image3_Click"/>
                                <div class="card-body">

                                      <h5 class="card-title">
                                            <asp:Label ID="cardTitle3" runat="server" AssociatedControlID="cardDescription3" Text=""></asp:Label>
                                      </h5>

                                      <label for="card-description-1" class="card-text">
                                            <asp:Label ID="cardDescription3" runat="server" Text=""></asp:Label>
                                      </label>
                                     
                                    <div>
                                        <h6>
                                            <asp:Label ID="lblAuthor3" runat="server" style="position: absolute; bottom: 0; right: 0;"></asp:Label>
                                        </h6>
                                    </div>

                                </div>

                                <div class="card-footer">

                                  <small class="text-muted">
                                    <asp:Label ID="cardFooter3" runat="server" Text=""></asp:Label>
                                  </small>
                              
                                </div>
                            
                            </div>

                          </div>
                         <%-- end --%>


                    
                     </div>

                </div>
            

                <div class="col-md-1">
                    <!-- Third section content here -->
                </div>

            </div>


            
            <%--la troisieme ligne--%>
            <div class="row justify-content-center"style="height: 50px">
                 <div class="col">
	                <asp:Label ID="lblNotice" runat="server" Text=""></asp:Label>
                    <div class="d-flex justify-content-between">
                        <div class="d-flex align-items-center">
                            <div>
                                <asp:Button ID="btnPrevious" runat="server" Text="Previous" OnClick="btnPrevious_Click" Enabled="false" />
                            </div>
                        </div>


                        <div class="d-flex align-items-center">
                            <div>
                                <asp:Button ID="btnNext" runat="server" Text="Next" OnClick="btnNext_Click" />
                            </div>
                        </div>


                    </div>
                </div>
            </div>


        </div>


    </form>
    <script src="Scripts/bootstrap.min.js"></script>
    <script src="Scripts/bootstrap.js"></script>
</body>
</html>



