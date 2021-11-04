Public Class GesCorsi
    Inherits System.Web.UI.Page

#Region " Codice generato da Progettazione Web Form "

    'Chiamata richiesta da Progettazione Web Form.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents txtNomeCorso As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label3 As System.Web.UI.WebControls.Label
    Protected WithEvents txtDescrizioneCorso As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label4 As System.Web.UI.WebControls.Label
    Protected WithEvents txtNumeroPosti As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label5 As System.Web.UI.WebControls.Label
    Protected WithEvents Label6 As System.Web.UI.WebControls.Label
    Protected WithEvents Label7 As System.Web.UI.WebControls.Label
    Protected WithEvents Label8 As System.Web.UI.WebControls.Label
    Protected WithEvents btnAggiungi As System.Web.UI.WebControls.Button
    Protected WithEvents txtNumeroProfessori As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtCostoCorso As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtIdMateriale As System.Web.UI.WebControls.TextBox
    Protected WithEvents RangeValidator1 As System.Web.UI.WebControls.RangeValidator
    Protected WithEvents RangeValidator2 As System.Web.UI.WebControls.RangeValidator
    Protected WithEvents RangeValidator3 As System.Web.UI.WebControls.RangeValidator
    Protected WithEvents RangeValidator4 As System.Web.UI.WebControls.RangeValidator
    Protected WithEvents ValidationSummary4 As System.Web.UI.WebControls.ValidationSummary
    Protected WithEvents RangeValidator5 As System.Web.UI.WebControls.RangeValidator
    Protected WithEvents RangeValidator6 As System.Web.UI.WebControls.RangeValidator

    'NOTA: la seguente dichiarazione è richiesta da Progettazione Web Form.
    'Non spostarla o rimuoverla.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: questa chiamata al metodo è richiesta da Progettazione Web Form.
        'Non modificarla nell'editor del codice.
        InitializeComponent()
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Inserire qui il codice utente necessario per inizializzare la pagina
    End Sub



    Private Sub btnAggiungi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAggiungi.Click
        Dim txtIdCorso As String
        Dim strInserimento As String
        Dim oCommand As OleDb.OleDbCommand
        Dim oConnection As OleDb.OleDbConnection
        Dim stringaCon As String
        'stringaCon = "Provider = Microsoft.jet.oledb.4.0; USER ID = ADMIN; DATA SOURCE = 'C:\InetPub\wwwroot\WebApplication1\GestioneCorsi\GestioneCorsi.mdb'"

        stringaCon = ConfigurationSettings.AppSettings("ConnessioneDataBase")



        strInserimento = "INSERT INTO CORSO  (nomeCorso, descrizioneCorso, numeroPosti, numeroProfessori, costoCorso, idMateriali) "
        strInserimento = strInserimento & " VALUES ( '" & txtNomeCorso.Text & "','" & txtDescrizioneCorso.Text & "'," & txtNumeroPosti.Text & "," & txtNumeroProfessori.Text & "," & txtCostoCorso.Text & "," & txtIdMateriale.Text & ")"

        oConnection = New OleDb.OleDbConnection

        oConnection.ConnectionString = stringaCon
        oConnection.Open()
        oCommand = New OleDb.OleDbCommand(strInserimento, oConnection)
        oCommand.ExecuteNonQuery()

        oConnection.Close()


    End Sub



    '   Private Sub btnModifica_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim stringaConn As String
    '    stringaConn = ConfigurationSettings.AppSettings("ConnessioneDataBase")

    'End Sub

End Class
