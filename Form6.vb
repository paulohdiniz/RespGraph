Imports System.Windows.Forms.DataVisualization.Charting

Public Class Form6
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

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim sfdPic As New SaveFileDialog()

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

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'validacoes
        If (CheckBox7.Checked) Then
            CheckBox1.Checked = True
        End If
        If (CheckBox8.Checked) Then
            CheckBox2.Checked = True
        End If
        If (CheckBox9.Checked) Then
            CheckBox3.Checked = True
        End If
        If (CheckBox10.Checked) Then
            CheckBox4.Checked = True
        End If
        If (CheckBox11.Checked) Then
            CheckBox5.Checked = True
        End If
        If (CheckBox12.Checked) Then
            CheckBox6.Checked = True
        End If

        Dim quantidadeDeCurvas = IIf(CheckBox1.Checked, 1, 0) + IIf(CheckBox2.Checked, 1, 0) + IIf(CheckBox3.Checked, 1, 0) +
            IIf(CheckBox4.Checked, 1, 0) + IIf(CheckBox5.Checked, 1, 0) + IIf(CheckBox6.Checked, 1, 0)

        If quantidadeDeCurvas = 0 Then
            MsgBox("Selecione alguma curva para ser exibida !",, "Atenção !")
            Exit Sub
        End If

        Dim listaSensores As New List(Of SensorFabricante)

        If (CheckBox1.Checked) Then
            If (CheckBox7.Checked) Then
                listaSensores.Add(New SensorFabricante(CheckBox1.Text).Normalized)
            Else
                listaSensores.Add(New SensorFabricante(CheckBox1.Text))
            End If
        End If
        If (CheckBox2.Checked) Then
            If (CheckBox8.Checked) Then
                listaSensores.Add(New SensorFabricante(CheckBox2.Text).Normalized)
            Else
                listaSensores.Add(New SensorFabricante(CheckBox2.Text))
            End If
        End If
        If (CheckBox3.Checked) Then
            If (CheckBox9.Checked) Then
                listaSensores.Add(New SensorFabricante(CheckBox3.Text).Normalized)
            Else
                listaSensores.Add(New SensorFabricante(CheckBox3.Text))
            End If
        End If
        If (CheckBox4.Checked) Then
            If (CheckBox10.Checked) Then
                listaSensores.Add(New SensorFabricante(CheckBox4.Text).Normalized)
            Else
                listaSensores.Add(New SensorFabricante(CheckBox4.Text))
            End If
        End If
        If (CheckBox5.Checked) Then
            If (CheckBox11.Checked) Then
                listaSensores.Add(New SensorFabricante(CheckBox5.Text).Normalized)
            Else
                listaSensores.Add(New SensorFabricante(CheckBox5.Text))
            End If
        End If
        If (CheckBox6.Checked) Then
            If (CheckBox12.Checked) Then
                listaSensores.Add(New SensorFabricante(CheckBox6.Text).Normalized)
            Else
                listaSensores.Add(New SensorFabricante(CheckBox6.Text))
            End If
        End If

        'Começa a mexer no chart
        Dim titulo As String
        If quantidadeDeCurvas = 1 Then
            titulo = "Curva do sensor    " & listaSensores(0).Nome
        Else
            titulo = "Curvas dos sensores"
        End If

        Dim nomeEixoY As String = " "
        Dim maximoY As Double
        ' N indica o numero como ele realmente é, o NX indica com X casas decimais
        Dim formatX As String = "eixoX"
        Dim formatY As String
        If (CheckBox7.Checked Or CheckBox8.Checked Or CheckBox9.Checked Or CheckBox10.Checked Or CheckBox11.Checked Or CheckBox12.Checked) Then
            maximoY = 1.0
            formatY = "N1"
        Else
            If listaSensores.Count = 1 Then
                nomeEixoY = listaSensores(0).UnidadeResponsividade
            End If
            maximoY = Double.NaN
            formatY = "N1"
        End If

        Me.Chart1.Titles.Clear()
        Me.Chart1.Titles.Add(titulo) 'specify chart name
        Me.Chart1.Titles(0).Font = New Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold) 'mexa aqui pra mudar a fonte do titulo
        Me.Chart1.ChartAreas.Clear()
        Me.Chart1.Series.Clear()
        Me.Chart1.Annotations.Clear()
        Me.Chart1.ChartAreas.Add(titulo)
        Me.Chart1.AntiAliasing = True
        With Me.Chart1.ChartAreas(titulo)
            .AxisX.Title = "Comprimento de onda(nm)" 'x label
            .AxisX.MajorGrid.LineColor = Color.SkyBlue
            .AxisY.MajorGrid.LineColor = Color.SkyBlue
            .AxisY.Title = nomeEixoY 'y label
            .AxisX.Minimum = Double.NaN 'LIMITANDO O GRAFICO EM X ENTRE O VALOR MINIMUM E MAXIMUM
            .AxisX.Maximum = Double.NaN
            .AxisY.Maximum = maximoY
            .AxisX.LabelStyle.Format = formatX
            .AxisY.LabelStyle.Format = formatY
        End With

        ' INICIO - 1 GRAFICO
        If quantidadeDeCurvas = 1 Then
            Me.Chart1.Series.Clear()
            Me.Chart1.Series.Add(listaSensores(0).Nome)
            Me.Chart1.Series(listaSensores(0).Nome).Color = Color.FromKnownColor(KnownColor.Red)
            Me.Chart1.Series(listaSensores(0).Nome).ChartType = DataVisualization.Charting.SeriesChartType.Line

            Dim path As String = listaSensores(0).PathSensor
            If path = Nothing Then 'caso em que a abertura foi cancelada, o path ira vir nothinh e vc cancela o evento do butao
                Exit Sub
            End If
            Text = readTxtComplete(path)
            Dim y() As Double = getColumYOfStringComplete(Text)
            Dim x() As Double = getColumXOfStringComplete(Text)

            For i = 0 To x.Length - 2 'o ultimo elemento é 0, pois o vetor foi acrescentado e nada foi adiconado ao mesmo
                Me.Chart1.Series(listaSensores(0).Nome).Points.AddXY(x(i), y(i))
            Next i
        End If

        ' FIM - 1 GRAFICO
        ' INICIO - 2 GRAFICOS
        If quantidadeDeCurvas = 2 Then
            Me.Chart1.Series.Clear()
            Me.Chart1.Series.Add(listaSensores(0).Nome)
            Me.Chart1.Series(listaSensores(0).Nome).Color = Color.FromKnownColor(KnownColor.Red)
            Me.Chart1.Series(listaSensores(0).Nome).ChartType = DataVisualization.Charting.SeriesChartType.Line

            Dim path As String = listaSensores(0).PathSensor
            If path = Nothing Then 'caso em que a abertura foi cancelada, o path ira vir nothinh e vc cancela o evento do butao
                Exit Sub
            End If
            Text = readTxtComplete(path)
            Dim y() As Double = getColumYOfStringComplete(Text)
            Dim x() As Double = getColumXOfStringComplete(Text)

            For i = 0 To x.Length - 2 'o ultimo elemento é 0, pois o vetor foi acrescentado e nada foi adiconado ao mesmo
                Me.Chart1.Series(listaSensores(0).Nome).Points.AddXY(x(i), y(i))
            Next i

            Me.Chart1.Series.Add(listaSensores(1).Nome)
            Me.Chart1.Series(listaSensores(1).Nome).Color = Color.FromKnownColor(KnownColor.Blue)
            Me.Chart1.Series(listaSensores(1).Nome).ChartType = DataVisualization.Charting.SeriesChartType.Line

            Dim path1 As String = listaSensores(1).PathSensor
            If path1 = Nothing Then 'caso em que a abertura foi cancelada, o path ira vir nothinh e vc cancela o evento do butao
                Exit Sub
            End If
            Dim Text1 As String = readTxtComplete(path1)
            Dim y1() As Double = getColumYOfStringComplete(Text1)
            Dim x1() As Double = getColumXOfStringComplete(Text1)

            For i = 0 To x1.Length - 2 'o ultimo elemento é 0, pois o vetor foi acrescentado e nada foi adiconado ao mesmo
                Me.Chart1.Series(listaSensores(1).Nome).Points.AddXY(x1(i), y1(i))
            Next i

        End If
        ' FIM - 2 GRAFICOS
        ' INICIO - 3 GRAFICOS
        If quantidadeDeCurvas = 3 Then
            Me.Chart1.Series.Clear()
            Me.Chart1.Series.Add(listaSensores(0).Nome)
            Me.Chart1.Series(listaSensores(0).Nome).Color = Color.FromKnownColor(KnownColor.Red)
            Me.Chart1.Series(listaSensores(0).Nome).ChartType = DataVisualization.Charting.SeriesChartType.Line

            Dim path As String = listaSensores(0).PathSensor
            If path = Nothing Then 'caso em que a abertura foi cancelada, o path ira vir nothinh e vc cancela o evento do butao
                Exit Sub
            End If
            Text = readTxtComplete(path)
            Dim y() As Double = getColumYOfStringComplete(Text)
            Dim x() As Double = getColumXOfStringComplete(Text)

            For i = 0 To x.Length - 2 'o ultimo elemento é 0, pois o vetor foi acrescentado e nada foi adiconado ao mesmo
                Me.Chart1.Series(listaSensores(0).Nome).Points.AddXY(x(i), y(i))
            Next i

            Me.Chart1.Series.Add(listaSensores(1).Nome)
            Me.Chart1.Series(listaSensores(1).Nome).Color = Color.FromKnownColor(KnownColor.Blue)
            Me.Chart1.Series(listaSensores(1).Nome).ChartType = DataVisualization.Charting.SeriesChartType.Line

            Dim path1 As String = listaSensores(1).PathSensor
            If path1 = Nothing Then 'caso em que a abertura foi cancelada, o path ira vir nothinh e vc cancela o evento do butao
                Exit Sub
            End If
            Dim Text1 As String = readTxtComplete(path1)
            Dim y1() As Double = getColumYOfStringComplete(Text1)
            Dim x1() As Double = getColumXOfStringComplete(Text1)

            For i = 0 To x1.Length - 2 'o ultimo elemento é 0, pois o vetor foi acrescentado e nada foi adiconado ao mesmo
                Me.Chart1.Series(listaSensores(1).Nome).Points.AddXY(x1(i), y1(i))
            Next i

            Me.Chart1.Series.Add(listaSensores(2).Nome)
            Me.Chart1.Series(listaSensores(2).Nome).Color = Color.FromKnownColor(KnownColor.Green)
            Me.Chart1.Series(listaSensores(2).Nome).ChartType = DataVisualization.Charting.SeriesChartType.Line

            Dim path2 As String = listaSensores(2).PathSensor
            If path2 = Nothing Then 'caso em que a abertura foi cancelada, o path ira vir nothinh e vc cancela o evento do butao
                Exit Sub
            End If
            Dim Text2 As String = readTxtComplete(path2)
            Dim y2() As Double = getColumYOfStringComplete(Text2)
            Dim x2() As Double = getColumXOfStringComplete(Text2)

            For i = 0 To x2.Length - 2 'o ultimo elemento é 0, pois o vetor foi acrescentado e nada foi adiconado ao mesmo
                Me.Chart1.Series(listaSensores(2).Nome).Points.AddXY(x2(i), y2(i))
            Next i

        End If
        ' FIM - 3 GRAFICOS
        ' INICIO - 4 GRAFICOS
        If quantidadeDeCurvas = 4 Then
            Me.Chart1.Series.Clear()
            Me.Chart1.Series.Add(listaSensores(0).Nome)
            Me.Chart1.Series(listaSensores(0).Nome).Color = Color.FromKnownColor(KnownColor.Red)
            Me.Chart1.Series(listaSensores(0).Nome).ChartType = DataVisualization.Charting.SeriesChartType.Line

            Dim path As String = listaSensores(0).PathSensor
            If path = Nothing Then 'caso em que a abertura foi cancelada, o path ira vir nothinh e vc cancela o evento do butao
                Exit Sub
            End If
            Text = readTxtComplete(path)
            Dim y() As Double = getColumYOfStringComplete(Text)
            Dim x() As Double = getColumXOfStringComplete(Text)

            For i = 0 To x.Length - 2 'o ultimo elemento é 0, pois o vetor foi acrescentado e nada foi adiconado ao mesmo
                Me.Chart1.Series(listaSensores(0).Nome).Points.AddXY(x(i), y(i))
            Next i

            Me.Chart1.Series.Add(listaSensores(1).Nome)
            Me.Chart1.Series(listaSensores(1).Nome).Color = Color.FromKnownColor(KnownColor.Blue)
            Me.Chart1.Series(listaSensores(1).Nome).ChartType = DataVisualization.Charting.SeriesChartType.Line

            Dim path1 As String = listaSensores(1).PathSensor
            If path1 = Nothing Then 'caso em que a abertura foi cancelada, o path ira vir nothinh e vc cancela o evento do butao
                Exit Sub
            End If
            Dim Text1 As String = readTxtComplete(path1)
            Dim y1() As Double = getColumYOfStringComplete(Text1)
            Dim x1() As Double = getColumXOfStringComplete(Text1)

            For i = 0 To x1.Length - 2 'o ultimo elemento é 0, pois o vetor foi acrescentado e nada foi adiconado ao mesmo
                Me.Chart1.Series(listaSensores(1).Nome).Points.AddXY(x1(i), y1(i))
            Next i

            Me.Chart1.Series.Add(listaSensores(2).Nome)
            Me.Chart1.Series(listaSensores(2).Nome).Color = Color.FromKnownColor(KnownColor.Green)
            Me.Chart1.Series(listaSensores(2).Nome).ChartType = DataVisualization.Charting.SeriesChartType.Line

            Dim path2 As String = listaSensores(2).PathSensor
            If path2 = Nothing Then 'caso em que a abertura foi cancelada, o path ira vir nothinh e vc cancela o evento do butao
                Exit Sub
            End If
            Dim Text2 As String = readTxtComplete(path2)
            Dim y2() As Double = getColumYOfStringComplete(Text2)
            Dim x2() As Double = getColumXOfStringComplete(Text2)

            For i = 0 To x2.Length - 2 'o ultimo elemento é 0, pois o vetor foi acrescentado e nada foi adiconado ao mesmo
                Me.Chart1.Series(listaSensores(2).Nome).Points.AddXY(x2(i), y2(i))
            Next i

            Me.Chart1.Series.Add(listaSensores(3).Nome)
            Me.Chart1.Series(listaSensores(3).Nome).Color = Color.FromKnownColor(KnownColor.Black)
            Me.Chart1.Series(listaSensores(3).Nome).ChartType = DataVisualization.Charting.SeriesChartType.Line

            Dim path3 As String = listaSensores(3).PathSensor
            If path3 = Nothing Then 'caso em que a abertura foi cancelada, o path ira vir nothinh e vc cancela o evento do butao
                Exit Sub
            End If
            Dim Text3 As String = readTxtComplete(path3)
            Dim y3() As Double = getColumYOfStringComplete(Text3)
            Dim x3() As Double = getColumXOfStringComplete(Text3)

            For i = 0 To x3.Length - 2 'o ultimo elemento é 0, pois o vetor foi acrescentado e nada foi adiconado ao mesmo
                Me.Chart1.Series(listaSensores(3).Nome).Points.AddXY(x3(i), y3(i))
            Next i
        End If
        ' FIM - 4 GRAFICOS
        ' INICIO - 5 GRAFICOS
        If quantidadeDeCurvas = 5 Then
            Me.Chart1.Series.Clear()
            Me.Chart1.Series.Add(listaSensores(0).Nome)
            Me.Chart1.Series(listaSensores(0).Nome).Color = Color.FromKnownColor(KnownColor.Red)
            Me.Chart1.Series(listaSensores(0).Nome).ChartType = DataVisualization.Charting.SeriesChartType.Line

            Dim path As String = listaSensores(0).PathSensor
            If path = Nothing Then 'caso em que a abertura foi cancelada, o path ira vir nothinh e vc cancela o evento do butao
                Exit Sub
            End If
            Text = readTxtComplete(path)
            Dim y() As Double = getColumYOfStringComplete(Text)
            Dim x() As Double = getColumXOfStringComplete(Text)

            For i = 0 To x.Length - 2 'o ultimo elemento é 0, pois o vetor foi acrescentado e nada foi adiconado ao mesmo
                Me.Chart1.Series(listaSensores(0).Nome).Points.AddXY(x(i), y(i))
            Next i

            Me.Chart1.Series.Add(listaSensores(1).Nome)
            Me.Chart1.Series(listaSensores(1).Nome).Color = Color.FromKnownColor(KnownColor.Blue)
            Me.Chart1.Series(listaSensores(1).Nome).ChartType = DataVisualization.Charting.SeriesChartType.Line
            Dim path1 As String = listaSensores(1).PathSensor
            If path1 = Nothing Then 'caso em que a abertura foi cancelada, o path ira vir nothinh e vc cancela o evento do butao
                Exit Sub
            End If
            Dim Text1 As String = readTxtComplete(path1)
            Dim y1() As Double = getColumYOfStringComplete(Text1)
            Dim x1() As Double = getColumXOfStringComplete(Text1)
            For i = 0 To x1.Length - 2 'o ultimo elemento é 0, pois o vetor foi acrescentado e nada foi adiconado ao mesmo
                Me.Chart1.Series(listaSensores(1).Nome).Points.AddXY(x1(i), y1(i))
            Next i

            Me.Chart1.Series.Add(listaSensores(2).Nome)
            Me.Chart1.Series(listaSensores(2).Nome).Color = Color.FromKnownColor(KnownColor.Green)
            Me.Chart1.Series(listaSensores(2).Nome).ChartType = DataVisualization.Charting.SeriesChartType.Line
            Dim path2 As String = listaSensores(2).PathSensor
            If path2 = Nothing Then 'caso em que a abertura foi cancelada, o path ira vir nothinh e vc cancela o evento do butao
                Exit Sub
            End If
            Dim Text2 As String = readTxtComplete(path2)
            Dim y2() As Double = getColumYOfStringComplete(Text2)
            Dim x2() As Double = getColumXOfStringComplete(Text2)
            For i = 0 To x2.Length - 2 'o ultimo elemento é 0, pois o vetor foi acrescentado e nada foi adiconado ao mesmo
                Me.Chart1.Series(listaSensores(2).Nome).Points.AddXY(x2(i), y2(i))
            Next i

            Me.Chart1.Series.Add(listaSensores(3).Nome)
            Me.Chart1.Series(listaSensores(3).Nome).Color = Color.FromKnownColor(KnownColor.Black)
            Me.Chart1.Series(listaSensores(3).Nome).ChartType = DataVisualization.Charting.SeriesChartType.Line

            Dim path3 As String = listaSensores(3).PathSensor
            If path3 = Nothing Then 'caso em que a abertura foi cancelada, o path ira vir nothinh e vc cancela o evento do butao
                Exit Sub
            End If
            Dim Text3 As String = readTxtComplete(path3)
            Dim y3() As Double = getColumYOfStringComplete(Text3)
            Dim x3() As Double = getColumXOfStringComplete(Text3)

            For i = 0 To x3.Length - 2 'o ultimo elemento é 0, pois o vetor foi acrescentado e nada foi adiconado ao mesmo
                Me.Chart1.Series(listaSensores(3).Nome).Points.AddXY(x3(i), y3(i))
            Next i

            Me.Chart1.Series.Add(listaSensores(4).Nome)
            Me.Chart1.Series(listaSensores(4).Nome).Color = Color.FromKnownColor(KnownColor.Yellow)
            Me.Chart1.Series(listaSensores(4).Nome).ChartType = DataVisualization.Charting.SeriesChartType.Line
            Dim path4 As String = listaSensores(4).PathSensor
            If path4 = Nothing Then 'caso em que a abertura foi cancelada, o path ira vir nothinh e vc cancela o evento do butao
                Exit Sub
            End If
            Dim Text4 As String = readTxtComplete(path4)
            Dim y4() As Double = getColumYOfStringComplete(Text4)
            Dim x4() As Double = getColumXOfStringComplete(Text4)
            For i = 0 To x4.Length - 2 'o ultimo elemento é 0, pois o vetor foi acrescentado e nada foi adiconado ao mesmo
                Me.Chart1.Series(listaSensores(4).Nome).Points.AddXY(x4(i), y4(i))
            Next i
        End If
        ' FIM - 5 GRAFICOS
        ' INICIO - 6 GRAFICOS
        If quantidadeDeCurvas = 6 Then
            Me.Chart1.Series.Clear()
            Me.Chart1.Series.Add(listaSensores(0).Nome)
            Me.Chart1.Series(listaSensores(0).Nome).Color = Color.FromKnownColor(KnownColor.Red)
            Me.Chart1.Series(listaSensores(0).Nome).ChartType = DataVisualization.Charting.SeriesChartType.Line
            Dim path As String = listaSensores(0).PathSensor
            If path = Nothing Then 'caso em que a abertura foi cancelada, o path ira vir nothinh e vc cancela o evento do butao
                Exit Sub
            End If
            Text = readTxtComplete(path)
            Dim y() As Double = getColumYOfStringComplete(Text)
            Dim x() As Double = getColumXOfStringComplete(Text)
            For i = 0 To x.Length - 2 'o ultimo elemento é 0, pois o vetor foi acrescentado e nada foi adiconado ao mesmo
                Me.Chart1.Series(listaSensores(0).Nome).Points.AddXY(x(i), y(i))
            Next i

            Me.Chart1.Series.Add(listaSensores(1).Nome)
            Me.Chart1.Series(listaSensores(1).Nome).Color = Color.FromKnownColor(KnownColor.Blue)
            Me.Chart1.Series(listaSensores(1).Nome).ChartType = DataVisualization.Charting.SeriesChartType.Line
            Dim path1 As String = listaSensores(1).PathSensor
            If path1 = Nothing Then 'caso em que a abertura foi cancelada, o path ira vir nothinh e vc cancela o evento do butao
                Exit Sub
            End If
            Dim Text1 As String = readTxtComplete(path1)
            Dim y1() As Double = getColumYOfStringComplete(Text1)
            Dim x1() As Double = getColumXOfStringComplete(Text1)
            For i = 0 To x1.Length - 2 'o ultimo elemento é 0, pois o vetor foi acrescentado e nada foi adiconado ao mesmo
                Me.Chart1.Series(listaSensores(1).Nome).Points.AddXY(x1(i), y1(i))
            Next i

            Me.Chart1.Series.Add(listaSensores(2).Nome)
            Me.Chart1.Series(listaSensores(2).Nome).Color = Color.FromKnownColor(KnownColor.Green)
            Me.Chart1.Series(listaSensores(2).Nome).ChartType = DataVisualization.Charting.SeriesChartType.Line

            Dim path2 As String = listaSensores(2).PathSensor
            If path2 = Nothing Then 'caso em que a abertura foi cancelada, o path ira vir nothinh e vc cancela o evento do butao
                Exit Sub
            End If
            Dim Text2 As String = readTxtComplete(path2)
            Dim y2() As Double = getColumYOfStringComplete(Text2)
            Dim x2() As Double = getColumXOfStringComplete(Text2)

            For i = 0 To x2.Length - 2 'o ultimo elemento é 0, pois o vetor foi acrescentado e nada foi adiconado ao mesmo
                Me.Chart1.Series(listaSensores(2).Nome).Points.AddXY(x2(i), y2(i))
            Next i

            Me.Chart1.Series.Add(listaSensores(3).Nome)
            Me.Chart1.Series(listaSensores(3).Nome).Color = Color.FromKnownColor(KnownColor.Black)
            Me.Chart1.Series(listaSensores(3).Nome).ChartType = DataVisualization.Charting.SeriesChartType.Line

            Dim path3 As String = listaSensores(3).PathSensor
            If path3 = Nothing Then 'caso em que a abertura foi cancelada, o path ira vir nothinh e vc cancela o evento do butao
                Exit Sub
            End If
            Dim Text3 As String = readTxtComplete(path3)
            Dim y3() As Double = getColumYOfStringComplete(Text3)
            Dim x3() As Double = getColumXOfStringComplete(Text3)

            For i = 0 To x3.Length - 2 'o ultimo elemento é 0, pois o vetor foi acrescentado e nada foi adiconado ao mesmo
                Me.Chart1.Series(listaSensores(3).Nome).Points.AddXY(x3(i), y3(i))
            Next i

            Me.Chart1.Series.Add(listaSensores(4).Nome)
            Me.Chart1.Series(listaSensores(4).Nome).Color = Color.FromKnownColor(KnownColor.Yellow)
            Me.Chart1.Series(listaSensores(4).Nome).ChartType = DataVisualization.Charting.SeriesChartType.Line

            Dim path4 As String = listaSensores(4).PathSensor
            If path4 = Nothing Then 'caso em que a abertura foi cancelada, o path ira vir nothinh e vc cancela o evento do butao
                Exit Sub
            End If
            Dim Text4 As String = readTxtComplete(path4)
            Dim y4() As Double = getColumYOfStringComplete(Text4)
            Dim x4() As Double = getColumXOfStringComplete(Text4)

            For i = 0 To x4.Length - 2 'o ultimo elemento é 0, pois o vetor foi acrescentado e nada foi adiconado ao mesmo
                Me.Chart1.Series(listaSensores(4).Nome).Points.AddXY(x4(i), y4(i))
            Next i

            Me.Chart1.Series.Add(listaSensores(5).Nome)
            Me.Chart1.Series(listaSensores(5).Nome).Color = Color.FromKnownColor(KnownColor.Pink)
            Me.Chart1.Series(listaSensores(5).Nome).ChartType = DataVisualization.Charting.SeriesChartType.Line

            Dim path5 As String = listaSensores(5).PathSensor
            If path5 = Nothing Then 'caso em que a abertura foi cancelada, o path ira vir nothinh e vc cancela o evento do butao
                Exit Sub
            End If
            Dim Text5 As String = readTxtComplete(path5)
            Dim y5() As Double = getColumYOfStringComplete(Text5)
            Dim x5() As Double = getColumXOfStringComplete(Text5)

            For i = 0 To x5.Length - 2 'o ultimo elemento é 0, pois o vetor foi acrescentado e nada foi adiconado ao mesmo
                Me.Chart1.Series(listaSensores(5).Nome).Points.AddXY(x5(i), y5(i))
            Next i
        End If
        ' FIM - 6 GRAFICOS

        Dim verticalLine = New VerticalLineAnnotation()
        verticalLine.AxisX = Chart1.ChartAreas.First.AxisX
        verticalLine.AllowMoving = True
        verticalLine.IsInfinitive = True
        verticalLine.LineColor = Color.Navy
        verticalLine.LineWidth = 2
        verticalLine.AnchorOffsetX = 50
        verticalLine.ClipToChartArea = Chart1.ChartAreas.First.Name
        verticalLine.Name = "VA"
        verticalLine.LineDashStyle = 1
        verticalLine.AnchorDataPoint = Chart1.Series.First.Points(0)
        'verticalLine.X = 1

        Dim RA = New RectangleAnnotation()
        RA.AxisX = verticalLine.AxisX
        RA.IsSizeAlwaysRelative = False
        RA.Width = 50
        RA.Height = 3
        RA.Name = "RA"
        RA.LineColor = Color.Blue
        RA.BackColor = Color.Red
        'RA.AxisY = verticalLine.AxisY
        RA.Y = RA.Height
        RA.X = verticalLine.X - RA.Width / 2
        RA.Text = "Hello"
        RA.ForeColor = Color.White
        RA.Font = New System.Drawing.Font("Arial", 8.0F)


        Chart1.Annotations.Add(verticalLine)
        Chart1.Annotations.Add(RA)
    End Sub

    Private Sub CheckBox13_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox13.CheckedChanged

        If Chart1.Annotations.Count = 0 Then

        Else
            If CheckBox13.Checked Then
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
    Public Sub chart1_AnnotationPositionChanged(sender As Object, e As EventArgs) Handles Chart1.AnnotationPositionChanged
        Dim VA = Chart1.Annotations.FindByName("VA")
        Dim RA As RectangleAnnotation = Chart1.Annotations.FindByName("RA")

        VA.X = Int(VA.X + 0.5)
        RA.X = VA.X - RA.Width / 2

        RA.Text = VA.X

        'redimensionando
        Dim S1 = Chart1.Series.First
        Dim N = S1.Points.Count
        Dim xFactor = (Chart1.Width) / 10

        RA.Width = 250
        'RA.ResizeToContent()

    End Sub
    Public Sub chart1_AnnotationPositionChanging(sender As Object, e As AnnotationPositionChangingEventArgs) Handles Chart1.AnnotationPositionChanging
        Dim VA = Chart1.Annotations.FindByName("VA")
        Dim RA As RectangleAnnotation = Chart1.Annotations.FindByName("RA")

        If sender.Equals(VA) Then
            RA.X = VA.X - RA.Width / 2
        End If

        'Dim S1 = Chart1.Series.First
        'Dim CA = Chart1.ChartAreas.First
        'Dim xv = e.NewLocationX

        'Dim px = Int(CA.AxisX.ValueToPixelPosition(xv))
        'Dim dp = S1.Points.Where(Function(x) x.XValue >= xv).FirstOrDefault()
        'Dim py
        'If dp IsNot Nothing Then
        '    py = Int(CA.AxisX.ValueToPixelPosition(S1.Points(0).YValues(0))) - 20
        'End If

        ''If px.ToString IsNot Nothing And py IsNot Nothing Then
        ''    RA.Text = px.ToString & "," & py.ToString
        ''End If


        Chart1.Update()

    End Sub
End Class