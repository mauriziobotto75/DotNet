Dim ErrorProvider1 as New System.Windows.Forms.ErrorProvider()

Non è necessario aggiungerlo all'array di controlli del Form.

Impostazioni del controllo

E' possibile utilizzare una sorta di DataBinding anche con questo controllo. Per associare il controllo alla fonte dati si possono impostare le proprietà DataSource e DataMember in fase di programmazione o, in alternativa, utilizzare il metodo BindToDataAndErrors   in fase di esecuzione.

'associare ErrorProvider a una fonte dati in fase di progettazione (supponendo che esistano DataSet1 e DataTabel1
ErrorProvider1.DataSource = DataSet1
ErrorProvider1.DataMember = dataTable1.TableName

'associare ErrorProvider a una fonte dati in fase di esecuzione
ErrorProvider1.BindToDataAndErrors(nomeDataSet,nomeDataMember)




ErrorProvider1.BlinkRate = 500
'imposto lo stile
ErrorProvider1.BlinkStyle = ErrorBlinkStyle.AlwaysBlink
'imposto l'icona (supponendo che esista)
ErrorProvider1.Icon = icona


ErrorProvider1.SetError(controllo_associato,"Messaggio di errore")

'Caso pratico :supponiamo ad esempio di avere un form con una casella di testo txtPippo e un controllo ErrorProvider1. Vogliamo fare in modo che l'utente scriva qualcosa nella casella di testo, altrimenti verrà visualizzato un errore. Inserisco il collegamento all'ErrorProvider  nell'evento Validanting di txtPippo. Ecco il codice:

'associo una casella di testo all'ErrorProvider
Private Sub txtPippo_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) _                       Handles txtPippo.Validating                                                                                                                        'controlla che il campo non sia vuoto
If Len(txtPippo.text)=0 then
    ErrorProvider1.SetError(txtPippo, "Inserire una stringa nella casella di testo txtPippo")
Else
    ErrorProvider1.SetError(txtPippo, "")
End If
