Public Class Form8
    Private Sub Form8_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim path As String = IO.Path.Combine(Application.StartupPath, "TxtsDasReferencias", "alfa" + ".png")
        Try
            Using fs As New System.IO.FileStream(path, IO.FileMode.Open)
                PictureBox1.Image = New Bitmap(Image.FromStream(fs))
            End Using
        Catch ex As Exception
            Dim msg As String = "Filename: " & path &
                Environment.NewLine & Environment.NewLine &
                "Exception: " & ex.ToString
            MessageBox.Show(msg, "Error Opening Image File")
        End Try
    End Sub
End Class