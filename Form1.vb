Public Class Form1

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Form2.Visible = True
        Form2.WindowState = FormWindowState.Normal
        Form2.BringToFront()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Form3.Visible = True
        Form3.WindowState = FormWindowState.Normal
        Form3.BringToFront()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Sobre.Visible = True
        Sobre.WindowState = FormWindowState.Normal
        Sobre.BringToFront()
    End Sub

End Class
