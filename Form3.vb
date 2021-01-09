
Public Class Form3

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        RichTextBox1.Visible = True
        RichTextBox3.Visible = False
        RichTextBox4.Visible = False
        RichTextBox5.Visible = False
        RichTextBox6.Visible = False
        RichTextBox7.Visible = False
        Label8.Visible = False
        Label9.Visible = False
        Label10.Visible = False
        Label11.Visible = False
        Label12.Visible = False

    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        RichTextBox1.Visible = True
        RichTextBox3.Visible = True
        RichTextBox4.Visible = False
        RichTextBox5.Visible = False
        RichTextBox6.Visible = False
        RichTextBox7.Visible = False
        Label8.Visible = True
        Label9.Visible = False
        Label10.Visible = False
        Label11.Visible = False
        Label12.Visible = False
    End Sub

    Private Sub RadioButton3_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton3.CheckedChanged
        RichTextBox1.Visible = True
        RichTextBox3.Visible = True
        RichTextBox4.Visible = True
        RichTextBox5.Visible = False
        RichTextBox6.Visible = False
        RichTextBox7.Visible = False
        Label8.Visible = True
        Label9.Visible = True
        Label10.Visible = False
        Label11.Visible = False
        Label12.Visible = False
    End Sub

    Private Sub RadioButton4_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton4.CheckedChanged
        RichTextBox1.Visible = True
        RichTextBox3.Visible = True
        RichTextBox4.Visible = True
        RichTextBox5.Visible = True
        RichTextBox6.Visible = False
        RichTextBox7.Visible = False
        Label8.Visible = True
        Label9.Visible = True
        Label10.Visible = True
        Label11.Visible = False
        Label12.Visible = False
    End Sub

    Private Sub RadioButton5_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton5.CheckedChanged
        RichTextBox1.Visible = True
        RichTextBox3.Visible = True
        RichTextBox4.Visible = True
        RichTextBox5.Visible = True
        RichTextBox6.Visible = True
        RichTextBox7.Visible = False
        Label8.Visible = True
        Label9.Visible = True
        Label10.Visible = True
        Label11.Visible = True
        Label12.Visible = False
    End Sub

    Private Sub RadioButton6_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton6.CheckedChanged
        RichTextBox1.Visible = True
        RichTextBox3.Visible = True
        RichTextBox4.Visible = True
        RichTextBox5.Visible = True
        RichTextBox6.Visible = True
        RichTextBox7.Visible = True
        Label8.Visible = True
        Label9.Visible = True
        Label10.Visible = True
        Label11.Visible = True
        Label12.Visible = True
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'setup the chart area 
        Dim titulo As String 'Titulo do gráfico
        titulo = RichTextBox2.Text
        If String.IsNullOrEmpty(titulo) Then
            titulo = "Título"
        End If
        Dim nomeAmostra(5) As String 'nome das amostras referente as curvas

        nomeAmostra(0) = RichTextBox1.Text
        If String.IsNullOrEmpty(nomeAmostra(0)) Then
            nomeAmostra(0) = "Amostra0"
        End If

        nomeAmostra(1) = RichTextBox3.Text
        If String.IsNullOrEmpty(nomeAmostra(1)) Then
            nomeAmostra(1) = "Amostra1"
        End If

        nomeAmostra(2) = RichTextBox4.Text
        If String.IsNullOrEmpty(nomeAmostra(2)) Then
            nomeAmostra(2) = "Amostra2"
        End If

        nomeAmostra(3) = RichTextBox5.Text
        If String.IsNullOrEmpty(nomeAmostra(3)) Then
            nomeAmostra(3) = "Amostra3"
        End If

        nomeAmostra(4) = RichTextBox6.Text
        If String.IsNullOrEmpty(nomeAmostra(4)) Then
            nomeAmostra(4) = "Amostra4"
        End If

        nomeAmostra(5) = RichTextBox7.Text
        If String.IsNullOrEmpty(nomeAmostra(5)) Then
            nomeAmostra(5) = "Amostra5"
        End If

        Dim minimo As Double
        Dim minimoTxt As String
        minimoTxt = RichTextBox8.Text
        If String.IsNullOrEmpty(minimoTxt) Then
            minimo = Double.NaN
        Else
            Double.TryParse(RichTextBox8.Text, minimo) 'transformando a string em double
        End If

        Dim maximo As Double
        Dim maximoTxt As String
        maximoTxt = RichTextBox9.Text
        If String.IsNullOrEmpty(maximoTxt) Then
            maximo = Double.NaN
        Else
            Double.TryParse(RichTextBox9.Text, maximo) 'transformando a string em double
        End If

        Dim renameX As String
        renameX = RichTextBox10.Text
        If String.IsNullOrEmpty(renameX) Then
            renameX = "Comprimento de onda (nm)"
        End If

        Dim renameY As String
        renameY = RichTextBox11.Text
        If String.IsNullOrEmpty(renameY) Then
            renameY = "Responsividade"
        End If

        ' N indica o numero como ele realmente é, o NX indica com X casas decimais
        Dim formatX As String
        Dim formatY As String
        formatX = "N"
        formatY = "N"
        'X
        If RadioButton7.Checked Then
            formatX = "N0"
        End If
        If RadioButton8.Checked Then
            formatX = "N1"
        End If
        If RadioButton9.Checked Then
            formatX = "N2"
        End If
        If RadioButton10.Checked Then
            formatX = "N3"
        End If
        'Y - a ordem la ta esquisita mesmo, mas nada demais só olhar la e colocar aqui
        If RadioButton11.Checked Then
            formatY = "N0"
        End If
        If RadioButton14.Checked Then
            formatY = "N1"
        End If
        If RadioButton13.Checked Then
            formatY = "N2"
        End If
        If RadioButton12.Checked Then
            formatY = "N3"
        End If

        Form1.Chart1.Titles.Clear()
        Form1.Chart1.Titles.Add(titulo) 'specify chart name
        Form1.Chart1.ChartAreas.Clear()
        Form1.Chart1.ChartAreas.Add(nomeAmostra(0))
        With Form1.Chart1.ChartAreas(nomeAmostra(0))
            .AxisX.Title = renameX 'x label
            .AxisX.MajorGrid.LineColor = Color.SkyBlue
            .AxisY.MajorGrid.LineColor = Color.SkyBlue
            .AxisX.Minimum = minimo 'LIMITANDO O GRAFICO EM X ENTRE O VALOR MINIMUM E MAXIMUM
            .AxisX.Maximum = maximo
            .AxisY.Title = renameY 'y label
            .AxisX.LabelStyle.Format = formatX
            .AxisY.LabelStyle.Format = formatY
        End With
        'specify series plot lines
        Form1.Chart1.Series.Clear()

        ' INICIO - 1 GRAFICO
        If RadioButton1.Checked Then
            Form1.Chart1.Series.Clear()
            Form1.Chart1.Series.Add(nomeAmostra(0))
            Form1.Chart1.Series(nomeAmostra(0)).Color = Color.FromKnownColor(KnownColor.Red)
            Form1.Chart1.Series(nomeAmostra(0)).ChartType = DataVisualization.Charting.SeriesChartType.Line

            Dim path As String = openFile()
            If path = Nothing Then 'caso em que a abertura foi cancelada, o path ira vir nothinh e vc cancela o evento do butao
                Exit Sub
            End If
            Text = readTxtComplete(path)
                Dim y() As Double = getColumYOfStringComplete(Text)
                Dim x() As Double = getColumXOfStringComplete(Text)

                For i = 0 To x.Length - 2 'o ultimo elemento é 0, pois o vetor foi acrescentado e nada foi adiconado ao mesmo
                    Form1.Chart1.Series(nomeAmostra(0)).Points.AddXY(x(i), y(i))
                Next i
            End If
            ' FIM - 1 GRAFICO
            ' INICIO - 2 GRAFICOS
            If RadioButton2.Checked Then
            Form1.Chart1.Series.Clear()
            Form1.Chart1.Series.Add(nomeAmostra(0))
            Form1.Chart1.Series(nomeAmostra(0)).Color = Color.FromKnownColor(KnownColor.Red)
            Form1.Chart1.Series(nomeAmostra(0)).ChartType = DataVisualization.Charting.SeriesChartType.Line

            Dim path As String = openFile()
            If path = Nothing Then 'caso em que a abertura foi cancelada, o path ira vir nothinh e vc cancela o evento do butao
                Exit Sub
            End If
            Dim Text As String = readTxtComplete(path)
            Dim y() As Double = getColumYOfStringComplete(Text)
            Dim x() As Double = getColumXOfStringComplete(Text)

            For i = 0 To x.Length - 2 'o ultimo elemento é 0, pois o vetor foi acrescentado e nada foi adiconado ao mesmo
                Form1.Chart1.Series(nomeAmostra(0)).Points.AddXY(x(i), y(i))
            Next i


            Form1.Chart1.Series.Add(nomeAmostra(1))
            Form1.Chart1.Series(nomeAmostra(1)).Color = Color.FromKnownColor(KnownColor.Blue)
            Form1.Chart1.Series(nomeAmostra(1)).ChartType = DataVisualization.Charting.SeriesChartType.Line

            Dim path1 As String = openFile()
            If path1 = Nothing Then 'caso em que a abertura foi cancelada, o path ira vir nothinh e vc cancela o evento do butao
                Exit Sub
            End If
            Dim Text1 As String = readTxtComplete(path1)
            Dim y1() As Double = getColumYOfStringComplete(Text1)
            Dim x1() As Double = getColumXOfStringComplete(Text1)

            For i = 0 To x1.Length - 2 'o ultimo elemento é 0, pois o vetor foi acrescentado e nada foi adiconado ao mesmo
                Form1.Chart1.Series(nomeAmostra(1)).Points.AddXY(x1(i), y1(i))
            Next i

        End If
        ' FIM - 2 GRAFICOS
        ' INICIO - 3 GRAFICOS
        If RadioButton3.Checked Then

            Form1.Chart1.Series.Clear()
            Form1.Chart1.Series.Add(nomeAmostra(0))
            Form1.Chart1.Series(nomeAmostra(0)).Color = Color.FromKnownColor(KnownColor.Red)
            Form1.Chart1.Series(nomeAmostra(0)).ChartType = DataVisualization.Charting.SeriesChartType.Line

            Dim path As String = openFile()
            If path = Nothing Then 'caso em que a abertura foi cancelada, o path ira vir nothinh e vc cancela o evento do butao
                Exit Sub
            End If
            Text = readTxtComplete(path)
            Dim y() As Double = getColumYOfStringComplete(Text)
            Dim x() As Double = getColumXOfStringComplete(Text)

            For i = 0 To x.Length - 2 'o ultimo elemento é 0, pois o vetor foi acrescentado e nada foi adiconado ao mesmo
                Form1.Chart1.Series(nomeAmostra(0)).Points.AddXY(x(i), y(i))
            Next i


            Form1.Chart1.Series.Add(nomeAmostra(1))
            Form1.Chart1.Series(nomeAmostra(1)).Color = Color.FromKnownColor(KnownColor.Blue)
            Form1.Chart1.Series(nomeAmostra(1)).ChartType = DataVisualization.Charting.SeriesChartType.Line

            Dim path1 As String = openFile()
            If path1 = Nothing Then 'caso em que a abertura foi cancelada, o path ira vir nothinh e vc cancela o evento do butao
                Exit Sub
            End If
            Dim Text1 As String = readTxtComplete(path1)
            Dim y1() As Double = getColumYOfStringComplete(Text1)
            Dim x1() As Double = getColumXOfStringComplete(Text1)

            For i = 0 To x1.Length - 2 'o ultimo elemento é 0, pois o vetor foi acrescentado e nada foi adiconado ao mesmo
                Form1.Chart1.Series(nomeAmostra(1)).Points.AddXY(x1(i), y1(i))
            Next i


            Form1.Chart1.Series.Add(nomeAmostra(2))
            Form1.Chart1.Series(nomeAmostra(2)).Color = Color.FromKnownColor(KnownColor.Green)
            Form1.Chart1.Series(nomeAmostra(2)).ChartType = DataVisualization.Charting.SeriesChartType.Line

            Dim path2 As String = openFile()
            If path2 = Nothing Then 'caso em que a abertura foi cancelada, o path ira vir nothinh e vc cancela o evento do butao
                Exit Sub
            End If
            Dim Text2 As String = readTxtComplete(path2)
            Dim y2() As Double = getColumYOfStringComplete(Text2)
            Dim x2() As Double = getColumXOfStringComplete(Text2)

            For i = 0 To x2.Length - 2 'o ultimo elemento é 0, pois o vetor foi acrescentado e nada foi adiconado ao mesmo
                Form1.Chart1.Series(nomeAmostra(2)).Points.AddXY(x2(i), y2(i))
            Next i

        End If
        ' FIM - 3 GRAFICOS
        ' INICIO - 4 GRAFICOS
        If RadioButton4.Checked Then

            Form1.Chart1.Series.Clear()
            Form1.Chart1.Series.Add(nomeAmostra(0))
            Form1.Chart1.Series(nomeAmostra(0)).Color = Color.FromKnownColor(KnownColor.Red)
            Form1.Chart1.Series(nomeAmostra(0)).ChartType = DataVisualization.Charting.SeriesChartType.Line

            Dim path As String = openFile()
            If path = Nothing Then 'caso em que a abertura foi cancelada, o path ira vir nothinh e vc cancela o evento do butao
                Exit Sub
            End If
            Text = readTxtComplete(path)
            Dim y() As Double = getColumYOfStringComplete(Text)
            Dim x() As Double = getColumXOfStringComplete(Text)

            For i = 0 To x.Length - 2 'o ultimo elemento é 0, pois o vetor foi acrescentado e nada foi adiconado ao mesmo
                Form1.Chart1.Series(nomeAmostra(0)).Points.AddXY(x(i), y(i))
            Next i


            Form1.Chart1.Series.Add(nomeAmostra(1))
            Form1.Chart1.Series(nomeAmostra(1)).Color = Color.FromKnownColor(KnownColor.Blue)
            Form1.Chart1.Series(nomeAmostra(1)).ChartType = DataVisualization.Charting.SeriesChartType.Line

            Dim path1 As String = openFile()
            If path1 = Nothing Then 'caso em que a abertura foi cancelada, o path ira vir nothinh e vc cancela o evento do butao
                Exit Sub
            End If
            Dim Text1 As String = readTxtComplete(path1)
            Dim y1() As Double = getColumYOfStringComplete(Text1)
            Dim x1() As Double = getColumXOfStringComplete(Text1)

            For i = 0 To x1.Length - 2 'o ultimo elemento é 0, pois o vetor foi acrescentado e nada foi adiconado ao mesmo
                Form1.Chart1.Series(nomeAmostra(1)).Points.AddXY(x1(i), y1(i))
            Next i


            Form1.Chart1.Series.Add(nomeAmostra(2))
            Form1.Chart1.Series(nomeAmostra(2)).Color = Color.FromKnownColor(KnownColor.Green)
            Form1.Chart1.Series(nomeAmostra(2)).ChartType = DataVisualization.Charting.SeriesChartType.Line

            Dim path2 As String = openFile()
            If path2 = Nothing Then 'caso em que a abertura foi cancelada, o path ira vir nothinh e vc cancela o evento do butao
                Exit Sub
            End If
            Dim Text2 As String = readTxtComplete(path2)
            Dim y2() As Double = getColumYOfStringComplete(Text2)
            Dim x2() As Double = getColumXOfStringComplete(Text2)

            For i = 0 To x2.Length - 2 'o ultimo elemento é 0, pois o vetor foi acrescentado e nada foi adiconado ao mesmo
                Form1.Chart1.Series(nomeAmostra(2)).Points.AddXY(x2(i), y2(i))
            Next i


            Form1.Chart1.Series.Add(nomeAmostra(3))
            Form1.Chart1.Series(nomeAmostra(3)).Color = Color.FromKnownColor(KnownColor.Black)
            Form1.Chart1.Series(nomeAmostra(3)).ChartType = DataVisualization.Charting.SeriesChartType.Line

            Dim path3 As String = openFile()
            If path3 = Nothing Then 'caso em que a abertura foi cancelada, o path ira vir nothinh e vc cancela o evento do butao
                Exit Sub
            End If
            Dim Text3 As String = readTxtComplete(path3)
            Dim y3() As Double = getColumYOfStringComplete(Text3)
            Dim x3() As Double = getColumXOfStringComplete(Text3)

            For i = 0 To x3.Length - 2 'o ultimo elemento é 0, pois o vetor foi acrescentado e nada foi adiconado ao mesmo
                Form1.Chart1.Series(nomeAmostra(3)).Points.AddXY(x3(i), y3(i))
            Next i
        End If
        ' FIM - 4 GRAFICOS
        ' INICIO - 5 GRAFICOS
        If RadioButton5.Checked Then

            Form1.Chart1.Series.Clear()
            Form1.Chart1.Series.Add(nomeAmostra(0))
            Form1.Chart1.Series(nomeAmostra(0)).Color = Color.FromKnownColor(KnownColor.Red)
            Form1.Chart1.Series(nomeAmostra(0)).ChartType = DataVisualization.Charting.SeriesChartType.Line

            Dim path As String = openFile()
            If path = Nothing Then 'caso em que a abertura foi cancelada, o path ira vir nothinh e vc cancela o evento do butao
                Exit Sub
            End If
            Text = readTxtComplete(path)
            Dim y() As Double = getColumYOfStringComplete(Text)
            Dim x() As Double = getColumXOfStringComplete(Text)

            For i = 0 To x.Length - 2 'o ultimo elemento é 0, pois o vetor foi acrescentado e nada foi adiconado ao mesmo
                Form1.Chart1.Series(nomeAmostra(0)).Points.AddXY(x(i), y(i))
            Next i


            Form1.Chart1.Series.Add(nomeAmostra(1))
            Form1.Chart1.Series(nomeAmostra(1)).Color = Color.FromKnownColor(KnownColor.Blue)
            Form1.Chart1.Series(nomeAmostra(1)).ChartType = DataVisualization.Charting.SeriesChartType.Line

            Dim path1 As String = openFile()
            If path1 = Nothing Then 'caso em que a abertura foi cancelada, o path ira vir nothinh e vc cancela o evento do butao
                Exit Sub
            End If
            Dim Text1 As String = readTxtComplete(path1)
            Dim y1() As Double = getColumYOfStringComplete(Text1)
            Dim x1() As Double = getColumXOfStringComplete(Text1)

            For i = 0 To x1.Length - 2 'o ultimo elemento é 0, pois o vetor foi acrescentado e nada foi adiconado ao mesmo
                Form1.Chart1.Series(nomeAmostra(1)).Points.AddXY(x1(i), y1(i))
            Next i


            Form1.Chart1.Series.Add(nomeAmostra(2))
            Form1.Chart1.Series(nomeAmostra(2)).Color = Color.FromKnownColor(KnownColor.Green)
            Form1.Chart1.Series(nomeAmostra(2)).ChartType = DataVisualization.Charting.SeriesChartType.Line

            Dim path2 As String = openFile()
            If path2 = Nothing Then 'caso em que a abertura foi cancelada, o path ira vir nothinh e vc cancela o evento do butao
                Exit Sub
            End If
            Dim Text2 As String = readTxtComplete(path2)
            Dim y2() As Double = getColumYOfStringComplete(Text2)
            Dim x2() As Double = getColumXOfStringComplete(Text2)

            For i = 0 To x2.Length - 2 'o ultimo elemento é 0, pois o vetor foi acrescentado e nada foi adiconado ao mesmo
                Form1.Chart1.Series(nomeAmostra(2)).Points.AddXY(x2(i), y2(i))
            Next i


            Form1.Chart1.Series.Add(nomeAmostra(3))
            Form1.Chart1.Series(nomeAmostra(3)).Color = Color.FromKnownColor(KnownColor.Black)
            Form1.Chart1.Series(nomeAmostra(3)).ChartType = DataVisualization.Charting.SeriesChartType.Line

            Dim path3 As String = openFile()
            If path3 = Nothing Then 'caso em que a abertura foi cancelada, o path ira vir nothinh e vc cancela o evento do butao
                Exit Sub
            End If
            Dim Text3 As String = readTxtComplete(path3)
            Dim y3() As Double = getColumYOfStringComplete(Text3)
            Dim x3() As Double = getColumXOfStringComplete(Text3)

            For i = 0 To x3.Length - 2 'o ultimo elemento é 0, pois o vetor foi acrescentado e nada foi adiconado ao mesmo
                Form1.Chart1.Series(nomeAmostra(3)).Points.AddXY(x3(i), y3(i))
            Next i


            Form1.Chart1.Series.Add(nomeAmostra(4))
            Form1.Chart1.Series(nomeAmostra(4)).Color = Color.FromKnownColor(KnownColor.Yellow)
            Form1.Chart1.Series(nomeAmostra(4)).ChartType = DataVisualization.Charting.SeriesChartType.Line

            Dim path4 As String = openFile()
            If path4 = Nothing Then 'caso em que a abertura foi cancelada, o path ira vir nothinh e vc cancela o evento do butao
                Exit Sub
            End If
            Dim Text4 As String = readTxtComplete(path4)
            Dim y4() As Double = getColumYOfStringComplete(Text4)
            Dim x4() As Double = getColumXOfStringComplete(Text4)

            For i = 0 To x4.Length - 2 'o ultimo elemento é 0, pois o vetor foi acrescentado e nada foi adiconado ao mesmo
                Form1.Chart1.Series(nomeAmostra(4)).Points.AddXY(x4(i), y4(i))
            Next i
        End If
        ' FIM - 5 GRAFICOS
        ' INICIO - 6 GRAFICOS
        If RadioButton6.Checked Then

            Form1.Chart1.Series.Clear()
            Form1.Chart1.Series.Add(nomeAmostra(0))
            Form1.Chart1.Series(nomeAmostra(0)).Color = Color.FromKnownColor(KnownColor.Red)
            Form1.Chart1.Series(nomeAmostra(0)).ChartType = DataVisualization.Charting.SeriesChartType.Line

            Dim path As String = openFile()
            If path = Nothing Then 'caso em que a abertura foi cancelada, o path ira vir nothinh e vc cancela o evento do butao
                Exit Sub
            End If
            Text = readTxtComplete(path)
            Dim y() As Double = getColumYOfStringComplete(Text)
            Dim x() As Double = getColumXOfStringComplete(Text)

            For i = 0 To x.Length - 2 'o ultimo elemento é 0, pois o vetor foi acrescentado e nada foi adiconado ao mesmo
                Form1.Chart1.Series(nomeAmostra(0)).Points.AddXY(x(i), y(i))
            Next i


            Form1.Chart1.Series.Add(nomeAmostra(1))
            Form1.Chart1.Series(nomeAmostra(1)).Color = Color.FromKnownColor(KnownColor.Blue)
            Form1.Chart1.Series(nomeAmostra(1)).ChartType = DataVisualization.Charting.SeriesChartType.Line

            Dim path1 As String = openFile()
            If path1 = Nothing Then 'caso em que a abertura foi cancelada, o path ira vir nothinh e vc cancela o evento do butao
                Exit Sub
            End If
            Dim Text1 As String = readTxtComplete(path1)
            Dim y1() As Double = getColumYOfStringComplete(Text1)
            Dim x1() As Double = getColumXOfStringComplete(Text1)

            For i = 0 To x1.Length - 2 'o ultimo elemento é 0, pois o vetor foi acrescentado e nada foi adiconado ao mesmo
                Form1.Chart1.Series(nomeAmostra(1)).Points.AddXY(x1(i), y1(i))
            Next i


            Form1.Chart1.Series.Add(nomeAmostra(2))
            Form1.Chart1.Series(nomeAmostra(2)).Color = Color.FromKnownColor(KnownColor.Green)
            Form1.Chart1.Series(nomeAmostra(2)).ChartType = DataVisualization.Charting.SeriesChartType.Line

            Dim path2 As String = openFile()
            If path2 = Nothing Then 'caso em que a abertura foi cancelada, o path ira vir nothinh e vc cancela o evento do butao
                Exit Sub
            End If
            Dim Text2 As String = readTxtComplete(path2)
            Dim y2() As Double = getColumYOfStringComplete(Text2)
            Dim x2() As Double = getColumXOfStringComplete(Text2)

            For i = 0 To x2.Length - 2 'o ultimo elemento é 0, pois o vetor foi acrescentado e nada foi adiconado ao mesmo
                Form1.Chart1.Series(nomeAmostra(2)).Points.AddXY(x2(i), y2(i))
            Next i


            Form1.Chart1.Series.Add(nomeAmostra(3))
            Form1.Chart1.Series(nomeAmostra(3)).Color = Color.FromKnownColor(KnownColor.Black)
            Form1.Chart1.Series(nomeAmostra(3)).ChartType = DataVisualization.Charting.SeriesChartType.Line

            Dim path3 As String = openFile()
            If path3 = Nothing Then 'caso em que a abertura foi cancelada, o path ira vir nothinh e vc cancela o evento do butao
                Exit Sub
            End If
            Dim Text3 As String = readTxtComplete(path3)
            Dim y3() As Double = getColumYOfStringComplete(Text3)
            Dim x3() As Double = getColumXOfStringComplete(Text3)

            For i = 0 To x3.Length - 2 'o ultimo elemento é 0, pois o vetor foi acrescentado e nada foi adiconado ao mesmo
                Form1.Chart1.Series(nomeAmostra(3)).Points.AddXY(x3(i), y3(i))
            Next i


            Form1.Chart1.Series.Add(nomeAmostra(4))
            Form1.Chart1.Series(nomeAmostra(4)).Color = Color.FromKnownColor(KnownColor.Yellow)
            Form1.Chart1.Series(nomeAmostra(4)).ChartType = DataVisualization.Charting.SeriesChartType.Line

            Dim path4 As String = openFile()
            If path4 = Nothing Then 'caso em que a abertura foi cancelada, o path ira vir nothinh e vc cancela o evento do butao
                Exit Sub
            End If
            Dim Text4 As String = readTxtComplete(path4)
            Dim y4() As Double = getColumYOfStringComplete(Text4)
            Dim x4() As Double = getColumXOfStringComplete(Text4)

            For i = 0 To x4.Length - 2 'o ultimo elemento é 0, pois o vetor foi acrescentado e nada foi adiconado ao mesmo
                Form1.Chart1.Series(nomeAmostra(4)).Points.AddXY(x4(i), y4(i))
            Next i


            Form1.Chart1.Series.Add(nomeAmostra(5))
            Form1.Chart1.Series(nomeAmostra(5)).Color = Color.FromKnownColor(KnownColor.Pink)
            Form1.Chart1.Series(nomeAmostra(5)).ChartType = DataVisualization.Charting.SeriesChartType.Line

            Dim path5 As String = openFile()
            If path5 = Nothing Then 'caso em que a abertura foi cancelada, o path ira vir nothinh e vc cancela o evento do butao
                Exit Sub
            End If
            Dim Text5 As String = readTxtComplete(path5)
            Dim y5() As Double = getColumYOfStringComplete(Text5)
            Dim x5() As Double = getColumXOfStringComplete(Text5)

            For i = 0 To x5.Length - 2 'o ultimo elemento é 0, pois o vetor foi acrescentado e nada foi adiconado ao mesmo
                Form1.Chart1.Series(nomeAmostra(5)).Points.AddXY(x5(i), y5(i))
            Next i
        End If
        ' FIM - 6 GRAFICOS

        Me.Hide()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Form4.Visible = True
    End Sub
End Class