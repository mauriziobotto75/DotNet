using System;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FashionUP
{
    public partial class DefaultPage : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DocumentDate.Text = DateTime.Today.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
                ValidFrom.Text = DateTime.Today.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
                try
                {
                    LoadProducts();
                }
                catch (Exception exception)
                {
                    ShowError(exception);
                }
            }
        }

        protected void NavProducts_Click(object sender, EventArgs e) { SelectSection(0, LoadProducts); }
        protected void NavParties_Click(object sender, EventArgs e) { SelectSection(1, LoadParties); }
        protected void NavDocuments_Click(object sender, EventArgs e) { SelectSection(2, LoadDocuments); }
        protected void NavStock_Click(object sender, EventArgs e) { SelectSection(3, LoadStock); }
        protected void NavPrices_Click(object sender, EventArgs e) { SelectSection(4, LoadPrices); }
        protected void NavStatistics_Click(object sender, EventArgs e) { SelectSection(5, LoadStatistics); }
        protected void NavBarcode_Click(object sender, EventArgs e) { SelectSection(6, LoadBarcode); }

        protected void CreateArticle_Click(object sender, EventArgs e)
        {
            Run(delegate
            {
                FashionUpDb.Execute(
                    "INSERT dbo.Articles (ArticleCode, Description, Brand, Season, BaseSalePrice) VALUES (@code, @description, @brand, @season, @price);",
                    FashionUpDb.Parameter("@code", SqlDbType.NVarChar, Required(ArticleCode.Text, "Codice articolo"), 40),
                    FashionUpDb.Parameter("@description", SqlDbType.NVarChar, Required(ArticleDescription.Text, "Descrizione"), 200),
                    FashionUpDb.Parameter("@brand", SqlDbType.NVarChar, Optional(Brand.Text), 80),
                    FashionUpDb.Parameter("@season", SqlDbType.NVarChar, Optional(Season.Text), 30),
                    FashionUpDb.Decimal("@price", ParseMoney(BaseSalePrice.Text, "Prezzo base"), 2));
                LoadProducts();
            });
        }

        protected void CreateVariant_Click(object sender, EventArgs e)
        {
            Run(delegate
            {
                FashionUpDb.ExecuteProcedure("dbo.usp_CreateVariant",
                    FashionUpDb.Parameter("@ArticleCode", SqlDbType.NVarChar, Required(VariantArticleCode.Text, "Codice articolo padre"), 40),
                    FashionUpDb.Parameter("@VariantCode", SqlDbType.NVarChar, Required(VariantCode.Text, "Codice variante"), 60),
                    FashionUpDb.Parameter("@SizeCode", SqlDbType.NVarChar, Optional(SizeCode.Text), 30),
                    FashionUpDb.Parameter("@ColorName", SqlDbType.NVarChar, Optional(ColorName.Text), 60));
                LoadProducts();
            });
        }

        protected void CreateParty_Click(object sender, EventArgs e)
        {
            Run(delegate
            {
                FashionUpDb.Execute(
                    "INSERT dbo.Parties (PartyCode, Role, CompanyName, TaxCode, Email, Phone) VALUES (@code, @role, @name, @tax, @email, @phone);",
                    FashionUpDb.Parameter("@code", SqlDbType.NVarChar, Required(PartyCode.Text, "Codice"), 30),
                    FashionUpDb.Parameter("@role", SqlDbType.Char, PartyRole.SelectedValue, 1),
                    FashionUpDb.Parameter("@name", SqlDbType.NVarChar, Required(CompanyName.Text, "Ragione sociale"), 200),
                    FashionUpDb.Parameter("@tax", SqlDbType.NVarChar, Optional(TaxCode.Text), 30),
                    FashionUpDb.Parameter("@email", SqlDbType.NVarChar, Optional(Email.Text), 254),
                    FashionUpDb.Parameter("@phone", SqlDbType.NVarChar, Optional(Phone.Text), 40));
                LoadParties();
            });
        }

        protected void CreateDocument_Click(object sender, EventArgs e)
        {
            Run(delegate
            {
                FashionUpDb.Execute(
                    "INSERT dbo.Documents (DocumentType, DocumentNumber, DocumentDate, PartyId, WarehouseId) VALUES (@type, @number, @date, @party, @warehouse);",
                    FashionUpDb.Parameter("@type", SqlDbType.Char, DocumentType.SelectedValue, 1),
                    FashionUpDb.Parameter("@number", SqlDbType.NVarChar, Required(DocumentNumber.Text, "Numero documento"), 40),
                    FashionUpDb.Parameter("@date", SqlDbType.Date, ParseDate(DocumentDate.Text, "Data documento"), 0),
                    FashionUpDb.Parameter("@party", SqlDbType.Int, ParseId(DocumentPartyId.Text, "ID cliente/fornitore"), 0),
                    FashionUpDb.Parameter("@warehouse", SqlDbType.Int, ParseId(DocumentWarehouseId.Text, "ID deposito"), 0));
                LoadDocuments();
            });
        }

        protected void AddLine_Click(object sender, EventArgs e)
        {
            Run(delegate
            {
                FashionUpDb.ExecuteProcedure("dbo.usp_AddDocumentLine",
                    FashionUpDb.Parameter("@DocumentId", SqlDbType.Int, ParseId(LineDocumentId.Text, "ID documento"), 0),
                    FashionUpDb.Parameter("@VariantId", SqlDbType.Int, ParseId(LineVariantId.Text, "ID variante"), 0),
                    FashionUpDb.Decimal("@Quantity", ParseQuantity(LineQuantity.Text), 3),
                    FashionUpDb.Decimal("@UnitPrice", ParseMoney(LineUnitPrice.Text, "Prezzo unitario"), 2));
                LoadDocuments();
            });
        }

        protected void PostDocument_Click(object sender, EventArgs e)
        {
            Run(delegate
            {
                FashionUpDb.ExecuteProcedure("dbo.usp_PostDocument",
                    FashionUpDb.Parameter("@DocumentId", SqlDbType.Int, ParseId(LineDocumentId.Text, "ID documento"), 0));
                LoadDocuments();
                LoadStock();
            });
        }

        protected void AdjustStock_Click(object sender, EventArgs e)
        {
            Run(delegate
            {
                decimal delta = ParseSignedQuantity(StockDelta.Text);
                FashionUpDb.ExecuteProcedure("dbo.usp_AdjustStock",
                    FashionUpDb.Parameter("@VariantId", SqlDbType.Int, ParseId(StockVariantId.Text, "ID variante"), 0),
                    FashionUpDb.Parameter("@WarehouseId", SqlDbType.Int, ParseId(StockWarehouseId.Text, "ID deposito"), 0),
                    FashionUpDb.Decimal("@QuantityDelta", delta, 3),
                    FashionUpDb.Parameter("@Reason", SqlDbType.NVarChar, Required(StockReason.Text, "Causale"), 200));
                LoadStock();
            });
        }

        protected void CreatePriceList_Click(object sender, EventArgs e)
        {
            Run(delegate
            {
                DateTime? validTo = String.IsNullOrWhiteSpace(ValidTo.Text)
                    ? (DateTime?)null
                    : ParseDate(ValidTo.Text, "Data fine validita");
                FashionUpDb.Execute(
                    "INSERT dbo.PriceLists (ListName, CurrencyCode, ValidFrom, ValidTo) VALUES (@name, @currency, @from, @to);",
                    FashionUpDb.Parameter("@name", SqlDbType.NVarChar, Required(ListName.Text, "Nome listino"), 80),
                    FashionUpDb.Parameter("@currency", SqlDbType.Char, Required(CurrencyCode.Text, "Valuta").ToUpperInvariant(), 3),
                    FashionUpDb.Parameter("@from", SqlDbType.Date, ParseDate(ValidFrom.Text, "Data inizio validita"), 0),
                    FashionUpDb.Parameter("@to", SqlDbType.Date, validTo.HasValue ? (object)validTo.Value : null, 0));
                LoadPrices();
            });
        }

        protected void SetPrice_Click(object sender, EventArgs e)
        {
            Run(delegate
            {
                FashionUpDb.ExecuteProcedure("dbo.usp_SetVariantPrice",
                    FashionUpDb.Parameter("@PriceListId", SqlDbType.Int, ParseId(PriceListId.Text, "ID listino"), 0),
                    FashionUpDb.Parameter("@VariantId", SqlDbType.Int, ParseId(PriceVariantId.Text, "ID variante"), 0),
                    FashionUpDb.Decimal("@UnitPrice", ParseMoney(VariantPrice.Text, "Prezzo"), 2));
                LoadPrices();
            });
        }

        protected void AssignBarcode_Click(object sender, EventArgs e)
        {
            Run(delegate
            {
                FashionUpDb.Execute(
                    "INSERT dbo.Barcodes (VariantId, Barcode) VALUES (@variant, @barcode);",
                    FashionUpDb.Parameter("@variant", SqlDbType.Int, ParseId(BarcodeVariantId.Text, "ID variante"), 0),
                    FashionUpDb.Parameter("@barcode", SqlDbType.NVarChar, Required(BarcodeValue.Text, "Barcode"), 80));
                LoadProducts();
                LoadBarcode();
            });
        }

        protected void SearchBarcode_Click(object sender, EventArgs e)
        {
            Run(delegate
            {
                Bind(BarcodeGrid,
                    "SELECT Barcode, ArticleCode, ArticleDescription, VariantCode, SizeName, ColorName FROM dbo.v_VariantCatalog WHERE Barcode = @barcode;",
                    FashionUpDb.Parameter("@barcode", SqlDbType.NVarChar, Required(BarcodeSearchValue.Text, "Barcode da cercare"), 80));
            });
        }

        private void SelectSection(int index, Action loader)
        {
            Sections.ActiveViewIndex = index;
            Run(loader);
        }

        private void Run(Action operation)
        {
            Message.Text = String.Empty;
            Message.CssClass = String.Empty;
            try
            {
                operation();
                ShowSuccess("Operazione completata.");
            }
            catch (Exception exception)
            {
                ShowError(exception);
            }
        }

        private void ShowSuccess(string text)
        {
            Message.CssClass = "message";
            Message.Text = Server.HtmlEncode(text);
        }

        private void ShowError(Exception exception)
        {
            Message.CssClass = "message message-error";
            Message.Text = Server.HtmlEncode("Operazione non riuscita: " + exception.Message);
        }

        private static string Required(string value, string label)
        {
            if (String.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Il campo '" + label + "' e obbligatorio.");
            return value.Trim();
        }

        private static object Optional(string value)
        {
            return String.IsNullOrWhiteSpace(value) ? null : (object)value.Trim();
        }

        private static int ParseId(string value, string label)
        {
            int result;
            if (!Int32.TryParse(value, NumberStyles.Integer, CultureInfo.CurrentCulture, out result) || result <= 0)
                throw new ArgumentException("Inserire un " + label + " numerico positivo.");
            return result;
        }

        private static decimal ParseMoney(string value, string label)
        {
            decimal result;
            if (!Decimal.TryParse(value, NumberStyles.Number, CultureInfo.CurrentCulture, out result) || result < 0)
                throw new ArgumentException("Inserire un importo valido e non negativo per '" + label + "'.");
            return result;
        }

        private static decimal ParseQuantity(string value)
        {
            decimal result;
            if (!Decimal.TryParse(value, NumberStyles.Number, CultureInfo.CurrentCulture, out result) || result <= 0)
                throw new ArgumentException("Inserire una quantita valida maggiore di zero.");
            return result;
        }

        private static decimal ParseSignedQuantity(string value)
        {
            decimal result;
            if (!Decimal.TryParse(value, NumberStyles.Number | NumberStyles.AllowLeadingSign, CultureInfo.CurrentCulture, out result) || result == 0)
                throw new ArgumentException("Inserire una quantita valida diversa da zero.");
            return result;
        }

        private static DateTime ParseDate(string value, string label)
        {
            DateTime result;
            if (!DateTime.TryParseExact(value, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out result))
                throw new ArgumentException("Inserire '" + label + "' nel formato AAAA-MM-GG.");
            return result;
        }

        private void Bind(GridView grid, string sql, params SqlParameter[] parameters)
        {
            grid.DataSource = FashionUpDb.Query(sql, parameters);
            grid.DataBind();
        }

        private void LoadProducts()
        {
            Bind(ProductsGrid, "SELECT * FROM dbo.v_VariantCatalog ORDER BY ArticleCode, SizeSortOrder, ColorName;");
        }

        private void LoadParties()
        {
            Bind(PartiesGrid, "SELECT PartyId, PartyCode, Role, CompanyName, TaxCode, Email, Phone, IsActive FROM dbo.Parties ORDER BY CompanyName;");
        }

        private void LoadDocuments()
        {
            Bind(DocumentsGrid, "SELECT DocumentId, DocumentType, DocumentNumber, DocumentDate, CompanyName, Status, TotalAmount FROM dbo.v_DocumentSummary ORDER BY DocumentDate DESC, DocumentId DESC;");
        }

        private void LoadStock()
        {
            Bind(StockGrid, "SELECT * FROM dbo.v_Stock ORDER BY WarehouseName, ArticleCode, VariantCode;");
        }

        private void LoadPrices()
        {
            Bind(PricesGrid, "SELECT p.PriceListId, p.ListName, p.CurrencyCode, p.ValidFrom, p.ValidTo, v.ArticleCode, v.VariantCode, v.SizeName, v.ColorName, l.UnitPrice FROM dbo.PriceLists p LEFT JOIN dbo.PriceListLines l ON l.PriceListId = p.PriceListId LEFT JOIN dbo.Variants v ON v.VariantId = l.VariantId ORDER BY p.ListName, v.ArticleCode, v.VariantCode;");
        }

        private void LoadStatistics()
        {
            Bind(StatisticsGrid, "SELECT * FROM dbo.v_SalesStatistics ORDER BY SalesMonth DESC, ArticleCode, VariantCode;");
        }

        private void LoadBarcode()
        {
            Bind(BarcodeGrid, "SELECT TOP (0) Barcode, ArticleCode, ArticleDescription, VariantCode, SizeName, ColorName FROM dbo.v_VariantCatalog;");
        }
    }
}
