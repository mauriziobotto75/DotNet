<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default2.aspx.cs" Inherits="Lezione5.Default2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Collections & Generics</title>
    
    <link href="css/main.css" rel="stylesheet" type="text/css" media="screen" />
    <script type="text/javascript" src="js/jquery-1.9.1.js"></script>
    <script type="text/javascript" src="js/jquery-ui-1.10.3.custom.js"></script>
    <script type="text/javascript" src="js/main.js"></script>
    <script type="text/javascript">
        function iniziale() {
            var ListaCucina = "<%=lcSerialized%>";
            var ListaBar = "<%=lbSerialized%>";
            var jsonLC = "<%=jsonLC%>";
            var jsonLB = "<%=jsonLB%>";
            inizializza(ListaCucina, ListaBar, jsonLC, jsonLB);
        }
    </script>
</head>
<body onload="iniziale();" style="background-image: url('img/pizzeria.jpg');">
    <input type="hidden" id ="ListaCucinaId" />
    <form id="form1" runat="server">
    <div style="font-size: 8px;">
        <h2>Gestione Ristorante</h2>
            <div class="menu_simple">
                <ul>
                    <li onclick="eseguiApp(1);"><a href="#">Ordini al Tavolo</a></li>
                    <li onclick="eseguiApp(2);"><a href="#">Cucina</a></li>
                    <li onclick="eseguiApp(3);"><a href="#">Bar</a></li>
                    <li onclick="eseguiApp(4);"><a href="#">Cassa</a></li>
                    <li onclick="eseguiApp(5);"><a href="#">Chiusura</a></li>
                    <li onclick="terminaApp();"><a href="#">Uscita</a></li>
                </ul>
                <br />
            </div>
            <div class="main_div">
                <div id="ordini_div" style="display: none; background-color: aquamarine;">
                    <h2>Ordini</h2>

                    <table id="tab_tavolo">
                        <tr>
                            <td>Tavolo :</td>
                            <td>
                                <select id="sel_tavolo" class="small_font" onchange="checkOrdine();">
                                    <option value="0"></option>
                                </select>
                            </td>
                        </tr>
                    </table>
                    
                    <table id="ordinazione">
                        <tr>
                            <td>Cucina</td><td>Bar</td><td>Quantità</td>
                        </tr>
                    </table>
                    
                    <table>
                        <tr  class="small_font">
                            <td>Pizza</td>
                            <td>
                                <select id="sel_prodotto" class="small_font" onchange="checkOrdine();">
                                    <option value="0"></option>
                                </select>
                            </td>
                            <td>Bevanda</td>
                            <td>
                                <select id="sel_bevanda" class="small_font" onchange="checkOrdine();">
                                    <option value="0"></option>
                                </select>
                            </td>
                            <td>Quantità</td>
                            <td>
                                <select id="sel_quantita" class="small_font">
                                    <option value="0"></option>
                                </select>

                            </td>
                            <td>
                                <input type="button" class="small_font" value="Aggiungi" id="btnAddRiga" onclick="aggiungiOrdine();"/>
                            </td>
                            <td>
                                <input type="button" class="small_font" value="Accetta" id="btnAccOrdine" onclick="accettaOrdine();"/>
                            </td>
                        </tr>
                    </table>
                </div>
                <div id="cucina_div" style="display: none; background-color: lightblue;">
                    <h2>Cucina</h2>
                    <table id="ordiniCucina">
                        <tr>
                            <td>Tavolo</td><td>Ordinazione</td><td>Quantità</td><td>Stato</td>
                        </tr>
                    </table>
                </div>
                <div id="bar_div" style="display: none; background-color: blueviolet;">
                    <h2>Bar</h2>
                    <table id="ordiniBar">
                        <tr>
                            <td>Tavolo</td><td>Ordinazione</td><td>Quantità</td><td>Stato</td>
                        </tr>
                    </table>
                </div>
                <div id="cassa_div" style="display: none; background-color: burlywood;">
                    <h2>Cassa</h2>
                    <table id="cassa_tavolo">
                        <tr>
                            <td>Tavolo :</td>
                            <td>
                                <select id="c_tavolo" class="small_font" onchange="displayOrdini(4);">
                                    <option value="0"></option>
                                </select>
                            </td>
                        </tr>
                    </table>
                    <table id="ordiniTavolo">
                        <tr>
                            <td>Ordinazione</td><td>Quantità</td><td>Prezzo Unitario</td><td>Prezzo Totale</td>
                        </tr>
                    </table>
                </div>
                <div id="chiusura_div" style="display: none; background-color: coral;">
                    <h2>Chiusura</h2>
                </div>
            </div>
    </div>
    </form>
</body>
</html>
