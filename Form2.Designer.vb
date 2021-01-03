<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form2
    Inherits System.Windows.Forms.Form

    'Descartar substituições de formulário para limpar a lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Exigido pelo Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'OBSERVAÇÃO: o procedimento a seguir é exigido pelo Windows Form Designer
    'Pode ser modificado usando o Windows Form Designer.  
    'Não o modifique usando o editor de códigos.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.TextBox5 = New System.Windows.Forms.TextBox()
        Me.TextBox6 = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TextBox7 = New System.Windows.Forms.TextBox()
        Me.ButtonOut = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TextBox8 = New System.Windows.Forms.TextBox()
        Me.TextBox9 = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(33, 39)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(228, 26)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Sensor de Referência"
        '
        'ComboBox1
        '
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"Si antigo", "EOS Si S-type detector S-series", "EOS Si S-type detector UVS-series", "IGA-010-E-LN6N (22)", "IGA-010-E-LN6N (-30)", "IGA-010-E-LN6N (-196)", "IS-010-E-LN6N", "MCT14-010-E-LN6N", "MCT20-010-E-LN6N"})
        Me.ComboBox1.Location = New System.Drawing.Point(21, 84)
        Me.ComboBox1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(269, 24)
        Me.ComboBox1.TabIndex = 7
        '
        'Button4
        '
        Me.Button4.Font = New System.Drawing.Font("Times New Roman", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.Location = New System.Drawing.Point(617, 233)
        Me.Button4.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(111, 38)
        Me.Button4.TabIndex = 18
        Me.Button4.Text = "Buscar"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Times New Roman", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(565, 63)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(227, 26)
        Me.Label3.TabIndex = 17
        Me.Label3.Text = "Espectro da Amostra"
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(535, 122)
        Me.TextBox2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TextBox2.Multiline = True
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.ReadOnly = True
        Me.TextBox2.Size = New System.Drawing.Size(280, 50)
        Me.TextBox2.TabIndex = 16
        '
        'Button3
        '
        Me.Button3.Font = New System.Drawing.Font("Times New Roman", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.Location = New System.Drawing.Point(100, 453)
        Me.Button3.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(120, 39)
        Me.Button3.TabIndex = 15
        Me.Button3.Text = "Buscar"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(21, 327)
        Me.TextBox1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(280, 50)
        Me.TextBox1.TabIndex = 14
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(49, 272)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(228, 52)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "Espectro do " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Sensor de Referência"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(580, 563)
        Me.Button2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(197, 41)
        Me.Button2.TabIndex = 12
        Me.Button2.Text = "Ready"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(35, 390)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(74, 17)
        Me.Label4.TabIndex = 19
        Me.Label4.Text = "Área (mm)"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(199, 390)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(102, 17)
        Me.Label5.TabIndex = 20
        Me.Label5.Text = "Distância (mm)"
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(21, 410)
        Me.TextBox3.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(100, 22)
        Me.TextBox3.TabIndex = 23
        '
        'TextBox4
        '
        Me.TextBox4.Location = New System.Drawing.Point(201, 410)
        Me.TextBox4.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(100, 22)
        Me.TextBox4.TabIndex = 24
        '
        'TextBox5
        '
        Me.TextBox5.Location = New System.Drawing.Point(535, 206)
        Me.TextBox5.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Size = New System.Drawing.Size(100, 22)
        Me.TextBox5.TabIndex = 25
        '
        'TextBox6
        '
        Me.TextBox6.Location = New System.Drawing.Point(715, 206)
        Me.TextBox6.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.Size = New System.Drawing.Size(100, 22)
        Me.TextBox6.TabIndex = 26
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(551, 185)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(74, 17)
        Me.Label6.TabIndex = 27
        Me.Label6.Text = "Área (mm)"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(713, 185)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(102, 17)
        Me.Label7.TabIndex = 28
        Me.Label7.Text = "Distância (mm)"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(597, 322)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(149, 20)
        Me.Label8.TabIndex = 29
        Me.Label8.Text = "Arquivo de saída"
        '
        'TextBox7
        '
        Me.TextBox7.Location = New System.Drawing.Point(535, 345)
        Me.TextBox7.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TextBox7.Multiline = True
        Me.TextBox7.Name = "TextBox7"
        Me.TextBox7.ReadOnly = True
        Me.TextBox7.Size = New System.Drawing.Size(280, 50)
        Me.TextBox7.TabIndex = 30
        '
        'ButtonOut
        '
        Me.ButtonOut.Font = New System.Drawing.Font("Times New Roman", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonOut.Location = New System.Drawing.Point(617, 401)
        Me.ButtonOut.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.ButtonOut.Name = "ButtonOut"
        Me.ButtonOut.Size = New System.Drawing.Size(111, 38)
        Me.ButtonOut.TabIndex = 31
        Me.ButtonOut.Text = "Buscar"
        Me.ButtonOut.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(561, 465)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(64, 17)
        Me.Label9.TabIndex = 32
        Me.Label9.Text = "Usuário"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(702, 465)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(136, 17)
        Me.Label10.TabIndex = 33
        Me.Label10.Text = "Nome da Amostra"
        '
        'TextBox8
        '
        Me.TextBox8.Location = New System.Drawing.Point(535, 484)
        Me.TextBox8.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TextBox8.Multiline = True
        Me.TextBox8.Name = "TextBox8"
        Me.TextBox8.Size = New System.Drawing.Size(114, 45)
        Me.TextBox8.TabIndex = 34
        '
        'TextBox9
        '
        Me.TextBox9.Location = New System.Drawing.Point(705, 484)
        Me.TextBox9.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TextBox9.Multiline = True
        Me.TextBox9.Name = "TextBox9"
        Me.TextBox9.Size = New System.Drawing.Size(133, 45)
        Me.TextBox9.TabIndex = 35
        '
        'Form2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(890, 625)
        Me.Controls.Add(Me.TextBox9)
        Me.Controls.Add(Me.TextBox8)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.ButtonOut)
        Me.Controls.Add(Me.TextBox7)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.TextBox6)
        Me.Controls.Add(Me.TextBox5)
        Me.Controls.Add(Me.TextBox4)
        Me.Controls.Add(Me.TextBox3)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.Label1)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "Form2"
        Me.Text = "Calculando..."
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents Button4 As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents Button3 As Button
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Button2 As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents TextBox4 As TextBox
    Friend WithEvents TextBox5 As TextBox
    Friend WithEvents TextBox6 As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents TextBox7 As TextBox
    Friend WithEvents ButtonOut As Button
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents TextBox8 As TextBox
    Friend WithEvents TextBox9 As TextBox
End Class
