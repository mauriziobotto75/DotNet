<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPrincipale
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
        Me.btnGestisciCittadini = New System.Windows.Forms.Button
        Me.btnVisualizzaCittadini = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'btnGestisciCittadini
        '
        Me.btnGestisciCittadini.Location = New System.Drawing.Point(54, 48)
        Me.btnGestisciCittadini.Name = "btnGestisciCittadini"
        Me.btnGestisciCittadini.Size = New System.Drawing.Size(117, 51)
        Me.btnGestisciCittadini.TabIndex = 0
        Me.btnGestisciCittadini.Text = "Gestione Cittadini"
        Me.btnGestisciCittadini.UseVisualStyleBackColor = True
        '
        'btnVisualizzaCittadini
        '
        Me.btnVisualizzaCittadini.Location = New System.Drawing.Point(54, 120)
        Me.btnVisualizzaCittadini.Name = "btnVisualizzaCittadini"
        Me.btnVisualizzaCittadini.Size = New System.Drawing.Size(117, 51)
        Me.btnVisualizzaCittadini.TabIndex = 1
        Me.btnVisualizzaCittadini.Text = "Visualizza Cittadini"
        Me.btnVisualizzaCittadini.UseVisualStyleBackColor = True
        '
        'frmPrincipale
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(487, 266)
        Me.Controls.Add(Me.btnVisualizzaCittadini)
        Me.Controls.Add(Me.btnGestisciCittadini)
        Me.Name = "frmPrincipale"
        Me.Text = "frmPrincipale"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnGestisciCittadini As System.Windows.Forms.Button
    Friend WithEvents btnVisualizzaCittadini As System.Windows.Forms.Button
End Class
