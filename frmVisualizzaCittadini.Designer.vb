<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmVisualizzaCittadini
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
        Me.cmbCitta = New System.Windows.Forms.ComboBox
        Me.TbCittaBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.BindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsCitta = New ProgettoCittadini.dsCitta
        Me.dgrDatiCittadini = New System.Windows.Forms.DataGridView
        Me.TbCittaTableAdapter = New ProgettoCittadini.dsCittaTableAdapters.tbCittaTableAdapter
        Me.btnPrimo = New System.Windows.Forms.Button
        Me.btnPrecedente = New System.Windows.Forms.Button
        Me.btnSuccessivo = New System.Windows.Forms.Button
        Me.btnUltimo = New System.Windows.Forms.Button
        CType(Me.TbCittaBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsCitta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgrDatiCittadini, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(35, 66)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(28, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Città"
        '
        'cmbCitta
        '
        Me.cmbCitta.DataSource = Me.TbCittaBindingSource
        Me.cmbCitta.DisplayMember = "nomeCitta"
        Me.cmbCitta.FormattingEnabled = True
        Me.cmbCitta.Location = New System.Drawing.Point(184, 58)
        Me.cmbCitta.Name = "cmbCitta"
        Me.cmbCitta.Size = New System.Drawing.Size(178, 21)
        Me.cmbCitta.TabIndex = 1
        Me.cmbCitta.ValueMember = "nomeCitta"
        '
        'TbCittaBindingSource
        '
        Me.TbCittaBindingSource.DataSource = Me.BindingSource1
        '
        'BindingSource1
        '
        Me.BindingSource1.DataMember = "tbCitta"
        Me.BindingSource1.DataSource = Me.DsCitta
        '
        'DsCitta
        '
        Me.DsCitta.DataSetName = "dsCitta"
        Me.DsCitta.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'dgrDatiCittadini
        '
        Me.dgrDatiCittadini.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgrDatiCittadini.Location = New System.Drawing.Point(184, 144)
        Me.dgrDatiCittadini.Name = "dgrDatiCittadini"
        Me.dgrDatiCittadini.Size = New System.Drawing.Size(566, 248)
        Me.dgrDatiCittadini.TabIndex = 2
        '
        'TbCittaTableAdapter
        '
        Me.TbCittaTableAdapter.ClearBeforeFill = True
        '
        'btnPrimo
        '
        Me.btnPrimo.Location = New System.Drawing.Point(184, 436)
        Me.btnPrimo.Name = "btnPrimo"
        Me.btnPrimo.Size = New System.Drawing.Size(79, 41)
        Me.btnPrimo.TabIndex = 3
        Me.btnPrimo.Text = "Primo"
        Me.btnPrimo.UseVisualStyleBackColor = True
        '
        'btnPrecedente
        '
        Me.btnPrecedente.Location = New System.Drawing.Point(283, 436)
        Me.btnPrecedente.Name = "btnPrecedente"
        Me.btnPrecedente.Size = New System.Drawing.Size(79, 41)
        Me.btnPrecedente.TabIndex = 4
        Me.btnPrecedente.Text = "Precedente"
        Me.btnPrecedente.UseVisualStyleBackColor = True
        '
        'btnSuccessivo
        '
        Me.btnSuccessivo.Location = New System.Drawing.Point(378, 436)
        Me.btnSuccessivo.Name = "btnSuccessivo"
        Me.btnSuccessivo.Size = New System.Drawing.Size(79, 41)
        Me.btnSuccessivo.TabIndex = 5
        Me.btnSuccessivo.Text = "Successivo" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.btnSuccessivo.UseVisualStyleBackColor = True
        '
        'btnUltimo
        '
        Me.btnUltimo.Location = New System.Drawing.Point(474, 436)
        Me.btnUltimo.Name = "btnUltimo"
        Me.btnUltimo.Size = New System.Drawing.Size(79, 41)
        Me.btnUltimo.TabIndex = 6
        Me.btnUltimo.Text = "Ultimo"
        Me.btnUltimo.UseVisualStyleBackColor = True
        '
        'frmVisualizzaCittadini
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(792, 578)
        Me.Controls.Add(Me.btnUltimo)
        Me.Controls.Add(Me.btnSuccessivo)
        Me.Controls.Add(Me.btnPrecedente)
        Me.Controls.Add(Me.btnPrimo)
        Me.Controls.Add(Me.dgrDatiCittadini)
        Me.Controls.Add(Me.cmbCitta)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmVisualizzaCittadini"
        Me.Text = "Visualizza Cittadini"
        CType(Me.TbCittaBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsCitta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgrDatiCittadini, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbCitta As System.Windows.Forms.ComboBox
    Friend WithEvents dgrDatiCittadini As System.Windows.Forms.DataGridView
    Friend WithEvents BindingSource1 As System.Windows.Forms.BindingSource
    Friend WithEvents DsCitta As ProgettoCittadini.dsCitta
    Friend WithEvents TbCittaBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents TbCittaTableAdapter As ProgettoCittadini.dsCittaTableAdapters.tbCittaTableAdapter
    Friend WithEvents btnPrimo As System.Windows.Forms.Button
    Friend WithEvents btnPrecedente As System.Windows.Forms.Button
    Friend WithEvents btnSuccessivo As System.Windows.Forms.Button
    Friend WithEvents btnUltimo As System.Windows.Forms.Button

End Class
