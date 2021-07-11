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
End Class