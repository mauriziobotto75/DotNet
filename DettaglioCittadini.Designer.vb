<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DettaglioCittadini
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
        Me.components = New System.ComponentModel.Container()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtNome = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtCognome = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtDataNascita = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtResidenza = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtDomicilio = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtCittà = New System.Windows.Forms.TextBox()
        Me.BindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.DbCittadiniDataSet1 = New ProgettoCittadini.DbCittadiniDataSet()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DbCittadiniDataSet1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(81, 36)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(35, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Nome"
        '
        'txtNome
        '
        Me.txtNome.Location = New System.Drawing.Point(214, 33)
        Me.txtNome.Name = "txtNome"
        Me.txtNome.Size = New System.Drawing.Size(100, 20)
        Me.txtNome.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(81, 74)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Cognome"
        '
        'txtCognome
        '
        Me.txtCognome.Location = New System.Drawing.Point(214, 66)
        Me.txtCognome.Name = "txtCognome"
        Me.txtCognome.Size = New System.Drawing.Size(100, 20)
        Me.txtCognome.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(81, 112)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(69, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Data Nascita"
        '
        'txtDataNascita
        '
        Me.txtDataNascita.Location = New System.Drawing.Point(214, 112)
        Me.txtDataNascita.Name = "txtDataNascita"
        Me.txtDataNascita.Size = New System.Drawing.Size(200, 20)
        Me.txtDataNascita.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(81, 159)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(57, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Residenza"
        '
        'txtResidenza
        '
        Me.txtResidenza.Location = New System.Drawing.Point(214, 151)
        Me.txtResidenza.Name = "txtResidenza"
        Me.txtResidenza.Size = New System.Drawing.Size(100, 20)
        Me.txtResidenza.TabIndex = 7
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(81, 227)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(49, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Domicilio"
        '
        'txtDomicilio
        '
        Me.txtDomicilio.Location = New System.Drawing.Point(214, 220)
        Me.txtDomicilio.Name = "txtDomicilio"
        Me.txtDomicilio.Size = New System.Drawing.Size(100, 20)
        Me.txtDomicilio.TabIndex = 9
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(81, 190)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(28, 13)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Città"
        '
        'txtCittà
        '
        Me.txtCittà.Location = New System.Drawing.Point(214, 187)
        Me.txtCittà.Name = "txtCittà"
        Me.txtCittà.Size = New System.Drawing.Size(100, 20)
        Me.txtCittà.TabIndex = 11
        '
        'DbCittadiniDataSet1
        '
        Me.DbCittadiniDataSet1.DataSetName = "DbCittadiniDataSet"
        Me.DbCittadiniDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'DettaglioCittadini
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(489, 266)
        Me.Controls.Add(Me.txtCittà)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtDomicilio)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtResidenza)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtDataNascita)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtCognome)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtNome)
        Me.Controls.Add(Me.Label1)
        Me.Name = "DettaglioCittadini"
        Me.Text = "DettaglioCittadini"
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DbCittadiniDataSet1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtNome As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtCognome As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtDataNascita As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtResidenza As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtDomicilio As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtCittà As System.Windows.Forms.TextBox
    Friend WithEvents BindingSource1 As System.Windows.Forms.BindingSource
    Friend WithEvents DbCittadiniDataSet1 As ProgettoCittadini.DbCittadiniDataSet
End Class
