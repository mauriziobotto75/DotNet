Public Class frmPrincipale

    Private Sub btnGestisciCittadini_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGestisciCittadini.Click

        Dim InserisciCittadini As New InserisciCittadini
        InserisciCittadini = New InserisciCittadini()

        InserisciCittadini.ShowDialog()

    End Sub

    Private Sub btnVisualizzaCittadini_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVisualizzaCittadini.Click
        Dim frmVisualizzaCittadini As frmVisualizzaCittadini
        frmVisualizzaCittadini = New frmVisualizzaCittadini()
        frmVisualizzaCittadini.ShowDialog()


    End Sub
End Class