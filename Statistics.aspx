<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Statistics.aspx.cs" Inherits="Statistics" %>

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

<body style="background-image: url('Images/statistics_bg.jpg')">

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
                    <li><a href="HomePage.aspx">Chemistry</a></li>
                    <li class="active"><a href="Statistics.aspx">Statistics</a></li>
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
            <div class="page-header" style="text-align: center; margin-top: 70px; background-color: #EDE7E7;">
                <h1><b>Statistics for Everyone! </b><small>statistics were never easier..</small></h1>
            </div>

            <!-- Textarea -->
            <div class="form-group" style="margin-top: 50px;">
                <div class="col-md-1"></div>
                <div class="col-md-8">
                    <label for="numbers" style="color: red; font-size: 25px; font-style: italic; font-weight: bolder;"><b>Numbers:</b></label>
                    <textarea runat="server" class="form-control" rows="5" id="textAreaNumbers" placeholder="Insert the numbers that you want in text area above seperated by comma (,). e.g. 2, 6, 8.45, 7"></textarea>
                </div>
                <div class="col-md-3" style="margin-top: 100px;">
                    <asp:Button class="btn btn-primary btn-block" ID="Button1" runat="server" Text="Calculate Statistics" />
                </div>
            </div>

            <!-- results -->
            <div class="row">
                <div class="col-md-2"></div>
                <div class="col-md-4" style="margin-top: 25px;">

                    <div class="alert alert-info fade in" id="div1" runat="server" visible="false">
                        <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
                        <strong>Success!</strong><h4 runat="server" id="H1"></h4>
                    </div>

                    <div class="alert alert-info fade in" id="div3" runat="server" visible="false">
                        <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
                        <strong>Success!</strong><h4 runat="server" id="H3"></h4>
                    </div>

                    <div class="alert alert-info fade in" id="div5" runat="server" visible="false">
                        <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
                        <strong>Success!</strong><h4 runat="server" id="H5"></h4>
                    </div>

                </div>
                <div class="col-md-4" style="margin-top: 25px;">

                    <div class="alert alert-info fade in" id="div2" runat="server" visible="false">
                        <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
                        <strong>Success!</strong><h4 runat="server" id="H2"></h4>
                    </div>

                    <div class="alert alert-info fade in" id="div4" runat="server" visible="false">
                        <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
                        <strong>Success!</strong><h4 runat="server" id="H4"></h4>
                    </div>

                    <!-- Error -->
                    <div class="alert alert-danger fade in" id="div6" runat="server" visible="false">
                        <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
                        <strong>Error!</strong><h4 runat="server" id="H6"></h4>
                    </div>

                </div>
                <div class="col-md-2"></div>
            </div>

        </div>
    </form>
</body>
</html>
