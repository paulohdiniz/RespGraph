Public Class Form1
    Private Sub OpenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem.Click
        Form2.Visible = True
    End Sub
    Private Sub PlotarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PlotarToolStripMenuItem.Click
        Form3.Visible = True
    End Sub



    'esse codigo abaixo eu peguei pronto. Ao descansar o mouse no gráfico ele da o ponto q vc passou por cima.
    Private Sub Chart1_MouseMove(sender As Object, e As MouseEventArgs) Handles Chart1.MouseMove
        Dim h As Windows.Forms.DataVisualization.Charting.HitTestResult = Chart1.HitTest(e.X, e.Y)
        If h.ChartElementType = DataVisualization.Charting.ChartElementType.DataPoint Then
            ToolTip1.SetToolTip(Chart1, "(" & h.Series.Points(h.PointIndex).XValue & " ; " & h.Series.Points(h.PointIndex).YValues(0) & ")")
        End If
    End Sub

    Private Sub SobreToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SobreToolStripMenuItem.Click
        Sobre.Visible = True
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim nomeImagem As String
        Dim pathDirectory As String
        Dim pathFileIMG As String
        If String.IsNullOrEmpty(TextBox1.Text) Then
            nomeImagem = "ChartImage-RESPGRAPH"
        Else
            nomeImagem = TextBox1.Text
        End If
        FolderBrowserDialog1.ShowDialog()

        If String.IsNullOrEmpty(FolderBrowserDialog1.SelectedPath) Then
            MsgBox("Você cancelou a abertura")
            Exit Sub
        Else
            pathDirectory = FolderBrowserDialog1.SelectedPath
        End If
        pathFileIMG = pathDirectory & "\" & nomeImagem & ".png"
        If System.IO.File.Exists(pathFileIMG) = True Then
            MsgBox("Já existe um arquivo com esse nome, para não sobescrever o mesmo(e perder a imagem antiga) escolha outro nome.")
            Exit Sub
        Else
            Chart1.SaveImage(pathFileIMG, System.Drawing.Imaging.ImageFormat.Png)
            MsgBox("A imagem " & nomeImagem & " foi salva.")
        End If

    End Sub
End Class
