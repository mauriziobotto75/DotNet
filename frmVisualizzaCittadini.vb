Imports System.Windows.Forms.Form
Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class frmVisualizzaCittadini
    Dim bmb As BindingManagerBase

    Dim elencoCittadini As BindingSource

    Private Sub frmVisualizzaCittadini_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'DsCitta.tbCitta' table. You can move, or remove it, as needed.
        Me.TbCittaTableAdapter.Fill(Me.DsCitta.tbCitta)


    End Sub

    Private Sub cmbCitta_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCitta.SelectedIndexChanged
        Dim con As SqlConnection
        Dim stringa As String


        Dim tabella As DataTable
        Dim cercaDati As SqlDataAdapter
        Dim bmb As BindingManagerBase


        stringa = "Data Source=maurizio-b1163e\sqlexpress2005;Initial Catalog=DbCittadini;Integrated Security = true"
        con = New SqlConnection(stringa)
        con.Open()


 
        tabella = New DataTable()
        cercaDati = New SqlDataAdapter("Select * from tbCittadini where citta = '" + cmbCitta.Text + "'", con)


        cercaDati.Fill(tabella)
        dgrDatiCittadini.Visible = True
        elencoCittadini = New BindingSource()
        elencoCittadini.DataSource = tabella
        dgrDatiCittadini.DataSource = elencoCittadini
        bmb = Me.BindingContext(elencoCittadini)

        bmb.Position = 0

        btnPrimo.Visible = True
        btnPrecedente.Visible = True
        btnSuccessivo.Visible = True
        btnUltimo.Visible = True



        con.Close()





    End Sub

    Private Sub btnPrimo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrimo.Click
        bmb = Me.BindingContext(elencoCittadini)

        bmb.Position = 0
    End Sub

    Private Sub btnUltimo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUltimo.Click
        bmb = Me.BindingContext(elencoCittadini)

        bmb.Position = bmb.Count - 1

    End Sub

    Private Sub btnPrecedente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrecedente.Click
        bmb = Me.BindingContext(elencoCittadini)
        bmb.Position = bmb.Position - 1
        If (bmb.Position < 0) Then
            bmb.Position = 0
        End If

    End Sub

    Private Sub btnSuccessivo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSuccessivo.Click
        bmb = Me.BindingContext(elencoCittadini)
        bmb.Position = bmb.Position + 1
        If (bmb.Position = bmb.Count) Then
            bmb.Position = bmb.Position - 1
        End If
    End Sub

    Private Sub dgrDatiCittadini_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgrDatiCittadini.CellContentClick




        Dim dv As DataRowView = elencoCittadini.Current



        Dim nome As String = dv("Nome").ToString
        Dim cognome As String = dv("Cognome").ToString
        Dim dataNascita As DateTime = DateTime.Parse(dv("DataNascita"))

        Dim citta As String = dv("Citta").ToString
        Dim residenza As String = dv("Residenza").ToString
        Dim domicilio As String = dv("Domicilio").ToString
        Dim dettaglioCittadini As DettaglioCittadini = New DettaglioCittadini()
        dettaglioCittadini.Controls("txtNome").Text = nome
        dettaglioCittadini.Controls("txtCognome").Text = cognome
        dettaglioCittadini.Controls("txtDataNascita").Text = DateTime.Parse(dataNascita.ToString)
        dettaglioCittadini.Controls("txtCittà").Text = citta
        dettaglioCittadini.Controls("txtResidenza").Text = residenza
        dettaglioCittadini.Controls("txtDomicilio").Text = domicilio

        dettaglioCittadini.ShowDialog()
 

    End Sub
End Class
