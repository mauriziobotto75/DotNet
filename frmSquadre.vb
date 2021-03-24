Imports System.data.OleDb
Imports System.Data.SqlClient
Imports System.Windows.Forms




Public Class frmGestioneSquadre


    Inherits System.Windows.Forms.Form

#Region " Codice generato da Progettazione Windows Form "

    Public Sub New()
        MyBase.New()

        'Chiamata richiesta da Progettazione Windows Form.
        InitializeComponent()

        'Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent()

    End Sub

    'Form esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Richiesto da Progettazione Windows Form
    Private components As System.ComponentModel.IContainer

    'NOTA: la procedura che segue è richiesta da Progettazione Windows Form.
    'Può essere modificata in Progettazione Windows Form.  
    'Non modificarla nell'editor del codice.
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtSquadra As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtGiocate As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtVinte As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtPareggiate As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtPerse As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtGolFatti As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtGolSubiti As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtPunti As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtDifferenzaReti As System.Windows.Forms.TextBox
    Friend WithEvents btnPrimo As System.Windows.Forms.Button
    Friend WithEvents btnPrecedente As System.Windows.Forms.Button
    Friend WithEvents btnSuccessivo As System.Windows.Forms.Button
    Friend WithEvents btnUltimo As System.Windows.Forms.Button
    Friend WithEvents OleDbCommand1 As System.Data.OleDb.OleDbCommand
    Friend WithEvents OleDbConnection1 As System.Data.OleDb.OleDbConnection
    Friend WithEvents OleDbSelectCommand1 As System.Data.OleDb.OleDbCommand
    Friend WithEvents OleDbInsertCommand1 As System.Data.OleDb.OleDbCommand
    Friend WithEvents OleDbUpdateCommand1 As System.Data.OleDb.OleDbCommand
    Friend WithEvents OleDbDeleteCommand1 As System.Data.OleDb.OleDbCommand
    Friend WithEvents daSquadre As System.Data.OleDb.OleDbDataAdapter
    Friend WithEvents DsSquadre As GestioneSquadre.dsSquadre
    Friend WithEvents btnAggiungi As System.Windows.Forms.Button
    Friend WithEvents btnDifferenzaReti As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtSquadra = New System.Windows.Forms.TextBox
        Me.DsSquadre = New GestioneSquadre.dsSquadre
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtGiocate = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtVinte = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtPareggiate = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtPerse = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtGolFatti = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtGolSubiti = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtPunti = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtDifferenzaReti = New System.Windows.Forms.TextBox
        Me.btnPrimo = New System.Windows.Forms.Button
        Me.btnPrecedente = New System.Windows.Forms.Button
        Me.btnSuccessivo = New System.Windows.Forms.Button
        Me.btnUltimo = New System.Windows.Forms.Button
        Me.OleDbCommand1 = New System.Data.OleDb.OleDbCommand
        Me.OleDbConnection1 = New System.Data.OleDb.OleDbConnection
        Me.daSquadre = New System.Data.OleDb.OleDbDataAdapter
        Me.OleDbDeleteCommand1 = New System.Data.OleDb.OleDbCommand
        Me.OleDbInsertCommand1 = New System.Data.OleDb.OleDbCommand
        Me.OleDbSelectCommand1 = New System.Data.OleDb.OleDbCommand
        Me.OleDbUpdateCommand1 = New System.Data.OleDb.OleDbCommand
        Me.btnAggiungi = New System.Windows.Forms.Button
        Me.btnDifferenzaReti = New System.Windows.Forms.Button
        CType(Me.DsSquadre, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(8, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(112, 24)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Squadra"
        '
        'txtSquadra
        '
        Me.txtSquadra.DataBindings.Add(New System.Windows.Forms.Binding("Tag", Me.DsSquadre, "Squadre.Squadra"))
        Me.txtSquadra.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.DsSquadre, "Squadre.Squadra"))
        Me.txtSquadra.Location = New System.Drawing.Point(128, 32)
        Me.txtSquadra.Name = "txtSquadra"
        Me.txtSquadra.Size = New System.Drawing.Size(168, 20)
        Me.txtSquadra.TabIndex = 1
        Me.txtSquadra.Text = ""
        '
        'DsSquadre
        '
        Me.DsSquadre.DataSetName = "dsSquadre"
        Me.DsSquadre.Locale = New System.Globalization.CultureInfo("it-IT")
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(8, 72)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(112, 24)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Giocate"
        '
        'txtGiocate
        '
        Me.txtGiocate.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.DsSquadre, "Squadre.Giocate"))
        Me.txtGiocate.DataBindings.Add(New System.Windows.Forms.Binding("Tag", Me.DsSquadre, "Squadre.Giocate"))
        Me.txtGiocate.Location = New System.Drawing.Point(128, 72)
        Me.txtGiocate.Name = "txtGiocate"
        Me.txtGiocate.Size = New System.Drawing.Size(32, 20)
        Me.txtGiocate.TabIndex = 3
        Me.txtGiocate.Text = ""
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(8, 104)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(112, 24)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Vinte"
        '
        'txtVinte
        '
        Me.txtVinte.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.DsSquadre, "Squadre.Vinte"))
        Me.txtVinte.DataBindings.Add(New System.Windows.Forms.Binding("Tag", Me.DsSquadre, "Squadre.Vinte"))
        Me.txtVinte.Location = New System.Drawing.Point(128, 104)
        Me.txtVinte.Name = "txtVinte"
        Me.txtVinte.Size = New System.Drawing.Size(32, 20)
        Me.txtVinte.TabIndex = 5
        Me.txtVinte.Text = ""
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(8, 136)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(112, 24)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Pareggiate"
        '
        'txtPareggiate
        '
        Me.txtPareggiate.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.DsSquadre, "Squadre.Pareggiate"))
        Me.txtPareggiate.DataBindings.Add(New System.Windows.Forms.Binding("Tag", Me.DsSquadre, "Squadre.Pareggiate"))
        Me.txtPareggiate.Location = New System.Drawing.Point(128, 136)
        Me.txtPareggiate.Name = "txtPareggiate"
        Me.txtPareggiate.Size = New System.Drawing.Size(32, 20)
        Me.txtPareggiate.TabIndex = 7
        Me.txtPareggiate.Text = ""
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(8, 168)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(112, 24)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Perse"
        '
        'txtPerse
        '
        Me.txtPerse.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.DsSquadre, "Squadre.Perse"))
        Me.txtPerse.DataBindings.Add(New System.Windows.Forms.Binding("Tag", Me.DsSquadre, "Squadre.Perse"))
        Me.txtPerse.Location = New System.Drawing.Point(128, 168)
        Me.txtPerse.Name = "txtPerse"
        Me.txtPerse.Size = New System.Drawing.Size(32, 20)
        Me.txtPerse.TabIndex = 9
        Me.txtPerse.Text = ""
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(8, 200)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(112, 24)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Gol Fatti"
        '
        'txtGolFatti
        '
        Me.txtGolFatti.DataBindings.Add(New System.Windows.Forms.Binding("Tag", Me.DsSquadre, "Squadre.GolFatti"))
        Me.txtGolFatti.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.DsSquadre, "Squadre.GolFatti"))
        Me.txtGolFatti.Location = New System.Drawing.Point(128, 200)
        Me.txtGolFatti.Name = "txtGolFatti"
        Me.txtGolFatti.Size = New System.Drawing.Size(32, 20)
        Me.txtGolFatti.TabIndex = 11
        Me.txtGolFatti.Text = ""
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(8, 240)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(112, 16)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "Gol Subiti"
        '
        'txtGolSubiti
        '
        Me.txtGolSubiti.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.DsSquadre, "Squadre.GolSubiti"))
        Me.txtGolSubiti.DataBindings.Add(New System.Windows.Forms.Binding("Tag", Me.DsSquadre, "Squadre.GolSubiti"))
        Me.txtGolSubiti.Location = New System.Drawing.Point(128, 232)
        Me.txtGolSubiti.Name = "txtGolSubiti"
        Me.txtGolSubiti.Size = New System.Drawing.Size(32, 20)
        Me.txtGolSubiti.TabIndex = 13
        Me.txtGolSubiti.Text = ""
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(8, 264)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(104, 16)
        Me.Label8.TabIndex = 14
        Me.Label8.Text = "Punti"
        '
        'txtPunti
        '
        Me.txtPunti.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.DsSquadre, "Squadre.Punti"))
        Me.txtPunti.DataBindings.Add(New System.Windows.Forms.Binding("Tag", Me.DsSquadre, "Squadre.Punti"))
        Me.txtPunti.Location = New System.Drawing.Point(128, 264)
        Me.txtPunti.Name = "txtPunti"
        Me.txtPunti.Size = New System.Drawing.Size(32, 20)
        Me.txtPunti.TabIndex = 15
        Me.txtPunti.Text = ""
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(8, 296)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(112, 24)
        Me.Label9.TabIndex = 16
        Me.Label9.Text = "Differenza Reti"
        '
        'txtDifferenzaReti
        '
        Me.txtDifferenzaReti.Location = New System.Drawing.Point(128, 296)
        Me.txtDifferenzaReti.Name = "txtDifferenzaReti"
        Me.txtDifferenzaReti.Size = New System.Drawing.Size(32, 20)
        Me.txtDifferenzaReti.TabIndex = 17
        Me.txtDifferenzaReti.Text = ""
        '
        'btnPrimo
        '
        Me.btnPrimo.Location = New System.Drawing.Point(8, 328)
        Me.btnPrimo.Name = "btnPrimo"
        Me.btnPrimo.Size = New System.Drawing.Size(104, 40)
        Me.btnPrimo.TabIndex = 18
        Me.btnPrimo.Text = "Primo"
        '
        'btnPrecedente
        '
        Me.btnPrecedente.Location = New System.Drawing.Point(120, 328)
        Me.btnPrecedente.Name = "btnPrecedente"
        Me.btnPrecedente.Size = New System.Drawing.Size(104, 40)
        Me.btnPrecedente.TabIndex = 19
        Me.btnPrecedente.Text = "Precedente"
        '
        'btnSuccessivo
        '
        Me.btnSuccessivo.Location = New System.Drawing.Point(240, 328)
        Me.btnSuccessivo.Name = "btnSuccessivo"
        Me.btnSuccessivo.Size = New System.Drawing.Size(104, 40)
        Me.btnSuccessivo.TabIndex = 20
        Me.btnSuccessivo.Text = "Successivo"
        '
        'btnUltimo
        '
        Me.btnUltimo.Location = New System.Drawing.Point(360, 328)
        Me.btnUltimo.Name = "btnUltimo"
        Me.btnUltimo.Size = New System.Drawing.Size(104, 40)
        Me.btnUltimo.TabIndex = 21
        Me.btnUltimo.Text = "Ultimo"
        '
        'OleDbCommand1
        '
        Me.OleDbCommand1.CommandText = "SELECT Vinte, Squadra, Punti, Perse, Pareggiate, GolSubiti, GolFatti, Giocate, Di" & _
        "fferenzaReti FROM Squadre"
        Me.OleDbCommand1.Connection = Me.OleDbConnection1
        '
        'OleDbConnection1
        '
        Me.OleDbConnection1.ConnectionString = "Jet OLEDB:Registry Path=;Data Source=""C:\EsercizioISCS\Campionato.mdb"";Jet OLEDB:" & _
        "System database=;Jet OLEDB:Global Bulk Transactions=1;User ID=Admin;Provider=""Mi" & _
        "crosoft.Jet.OLEDB.4.0"";Jet OLEDB:Don't Copy Locale on Compact=False;Jet OLEDB:SF" & _
        "P=False;Jet OLEDB:Encrypt Database=False;Jet OLEDB:Engine Type=5;Jet OLEDB:Compa" & _
        "ct Without Replica Repair=False;Jet OLEDB:Global Partial Bulk Ops=2;Extended Pro" & _
        "perties=;Mode=Share Deny None;Jet OLEDB:Create System Database=False;Jet OLEDB:D" & _
        "atabase Locking Mode=1"
        '
        'daSquadre
        '
        Me.daSquadre.DeleteCommand = Me.OleDbDeleteCommand1
        Me.daSquadre.InsertCommand = Me.OleDbInsertCommand1
        Me.daSquadre.SelectCommand = Me.OleDbSelectCommand1
        Me.daSquadre.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "Squadre", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("DifferenzaReti", "DifferenzaReti"), New System.Data.Common.DataColumnMapping("Giocate", "Giocate"), New System.Data.Common.DataColumnMapping("GolFatti", "GolFatti"), New System.Data.Common.DataColumnMapping("GolSubiti", "GolSubiti"), New System.Data.Common.DataColumnMapping("Pareggiate", "Pareggiate"), New System.Data.Common.DataColumnMapping("Perse", "Perse"), New System.Data.Common.DataColumnMapping("Punti", "Punti"), New System.Data.Common.DataColumnMapping("Squadra", "Squadra"), New System.Data.Common.DataColumnMapping("Vinte", "Vinte"), New System.Data.Common.DataColumnMapping("ID", "ID")})})
        Me.daSquadre.UpdateCommand = Me.OleDbUpdateCommand1
        '
        'OleDbDeleteCommand1
        '
        Me.OleDbDeleteCommand1.CommandText = "DELETE FROM Squadre WHERE (ID = ?) AND (DifferenzaReti = ? OR ? IS NULL AND Diffe" & _
        "renzaReti IS NULL) AND (Giocate = ? OR ? IS NULL AND Giocate IS NULL) AND (GolFa" & _
        "tti = ? OR ? IS NULL AND GolFatti IS NULL) AND (GolSubiti = ? OR ? IS NULL AND G" & _
        "olSubiti IS NULL) AND (Pareggiate = ? OR ? IS NULL AND Pareggiate IS NULL) AND (" & _
        "Perse = ? OR ? IS NULL AND Perse IS NULL) AND (Punti = ? OR ? IS NULL AND Punti " & _
        "IS NULL) AND (Squadra = ? OR ? IS NULL AND Squadra IS NULL) AND (Vinte = ? OR ? " & _
        "IS NULL AND Vinte IS NULL)"
        Me.OleDbDeleteCommand1.Connection = Me.OleDbConnection1
        Me.OleDbDeleteCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ID", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbDeleteCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_DifferenzaReti", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "DifferenzaReti", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbDeleteCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_DifferenzaReti1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "DifferenzaReti", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbDeleteCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Giocate", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Giocate", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbDeleteCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Giocate1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Giocate", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbDeleteCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_GolFatti", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "GolFatti", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbDeleteCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_GolFatti1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "GolFatti", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbDeleteCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_GolSubiti", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "GolSubiti", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbDeleteCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_GolSubiti1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "GolSubiti", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbDeleteCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Pareggiate", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Pareggiate", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbDeleteCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Pareggiate1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Pareggiate", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbDeleteCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Perse", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Perse", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbDeleteCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Perse1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Perse", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbDeleteCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Punti", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Punti", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbDeleteCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Punti1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Punti", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbDeleteCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Squadra", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Squadra", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbDeleteCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Squadra1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Squadra", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbDeleteCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Vinte", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Vinte", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbDeleteCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Vinte1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Vinte", System.Data.DataRowVersion.Original, Nothing))
        '
        'OleDbInsertCommand1
        '
        Me.OleDbInsertCommand1.CommandText = "INSERT INTO Squadre(DifferenzaReti, Giocate, GolFatti, GolSubiti, Pareggiate, Per" & _
        "se, Punti, Squadra, Vinte) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?)"
        Me.OleDbInsertCommand1.Connection = Me.OleDbConnection1
        Me.OleDbInsertCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("DifferenzaReti", System.Data.OleDb.OleDbType.Integer, 0, "DifferenzaReti"))
        Me.OleDbInsertCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Giocate", System.Data.OleDb.OleDbType.Integer, 0, "Giocate"))
        Me.OleDbInsertCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("GolFatti", System.Data.OleDb.OleDbType.Integer, 0, "GolFatti"))
        Me.OleDbInsertCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("GolSubiti", System.Data.OleDb.OleDbType.Integer, 0, "GolSubiti"))
        Me.OleDbInsertCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Pareggiate", System.Data.OleDb.OleDbType.Integer, 0, "Pareggiate"))
        Me.OleDbInsertCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Perse", System.Data.OleDb.OleDbType.Integer, 0, "Perse"))
        Me.OleDbInsertCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Punti", System.Data.OleDb.OleDbType.Integer, 0, "Punti"))
        Me.OleDbInsertCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Squadra", System.Data.OleDb.OleDbType.VarWChar, 50, "Squadra"))
        Me.OleDbInsertCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Vinte", System.Data.OleDb.OleDbType.Integer, 0, "Vinte"))
        '
        'OleDbSelectCommand1
        '
        Me.OleDbSelectCommand1.CommandText = "SELECT DifferenzaReti, Giocate, GolFatti, GolSubiti, Pareggiate, Perse, Punti, Sq" & _
        "uadra, Vinte, ID FROM Squadre"
        Me.OleDbSelectCommand1.Connection = Me.OleDbConnection1
        '
        'OleDbUpdateCommand1
        '
        Me.OleDbUpdateCommand1.CommandText = "UPDATE Squadre SET DifferenzaReti = ?, Giocate = ?, GolFatti = ?, GolSubiti = ?, " & _
        "Pareggiate = ?, Perse = ?, Punti = ?, Squadra = ?, Vinte = ? WHERE (ID = ?) AND " & _
        "(DifferenzaReti = ? OR ? IS NULL AND DifferenzaReti IS NULL) AND (Giocate = ? OR" & _
        " ? IS NULL AND Giocate IS NULL) AND (GolFatti = ? OR ? IS NULL AND GolFatti IS N" & _
        "ULL) AND (GolSubiti = ? OR ? IS NULL AND GolSubiti IS NULL) AND (Pareggiate = ? " & _
        "OR ? IS NULL AND Pareggiate IS NULL) AND (Perse = ? OR ? IS NULL AND Perse IS NU" & _
        "LL) AND (Punti = ? OR ? IS NULL AND Punti IS NULL) AND (Squadra = ? OR ? IS NULL" & _
        " AND Squadra IS NULL) AND (Vinte = ? OR ? IS NULL AND Vinte IS NULL)"
        Me.OleDbUpdateCommand1.Connection = Me.OleDbConnection1
        Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("DifferenzaReti", System.Data.OleDb.OleDbType.Integer, 0, "DifferenzaReti"))
        Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Giocate", System.Data.OleDb.OleDbType.Integer, 0, "Giocate"))
        Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("GolFatti", System.Data.OleDb.OleDbType.Integer, 0, "GolFatti"))
        Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("GolSubiti", System.Data.OleDb.OleDbType.Integer, 0, "GolSubiti"))
        Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Pareggiate", System.Data.OleDb.OleDbType.Integer, 0, "Pareggiate"))
        Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Perse", System.Data.OleDb.OleDbType.Integer, 0, "Perse"))
        Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Punti", System.Data.OleDb.OleDbType.Integer, 0, "Punti"))
        Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Squadra", System.Data.OleDb.OleDbType.VarWChar, 50, "Squadra"))
        Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Vinte", System.Data.OleDb.OleDbType.Integer, 0, "Vinte"))
        Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ID", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_DifferenzaReti", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "DifferenzaReti", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_DifferenzaReti1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "DifferenzaReti", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Giocate", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Giocate", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Giocate1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Giocate", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_GolFatti", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "GolFatti", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_GolFatti1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "GolFatti", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_GolSubiti", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "GolSubiti", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_GolSubiti1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "GolSubiti", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Pareggiate", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Pareggiate", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Pareggiate1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Pareggiate", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Perse", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Perse", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Perse1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Perse", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Punti", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Punti", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Punti1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Punti", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Squadra", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Squadra", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Squadra1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Squadra", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Vinte", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Vinte", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Vinte1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Vinte", System.Data.DataRowVersion.Original, Nothing))
        '
        'btnAggiungi
        '
        Me.btnAggiungi.Location = New System.Drawing.Point(376, 168)
        Me.btnAggiungi.Name = "btnAggiungi"
        Me.btnAggiungi.Size = New System.Drawing.Size(104, 40)
        Me.btnAggiungi.TabIndex = 22
        Me.btnAggiungi.Text = "Aggiungi"
        '
        'btnDifferenzaReti
        '
        Me.btnDifferenzaReti.Location = New System.Drawing.Point(376, 224)
        Me.btnDifferenzaReti.Name = "btnDifferenzaReti"
        Me.btnDifferenzaReti.Size = New System.Drawing.Size(104, 40)
        Me.btnDifferenzaReti.TabIndex = 23
        Me.btnDifferenzaReti.Text = "Differenza Reti"
        '
        'frmGestioneSquadre
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(552, 374)
        Me.Controls.Add(Me.btnDifferenzaReti)
        Me.Controls.Add(Me.btnAggiungi)
        Me.Controls.Add(Me.btnUltimo)
        Me.Controls.Add(Me.btnSuccessivo)
        Me.Controls.Add(Me.btnPrecedente)
        Me.Controls.Add(Me.btnPrimo)
        Me.Controls.Add(Me.txtDifferenzaReti)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtPunti)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtGolSubiti)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtGolFatti)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtPerse)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtPareggiate)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtVinte)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtGiocate)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtSquadra)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmGestioneSquadre"
        Me.Text = "Gestione Squadre"
        CType(Me.DsSquadre, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub frmGestioneSquadre_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        daSquadre.Fill(DsSquadre)


    End Sub

    Private Sub btnPrimo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrimo.Click
        Dim bmb As BindingManagerBase
        bmb = Me.BindingContext(DsSquadre, "Squadre")
        bmb.Position = 0




    End Sub

    Private Sub btnUltimo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUltimo.Click
        Dim bmb As BindingManagerBase
        bmb = Me.BindingContext(DsSquadre, "Squadre")
        bmb.Position = bmb.Count - 1


    End Sub

    Private Sub btnPrecedente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrecedente.Click
        Dim bmb As BindingManagerBase
        bmb = Me.BindingContext(DsSquadre, "Squadre")
        bmb.Position = bmb.Position - 1
        If bmb.Position < 0 Then
            bmb.Position = 0
        End If
    End Sub

    Private Sub btnSuccessivo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSuccessivo.Click
        Dim bmb As BindingManagerBase
        bmb = Me.BindingContext(DsSquadre, "Squadre")
        bmb.Position = bmb.Position + 1
        If bmb.Position >= bmb.Count Then
            bmb.Position = bmb.Position - 1

        End If
    End Sub

    Private Sub btnDifferenzaReti_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDifferenzaReti.Click
        Dim bmb As BindingManagerBase
        Dim valore1 As Integer

        bmb = Me.BindingContext(DsSquadre, "Squadre")
        bmb.Position = 0
        Dim con As OleDbConnection

        Dim calcolaDifferenza As OleDbCommand

        Dim inserisciValore As OleDbCommand


        Dim risultato As Integer
        Dim arrayRisultato As Array
        Dim i As Integer


        Dim numeroRighe As Integer


        Dim drDifferenza As OleDbDataReader

        Dim strConnessione As String
        strConnessione = "Password='admin';Data Source='ACCESS.C:\EsercizioISCS\Campionato.mdb';Provider = Microsoft.JET.OleDb.4.0"


        con = New OleDbConnection(strConnessione)









        Try
            con.Open()
            calcolaDifferenza = New OleDbCommand("Select * from Squadre", con)
            drDifferenza = calcolaDifferenza.ExecuteReader()

            i = 0
            Do While drDifferenza.Read
                risultato = drDifferenza.Item("GolFatti") - drDifferenza.Item("GolSubiti")
                arrayRisultato(i) = risultato
                i = i + 1
                inserisciValore = "Insert into Squadre (Squadra, Giocate, Vinte, Pareggiate, Perse, GolFatti, GolSubiti, Punti, DifferenzaReti) values ('" + drDifferenza.Item(0) + "','" + drDifferenza.Item(1) + "," + drDifferenza.Item(2) + "," + drDifferenza.Item(3) + "," + drDifferenza.Item(4) + "," + drDifferenza.Item(5) + "," + drDifferenza(6) + "," + drDifferenza(7) + "," + arrayRisultato(i) + ")"
                numeroRighe = inserisciValore.ExecuteNonQuery()
                If numeroRighe > 0 Then
                    MessageBox.Show("Aggiornamento differenza reti effettuato")
                Else
                    MessageBox.Show("Errore")


                End If
            Loop
        Catch
            MessageBox.Show("Errore dovuto al provider errato")

        Finally
            con.Close()

        End Try

    End Sub
End Class
