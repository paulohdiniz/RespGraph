Imports System.Windows.Forms.DataVisualization.Charting

Public Class Form7
    'esse codigo abaixo eu peguei pronto. Ao descansar o mouse no gráfico ele da o ponto q vc passou por cima.
    Private Sub Chart1_MouseMove(sender As Object, e As MouseEventArgs) Handles Chart1.MouseMove
        Dim h As Windows.Forms.DataVisualization.Charting.HitTestResult = Chart1.HitTest(e.X, e.Y)
        If h.ChartElementType = DataVisualization.Charting.ChartElementType.DataPoint Then
            ToolTip1.SetToolTip(Chart1, "(" & h.Series.Points(h.PointIndex).XValue & " ; " & h.Series.Points(h.PointIndex).YValues(0) & ")")
        End If
    End Sub

    Public Sub Chart1_FormatNumber(sender As Object, e As DataVisualization.Charting.FormatNumberEventArgs) Handles Chart1.FormatNumber
        If (e.ElementType = DataVisualization.Charting.ChartElementType.AxisLabels) Then
            If e.Value > 20 And e.Format.Equals("eixoX") Then
                If e.Value < 100 Then
                    e.LocalizedValue = e.Value - (e.Value Mod 10)
                ElseIf e.Value < 1000 Then
                    e.LocalizedValue = e.Value - (e.Value Mod 10)
                ElseIf e.Value < 10000 Then
                    e.LocalizedValue = e.Value - (e.Value Mod 10)
                ElseIf e.Value < 100000 Then
                    e.LocalizedValue = e.Value - (e.Value Mod 10)
                End If
            End If
        End If
    End Sub

    Private Sub FileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FileToolStripMenuItem.Click
        Dim sfdPic As New SaveFileDialog()
        sfdPic.RestoreDirectory = True

        Dim title As String = "Veja a imagem."
        Dim btn = MessageBoxButtons.YesNo
        Dim ico = MessageBoxIcon.Information
        Try
            With sfdPic
                .Title = "Salve a imagem como"
                .Filter = "PNG IMAGEM|*.png"
                .AddExtension = True
                .DefaultExt = ".png"
                .FileName = "Imagem.png"
                .ValidateNames = True
                .OverwritePrompt = True
                .RestoreDirectory = True

                If .ShowDialog = DialogResult.OK Then
                    Chart1.SaveImage(sfdPic.FileName, System.Drawing.Imaging.ImageFormat.Png)
                Else
                    Return
                End If

            End With

            Dim r As DialogResult
            Dim msg As String = "A imagem foi salva corretamente." & vbNewLine
            msg &= "Você quer ver a imagem agora?"

            r = MessageBox.Show(msg, title, btn, ico)

            If r = System.Windows.Forms.DialogResult.Yes Then
                Dim startInfo As New ProcessStartInfo("mspaint.exe")
                startInfo.WindowStyle = ProcessWindowStyle.Maximized
                startInfo.Arguments = sfdPic.FileName
                Process.Start(startInfo)
            Else
                Return
            End If

        Catch ex As Exception
            MessageBox.Show("Erro: Salvar a imagem falhou ->> " & ex.Message.ToString())
        Finally
            sfdPic.Dispose()

        End Try
    End Sub

    Public Sub chart1_AnnotationPositionChanged(sender As Object, e As EventArgs) Handles Chart1.AnnotationPositionChanged
        Dim VA = Chart1.Annotations.FindByName("VA")
        Dim RA As RectangleAnnotation = Chart1.Annotations.FindByName("RA")

        VA.X = Int(VA.X + 0.5)
        RA.X = VA.X - RA.Width / 2

        RA.Text = VA.X

        RA.Width = MaiorRange() / 16.5 'number magic !!!
        Chart1.Update()

    End Sub
    Public Sub chart1_AnnotationPositionChanging(sender As Object, e As AnnotationPositionChangingEventArgs) Handles Chart1.AnnotationPositionChanging
        Dim VA = Chart1.Annotations.FindByName("VA")
        Dim RA As RectangleAnnotation = Chart1.Annotations.FindByName("RA")

        If sender.Equals(VA) Then
            RA.X = VA.X - RA.Width / 2
        End If
        Chart1.Update()

    End Sub
    Private Function MaiorRange() As Double
        'redimensionando
        Dim maiorRang As Double = 0
        Dim lastPoint As Integer
        Dim range As Double
        For Each serie In Chart1.Series
            lastPoint = serie.Points.Count - 1
            range = serie.Points(lastPoint).XValue - serie.Points(0).XValue
            If range > maiorRang Then
                maiorRang = range
            End If
        Next
        Return maiorRang
    End Function

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        'mostrar ou não mostrar a linha vertical auxiliar
        If Chart1.Annotations.Count = 0 Then

        Else
            If CheckBox1.Checked Then
                For i = 0 To Chart1.Annotations.Count - 1
                    Chart1.Annotations(i).Visible = True
                Next
            Else
                For i = 0 To Chart1.Annotations.Count - 1
                    Chart1.Annotations(i).Visible = False
                Next
            End If
        End If
    End Sub
End Class