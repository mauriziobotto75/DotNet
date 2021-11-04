Public Class Entra
    Inherits System.Web.UI.Page

#Region " Codice generato da Progettazione Web Form "

    'Chiamata richiesta da Progettazione Web Form.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents txtPassword As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents Label2 As System.Web.UI.WebControls.Label
    Protected WithEvents txtUtente As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label3 As System.Web.UI.WebControls.Label
    Protected WithEvents btnEntra As System.Web.UI.WebControls.Button

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

    Private Sub btnEntra_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEntra.Click
        Dim oConn As OleDb.OleDbConnection
        Dim oCOmmand As OleDb.OleDbCommand
        Dim dataReader As OleDb.OleDbDataReader

        Dim stringaCon As String
        '     Response.Redirect("GesCalendari.aspx")
        Dim stringaSql As String

        stringaCon = ConfigurationSettings.AppSettings("ConnessioneDataBase")

        stringaSql = "SELECT * FROM tblUtenti where userid = ' " & txtUtente.Text.Trim & "' and password = ' " & txtPassword.Text.Trim & "'"
        oConn = New OleDb.OleDbConnection
        oConn.ConnectionString = stringaCon

        oConn.Open()
       
        oCOmmand = New OleDb.OleDbCommand(stringaSql, oConn)
        dataReader = oCOmmand.ExecuteReader
        If dataReader.Read = False Then
            MsgBox("Non sei registrato!Registrati")
            Response.Redirect("Registrati.asp")
        Else
            Response.Redirect("GesCorsi.asp")
        End If
        dataReader.Close()
        oConn.Close()

    End Sub
End Class
