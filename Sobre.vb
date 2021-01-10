Public NotInheritable Class Sobre

    Private Sub AboutBox1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Configura o titulo do formulário.
        Dim ApplicationTitle As String
        If My.Application.Info.Title <> "" Then
            ApplicationTitle = My.Application.Info.Title
        Else
            ApplicationTitle = System.IO.Path.GetFileNameWithoutExtension(My.Application.Info.AssemblyName)
        End If
        Me.Text = String.Format("Sobre {0}", ApplicationTitle)
        ' Inicializa todo o texto exibido na About Box.
        ' TODO: Personalize o assembly da aplicação no painel "Application" das propriedades do projeto 
        '    (abaixo do menu"Project").
        Me.LabelProductName.Text = Me.LabelProductName.Text
        Me.LabelVersion.Text = Me.LabelVersion.Text
        Me.LabelCompanyName.Text = Me.LabelCompanyName.Text
        Me.TextBoxDescription.Text = Me.TextBoxDescription.Text
    End Sub

    Private Sub OKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OKButton.Click
        Me.Close()
    End Sub

End Class
