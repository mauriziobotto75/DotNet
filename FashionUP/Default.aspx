<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="FashionUP.DefaultPage" %>

<!DOCTYPE html>
<html lang="it">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>FashionUP | Gestione aziendale</title>
    <link rel="stylesheet" href="Content/site.css" />
</head>
<body>
    <form id="form1" runat="server">
        <header class="topbar">
            <h1>FashionUP</h1>
            <p>Articoli, varianti, documenti commerciali e magazzino</p>
        </header>
        <main class="shell">
            <nav class="navigation" aria-label="Sezioni">
                <asp:LinkButton ID="NavProducts" runat="server" CssClass="nav-button" OnClick="NavProducts_Click">Articoli e varianti</asp:LinkButton>
                <asp:LinkButton ID="NavParties" runat="server" CssClass="nav-button" OnClick="NavParties_Click">Clienti e fornitori</asp:LinkButton>
                <asp:LinkButton ID="NavDocuments" runat="server" CssClass="nav-button" OnClick="NavDocuments_Click">Documenti</asp:LinkButton>
                <asp:LinkButton ID="NavStock" runat="server" CssClass="nav-button" OnClick="NavStock_Click">Magazzino</asp:LinkButton>
                <asp:LinkButton ID="NavPrices" runat="server" CssClass="nav-button" OnClick="NavPrices_Click">Listini</asp:LinkButton>
                <asp:LinkButton ID="NavStatistics" runat="server" CssClass="nav-button" OnClick="NavStatistics_Click">Statistiche</asp:LinkButton>
                <asp:LinkButton ID="NavBarcode" runat="server" CssClass="nav-button" OnClick="NavBarcode_Click">Barcode</asp:LinkButton>
            </nav>
            <asp:Label ID="Message" runat="server" EnableViewState="false" />
            <asp:MultiView ID="Sections" runat="server" ActiveViewIndex="0">
                <asp:View ID="ProductsView" runat="server">
                    <section class="panel">
                        <h2>Nuovo articolo padre</h2>
                        <p class="muted">Codifica l'articolo una sola volta: le taglie e i colori si gestiscono come varianti.</p>
                        <div class="form-grid">
                            <div class="field"><label for="ArticleCode">Codice articolo</label><asp:TextBox ID="ArticleCode" runat="server" MaxLength="40" /></div>
                            <div class="field"><label for="ArticleDescription">Descrizione</label><asp:TextBox ID="ArticleDescription" runat="server" MaxLength="200" /></div>
                            <div class="field"><label for="Brand">Marca</label><asp:TextBox ID="Brand" runat="server" MaxLength="80" /></div>
                            <div class="field"><label for="Season">Stagione</label><asp:TextBox ID="Season" runat="server" MaxLength="30" /></div>
                            <div class="field"><label for="BaseSalePrice">Prezzo vendita base</label><asp:TextBox ID="BaseSalePrice" runat="server" Text="0" /></div>
                        </div>
                        <div class="actions"><asp:Button ID="CreateArticle" runat="server" Text="Crea articolo" CssClass="button button-primary" OnClick="CreateArticle_Click" /></div>
                    </section>
                    <section class="panel">
                        <h2>Nuova variante</h2>
                        <div class="form-grid">
                            <div class="field"><label for="VariantArticleCode">Codice articolo padre</label><asp:TextBox ID="VariantArticleCode" runat="server" MaxLength="40" /></div>
                            <div class="field"><label for="VariantCode">Codice variante / SKU</label><asp:TextBox ID="VariantCode" runat="server" MaxLength="60" /></div>
                            <div class="field"><label for="SizeCode">Taglia (facoltativa)</label><asp:TextBox ID="SizeCode" runat="server" MaxLength="30" /></div>
                            <div class="field"><label for="ColorName">Colore (facoltativo)</label><asp:TextBox ID="ColorName" runat="server" MaxLength="60" /></div>
                        </div>
                        <div class="actions"><asp:Button ID="CreateVariant" runat="server" Text="Crea variante" CssClass="button button-primary" OnClick="CreateVariant_Click" /></div>
                    </section>
                    <section class="panel">
                        <h2>Catalogo articoli e varianti</h2>
                        <div class="grid-wrap"><asp:GridView ID="ProductsGrid" runat="server" CssClass="data-grid" GridLines="None" AutoGenerateColumns="true" EmptyDataText="Nessuna variante presente." /></div>
                    </section>
                </asp:View>

                <asp:View ID="PartiesView" runat="server">
                    <section class="panel">
                        <h2>Nuovo cliente o fornitore</h2>
                        <div class="form-grid">
                            <div class="field"><label for="PartyCode">Codice</label><asp:TextBox ID="PartyCode" runat="server" MaxLength="30" /></div>
                            <div class="field"><label for="PartyRole">Ruolo (C, F oppure E)</label><asp:DropDownList ID="PartyRole" runat="server"><asp:ListItem Value="C">Cliente</asp:ListItem><asp:ListItem Value="F">Fornitore</asp:ListItem><asp:ListItem Value="E">Entrambi</asp:ListItem></asp:DropDownList></div>
                            <div class="field"><label for="CompanyName">Ragione sociale</label><asp:TextBox ID="CompanyName" runat="server" MaxLength="200" /></div>
                            <div class="field"><label for="TaxCode">Codice fiscale / P.IVA</label><asp:TextBox ID="TaxCode" runat="server" MaxLength="30" /></div>
                            <div class="field"><label for="Email">Email</label><asp:TextBox ID="Email" runat="server" MaxLength="254" /></div>
                            <div class="field"><label for="Phone">Telefono</label><asp:TextBox ID="Phone" runat="server" MaxLength="40" /></div>
                        </div>
                        <div class="actions"><asp:Button ID="CreateParty" runat="server" Text="Crea anagrafica" CssClass="button button-primary" OnClick="CreateParty_Click" /></div>
                    </section>
                    <section class="panel"><h2>Clienti e fornitori</h2><div class="grid-wrap"><asp:GridView ID="PartiesGrid" runat="server" CssClass="data-grid" GridLines="None" AutoGenerateColumns="true" EmptyDataText="Nessuna anagrafica presente." /></div></section>
                </asp:View>

                <asp:View ID="DocumentsView" runat="server">
                    <section class="panel">
                        <h2>Nuovo documento</h2>
                        <div class="form-grid">
                            <div class="field"><label for="DocumentType">Tipo</label><asp:DropDownList ID="DocumentType" runat="server"><asp:ListItem Value="V">Vendita</asp:ListItem><asp:ListItem Value="A">Acquisto</asp:ListItem></asp:DropDownList></div>
                            <div class="field"><label for="DocumentPartyId">ID cliente/fornitore</label><asp:TextBox ID="DocumentPartyId" runat="server" /></div>
                            <div class="field"><label for="DocumentNumber">Numero documento</label><asp:TextBox ID="DocumentNumber" runat="server" MaxLength="40" /></div>
                            <div class="field"><label for="DocumentDate">Data</label><asp:TextBox ID="DocumentDate" runat="server" TextMode="Date" /></div>
                            <div class="field"><label for="DocumentWarehouseId">ID deposito</label><asp:TextBox ID="DocumentWarehouseId" runat="server" Text="1" /></div>
                        </div>
                        <div class="actions"><asp:Button ID="CreateDocument" runat="server" Text="Crea bozza" CssClass="button button-primary" OnClick="CreateDocument_Click" /></div>
                    </section>
                    <section class="panel">
                        <h2>Aggiungi riga alla bozza</h2>
                        <div class="form-grid">
                            <div class="field"><label for="LineDocumentId">ID documento</label><asp:TextBox ID="LineDocumentId" runat="server" /></div>
                            <div class="field"><label for="LineVariantId">ID variante</label><asp:TextBox ID="LineVariantId" runat="server" /></div>
                            <div class="field"><label for="LineQuantity">Quantità</label><asp:TextBox ID="LineQuantity" runat="server" Text="1" /></div>
                            <div class="field"><label for="LineUnitPrice">Prezzo unitario</label><asp:TextBox ID="LineUnitPrice" runat="server" Text="0" /></div>
                        </div>
                        <div class="actions">
                            <asp:Button ID="AddLine" runat="server" Text="Aggiungi riga" CssClass="button" OnClick="AddLine_Click" />
                            <asp:Button ID="PostDocument" runat="server" Text="Registra documento e aggiorna scorte" CssClass="button button-primary" OnClick="PostDocument_Click" />
                        </div>
                    </section>
                    <section class="panel"><h2>Documenti</h2><p class="muted">Le bozze non movimentano il magazzino; la registrazione è atomica e le vendite oltre la giacenza sono bloccate.</p><div class="grid-wrap"><asp:GridView ID="DocumentsGrid" runat="server" CssClass="data-grid" GridLines="None" AutoGenerateColumns="true" EmptyDataText="Nessun documento presente." /></div></section>
                </asp:View>

                <asp:View ID="StockView" runat="server">
                    <section class="panel">
                        <h2>Rettifica inventario</h2>
                        <div class="form-grid">
                            <div class="field"><label for="StockVariantId">ID variante</label><asp:TextBox ID="StockVariantId" runat="server" /></div>
                            <div class="field"><label for="StockWarehouseId">ID deposito</label><asp:TextBox ID="StockWarehouseId" runat="server" Text="1" /></div>
                            <div class="field"><label for="StockDelta">Quantità (+ carico / - scarico)</label><asp:TextBox ID="StockDelta" runat="server" /></div>
                            <div class="field"><label for="StockReason">Causale</label><asp:TextBox ID="StockReason" runat="server" Text="Rettifica inventario" MaxLength="200" /></div>
                        </div>
                        <div class="actions"><asp:Button ID="AdjustStock" runat="server" Text="Registra rettifica" CssClass="button button-primary" OnClick="AdjustStock_Click" /></div>
                    </section>
                    <section class="panel"><h2>Giacenze per variante e deposito</h2><div class="grid-wrap"><asp:GridView ID="StockGrid" runat="server" CssClass="data-grid" GridLines="None" AutoGenerateColumns="true" EmptyDataText="Nessuna variante o deposito presente." /></div></section>
                </asp:View>

                <asp:View ID="PricesView" runat="server">
                    <section class="panel">
                        <h2>Nuovo listino</h2>
                        <div class="form-grid">
                            <div class="field"><label for="ListName">Nome listino</label><asp:TextBox ID="ListName" runat="server" MaxLength="80" /></div>
                            <div class="field"><label for="CurrencyCode">Valuta ISO</label><asp:TextBox ID="CurrencyCode" runat="server" Text="EUR" MaxLength="3" /></div>
                            <div class="field"><label for="ValidFrom">Valido dal</label><asp:TextBox ID="ValidFrom" runat="server" TextMode="Date" /></div>
                            <div class="field"><label for="ValidTo">Valido al (facoltativo)</label><asp:TextBox ID="ValidTo" runat="server" TextMode="Date" /></div>
                        </div>
                        <div class="actions"><asp:Button ID="CreatePriceList" runat="server" Text="Crea listino" CssClass="button button-primary" OnClick="CreatePriceList_Click" /></div>
                    </section>
                    <section class="panel">
                        <h2>Prezzo per variante</h2>
                        <div class="form-grid">
                            <div class="field"><label for="PriceListId">ID listino</label><asp:TextBox ID="PriceListId" runat="server" /></div>
                            <div class="field"><label for="PriceVariantId">ID variante</label><asp:TextBox ID="PriceVariantId" runat="server" /></div>
                            <div class="field"><label for="VariantPrice">Prezzo unitario</label><asp:TextBox ID="VariantPrice" runat="server" Text="0" /></div>
                        </div>
                        <div class="actions"><asp:Button ID="SetPrice" runat="server" Text="Salva prezzo" CssClass="button" OnClick="SetPrice_Click" /></div>
                    </section>
                    <section class="panel"><h2>Listini e prezzi</h2><div class="grid-wrap"><asp:GridView ID="PricesGrid" runat="server" CssClass="data-grid" GridLines="None" AutoGenerateColumns="true" EmptyDataText="Nessun listino presente." /></div></section>
                </asp:View>

                <asp:View ID="StatisticsView" runat="server">
                    <section class="panel"><h2>Statistiche vendite</h2><p class="muted">Quantità e importi mensili delle sole vendite registrate, distinti per variante.</p><div class="grid-wrap"><asp:GridView ID="StatisticsGrid" runat="server" CssClass="data-grid" GridLines="None" AutoGenerateColumns="true" EmptyDataText="Nessuna vendita registrata." /></div></section>
                </asp:View>

                <asp:View ID="BarcodeView" runat="server">
                    <section class="panel">
                        <h2>Associa barcode a una variante</h2>
                        <div class="form-grid">
                            <div class="field"><label for="BarcodeVariantId">ID variante</label><asp:TextBox ID="BarcodeVariantId" runat="server" /></div>
                            <div class="field"><label for="BarcodeValue">Barcode</label><asp:TextBox ID="BarcodeValue" runat="server" MaxLength="80" /></div>
                        </div>
                        <div class="actions"><asp:Button ID="AssignBarcode" runat="server" Text="Associa barcode" CssClass="button button-primary" OnClick="AssignBarcode_Click" /></div>
                    </section>
                    <section class="panel">
                        <h2>Ricerca barcode</h2>
                        <div class="form-grid"><div class="field"><label for="BarcodeSearchValue">Codice letto o scansionato</label><asp:TextBox ID="BarcodeSearchValue" runat="server" MaxLength="80" /></div></div>
                        <div class="actions"><asp:Button ID="SearchBarcode" runat="server" Text="Cerca" CssClass="button" OnClick="SearchBarcode_Click" /></div>
                        <div class="grid-wrap"><asp:GridView ID="BarcodeGrid" runat="server" CssClass="data-grid" GridLines="None" AutoGenerateColumns="true" EmptyDataText="Nessun risultato: inviare un codice barcode per iniziare la ricerca." /></div>
                    </section>
                </asp:View>
            </asp:MultiView>
            <footer class="footer">FashionUP · base WebForms per articoli, taglie/colori e gestione aziendale.</footer>
        </main>
    </form>
</body>
</html>
