Public Class GestioneLibri
    Inherits System.Web.UI.Page

#Region " Codice generato da Progettazione Web Form "

    'Chiamata richiesta da Progettazione Web Form.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents dtlLibri As System.Web.UI.WebControls.DataList
    Protected WithEvents Label5 As System.Web.UI.WebControls.Label
    Protected WithEvents cmdNuovo As System.Web.UI.WebControls.Button
    Protected WithEvents txtCodiceLibro As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblCodiceLibro As System.Web.UI.WebControls.Label
    Protected WithEvents cmdVisualizza As System.Web.UI.WebControls.Button

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
        If Page.IsPostBack = False Then
            lblCodiceLibro.Visible = True
            txtCodiceLibro.Visible = True

            If Session.Item("tipoUtente") = "Amministratore" Then
                cmdNuovo.Visible = True
                dtlLibri.Visible = False
            ElseIf Session.Item("tipoUtente") = "Dipendente" Then
                cmdNuovo.Visible = False
                dtlLibri.Visible = True
            End If
        End If

    End Sub


    Private Sub cmdNuovo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNuovo.Click


    End Sub

    Private Sub cmdVisualizza_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdVisualizza.Click
        Dim oConn As OleDb.OleDbConnection
        Dim oCommand As OleDb.OleDbCommand
        Dim dataReader As OleDb.OleDbDataReader
        Dim strConn As String

        Dim visualizzaStringa As String
        Dim sql As String

        strConn = "PROVIDER = MICROSOFT.JET.OLEDB.4.0; USER ID = ADMIN; DATA SOURCE = 'C:\InetPub\wwwroot\WebApplication1\GestioneBiblioteca\Libreria.mdb'"
        oConn = New OleDb.OleDbConnection(strConn)

        oConn.ConnectionString = strConn
        visualizzaStringa = "Select titolo, autore, disponibilità from Libro where codice = '" & txtCodiceLibro.Text & "'"

        oConn.Open()

 
        oCommand = New OleDb.OleDbCommand(visualizzaStringa, oConn)
        dataReader = oCommand.ExecuteReader()

        Do While dataReader.Read
            dtlLibri.DataSource = dataReader
            dtlLibri.DataBind()
        Loop
        oConn.Close()
    End Sub

    Private Sub dtlLibri_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataListItemEventArgs) Handles dtlLibri.ItemDataBound
        Dim AUTORE As String
        Dim DISPONIBILITA As String
        Dim TITOLO As String

        Dim lnk As LinkButton = e.Item.Controls("lnkElimina")
        Dim lnk2 As LinkButton = e.Item.Controls("lnkModifica")
        Dim SQL As String

        If lnk.CommandName() = "Elimina" Then

            Dim oCon As OleDb.OleDbConnection
            Dim oCommand As OleDb.OleDbCommand
            Dim dataReader As OleDb.OleDbDataReader

            oCon = New OleDb.OleDbConnection

            SQL = "SELECT * FROM Libro where codice = '" & txtCodiceLibro.Text & "'"
            oCommand = New OleDb.OleDbCommand(SQL, oCon)
            dataReader = oCommand.ExecuteReader

        ElseIf lnk.CommandName() = "Modifica" Then
            SQL = "UPDATE Libro SET TITOLO = '" & titolo & " AUTORE ='" & AUTORE & " DISPONIBILITA ='" & DISPONIBILITA
            'oCommand = New OleDb.OleDbCommand(SQL, oCon)

        End If

    End Sub

    Private Sub dtlLibri_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtlLibri.SelectedIndexChanged

    End Sub
End Class
