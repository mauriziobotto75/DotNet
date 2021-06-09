<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Lezione5.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Collections & Generics</title>
<style>
/* CSSTerm.com Simple CSS menu */
    br { clear:left }
    .menu_simple {
        width: 100%;
        background-color: #005555;
        font-size: 8px;
    }
    .menu_simple ul {
        margin: 0; padding: 0;
        float: left;
    }
    .menu_simple ul li {
        display: inline;
    }
    .menu_simple ul li a {
        float: left; text-decoration: none;
        color: white;
        padding: 10.5px 11px;
        background-color:  #005555;
    }
    .menu_simple ul li a:visited {
        color: white;
    }
    .menu_simple ul li a:hover, .menu_simple ul li .current {
        color: white;
        background-color: #5FD367;
    }
</style>
    <script type="text/javascript">
        /*
        function terminaApp() {
            notImplementedFunction(); 
        }
        function notImplementedFunction() {
            alert("Funzionalità non ancora implementata"); 
        }
        */
        function goToStartPage() {
            //window.location.href = "Default2.aspx"; 
        }
    </script>
</head>
<body onload="goToStartPage();">
    <form id="form1" runat="server">
    <div>
        <h2>Gestione Ristorante</h2>
            <div class="menu_simple">
                <ul>
                    <li onclick="terminaApp();"><a href="#">Ordini al Tavolo</a></li>
                    <li onclick="terminaApp();"><a href="#">Cucina</a></li>
                    <li onclick="terminaApp();"><a href="#">Bar</a></li>
                    <li onclick="terminaApp();"><a href="#">Cassa</a></li>
                    <li onclick="terminaApp();"><a href="#">Chiusura</a></li>
                    <li onclick="terminaApp();"><a href="#">Uscita</a></li>
                </ul>
                <br />
            </div>
    </div>
    </form>
</body>
</html>
