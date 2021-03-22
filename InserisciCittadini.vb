Imports System.Data.SqlClient
Imports System.Windows.Forms







Public Class InserisciCittadini

    Private Property DbCittadiniDataSetTableAdapter As Object

    Private Sub InserisciCittadini_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'DbCittadiniDataSet.tbCittadini' table. You can move, or remove it, as needed.
        Me.TbCittadiniTableAdapter.Fill(Me.DbCittadiniDataSet.tbCittadini)

    End Sub

    Private Sub btnPrimo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrimo.Click
        bdsCittadini.MoveFirst()

    End Sub

    Private Sub btnUltimo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUltimo.Click
        bdsCittadini.MoveLast()

    End Sub

    Private Sub btnSuccessivo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSuccessivo.Click
        bdsCittadini.MoveNext()
        If bdsCittadini.Position > (bdsCittadini.Count - 1) Then
            bdsCittadini.MovePrevious()
        End If
    End Sub

    Private Sub btnPrecedente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrecedente.Click
        bdsCittadini.MovePrevious()

        If bdsCittadini.Position < 0 Then
            bdsCittadini.MoveNext()
        End If
    End Sub

    Private Sub btnAggiungi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAggiungi.Click

        ' Me.Validate()
        ' Me.bdsCittadini.EndEdit()

        'Me.bdsCittadini.Item("nome") = txtNome.Text
        'Me.bdsCittadini.Item("cognome") = txtCognome.Text
        'Me.bdsCittadini.Item("dataNascita") = DateTime.Parse(dtpDataNascita.Text)
        'Me.bdsCittadini.Item("citta") = txtCittà.Text
        'Me.bdsCittadini.Item("residenza") = txtResidenza.Text

        'Me.bdsCittadini.AddNew()

        Dim connessione As String
        Dim con As SqlClient.SqlConnection
        Dim queryString As String
        Dim command As SqlClient.SqlCommand




        connessione = "Password='admin';Data Source=Maurizio-b1163e\sqlexpress2005;Integrated Security=SSPI;Initial Catalog=DbCittadini"
        con = New SqlClient.SqlConnection(connessione)

        con.Open()
        queryString = "INSERT INTO tbCittadini(Nome, Cognome, Citta, dataNascita, residenza, domicilio) VALUES('" + txtNome.Text + "','" + txtCognome.Text + "','" + txtCittà.Text + "','" + DateTime.Parse(dtpDataNascita.Text) + "','" + txtResidenza.Text + "','" + txtDomicilio.Text + "')"

        command = New SqlClient.SqlCommand(queryString, con)

        command.ExecuteNonQuery()
        MessageBox.Show("Cittadino inserito correttamente")


        con.Close()














    End Sub


    '    Private Sub NuovoRecord()
    '        bdsCittadini.EndEdit()
    '        bdsCittadini.AddNew()
    '    End Sub

    Private Sub btnElimina_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnElimina.Click
        Dim connessione As String
        Dim con As SqlConnection

        Dim queryElimina As String
        Dim command As SqlCommand

        connessione = "Password='admin';Data Source=Maurizio-b1163e\sqlexpress2005;Integrated Security=SSPI;Initial Catalog=DbCittadini"
        con = New SqlConnection(connessione)
        Try
            con.Open()
            queryElimina = "DELETE  FROM tbCittadini  WHERE COGNOME = '" + txtCognome.Text + "')"

            command = New SqlCommand(queryElimina, con)

            command.ExecuteNonQuery()



            MessageBox.Show("Cittadino eliminato correttamente")
        Catch
            MessageBox.Show("Cittadino non eliminato correttamente")


        Finally
            con.Close()
        End Try
    End Sub

    Private Sub btnModifica_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModifica.Click
 
        Try
            TbCittadiniTableAdapter.Update(DbCittadiniDataSet.tbCittadini)


            MessageBox.Show("Cittadino modificato correttamente")
        Catch
            MessageBox.Show("Cittadino non modificato correttamente")


        Finally

        End Try






        '     With btnModifica
        '' .Parameters("@categoryid").Value = ddlCategoryID.SelectedItem.Text
        '.Parameters("@categoryname").Value = txtCategoryName.Text
        '.Parameters("@categorydescription").Value = txtCategoryDescription.Text
        'End With
        'SqlConnection1.Open()
        'cmdCategoriesUpdate.ExecuteNonQuery()
        'SqlConnection1.Close()


    End Sub
End Class