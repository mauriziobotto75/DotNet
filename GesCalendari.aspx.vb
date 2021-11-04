Public Class GesCalendari
    Inherits System.Web.UI.Page

#Region " Codice generato da Progettazione Web Form "

    'Chiamata richiesta da Progettazione Web Form.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents Label2 As System.Web.UI.WebControls.Label
    Protected WithEvents Label3 As System.Web.UI.WebControls.Label
    Protected WithEvents txtData As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label4 As System.Web.UI.WebControls.Label
    Protected WithEvents Label5 As System.Web.UI.WebControls.Label
    Protected WithEvents dbMateria As System.Web.UI.WebControls.DropDownList
    Protected WithEvents dbDocente As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Label7 As System.Web.UI.WebControls.Label
    Protected WithEvents Label8 As System.Web.UI.WebControls.Label
    Protected WithEvents txtIdAULA As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnAggiungi As System.Web.UI.WebControls.Button
    Protected WithEvents Label6 As System.Web.UI.WebControls.Label
    Protected WithEvents txtOraInizioLezioni As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtOraFineLezioni As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtIdCorso As System.Web.UI.WebControls.TextBox

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
        'data source = data Reader
        'nel Form_load posso popolare la comboBox
        'combo.item.add(passo oggetto listItem nel load)
        'combo.items.add(new ListItem(desc, cod))
        If Page.IsPostBack = False Then

            Call carica_dbdocente()
            Call carica_dbMateria()
            'Call btnAggiungi_Click()

        End If

    End Sub

    Private Sub btnAggiungi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAggiungi.Click
        Dim txtIdCorso As String
        Dim txtIdMateriale As String
        Dim docente As String
        Dim materia As String


        Dim strInserimento As String
        Dim oCommand As OleDb.OleDbCommand
        Dim oConnection As OleDb.OleDbConnection
        Dim dataReader As OleDb.OleDbDataReader

        Dim stringaCon As String
        stringaCon = "Provider = Microsoft.jet.oledb.4.0; USER ID = ADMIN; DATA SOURCE = 'C:\InetPub\wwwroot\WebApplication1\GestioneCorsi\GestioneCorsi.mdb'"

        oConnection = New OleDb.OleDbConnection
        oConnection.ConnectionString = stringaCon

        strInserimento = "INSERT INTO Calendario ( dataCalendario, oraInizioLezione, nomeDocente, materiaDocente, idAula, oraFineLezione )"
        strInserimento = strInserimento & " VALUES ('"
        strInserimento = strInserimento & txtData.Text & "', "
        strInserimento = strInserimento & txtOraInizioLezioni.Text & ", '"
        strInserimento = strInserimento & dbDocente.SelectedItem.Text & "', '"

        strInserimento = strInserimento & dbMateria.SelectedItem.Text & "', "

        '    strInserimento = strInserimento & Val(txtIdCorso.Trim) & ", "
        strInserimento = strInserimento & txtIdAULA.Text & ","
        strInserimento = strInserimento & txtOraFineLezioni.Text & ")"


        oConnection.Open()
        oCommand = New OleDb.OleDbCommand(strInserimento, oConnection)

        oCommand.ExecuteNonQuery()

        '   dataReader.Close()
        oConnection.Close()

    End Sub
    Private Sub carica_dbdocente()


        Dim oCommand As OleDb.OleDbCommand
        Dim oConnection As OleDb.OleDbConnection
        Dim stringaCon As String
        Dim strPopolaCombo As String
        Dim strPopolaComboMateria As String


        Dim dataREader As OleDb.OleDbDataReader


        stringaCon = "Provider = Microsoft.jet.oledb.4.0; USER ID = ADMIN; DATA SOURCE = 'C:\InetPub\wwwroot\WebApplication1\GestioneCorsi\GestioneCorsi.mdb'"
        oConnection = New OleDb.OleDbConnection
        oConnection.ConnectionString = stringaCon
        oConnection.Open()
        strPopolaCombo = "SELECT NOMEDOCENTE, IDdocente FROM DOCENTE; "
        '    strPopolaComboMateria = "SELECT NOMEMATERIA, IDMATERIA FROM MATERIA; "
        oCommand = New OleDb.OleDbCommand(strPopolaCombo, oConnection)
        dataREader = oCommand.ExecuteReader()
        dbMateria.DataSource = dataREader
        Do While dataREader.Read
            dbMateria.Items.Add(New ListItem(dataREader("nomeDocente"), dataREader("idDocente")))

        Loop
        oConnection.Close()

    End Sub
    Private Sub carica_dbMateria()
 

    Dim oCommand As OleDb.OleDbCommand
    Dim oConnection As OleDb.OleDbConnection
    Dim stringaCon As String

    Dim strPopolaComboMateria As String
        Dim oCOmmand2 As OleDb.OleDbCommand


    Dim dataReader2 As OleDb.OleDbDataReader

        stringaCon = "Provider = Microsoft.jet.oledb.4.0; USER ID = ADMIN; DATA SOURCE = 'C:\InetPub\wwwroot\WebApplication1\GestioneCorsi\GestioneCorsi.mdb'"
        oConnection = New OleDb.OleDbConnection
        oConnection.ConnectionString = stringaCon
        oConnection.Open()
        strPopolaComboMateria = "SELECT  descrizioneMateria, IDMateria FROM MATERIA; "

        oCOmmand2 = New OleDb.OleDbCommand(strPopolaComboMateria, oConnection)

        dataReader2 = oCOmmand2.ExecuteReader()
        dbMateria.DataSource = dataReader2
        Do While dataReader2.Read

            dbDocente.Items.Add(New ListItem(dataReader2("descrizioneMateria"), dataReader2("idMateria")))
        Loop


        dataReader2.Close()

    End Sub

End Class

