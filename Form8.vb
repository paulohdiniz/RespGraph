Public Class Form8
    Private Sub Form8_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim pathAlfaBetaGama As String = IO.Path.Combine(Application.StartupPath, "TxtsDasReferencias", "alfabetagamma" + ".png")
        Dim pathFormulas As String = IO.Path.Combine(Application.StartupPath, "TxtsDasReferencias", "formulas" + ".png")
        Try
            Using fs As New System.IO.FileStream(pathAlfaBetaGama, IO.FileMode.Open)
                PictureBox1.Image = New Bitmap(Image.FromStream(fs))
            End Using
        Catch ex As Exception
            Dim msg As String = "Filename: " & pathAlfaBetaGama &
                Environment.NewLine & Environment.NewLine &
                "Exception: " & ex.ToString
            MessageBox.Show(msg, "Error Opening Image File")
        End Try

        Try
            Using fs2 As New System.IO.FileStream(pathFormulas, IO.FileMode.Open)
                PictureBox2.Image = New Bitmap(Image.FromStream(fs2))
            End Using
        Catch ex As Exception
            Dim msg As String = "Filename: " & pathFormulas &
                Environment.NewLine & Environment.NewLine &
                "Exception: " & ex.ToString
            MessageBox.Show(msg, "Error Opening Image File")
        End Try
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim PathRef As String
        PathRef = "EQEeResponsividade"
        Dim filePath As String = IO.Path.Combine(Application.StartupPath, "TxtsDasReferencias", PathRef + ".pdf")
        Process.Start(filePath)
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub
End Class