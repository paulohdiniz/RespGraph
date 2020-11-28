
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
            nomeAmostra(0) = "Amostra"
        End If

        nomeAmostra(1) = RichTextBox3.Text
        If String.IsNullOrEmpty(nomeAmostra(1)) Then
            nomeAmostra(1) = "Amostra"
        End If

        nomeAmostra(2) = RichTextBox4.Text
        If String.IsNullOrEmpty(nomeAmostra(2)) Then
            nomeAmostra(2) = "Amostra"
        End If

        nomeAmostra(3) = RichTextBox5.Text
        If String.IsNullOrEmpty(nomeAmostra(3)) Then
            nomeAmostra(3) = "Amostra"
        End If

        nomeAmostra(4) = RichTextBox6.Text
        If String.IsNullOrEmpty(nomeAmostra(4)) Then
            nomeAmostra(4) = "Amostra"
        End If

        nomeAmostra(5) = RichTextBox7.Text
        If String.IsNullOrEmpty(nomeAmostra(5)) Then
            nomeAmostra(5) = "Amostra"
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

        Form1.Chart1.Titles.Clear()
        Form1.Chart1.Titles.Add(titulo) 'specify chart name
        Form1.Chart1.ChartAreas.Clear()
        Form1.Chart1.ChartAreas.Add(nomeAmostra(0))
        With Form1.Chart1.ChartAreas(nomeAmostra(0))
            .AxisX.Title = "Comprimento de onda (nm)" 'x label
            .AxisX.MajorGrid.LineColor = Color.SkyBlue
            .AxisY.MajorGrid.LineColor = Color.SkyBlue
            .AxisX.Minimum = minimo 'LIMITANDO O GRAFICO EM X ENTRE O VALOR MINIMUM E MAXIMUM
            .AxisX.Maximum = maximo
            .AxisY.Title = "Responsividade" 'y label
        End With
        'specify series plot lines
        Form1.Chart1.Series.Clear()

        If RadioButton1.Checked Then
            Form1.Chart1.Series.Clear()
            Form1.Chart1.Series.Add(nomeAmostra(0))
            Form1.Chart1.Series(nomeAmostra(0)).Color = Color.FromKnownColor(KnownColor.Red)
            Form1.Chart1.Series(nomeAmostra(0)).ChartType = DataVisualization.Charting.SeriesChartType.Line

            Dim path As String = openFile()
            Text = readTxtComplete(path)
            Dim y() As Double = getColumYOfStringOfColumns(Text)
            Dim x() As Double = getColumXOfStringofColumns(Text)

            For i = 0 To x.Length - 1
                Console.WriteLine(x(i))
                Console.WriteLine(y(i))
                Form1.Chart1.Series(nomeAmostra(0)).Points.AddXY(x(i), y(i))
            Next i
        End If

        If RadioButton2.Checked Then
            Form1.Chart1.Series.Clear()
            Form1.Chart1.Series.Add(nomeAmostra(0))
            Form1.Chart1.Series(nomeAmostra(0)).Color = Color.FromKnownColor(KnownColor.Red)
            Form1.Chart1.Series(nomeAmostra(0)).ChartType = DataVisualization.Charting.SeriesChartType.Line

            Dim path As String = openFile()
            Dim Text As String = readTxtComplete(path)
            Dim y() As Double = getColumYOfStringOfColumns(Text)
            Dim x() As Double = getColumXOfStringofColumns(Text)

            For i = 0 To x.Length - 1
                Form1.Chart1.Series(nomeAmostra(0)).Points.AddXY(x(i), y(i))
            Next i



            Form1.Chart1.Series.Add(nomeAmostra(1))
            Form1.Chart1.Series(nomeAmostra(1)).Color = Color.FromKnownColor(KnownColor.Blue)
            Form1.Chart1.Series(nomeAmostra(1)).ChartType = DataVisualization.Charting.SeriesChartType.Line

            Dim path1 As String = openFile()
            Dim Text1 As String = readTxtComplete(path1)
            Dim y1() As Double = getColumYOfStringOfColumns(Text1)
            Dim x1() As Double = getColumXOfStringofColumns(Text1)

            For i = 0 To x1.Length - 1
                Form1.Chart1.Series(nomeAmostra(1)).Points.AddXY(x1(i), y1(i))
            Next i

        End If


        If RadioButton3.Checked Then
            Form1.Chart1.Series.Clear()
            Form1.Chart1.Series.Add(nomeAmostra(0))
            Form1.Chart1.Series(nomeAmostra(0)).Color = Color.FromKnownColor(KnownColor.Red)
            Form1.Chart1.Series(nomeAmostra(0)).ChartType = DataVisualization.Charting.SeriesChartType.Line

            Dim path As String = openFile()
            Text = readTxtComplete(path)
            Dim y() As Double = getColumYOfStringOfColumns(Text)
            Dim x() As Double = getColumXOfStringofColumns(Text)

            For i = 0 To x.Length - 1
                Form1.Chart1.Series(nomeAmostra(0)).Points.AddXY(x(i), y(i))
            Next i


            Form1.Chart1.Series.Add(nomeAmostra(1))
            Form1.Chart1.Series(nomeAmostra(1)).Color = Color.FromKnownColor(KnownColor.Blue)
            Form1.Chart1.Series(nomeAmostra(1)).ChartType = DataVisualization.Charting.SeriesChartType.Line

            Dim path1 As String = openFile()
            Dim Text1 As String = readTxtComplete(path1)
            Dim y1() As Double = getColumYOfStringOfColumns(Text1)
            Dim x1() As Double = getColumXOfStringofColumns(Text1)

            For i = 0 To x1.Length - 1
                Form1.Chart1.Series(nomeAmostra(1)).Points.AddXY(x1(i), y1(i))
            Next i


            Form1.Chart1.Series.Add(nomeAmostra(2))
            Form1.Chart1.Series(nomeAmostra(2)).Color = Color.FromKnownColor(KnownColor.Green)
            Form1.Chart1.Series(nomeAmostra(2)).ChartType = DataVisualization.Charting.SeriesChartType.Line

            Dim path2 As String = openFile()
            Dim Text2 As String = readTxtComplete(path2)
            Dim y2() As Double = getColumYOfStringOfColumns(Text2)
            Dim x2() As Double = getColumXOfStringofColumns(Text2)

            For i = 0 To x2.Length - 1
                Form1.Chart1.Series(nomeAmostra(2)).Points.AddXY(x2(i), y2(i))
            Next i

        End If

        Me.Hide()
    End Sub


End Class