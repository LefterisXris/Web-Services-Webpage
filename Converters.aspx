<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Converters.aspx.cs" Inherits="Converters" %>

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

<body style="background-image: url('mobile-mills-co-background.png')">

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
                    <li><a href="Statistics.aspx">Statistics</a></li>
                    <li class="active"><a href="Converters.aspx">Converters</a></li>
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
                <h1><b>Converters for Everyone! </b><small>and everything...</small></h1>
            </div>

            <div class="row">

                <!-- Temperature -->
                <div class="col-md-6" style="padding: 5px; border-style: dashed; border-width: thick;">
                    <div style="width: 100%; text-align: center; background-color: #CCCCCC;">
                        <h3>Temperature Converter </h3>
                    </div>
                    <asp:DropDownList ID="dropDownListTempFrom" runat="server" Width="25%"></asp:DropDownList>
                    <asp:Image runat="server" ImageUrl="~/convertTo trans.png" Width="25%" Height="25%" />
                    <asp:DropDownList ID="dropDownListTempTo" runat="server" Width="25%"></asp:DropDownList>
                    <asp:Button ID="Button1" runat="server" Text="OK" Width="20%" OnClick="TemperatureConverter" />
                    <asp:TextBox ID="textBoxTemperatureInsert" runat="server" Width="25%" placeholder="insert number"></asp:TextBox>
                    <asp:TextBox ID="textBoxResult" runat="server" Width="25%" Visible="false"></asp:TextBox>
                </div>

                <!-- Speed -->
                <div class="col-md-6" style="padding: 5px; border-style: dashed; border-width: thick;">
                    <div style="width: 100%; text-align: center; background-color: #CCCCCC;">
                        <h3>Speed Converter </h3>
                    </div>
                    <asp:DropDownList ID="dropDownListSpeedFrom" runat="server" Width="25%"></asp:DropDownList>
                    <asp:Image runat="server" ImageUrl="~/convertTo trans.png" Width="25%" Height="25%" />
                    <asp:DropDownList ID="dropDownListSpeedTo" runat="server" Width="25%"></asp:DropDownList>
                    <asp:Button ID="Button2" runat="server" Text="OK" Width="20%" OnClick="SpeedConverter" />
                    <asp:TextBox ID="textBoxSpeedInsert" runat="server" Width="25%" placeholder="insert number"></asp:TextBox>
                    <asp:TextBox ID="textBoxSpeedResult" runat="server" Width="25%" Visible="false"></asp:TextBox>
                </div>
            </div>

            <!-- Weight -->
            <div class="row">
                <div class="col-md-6" style="padding: 5px; border-style: dashed; border-width: thick;">
                    <div style="width: 100%; text-align: center; background-color: #CCCCCC;">
                        <h3>Weight Converter </h3>
                    </div>
                    <asp:DropDownList ID="dropDownListWeightFrom" runat="server" Width="25%"></asp:DropDownList>
                    <asp:Image runat="server" ImageUrl="~/convertTo trans.png" Width="25%" Height="25%" />
                    <asp:DropDownList ID="dropDownListWeightTo" runat="server" Width="25%"></asp:DropDownList>
                    <asp:Button ID="Button3" runat="server" Text="OK" Width="20%" OnClick="WeightConverter" />
                    <asp:TextBox ID="textBoxWeightInsert" runat="server" Width="25%" placeholder="insert number"></asp:TextBox>
                    <asp:TextBox ID="textBoxWeightResult" runat="server" Width="25%" Visible="false"></asp:TextBox>
                </div>

                <!-- Computer Unit -->
                <div class="col-md-6" style="padding: 5px; border-style: dashed; border-width: thick;">
                    <div style="width: 100%; text-align: center; background-color: #CCCCCC;">
                        <h3>Computer Unit Converter </h3>
                    </div>
                    <asp:DropDownList ID="dropDownListComputerFrom" runat="server" Width="25%"></asp:DropDownList>
                    <asp:Image runat="server" ImageUrl="~/convertTo trans.png" Width="25%" Height="25%" />
                    <asp:DropDownList ID="dropDownListComputerTo" runat="server" Width="25%"></asp:DropDownList>
                    <asp:Button ID="Button4" runat="server" Text="OK" Width="20%" OnClick="ComputerUnitConverter" />
                    <asp:TextBox ID="textBoxComputerInsert" runat="server" Width="25%" placeholder="insert number"></asp:TextBox>
                    <asp:TextBox ID="textBoxComputerResult" runat="server" Width="25%" Visible="false"></asp:TextBox>
                </div>
            </div>



        </div>
    </form>
</body>
</html>
