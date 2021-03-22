<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InserisciCittadini
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtNome = New System.Windows.Forms.TextBox
        Me.bdsCittadini = New System.Windows.Forms.BindingSource(Me.components)
        Me.DbCittadiniDataSet = New ProgettoCittadini.DbCittadiniDataSet


        Me.DsCitta = New ProgettoCittadini.dsCitta


        Me.txtCognome = New System.Windows.Forms.TextBox
        Me.txtCittà = New System.Windows.Forms.TextBox
        Me.dtpDataNascita = New System.Windows.Forms.DateTimePicker
        Me.txtResidenza = New System.Windows.Forms.TextBox
        Me.btnPrimo = New System.Windows.Forms.Button
        Me.btnPrecedente = New System.Windows.Forms.Button
        Me.btnSuccessivo = New System.Windows.Forms.Button
        Me.btnUltimo = New System.Windows.Forms.Button
        Me.DsCitta = New ProgettoCittadini.dsCitta
        Me.TbCittadiniTableAdapter = New ProgettoCittadini.DbCittadiniDataSetTableAdapters.tbCittadiniTableAdapter
        Me.btnAggiungi = New System.Windows.Forms.Button
        Me.btnElimina = New System.Windows.Forms.Button
        Me.btnModifica = New System.Windows.Forms.Button
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtDomicilio = New System.Windows.Forms.TextBox
        CType(Me.bdsCittadini, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DbCittadiniDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsCitta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(33, 39)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(35, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Nome"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(33, 80)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Cognome"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(33, 113)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(28, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Città"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(33, 147)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(78, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Data di nascita"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(33, 187)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(57, 13)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Residenza"
        '
        'txtNome
        '
        Me.txtNome.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bdsCittadini, "nome", True))
        Me.txtNome.DataBindings.Add(New System.Windows.Forms.Binding("Tag", Me.bdsCittadini, "nome", True))
        Me.txtNome.Location = New System.Drawing.Point(142, 36)
        Me.txtNome.Name = "txtNome"
        Me.txtNome.Size = New System.Drawing.Size(202, 20)
        Me.txtNome.TabIndex = 5
        '
        'bdsCittadini
        '
        Me.bdsCittadini.DataMember = "tbCittadini"
        Me.bdsCittadini.DataSource = Me.DbCittadiniDataSet
        '
        'DbCittadiniDataSet
        '
        Me.DbCittadiniDataSet.DataSetName = "DbCittadiniDataSet"
        Me.DbCittadiniDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'txtCognome
        '
        Me.txtCognome.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bdsCittadini, "cognome", True))
        Me.txtCognome.DataBindings.Add(New System.Windows.Forms.Binding("Tag", Me.bdsCittadini, "cognome", True))
        Me.txtCognome.Location = New System.Drawing.Point(142, 73)
        Me.txtCognome.Name = "txtCognome"
        Me.txtCognome.Size = New System.Drawing.Size(202, 20)
        Me.txtCognome.TabIndex = 6
        '
        'txtCittà
        '
        Me.txtCittà.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bdsCittadini, "citta", True))
        Me.txtCittà.DataBindings.Add(New System.Windows.Forms.Binding("Tag", Me.bdsCittadini, "citta", True))
        Me.txtCittà.Location = New System.Drawing.Point(142, 106)
        Me.txtCittà.Name = "txtCittà"
        Me.txtCittà.Size = New System.Drawing.Size(202, 20)
        Me.txtCittà.TabIndex = 7
        '
        'dtpDataNascita
        '
        Me.dtpDataNascita.DataBindings.Add(New System.Windows.Forms.Binding("Value", Me.bdsCittadini, "dataNascita", True))
        Me.dtpDataNascita.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bdsCittadini, "dataNascita", True))
        Me.dtpDataNascita.Location = New System.Drawing.Point(142, 144)
        Me.dtpDataNascita.Name = "dtpDataNascita"
        Me.dtpDataNascita.Size = New System.Drawing.Size(266, 20)
        Me.dtpDataNascita.TabIndex = 8
        '
        'txtResidenza
        '
        Me.txtResidenza.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bdsCittadini, "residenza", True))
        Me.txtResidenza.DataBindings.Add(New System.Windows.Forms.Binding("Tag", Me.bdsCittadini, "residenza", True))
        Me.txtResidenza.Location = New System.Drawing.Point(142, 179)
        Me.txtResidenza.Name = "txtResidenza"
        Me.txtResidenza.Size = New System.Drawing.Size(202, 20)
        Me.txtResidenza.TabIndex = 9
        '
        'btnPrimo
        '
        Me.btnPrimo.Location = New System.Drawing.Point(142, 249)
        Me.btnPrimo.Name = "btnPrimo"
        Me.btnPrimo.Size = New System.Drawing.Size(79, 38)
        Me.btnPrimo.TabIndex = 10
        Me.btnPrimo.Text = "Primo"
        Me.btnPrimo.UseVisualStyleBackColor = True
        '
        'btnPrecedente
        '
        Me.btnPrecedente.Location = New System.Drawing.Point(227, 249)
        Me.btnPrecedente.Name = "btnPrecedente"
        Me.btnPrecedente.Size = New System.Drawing.Size(79, 38)
        Me.btnPrecedente.TabIndex = 11
        Me.btnPrecedente.Text = "Precedente"
        Me.btnPrecedente.UseVisualStyleBackColor = True
        '
        'btnSuccessivo
        '
        Me.btnSuccessivo.Location = New System.Drawing.Point(312, 249)
        Me.btnSuccessivo.Name = "btnSuccessivo"
        Me.btnSuccessivo.Size = New System.Drawing.Size(79, 38)
        Me.btnSuccessivo.TabIndex = 12
        Me.btnSuccessivo.Text = "Successivo" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.btnSuccessivo.UseVisualStyleBackColor = True
        '
        'btnUltimo
        '
        Me.btnUltimo.Location = New System.Drawing.Point(397, 249)
        Me.btnUltimo.Name = "btnUltimo"
        Me.btnUltimo.Size = New System.Drawing.Size(79, 38)
        Me.btnUltimo.TabIndex = 13
        Me.btnUltimo.Text = "Ultimo"
        Me.btnUltimo.UseVisualStyleBackColor = True
        '
        'DsCitta
        '
        Me.DsCitta.DataSetName = "dsCitta"
        Me.DsCitta.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'TbCittadiniTableAdapter
        '
        Me.TbCittadiniTableAdapter.ClearBeforeFill = True
        '
        'btnAggiungi
        '
        Me.btnAggiungi.Location = New System.Drawing.Point(413, 18)
        Me.btnAggiungi.Name = "btnAggiungi"
        Me.btnAggiungi.Size = New System.Drawing.Size(79, 38)
        Me.btnAggiungi.TabIndex = 14
        Me.btnAggiungi.Text = "Aggiungi"
        Me.btnAggiungi.UseVisualStyleBackColor = True
        '
        'btnElimina
        '
        Me.btnElimina.Location = New System.Drawing.Point(413, 73)
        Me.btnElimina.Name = "btnElimina"
        Me.btnElimina.Size = New System.Drawing.Size(79, 38)
        Me.btnElimina.TabIndex = 15
        Me.btnElimina.Text = "Elimina"
        Me.btnElimina.UseVisualStyleBackColor = True
        '
        'btnModifica
        '
        Me.btnModifica.Location = New System.Drawing.Point(413, 134)
        Me.btnModifica.Name = "btnModifica"
        Me.btnModifica.Size = New System.Drawing.Size(79, 38)
        Me.btnModifica.TabIndex = 16
        Me.btnModifica.Text = "Modifica"
        Me.btnModifica.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(33, 219)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(49, 13)
        Me.Label6.TabIndex = 17
        Me.Label6.Text = "Domicilio"
        '
        'txtDomicilio
        '
        Me.txtDomicilio.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bdsCittadini, "domicilio", True))
        Me.txtDomicilio.DataBindings.Add(New System.Windows.Forms.Binding("Tag", Me.bdsCittadini, "domicilio", True))
        Me.txtDomicilio.Location = New System.Drawing.Point(142, 213)
        Me.txtDomicilio.Name = "txtDomicilio"
        Me.txtDomicilio.Size = New System.Drawing.Size(202, 20)
        Me.txtDomicilio.TabIndex = 18
        '
        'InserisciCittadini
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(591, 310)
        Me.Controls.Add(Me.txtDomicilio)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.btnModifica)
        Me.Controls.Add(Me.btnElimina)
        Me.Controls.Add(Me.btnAggiungi)
        Me.Controls.Add(Me.btnUltimo)
        Me.Controls.Add(Me.btnSuccessivo)
        Me.Controls.Add(Me.btnPrecedente)
        Me.Controls.Add(Me.btnPrimo)
        Me.Controls.Add(Me.txtResidenza)
        Me.Controls.Add(Me.dtpDataNascita)
        Me.Controls.Add(Me.txtCittà)
        Me.Controls.Add(Me.txtCognome)
        Me.Controls.Add(Me.txtNome)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "InserisciCittadini"
        Me.Text = "InserisciCittadini"
        CType(Me.bdsCittadini, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DbCittadiniDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsCitta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtNome As System.Windows.Forms.TextBox
    Friend WithEvents txtCognome As System.Windows.Forms.TextBox
    Friend WithEvents txtCittà As System.Windows.Forms.TextBox
    Friend WithEvents dtpDataNascita As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtResidenza As System.Windows.Forms.TextBox
    Friend WithEvents btnPrimo As System.Windows.Forms.Button
    Friend WithEvents btnPrecedente As System.Windows.Forms.Button
    Friend WithEvents btnSuccessivo As System.Windows.Forms.Button
    Friend WithEvents btnUltimo As System.Windows.Forms.Button
    Friend WithEvents bdsCittadini As System.Windows.Forms.BindingSource
    Friend WithEvents DbCittadiniDataSet As ProgettoCittadini.DbCittadiniDataSet
    Friend WithEvents DsCitta As ProgettoCittadini.dsCitta
    Friend WithEvents TbCittadiniTableAdapter As ProgettoCittadini.DbCittadiniDataSetTableAdapters.tbCittadiniTableAdapter
    Friend WithEvents btnAggiungi As System.Windows.Forms.Button
    Friend WithEvents btnElimina As System.Windows.Forms.Button
    Friend WithEvents btnModifica As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtDomicilio As System.Windows.Forms.TextBox
End Class
