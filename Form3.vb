


Public Class Form3

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        RichTextBox1.Visible = True 'Todo esse código só deixa dinamico os radiobuttons.
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
        Button3.Visible = True 'botao do 1
        Button4.Visible = False
        Button5.Visible = False
        Button6.Visible = False
        Button7.Visible = False
        Button8.Visible = False

        'nomarlizacao
        Label24.Visible = True
        CheckBox7.Visible = True
        CheckBox8.Visible = False
        CheckBox9.Visible = False
        CheckBox10.Visible = False
        CheckBox11.Visible = False
        CheckBox12.Visible = False

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
        Button3.Visible = True 'botao do 1
        Button4.Visible = True
        Button5.Visible = False
        Button6.Visible = False
        Button7.Visible = False
        Button8.Visible = False

        'nomarlizacao
        Label24.Visible = True
        CheckBox7.Visible = True
        CheckBox8.Visible = True
        CheckBox9.Visible = False
        CheckBox10.Visible = False
        CheckBox11.Visible = False
        CheckBox12.Visible = False
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
        Button3.Visible = True 'botao do 1
        Button4.Visible = True
        Button5.Visible = True
        Button6.Visible = False
        Button7.Visible = False
        Button8.Visible = False

        'nomarlizacao
        Label24.Visible = True
        CheckBox7.Visible = True
        CheckBox8.Visible = True
        CheckBox9.Visible = True
        CheckBox10.Visible = False
        CheckBox11.Visible = False
        CheckBox12.Visible = False
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
        Button3.Visible = True 'botao do 1
        Button4.Visible = True
        Button5.Visible = True
        Button6.Visible = True
        Button7.Visible = False
        Button8.Visible = False

        'nomarlizacao
        Label24.Visible = True
        CheckBox7.Visible = True
        CheckBox8.Visible = True
        CheckBox9.Visible = True
        CheckBox10.Visible = True
        CheckBox11.Visible = False
        CheckBox12.Visible = False
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
        Button3.Visible = True 'botao do 1
        Button4.Visible = True
        Button5.Visible = True
        Button6.Visible = True
        Button7.Visible = True
        Button8.Visible = False

        'nomarlizacao
        Label24.Visible = True
        CheckBox7.Visible = True
        CheckBox8.Visible = True
        CheckBox9.Visible = True
        CheckBox10.Visible = True
        CheckBox11.Visible = True
        CheckBox12.Visible = False
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
        Button3.Visible = True 'botao do 1
        Button4.Visible = True
        Button5.Visible = True
        Button6.Visible = True
        Button7.Visible = True
        Button8.Visible = True

        'nomarlizacao
        Label24.Visible = True
        CheckBox7.Visible = True
        CheckBox8.Visible = True
        CheckBox9.Visible = True
        CheckBox10.Visible = True
        CheckBox11.Visible = True
        CheckBox12.Visible = True

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
        If String.IsNullOrEmpty(nomeAmostra(0)) Then 'ficou dessa forma porque o vetor começa no zero, amostra 1 tem o nome salvo em nomeAmostra(0)
            nomeAmostra(0) = "Amostra_1"
        End If

        nomeAmostra(1) = RichTextBox3.Text
        If String.IsNullOrEmpty(nomeAmostra(1)) Then
            nomeAmostra(1) = "Amostra_2"
        End If

        nomeAmostra(2) = RichTextBox4.Text
        If String.IsNullOrEmpty(nomeAmostra(2)) Then
            nomeAmostra(2) = "Amostra_3"
        End If

        nomeAmostra(3) = RichTextBox5.Text
        If String.IsNullOrEmpty(nomeAmostra(3)) Then
            nomeAmostra(3) = "Amostra_4"
        End If

        nomeAmostra(4) = RichTextBox6.Text
        If String.IsNullOrEmpty(nomeAmostra(4)) Then
            nomeAmostra(4) = "Amostra_5"
        End If

        nomeAmostra(5) = RichTextBox7.Text
        If String.IsNullOrEmpty(nomeAmostra(5)) Then
            nomeAmostra(5) = "Amostra_6"
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
            renameY = "Responsividade (V/W)"
        End If

        ' N indica o numero como ele realmente é, o NX indica com X casas decimais
        Dim formatX As String
        Dim formatY As String
        formatX = "N"
        formatY = "N"

        Dim NumeroCasasDeX As String
        NumeroCasasDeX = RichTextBox12.Text
        If String.IsNullOrEmpty(NumeroCasasDeX) Then
            NumeroCasasDeX = "1"
        End If

        Dim NumeroCasasDeY As String
        NumeroCasasDeY = RichTextBox13.Text
        If String.IsNullOrEmpty(NumeroCasasDeY) Then
            NumeroCasasDeY = "1"
        End If

        'X
        If RadioButton7.Checked Then 'notacao sim
            formatX = "E" + NumeroCasasDeX
        End If
        If RadioButton8.Checked Then 'notacao nao
            formatX = "N" + NumeroCasasDeX
        End If

        'Y
        If RadioButton9.Checked Then
            formatY = "E" + NumeroCasasDeY
        End If
        If RadioButton10.Checked Then
            formatY = "N" + NumeroCasasDeY
        End If


        Form7.Chart1.Titles.Clear()
        Form7.Chart1.Titles.Add(titulo) 'specify chart name
        Form7.Chart1.Titles(0).Font = New Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold) 'mexa aqui pra mudar a fonte do titulo
        Form7.Chart1.ChartAreas.Clear()
        Form7.Chart1.ChartAreas.Add(nomeAmostra(0))
        With Form7.Chart1.ChartAreas(nomeAmostra(0))
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
        Form7.Chart1.Series.Clear()

        ' INICIO - 1 GRAFICO
        If RadioButton1.Checked Then
            Form7.Chart1.Series.Clear()
            Form7.Chart1.Series.Add(nomeAmostra(0))
            Form7.Chart1.Series(nomeAmostra(0)).Color = Color.FromKnownColor(KnownColor.Red)
            Form7.Chart1.Series(nomeAmostra(0)).ChartType = DataVisualization.Charting.SeriesChartType.Line

            Dim path As String = GlobalVariables.OpenFileDialog1.FileName
            If path = Nothing Then 'caso em que a abertura foi cancelada, o path ira vir nothinh e vc cancela o evento do butao
                Exit Sub
            End If
            Text = readTxtComplete(path)
            Dim y() As Double = getColumYOfStringComplete(Text)
            If (CheckBox7.Checked) Then
                y = NormalizaVetor(y)
            End If
            Dim x() As Double = getColumXOfStringComplete(Text)

            For i = 0 To x.Length - 2 'o ultimo elemento é 0, pois o vetor foi acrescentado e nada foi adiconado ao mesmo
                Form7.Chart1.Series(nomeAmostra(0)).Points.AddXY(x(i), y(i))
            Next i
        End If
        ' FIM - 1 GRAFICO
        ' INICIO - 2 GRAFICOS
        If RadioButton2.Checked Then
            Form7.Chart1.Series.Clear()
            Form7.Chart1.Series.Add(nomeAmostra(0))
            Form7.Chart1.Series(nomeAmostra(0)).Color = Color.FromKnownColor(KnownColor.Red)
            Form7.Chart1.Series(nomeAmostra(0)).ChartType = DataVisualization.Charting.SeriesChartType.Line

            Dim path As String = GlobalVariables.OpenFileDialog1.FileName
            If path = Nothing Then 'caso em que a abertura foi cancelada, o path ira vir nothinh e vc cancela o evento do butao
                Exit Sub
            End If
            Dim Text As String = readTxtComplete(path)
            Dim y() As Double = getColumYOfStringComplete(Text)
            If (CheckBox7.Checked) Then
                y = NormalizaVetor(y)
            End If
            Dim x() As Double = getColumXOfStringComplete(Text)

            For i = 0 To x.Length - 2 'o ultimo elemento é 0, pois o vetor foi acrescentado e nada foi adiconado ao mesmo
                Form7.Chart1.Series(nomeAmostra(0)).Points.AddXY(x(i), y(i))
            Next i

            Form7.Chart1.Series.Add(nomeAmostra(1))
            Form7.Chart1.Series(nomeAmostra(1)).Color = Color.FromKnownColor(KnownColor.Blue)
            Form7.Chart1.Series(nomeAmostra(1)).ChartType = DataVisualization.Charting.SeriesChartType.Line

            Dim path1 As String = GlobalVariables.OpenFileDialog2.FileName
            If path1 = Nothing Then 'caso em que a abertura foi cancelada, o path ira vir nothinh e vc cancela o evento do butao
                Exit Sub
            End If
            Dim Text1 As String = readTxtComplete(path1)
            Dim y1() As Double = getColumYOfStringComplete(Text1)
            If (CheckBox8.Checked) Then
                y1 = NormalizaVetor(y1)
            End If
            Dim x1() As Double = getColumXOfStringComplete(Text1)

            For i = 0 To x1.Length - 2 'o ultimo elemento é 0, pois o vetor foi acrescentado e nada foi adiconado ao mesmo
                Form7.Chart1.Series(nomeAmostra(1)).Points.AddXY(x1(i), y1(i))
            Next i

        End If
        ' FIM - 2 GRAFICOS
        ' INICIO - 3 GRAFICOS
        If RadioButton3.Checked Then

            Form7.Chart1.Series.Clear()
            Form7.Chart1.Series.Add(nomeAmostra(0))
            Form7.Chart1.Series(nomeAmostra(0)).Color = Color.FromKnownColor(KnownColor.Red)
            Form7.Chart1.Series(nomeAmostra(0)).ChartType = DataVisualization.Charting.SeriesChartType.Line

            Dim path As String = GlobalVariables.OpenFileDialog1.FileName
            If path = Nothing Then 'caso em que a abertura foi cancelada, o path ira vir nothinh e vc cancela o evento do butao
                Exit Sub
            End If
            Text = readTxtComplete(path)
            Dim y() As Double = getColumYOfStringComplete(Text)
            If (CheckBox7.Checked) Then
                y = NormalizaVetor(y)
            End If
            Dim x() As Double = getColumXOfStringComplete(Text)

            For i = 0 To x.Length - 2 'o ultimo elemento é 0, pois o vetor foi acrescentado e nada foi adiconado ao mesmo
                Form7.Chart1.Series(nomeAmostra(0)).Points.AddXY(x(i), y(i))
            Next i

            Form7.Chart1.Series.Add(nomeAmostra(1))
            Form7.Chart1.Series(nomeAmostra(1)).Color = Color.FromKnownColor(KnownColor.Blue)
            Form7.Chart1.Series(nomeAmostra(1)).ChartType = DataVisualization.Charting.SeriesChartType.Line

            Dim path1 As String = GlobalVariables.OpenFileDialog2.FileName
            If path1 = Nothing Then 'caso em que a abertura foi cancelada, o path ira vir nothinh e vc cancela o evento do butao
                Exit Sub
            End If
            Dim Text1 As String = readTxtComplete(path1)
            Dim y1() As Double = getColumYOfStringComplete(Text1)
            If (CheckBox8.Checked) Then
                y1 = NormalizaVetor(y1)
            End If
            Dim x1() As Double = getColumXOfStringComplete(Text1)

            For i = 0 To x1.Length - 2 'o ultimo elemento é 0, pois o vetor foi acrescentado e nada foi adiconado ao mesmo
                Form7.Chart1.Series(nomeAmostra(1)).Points.AddXY(x1(i), y1(i))
            Next i

            Form7.Chart1.Series.Add(nomeAmostra(2))
            Form7.Chart1.Series(nomeAmostra(2)).Color = Color.FromKnownColor(KnownColor.Green)
            Form7.Chart1.Series(nomeAmostra(2)).ChartType = DataVisualization.Charting.SeriesChartType.Line

            Dim path2 As String = GlobalVariables.OpenFileDialog3.FileName
            If path2 = Nothing Then 'caso em que a abertura foi cancelada, o path ira vir nothinh e vc cancela o evento do butao
                Exit Sub
            End If
            Dim Text2 As String = readTxtComplete(path2)
            Dim y2() As Double = getColumYOfStringComplete(Text2)
            If (CheckBox9.Checked) Then
                y2 = NormalizaVetor(y2)
            End If
            Dim x2() As Double = getColumXOfStringComplete(Text2)

            For i = 0 To x2.Length - 2 'o ultimo elemento é 0, pois o vetor foi acrescentado e nada foi adiconado ao mesmo
                Form7.Chart1.Series(nomeAmostra(2)).Points.AddXY(x2(i), y2(i))
            Next i

        End If
        ' FIM - 3 GRAFICOS
        ' INICIO - 4 GRAFICOS
        If RadioButton4.Checked Then

            Form7.Chart1.Series.Clear()
            Form7.Chart1.Series.Add(nomeAmostra(0))
            Form7.Chart1.Series(nomeAmostra(0)).Color = Color.FromKnownColor(KnownColor.Red)
            Form7.Chart1.Series(nomeAmostra(0)).ChartType = DataVisualization.Charting.SeriesChartType.Line

            Dim path As String = GlobalVariables.OpenFileDialog1.FileName
            If path = Nothing Then 'caso em que a abertura foi cancelada, o path ira vir nothinh e vc cancela o evento do butao
                Exit Sub
            End If
            Text = readTxtComplete(path)
            Dim y() As Double = getColumYOfStringComplete(Text)
            If (CheckBox7.Checked) Then
                y = NormalizaVetor(y)
            End If
            Dim x() As Double = getColumXOfStringComplete(Text)

            For i = 0 To x.Length - 2 'o ultimo elemento é 0, pois o vetor foi acrescentado e nada foi adiconado ao mesmo
                Form7.Chart1.Series(nomeAmostra(0)).Points.AddXY(x(i), y(i))
            Next i

            Form7.Chart1.Series.Add(nomeAmostra(1))
            Form7.Chart1.Series(nomeAmostra(1)).Color = Color.FromKnownColor(KnownColor.Blue)
            Form7.Chart1.Series(nomeAmostra(1)).ChartType = DataVisualization.Charting.SeriesChartType.Line

            Dim path1 As String = GlobalVariables.OpenFileDialog2.FileName
            If path1 = Nothing Then 'caso em que a abertura foi cancelada, o path ira vir nothinh e vc cancela o evento do butao
                Exit Sub
            End If
            Dim Text1 As String = readTxtComplete(path1)
            Dim y1() As Double = getColumYOfStringComplete(Text1)
            If (CheckBox8.Checked) Then
                y1 = NormalizaVetor(y1)
            End If
            Dim x1() As Double = getColumXOfStringComplete(Text1)

            For i = 0 To x1.Length - 2 'o ultimo elemento é 0, pois o vetor foi acrescentado e nada foi adiconado ao mesmo
                Form7.Chart1.Series(nomeAmostra(1)).Points.AddXY(x1(i), y1(i))
            Next i

            Form7.Chart1.Series.Add(nomeAmostra(2))
            Form7.Chart1.Series(nomeAmostra(2)).Color = Color.FromKnownColor(KnownColor.Green)
            Form7.Chart1.Series(nomeAmostra(2)).ChartType = DataVisualization.Charting.SeriesChartType.Line

            Dim path2 As String = GlobalVariables.OpenFileDialog3.FileName
            If path2 = Nothing Then 'caso em que a abertura foi cancelada, o path ira vir nothinh e vc cancela o evento do butao
                Exit Sub
            End If
            Dim Text2 As String = readTxtComplete(path2)
            Dim y2() As Double = getColumYOfStringComplete(Text2)
            If (CheckBox9.Checked) Then
                y2 = NormalizaVetor(y2)
            End If
            Dim x2() As Double = getColumXOfStringComplete(Text2)

            For i = 0 To x2.Length - 2 'o ultimo elemento é 0, pois o vetor foi acrescentado e nada foi adiconado ao mesmo
                Form7.Chart1.Series(nomeAmostra(2)).Points.AddXY(x2(i), y2(i))
            Next i

            Form7.Chart1.Series.Add(nomeAmostra(3))
            Form7.Chart1.Series(nomeAmostra(3)).Color = Color.FromKnownColor(KnownColor.Black)
            Form7.Chart1.Series(nomeAmostra(3)).ChartType = DataVisualization.Charting.SeriesChartType.Line

            Dim path3 As String = GlobalVariables.OpenFileDialog4.FileName
            If path3 = Nothing Then 'caso em que a abertura foi cancelada, o path ira vir nothinh e vc cancela o evento do butao
                Exit Sub
            End If
            Dim Text3 As String = readTxtComplete(path3)
            Dim y3() As Double = getColumYOfStringComplete(Text3)
            If (CheckBox10.Checked) Then
                y3 = NormalizaVetor(y3)
            End If
            Dim x3() As Double = getColumXOfStringComplete(Text3)

            For i = 0 To x3.Length - 2 'o ultimo elemento é 0, pois o vetor foi acrescentado e nada foi adiconado ao mesmo
                Form7.Chart1.Series(nomeAmostra(3)).Points.AddXY(x3(i), y3(i))
            Next i
        End If
        ' FIM - 4 GRAFICOS
        ' INICIO - 5 GRAFICOS
        If RadioButton5.Checked Then

            Form7.Chart1.Series.Clear()
            Form7.Chart1.Series.Add(nomeAmostra(0))
            Form7.Chart1.Series(nomeAmostra(0)).Color = Color.FromKnownColor(KnownColor.Red)
            Form7.Chart1.Series(nomeAmostra(0)).ChartType = DataVisualization.Charting.SeriesChartType.Line

            Dim path As String = GlobalVariables.OpenFileDialog1.FileName
            If path = Nothing Then 'caso em que a abertura foi cancelada, o path ira vir nothinh e vc cancela o evento do butao
                Exit Sub
            End If
            Text = readTxtComplete(path)
            Dim y() As Double = getColumYOfStringComplete(Text)
            If (CheckBox7.Checked) Then
                y = NormalizaVetor(y)
            End If
            Dim x() As Double = getColumXOfStringComplete(Text)

            For i = 0 To x.Length - 2 'o ultimo elemento é 0, pois o vetor foi acrescentado e nada foi adiconado ao mesmo
                Form7.Chart1.Series(nomeAmostra(0)).Points.AddXY(x(i), y(i))
            Next i

            Form7.Chart1.Series.Add(nomeAmostra(1))
            Form7.Chart1.Series(nomeAmostra(1)).Color = Color.FromKnownColor(KnownColor.Blue)
            Form7.Chart1.Series(nomeAmostra(1)).ChartType = DataVisualization.Charting.SeriesChartType.Line

            Dim path1 As String = GlobalVariables.OpenFileDialog2.FileName
            If path1 = Nothing Then 'caso em que a abertura foi cancelada, o path ira vir nothinh e vc cancela o evento do butao
                Exit Sub
            End If
            Dim Text1 As String = readTxtComplete(path1)
            Dim y1() As Double = getColumYOfStringComplete(Text1)
            If (CheckBox8.Checked) Then
                y1 = NormalizaVetor(y1)
            End If
            Dim x1() As Double = getColumXOfStringComplete(Text1)

            For i = 0 To x1.Length - 2 'o ultimo elemento é 0, pois o vetor foi acrescentado e nada foi adiconado ao mesmo
                Form7.Chart1.Series(nomeAmostra(1)).Points.AddXY(x1(i), y1(i))
            Next i

            Form7.Chart1.Series.Add(nomeAmostra(2))
            Form7.Chart1.Series(nomeAmostra(2)).Color = Color.FromKnownColor(KnownColor.Green)
            Form7.Chart1.Series(nomeAmostra(2)).ChartType = DataVisualization.Charting.SeriesChartType.Line

            Dim path2 As String = GlobalVariables.OpenFileDialog3.FileName
            If path2 = Nothing Then 'caso em que a abertura foi cancelada, o path ira vir nothinh e vc cancela o evento do butao
                Exit Sub
            End If
            Dim Text2 As String = readTxtComplete(path2)
            Dim y2() As Double = getColumYOfStringComplete(Text2)
            If (CheckBox9.Checked) Then
                y2 = NormalizaVetor(y2)
            End If
            Dim x2() As Double = getColumXOfStringComplete(Text2)

            For i = 0 To x2.Length - 2 'o ultimo elemento é 0, pois o vetor foi acrescentado e nada foi adiconado ao mesmo
                Form7.Chart1.Series(nomeAmostra(2)).Points.AddXY(x2(i), y2(i))
            Next i

            Form7.Chart1.Series.Add(nomeAmostra(3))
            Form7.Chart1.Series(nomeAmostra(3)).Color = Color.FromKnownColor(KnownColor.Black)
            Form7.Chart1.Series(nomeAmostra(3)).ChartType = DataVisualization.Charting.SeriesChartType.Line

            Dim path3 As String = GlobalVariables.OpenFileDialog4.FileName
            If path3 = Nothing Then 'caso em que a abertura foi cancelada, o path ira vir nothinh e vc cancela o evento do butao
                Exit Sub
            End If
            Dim Text3 As String = readTxtComplete(path3)
            Dim y3() As Double = getColumYOfStringComplete(Text3)
            If (CheckBox10.Checked) Then
                y3 = NormalizaVetor(y3)
            End If
            Dim x3() As Double = getColumXOfStringComplete(Text3)

            For i = 0 To x3.Length - 2 'o ultimo elemento é 0, pois o vetor foi acrescentado e nada foi adiconado ao mesmo
                Form7.Chart1.Series(nomeAmostra(3)).Points.AddXY(x3(i), y3(i))
            Next i

            Form7.Chart1.Series.Add(nomeAmostra(4))
            Form7.Chart1.Series(nomeAmostra(4)).Color = Color.FromKnownColor(KnownColor.Yellow)
            Form7.Chart1.Series(nomeAmostra(4)).ChartType = DataVisualization.Charting.SeriesChartType.Line

            Dim path4 As String = GlobalVariables.OpenFileDialog5.FileName
            If path4 = Nothing Then 'caso em que a abertura foi cancelada, o path ira vir nothinh e vc cancela o evento do butao
                Exit Sub
            End If
            Dim Text4 As String = readTxtComplete(path4)
            Dim y4() As Double = getColumYOfStringComplete(Text4)
            If (CheckBox11.Checked) Then
                y4 = NormalizaVetor(y4)
            End If
            Dim x4() As Double = getColumXOfStringComplete(Text4)

            For i = 0 To x4.Length - 2 'o ultimo elemento é 0, pois o vetor foi acrescentado e nada foi adiconado ao mesmo
                Form7.Chart1.Series(nomeAmostra(4)).Points.AddXY(x4(i), y4(i))
            Next i
        End If
        ' FIM - 5 GRAFICOS
        ' INICIO - 6 GRAFICOS
        If RadioButton6.Checked Then

            Form7.Chart1.Series.Clear()
            Form7.Chart1.Series.Add(nomeAmostra(0))
            Form7.Chart1.Series(nomeAmostra(0)).Color = Color.FromKnownColor(KnownColor.Red)
            Form7.Chart1.Series(nomeAmostra(0)).ChartType = DataVisualization.Charting.SeriesChartType.Line

            Dim path As String = GlobalVariables.OpenFileDialog1.FileName
            If path = Nothing Then 'caso em que a abertura foi cancelada, o path ira vir nothinh e vc cancela o evento do butao
                Exit Sub
            End If
            Text = readTxtComplete(path)
            Dim y() As Double = getColumYOfStringComplete(Text)
            If (CheckBox7.Checked) Then
                y = NormalizaVetor(y)
            End If
            Dim x() As Double = getColumXOfStringComplete(Text)

            For i = 0 To x.Length - 2 'o ultimo elemento é 0, pois o vetor foi acrescentado e nada foi adiconado ao mesmo
                Form7.Chart1.Series(nomeAmostra(0)).Points.AddXY(x(i), y(i))
            Next i

            Form7.Chart1.Series.Add(nomeAmostra(1))
            Form7.Chart1.Series(nomeAmostra(1)).Color = Color.FromKnownColor(KnownColor.Blue)
            Form7.Chart1.Series(nomeAmostra(1)).ChartType = DataVisualization.Charting.SeriesChartType.Line

            Dim path1 As String = GlobalVariables.OpenFileDialog2.FileName
            If path1 = Nothing Then 'caso em que a abertura foi cancelada, o path ira vir nothinh e vc cancela o evento do butao
                Exit Sub
            End If
            Dim Text1 As String = readTxtComplete(path1)
            Dim y1() As Double = getColumYOfStringComplete(Text1)
            If (CheckBox8.Checked) Then
                y1 = NormalizaVetor(y1)
            End If
            Dim x1() As Double = getColumXOfStringComplete(Text1)

            For i = 0 To x1.Length - 2 'o ultimo elemento é 0, pois o vetor foi acrescentado e nada foi adiconado ao mesmo
                Form7.Chart1.Series(nomeAmostra(1)).Points.AddXY(x1(i), y1(i))
            Next i

            Form7.Chart1.Series.Add(nomeAmostra(2))
            Form7.Chart1.Series(nomeAmostra(2)).Color = Color.FromKnownColor(KnownColor.Green)
            Form7.Chart1.Series(nomeAmostra(2)).ChartType = DataVisualization.Charting.SeriesChartType.Line

            Dim path2 As String = GlobalVariables.OpenFileDialog3.FileName
            If path2 = Nothing Then 'caso em que a abertura foi cancelada, o path ira vir nothinh e vc cancela o evento do butao
                Exit Sub
            End If
            Dim Text2 As String = readTxtComplete(path2)
            Dim y2() As Double = getColumYOfStringComplete(Text2)
            If (CheckBox9.Checked) Then
                y2 = NormalizaVetor(y2)
            End If
            Dim x2() As Double = getColumXOfStringComplete(Text2)

            For i = 0 To x2.Length - 2 'o ultimo elemento é 0, pois o vetor foi acrescentado e nada foi adiconado ao mesmo
                Form7.Chart1.Series(nomeAmostra(2)).Points.AddXY(x2(i), y2(i))
            Next i

            Form7.Chart1.Series.Add(nomeAmostra(3))
            Form7.Chart1.Series(nomeAmostra(3)).Color = Color.FromKnownColor(KnownColor.Black)
            Form7.Chart1.Series(nomeAmostra(3)).ChartType = DataVisualization.Charting.SeriesChartType.Line

            Dim path3 As String = GlobalVariables.OpenFileDialog4.FileName
            If path3 = Nothing Then 'caso em que a abertura foi cancelada, o path ira vir nothinh e vc cancela o evento do butao
                Exit Sub
            End If
            Dim Text3 As String = readTxtComplete(path3)
            Dim y3() As Double = getColumYOfStringComplete(Text3)
            If (CheckBox10.Checked) Then
                y3 = NormalizaVetor(y3)
            End If
            Dim x3() As Double = getColumXOfStringComplete(Text3)

            For i = 0 To x3.Length - 2 'o ultimo elemento é 0, pois o vetor foi acrescentado e nada foi adiconado ao mesmo
                Form7.Chart1.Series(nomeAmostra(3)).Points.AddXY(x3(i), y3(i))
            Next i

            Form7.Chart1.Series.Add(nomeAmostra(4))
            Form7.Chart1.Series(nomeAmostra(4)).Color = Color.FromKnownColor(KnownColor.Yellow)
            Form7.Chart1.Series(nomeAmostra(4)).ChartType = DataVisualization.Charting.SeriesChartType.Line

            Dim path4 As String = GlobalVariables.OpenFileDialog5.FileName
            If path4 = Nothing Then 'caso em que a abertura foi cancelada, o path ira vir nothinh e vc cancela o evento do butao
                Exit Sub
            End If
            Dim Text4 As String = readTxtComplete(path4)
            Dim y4() As Double = getColumYOfStringComplete(Text4)
            If (CheckBox11.Checked) Then
                y4 = NormalizaVetor(y4)
            End If
            Dim x4() As Double = getColumXOfStringComplete(Text4)

            For i = 0 To x4.Length - 2 'o ultimo elemento é 0, pois o vetor foi acrescentado e nada foi adiconado ao mesmo
                Form7.Chart1.Series(nomeAmostra(4)).Points.AddXY(x4(i), y4(i))
            Next i

            Form7.Chart1.Series.Add(nomeAmostra(5))
            Form7.Chart1.Series(nomeAmostra(5)).Color = Color.FromKnownColor(KnownColor.Pink)
            Form7.Chart1.Series(nomeAmostra(5)).ChartType = DataVisualization.Charting.SeriesChartType.Line

            Dim path5 As String = GlobalVariables.OpenFileDialog6.FileName
            If path5 = Nothing Then 'caso em que a abertura foi cancelada, o path ira vir nothinh e vc cancela o evento do butao
                Exit Sub
            End If
            Dim Text5 As String = readTxtComplete(path5)
            Dim y5() As Double = getColumYOfStringComplete(Text5)
            If (CheckBox12.Checked) Then
                y5 = NormalizaVetor(y5)
            End If
            Dim x5() As Double = getColumXOfStringComplete(Text5)

            For i = 0 To x5.Length - 2 'o ultimo elemento é 0, pois o vetor foi acrescentado e nada foi adiconado ao mesmo
                Form7.Chart1.Series(nomeAmostra(5)).Points.AddXY(x5(i), y5(i))
            Next i
        End If
        ' FIM - 6 GRAFICOS
        Me.Hide()
        Form7.Visible = True
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Form4.Visible = True
    End Sub

    Public Class GlobalVariables
        Public Shared OpenFileDialog1 As New OpenFileDialog
        Public Shared OpenFileDialog2 As New OpenFileDialog
        Public Shared OpenFileDialog3 As New OpenFileDialog
        Public Shared OpenFileDialog4 As New OpenFileDialog
        Public Shared OpenFileDialog5 As New OpenFileDialog
        Public Shared OpenFileDialog6 As New OpenFileDialog

    End Class

    Public Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        GlobalVariables.OpenFileDialog1.RestoreDirectory = True
        GlobalVariables.OpenFileDialog1.Title = "Buscando arquivo..."
        GlobalVariables.OpenFileDialog1.Filter = "Text Files|*.txt;*.doc;*.med;*.ref|All files|*.*" 'med e ref sao formatos que saem os arquivos do programa principal
        Dim DidWork As Integer = GlobalVariables.OpenFileDialog1.ShowDialog()
        If DidWork = DialogResult.Cancel Then
            MessageBox.Show("Você cancelou a abertura")
        End If

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        GlobalVariables.OpenFileDialog2.RestoreDirectory = True
        GlobalVariables.OpenFileDialog2.Title = "Buscando arquivo..."
        GlobalVariables.OpenFileDialog2.Filter = "Text Files|*.txt;*.doc;*.med;*.ref|All files|*.*" 'med e ref sao formatos que saem os arquivos do programa principal
        Dim DidWork As Integer = GlobalVariables.OpenFileDialog2.ShowDialog()
        If DidWork = DialogResult.Cancel Then
            MessageBox.Show("Você cancelou a abertura")
        End If

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        GlobalVariables.OpenFileDialog3.RestoreDirectory = True
        GlobalVariables.OpenFileDialog3.Title = "Buscando arquivo..."
        GlobalVariables.OpenFileDialog3.Filter = "Text Files|*.txt;*.doc;*.med;*.ref|All files|*.*" 'med e ref sao formatos que saem os arquivos do programa principal
        Dim DidWork As Integer = GlobalVariables.OpenFileDialog3.ShowDialog()
        If DidWork = DialogResult.Cancel Then
            MessageBox.Show("Você cancelou a abertura")
        End If

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        GlobalVariables.OpenFileDialog4.RestoreDirectory = True
        GlobalVariables.OpenFileDialog4.Title = "Buscando arquivo..."
        GlobalVariables.OpenFileDialog4.Filter = "Text Files|*.txt;*.doc;*.med;*.ref|All files|*.*" 'med e ref sao formatos que saem os arquivos do programa principal
        Dim DidWork As Integer = GlobalVariables.OpenFileDialog4.ShowDialog()
        If DidWork = DialogResult.Cancel Then
            MessageBox.Show("Você cancelou a abertura")
        End If

    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        GlobalVariables.OpenFileDialog5.RestoreDirectory = True
        GlobalVariables.OpenFileDialog5.Title = "Buscando arquivo..."
        GlobalVariables.OpenFileDialog5.Filter = "Text Files|*.txt;*.doc;*.med;*.ref|All files|*.*" 'med e ref sao formatos que saem os arquivos do programa principal
        Dim DidWork As Integer = GlobalVariables.OpenFileDialog5.ShowDialog()
        If DidWork = DialogResult.Cancel Then
            MessageBox.Show("Você cancelou a abertura")
        End If

    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        GlobalVariables.OpenFileDialog6.RestoreDirectory = True
        GlobalVariables.OpenFileDialog6.Title = "Buscando arquivo..."
        GlobalVariables.OpenFileDialog6.Filter = "Text Files|*.txt;*.doc;*.med;*.ref|All files|*.*" 'med e ref sao formatos que saem os arquivos do programa principal
        Dim DidWork As Integer = GlobalVariables.OpenFileDialog6.ShowDialog()
        If DidWork = DialogResult.Cancel Then
            MessageBox.Show("Você cancelou a abertura")
        End If

    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Form5.Visible = True
    End Sub
End Class