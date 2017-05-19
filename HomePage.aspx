<%@ Page Language="C#" AutoEventWireup="true" CodeFile="HomePage.aspx.cs" Inherits="HomePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <title>Web Services</title>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.1.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>


</head>

<body style="background-image: url('Images/chemistry_bg.jpg')">

    <!-- Navigation menu fixed -->
    <nav class="navbar navbar-inverse navbar-fixed-top">
        <div class="container-fluid">
            <div class="navbar-header">
                <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#myNavbar">
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>
                <a class="navbar-brand" href="#">All in One Site!</a>
            </div>
            <div class="collapse navbar-collapse" id="myNavbar">
                <ul class="nav navbar-nav">
                    <li class="active"><a href="HomePage.aspx">Chemistry</a></li>
                    <li><a href="Statistics.aspx">Statistics</a></li>
                    <li><a href="Converters.aspx">Converters</a></li>
                </ul>
                <ul class="nav navbar-nav navbar-right">
                    <li><a href="#"><span class="glyphicon glyphicon-user"></span>Sign Up</a></li>
                    <li><a href="#"><span class="glyphicon glyphicon-log-in"></span>Login</a></li>
                </ul>
            </div>
        </div>
    </nav>

    <form id="form1" runat="server">
        <div class="container">
            
            <!-- Header -->
            <div class="page-header" style="text-align: center; margin-top:70px; background-color: #EDE7E7;">
		        <h1> <b> Chemistry for Everyone! </b><small>explore the world of chemistry..</small></h1> 
	        </div>

            <!-- Select Element Message and List -->
            <div class="row">
                <div class="col-md-12" style="color: #FFFFFF">
                    <h3> Choose one of the elements to see more details about that element. </h3>
                </div>
            </div>
            <div class="row">
                <div class="col-md-4">
                    <asp:DropDownList ID="dropDownListElements" runat="server"></asp:DropDownList>
                </div>
            </div>
          
            <!-- Select Information Message, List and Button -->
            <div class="row">
                <div class="col-md-12" style="color: #FFFFFF">
                    <h3> Now, choose what information you want to learn about that element, or click the button Get All to see all information together. </h3>
                </div>
            </div>
            <div class="row" style="margin-top:15px;">
                <div class="col-md-4">
                    <asp:DropDownList ID="dropDownListInformationGet" runat="server" AutoPostBack="True"></asp:DropDownList>
                </div>
                <div class="col-md-2">
                    <asp:Button class="btn btn-primary btn-block" ID="Button1" runat="server" Text="Get All" OnClientClick="btnGetAll_Click" />
                </div>
            </div>
            
            <!-- Results -->
            <div class="row" style="margin-top:15px;">
                <div class="col-md-2"></div>
                <div class="col-md-8">
                    <div class="alert alert-success fade in" id="divResultMessage" runat="server" visible="false">
				        <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
				        <strong>Success!</strong><h4 runat="server" id="resultMessage"></h4>
			        </div>

                    <!-- Error -->
                    <div class="alert alert-danger fade in" id="divError" runat="server" visible="false">
                        <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
                        <strong>Error!</strong><h4 runat="server" id="HError"></h4>
                    </div>

                    <!-- Get All -->
                    <div class="alert alert-info fade in" id="div1" runat="server" visible="false">
				        <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
				        <strong>Success!</strong><h4 runat="server" id="H1"></h4>
			        </div>

                    <div class="alert alert-info fade in" id="div2" runat="server" visible="false">
				        <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
				        <strong>Success!</strong><h4 runat="server" id="H2"></h4>
			        </div>

                    <div class="alert alert-info fade in" id="div3" runat="server" visible="false">
				        <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
				        <strong>Success!</strong><h4 runat="server" id="H3"></h4>
			        </div>

                    <div class="alert alert-info fade in" id="div4" runat="server" visible="false">
				        <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
				        <strong>Success!</strong><h4 runat="server" id="H4"></h4>
			        </div>

                    <div class="alert alert-info fade in" id="div5" runat="server" visible="false">
				        <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
				        <strong>Success!</strong><h4 runat="server" id="H5"></h4>
			        </div>

                    <div class="alert alert-info fade in" id="div6" runat="server" visible="false">
				        <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
				        <strong>Success!</strong><h4 runat="server" id="H6"></h4>
			        </div>

                    <div class="alert alert-info fade in" id="div7" runat="server" visible="false">
				        <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
				        <strong>Success!</strong><h4 runat="server" id="H7"></h4>
			        </div>

                    <div class="alert alert-info fade in" id="div8" runat="server" visible="false">
				        <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
				        <strong>Success!</strong><h4 runat="server" id="H8"></h4>
			        </div>

                    <div class="alert alert-info fade in" id="div9" runat="server" visible="false">
				        <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
				        <strong>Success!</strong><h4 runat="server" id="H9"></h4>
			        </div>

                    <div class="alert alert-info fade in" id="div10" runat="server" visible="false">
				        <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
				        <strong>Success!</strong><h4 runat="server" id="H10"></h4>
			        </div>

                </div>
                <div class="col-md-2"></div>
            </div>          
            
            
    </div>
    </form>
</body>
</html>
