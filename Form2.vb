Imports System.IO
Imports System.Windows.Forms.DataVisualization.Charting

Public Class Form2

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged,
        TextBox4.TextChanged,
        TextBox5.TextChanged,
        TextBox6.TextChanged,
        TextBox7.TextChanged,
        TextBox8.TextChanged

        Dim alfa As Double = CalculaAlfa()

        If alfa.ToString.Length > 5 Then
            TextBoxAlfa.Text = alfa.ToString.Substring(0, 6)
        Else
            TextBoxAlfa.Text = alfa.ToString
        End If

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Label13.Visible = True
        Label14.Visible = True
        Label15.Visible = True
        Label16.Visible = True
        TextBox10.Visible = True
        TextBox11.Visible = True
        TextBox12.Visible = True
        TextBox13.Visible = True

        Button1.Visible = True
        Button4.Visible = True
        If (String.IsNullOrEmpty(TextBox4.Text)) Then
            TextBox4.Text = "50"
        End If
        If (String.IsNullOrEmpty(TextBox6.Text)) Then
            TextBox6.Text = "50"
        End If

        TextBox9.Text = CalculaBeta().ToString("0.00E+00")
        TextBox15.Text = CalculaGamma().ToString("0.00E+00")

        'validar que os LN6N tenham essa mensagem
        If ComboBox1.Text.Equals("818-BB-22") Or ComboBox1.Text.Equals("S-010-H") Then

        Else
            MsgBox(ChrW(215) & " Este é um sensor LN6N. Lembre-se de sempre resfria-lo com NL antes de liga-lo na fonte de alimentação." & vbCrLf & vbCrLf & ChrW(215) & " Atentar-se à posição do switch Hi/LO.",, "Atenção !")
        End If
        If ComboBox1.Text.Equals("S-010-H") Then
            MsgBox(ChrW(215) & " Atentar-se à posição do switch Hi/LO.",, "Atenção !")
        End If


        Dim sensor = New SensorFabricante(ComboBox1.Text)
        TextBox10.Text = sensor.Material

        Dim areaDouble As Double
        Dim ok As Boolean = Double.TryParse(sensor.Area.Substring(0, sensor.Area.Length - 4), areaDouble)

        If ok Then
            areaDouble = Math.Round(areaDouble, 4, MidpointRounding.AwayFromZero)
            TextBox11.Text = areaDouble.ToString & " mm²"
        Else
            TextBox11.Text = sensor.Area.Substring(0, sensor.Area.Length - 4) & " mm²"
        End If

        TextBox12.Text = sensor.RespMax
        TextBox13.Text = sensor.FaixaEspectral

        'retira o " mm²" do final e arredonda para 4 casas decimais

        If ok Then
            areaDouble = Math.Round(areaDouble, 4, MidpointRounding.AwayFromZero)
            TextBox3.Text = areaDouble.ToString
        Else
            TextBox3.Text = sensor.Area.Substring(0, sensor.Area.Length - 4)
        End If

        If (String.IsNullOrEmpty(TextBox5.Text)) Then
            TextBox5.Text = areaDouble
        End If

        If (String.IsNullOrEmpty(TextBox7.Text)) Then
            TextBox7.Text = "1"
        End If

        If (String.IsNullOrEmpty(TextBox8.Text)) Then
            TextBox8.Text = "1"
        End If

    End Sub

    Private Sub ButtonCalibracao_Click(sender As Object, e As EventArgs) Handles ButtonCalibracao.Click
        GlobalVariables.OpenFileDialogSensor.Title = "Buscando arquivo..."
        GlobalVariables.OpenFileDialogSensor.Filter = "Text Files|*.txt;*.doc;*.med;*.ref|All files|*.*" 'med e ref sao formatos que saem os arquivos do programa principal
        GlobalVariables.OpenFileDialogSensor.RestoreDirectory = True
        Dim DidWork As Integer = GlobalVariables.OpenFileDialogSensor.ShowDialog()
        If DidWork = DialogResult.Cancel Then
            MessageBox.Show("Você cancelou a abertura")
            TextBox1.Text = "Falhou !"
            TextBox1.BackColor = Color.Red
            Exit Sub 'isso faz com que saia do evento de botão clido, ele suspende todas as ações posteriores
        Else
            TextBox1.Text = "Inserido !"
            TextBox1.BackColor = Color.SpringGreen
        End If

    End Sub
    Private Sub ButtonAmostra_Click(sender As Object, e As EventArgs) Handles ButtonAmostra.Click
        GlobalVariables.OpenFileDialogAmostra.Title = "Buscando arquivo..."
        GlobalVariables.OpenFileDialogAmostra.Filter = "Text Files|*.txt;*.doc;*.med;*.ref|All files|*.*" 'med e ref sao formatos que saem os arquivos do programa principal
        GlobalVariables.OpenFileDialogAmostra.RestoreDirectory = True
        Dim DidWork As Integer = GlobalVariables.OpenFileDialogAmostra.ShowDialog()
        If DidWork = DialogResult.Cancel Then
            MessageBox.Show("Você cancelou a abertura")
            TextBox2.Text = "Falhou !"
            TextBox2.BackColor = Color.Red
            Exit Sub 'isso faz com que saia do evento de botão clido, ele suspende todas as ações posteriores
        Else
            TextBox2.Text = "Inserido !"
            TextBox2.BackColor = Color.SpringGreen
        End If

    End Sub

    Public Class GlobalVariables
        Public Shared OpenFileDialogSensor As New OpenFileDialog
        Public Shared OpenFileDialogAmostra As New OpenFileDialog
        Public Shared FolderBrowserDialog1 As New FolderBrowserDialog
        Public Shared pathNewArchive As String
        Public Shared nameNewArchive As String
        Public Shared flagBut As Integer 'sensor 0, potencia 1, respon/eqe 2, plotar 3

    End Class

    Private Sub ButtonCalcular_Click(sender As Object, e As EventArgs) Handles ButtonCalcular.Click
        Dim PathRef As String
        PathRef = ComboBox1.Text
        Dim filePath As String = IO.Path.Combine(Application.StartupPath, "TxtsDasReferencias", PathRef + ".txt") 'aqui está pegando o caminho (interno) do sensor de referencia escolhido dentre as opções

        'Parâmetros para o alfa (coeficiente que corrige os valores por causa das diferentes áreas e distancias)
        Dim alfa As Double = CalculaAlfa()
        Dim beta As Double = CalculaBeta()
        Dim gamma As Double = CalculaGamma()
        If (alfa = 0) Then
            MsgBox(ChrW(215) & " Área ou distância com valor ZERO não existe. Coloque um valor válido e continue.",, "Atenção !")
            Exit Sub 'isso faz com que saia do evento de botão clido, ele suspende todas as ações posteriores
        End If

        Dim textRef As String 'variável para pegar os dados do txt em forma de string
        Dim textCalib As String 'variável para pegar os dados do txt em forma de string
        Dim textAmostra As String 'variável para pegar os dados do txt em forma de string

        Dim indice As Integer
        Dim temporario As Double
        Dim yInterpolado(0) As Double

        Dim potencia(0) As Double
        Dim responsividade(0) As Double

        Dim columnXRef() As Double
        Dim columnYRef() As Double

        Dim columnXCalib() As Double
        Dim columnYCalib() As Double

        Dim columnXAmostra() As Double
        Dim columnYAmostra() As Double

        'curva do sensor de referencia dado pelo fabricante
        textRef = readTxtComplete(filePath) 'filepath é o caminho do arquivo do sensor de referencia dado pelo fabricante
        columnYRef = getColumYOfStringComplete(textRef) 'column y é a primeira coluna do txt
        columnXRef = getColumXOfStringComplete(textRef)  'column x é a segunda coluna do txt
        'curva do sensor de referencia no SETUP
        textCalib = readTxtComplete(GlobalVariables.OpenFileDialogSensor.FileName) 'aqui ele vai pegar o caminho do arquivo 
        columnYCalib = getColumYOfStringComplete(textCalib)
        columnXCalib = getColumXOfStringComplete(textCalib)
        'curva da amostra no SETUP
        textAmostra = readTxtComplete(GlobalVariables.OpenFileDialogAmostra.FileName)
        columnYAmostra = getColumYOfStringComplete(textAmostra)
        columnXAmostra = getColumXOfStringComplete(textAmostra)


        Dim menor As Integer = 0
        If columnXCalib(0) > columnXRef(0) Then 'se o menor valor do Xcalib ta dentro da referencia, entao começa do zero
            menor = 0
        Else
            While columnXCalib(menor) < columnXRef(0)
                menor += 1
            End While 'menor será o menor indice valido do Xcalib
        End If


        Dim maior As Integer = columnXCalib.Length - 1
        If columnXCalib(columnXCalib.Length - 1) < columnXRef(columnXRef.Length - 1) Then
            maior = columnXCalib.Length - 1
        Else
            While columnXCalib(maior) > columnXRef(columnXRef.Length - 1)
                maior -= 1
            End While 'maior é o ultimo indice valido de Xcalib
        End If


        'filtrando os vetores calib e amostra para valores só dentro do range do fabricante
        Dim NewColumnXCalib = columnXCalib.Take(maior + 1).Skip(menor).ToArray()
        Dim NewColumnYCalib = columnYCalib.Take(maior + 1).Skip(menor).ToArray()

        Dim NewColumnXAmostra = columnXAmostra.Take(maior + 1).Skip(menor).ToArray()
        Dim NewColumnYAmostra = columnYAmostra.Take(maior + 1).Skip(menor).ToArray()

        'Em posse de todos os vetores, agora calcularemos a responsividade
        For i = 0 To NewColumnXCalib.Length - 1
            indice = menorque(NewColumnXCalib(i), columnXRef)

            temporario = ((NewColumnXCalib(i)) * (columnYRef(indice + 1) - columnYRef(indice)) + columnYRef(indice) * columnXRef(indice + 1) - columnXRef(indice) * columnYRef(indice + 1)) / (columnXRef(indice + 1) - columnXRef(indice))
            Add(Of Double)(yInterpolado, temporario)

            If temporario.Equals(0) Then
                Add(Of Double)(potencia, 0)
            Else
                Add(Of Double)(potencia, NewColumnYCalib(i) / temporario)
            End If
            If (NewColumnYCalib(i).Equals(0)) Then
                Add(Of Double)(responsividade, 0)
            Else
                If CheckBox1.Checked Then
                    Add(Of Double)(responsividade, (NewColumnYAmostra(i) * temporario * alfa * beta) / NewColumnYCalib(i))
                End If
                If CheckBox2.Checked Then
                    Add(Of Double)(responsividade, (NewColumnYAmostra(i) * temporario * alfa * beta * gamma) / (NewColumnYCalib(i) * NewColumnXCalib(i) * 0.000000001))
                End If
            End If

        Next i
        Array.Resize(responsividade, responsividade.Length - 1) 'a funcao add sempre deixa o ultimo lugar vago, tira-se entao
        Array.Resize(yInterpolado, yInterpolado.Length - 1)
        Array.Resize(potencia, potencia.Length - 1)
        'receber nome do usuário.
        Dim nomeUsuario = InputBox("Digite seu nome: ", "Nome do usuário")

        'recebe So O nome Da Amostra
        Dim nomeAmostra As String = GetNameOfArchive(GlobalVariables.OpenFileDialogAmostra.FileName)

        'aqui começa criação do arquivo
        Dim sfdPic As New SaveFileDialog()
        sfdPic.OverwritePrompt = True
        Dim sensorReferenciaUsado = New SensorFabricante(ComboBox1.Text)

        Dim cabecalho As String = ""
        Dim tipoDeMedida As String = "_RESPONSIVIDADE_"
        Dim switchTemp As String = ""
        If CheckBox5.Checked Then
            switchTemp = "Posição HI, " & TextBox16.Text
        End If
        If CheckBox6.Checked Then
            switchTemp = "Posição LO, " & TextBox16.Text
        End If
        Dim datahoraAtual As DateTime = Now
        If CheckBox1.Checked Then
            tipoDeMedida = "_RESPONSIVIDADE_"
            cabecalho = "ARQUIVO DE MEDIDA DE RESPONSIVIDADE" & vbCrLf &
             "Usuário: " & nomeUsuario & vbCrLf &
             "Data e Hora: " & datahoraAtual.ToShortDateString & " " & datahoraAtual.ToShortTimeString & vbCrLf &
             "Fonte de radiação: " & ComboBox3.Text & " " & TextBox18.Text & vbCrLf &
             "Sensor de referência usado: " & sensorReferenciaUsado.Nome & vbCrLf &
             "Área do sensor de referência (mm²): " & TextBox3.Text & vbCrLf &
             "Distância do sensor de referência (mm): " & TextBox4.Text & vbCrLf &
             "Área da amostra (mm²): " & TextBox5.Text & vbCrLf &
             "Distância da amostra (mm): " & TextBox6.Text & vbCrLf &
             "Janela do sensor: " & TextBox7.Text & vbCrLf &
             "Janela do Criostato: " & TextBox8.Text & vbCrLf &
             "Switch: " & switchTemp & vbCrLf &
             "Alfa: " & TextBoxAlfa.Text & vbCrLf &
             "Ganho Keithley: " & TextBox14.Text & vbCrLf &
             sensorReferenciaUsado.UnidadeResponsividade & " Comprimento de onda(nm)"
        End If
        If CheckBox2.Checked Then
            tipoDeMedida = "_EQE_"
            cabecalho = "ARQUIVO DE MEDIDA DE EQE" & vbCrLf &
             "Usuário: " & nomeUsuario & vbCrLf &
             "Data e Hora: " & datahoraAtual.ToShortDateString & " " & datahoraAtual.ToShortTimeString & vbCrLf &
             "Fonte de radiação: " & ComboBox3.Text & " " & TextBox18.Text & vbCrLf &
             "Sensor de referência usado: " & sensorReferenciaUsado.Nome & vbCrLf &
             "Área do sensor de referência (mm²): " & TextBox3.Text & vbCrLf &
             "Distância do sensor de referência (mm): " & TextBox4.Text & vbCrLf &
             "Área da amostra (mm²): " & TextBox5.Text & vbCrLf &
             "Distância da amostra (mm): " & TextBox6.Text & vbCrLf &
             "Janela do sensor: " & TextBox7.Text & vbCrLf &
             "Janela do Criostato: " & TextBox8.Text & vbCrLf &
             "Switch: " & switchTemp & vbCrLf &
             "Alfa: " & TextBoxAlfa.Text & vbCrLf &
             "Ganho Stanford: " & TextBox14.Text & vbCrLf &
             "EQE " & " Comprimento de onda(nm)"
        End If

        Try
            With sfdPic
                .Title = "Salve o arquivo como"
                .Filter = "txt|*.txt"
                .AddExtension = True
                .DefaultExt = ".txt"
                .FileName = nomeAmostra & tipoDeMedida & Now.ToShortDateString.Replace("/", "") & "_" & Now.ToShortTimeString.Replace(":", "")
                .ValidateNames = True
                .RestoreDirectory = True

                If .ShowDialog = DialogResult.OK Then
                    Dim outFile As IO.StreamWriter
                    Dim qlqr As String
                    outFile = My.Computer.FileSystem.OpenTextFileWriter(sfdPic.FileName, False)
                    outFile.WriteLine(cabecalho)
                    For k = 0 To responsividade.Length - 1
                        qlqr = responsividade(k).ToString + " " + NewColumnXAmostra(k).ToString
                        outFile.WriteLine(qlqr)
                    Next k
                    outFile.Close()
                Else
                    Return
                End If

            End With

            Dim r As DialogResult
            Dim msg As String = "O arquivo foi salvo corretamente." & vbNewLine
            msg &= "Você quer abrir o arquivo agora?"

            Dim title As String = "Abrir o arquivo."
            Dim btn = MessageBoxButtons.YesNo
            Dim ico = MessageBoxIcon.Information

            r = MessageBox.Show(msg, title, btn, ico)

            If r = System.Windows.Forms.DialogResult.Yes Then
                Dim startInfo As New ProcessStartInfo("notepad.exe")
                startInfo.WindowStyle = ProcessWindowStyle.Maximized
                startInfo.Arguments = sfdPic.FileName
                Process.Start(startInfo)
            Else
                Return
            End If

        Catch ex As Exception
            MessageBox.Show("Erro: Salvar o arquivo falhou ->> " & ex.Message.ToString())
        Finally
            sfdPic.Dispose()
        End Try
        Me.Hide()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim PathRef As String
        PathRef = ComboBox1.Text
        Dim filePath As String = IO.Path.Combine(Application.StartupPath, "TxtsDasReferencias", PathRef + ".pdf")
        Process.Start(filePath)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Form6.Visible = True
        Form6.WindowState = FormWindowState.Normal
        Form6.BringToFront()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Form8.Visible = True
        Form8.WindowState = FormWindowState.Normal
        Form8.BringToFront()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        GlobalVariables.flagBut = 0
        Dim sensorSelected = New SensorFabricante(ComboBox1.Text)

        ' N indica o numero como ele realmente é, o NX indica com X casas decimais
        Dim formatX As String
        Dim formatY As String
        formatX = "eixoX"
        formatY = "N0"

        Dim renameY As String

        If Form7.CheckBox2.Checked Then
            renameY = "Log"
            formatY = "E0"
            Form7.CheckBox1.Visible = False 'tive que tirar pq a linha vertical sumiu e nao aparecia mais
        Else
            renameY = sensorSelected.UnidadeResponsividade
            Form7.CheckBox1.Visible = True 'tive que tirar pq a linha vertical sumiu e nao aparecia mais
        End If

        Form7.Chart1.Titles.Clear()
        Form7.Chart1.Titles.Add(sensorSelected.Nome) 'specify chart name
        Form7.Chart1.Titles(0).Font = New Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold) 'mexa aqui pra mudar a fonte do titulo
        Form7.Chart1.ChartAreas.Clear()
        Form7.Chart1.Series.Clear()
        Form7.Chart1.Annotations.Clear()
        Form7.Chart1.ChartAreas.Add(sensorSelected.Nome)
        With Form7.Chart1.ChartAreas(sensorSelected.Nome)
            .AxisX.Title = "Comprimento de onda(nm)" 'x label
            .AxisX.MajorGrid.LineColor = Color.SkyBlue
            .AxisY.MajorGrid.LineColor = Color.SkyBlue
            .AxisY.Title = renameY 'y label
            .AxisY.IsLogarithmic = Form7.CheckBox2.Checked
            .AxisY.IsStartedFromZero = False
            .AxisX.LabelStyle.Format = formatX
            .AxisY.LabelStyle.Format = formatY
        End With
        Form7.Chart1.Series.Clear()

        Form7.Chart1.Series.Add(sensorSelected.Nome)
        Form7.Chart1.Series(sensorSelected.Nome).Color = Color.FromKnownColor(KnownColor.Red)
        Form7.Chart1.Series(sensorSelected.Nome).ChartType = DataVisualization.Charting.SeriesChartType.Line

        Dim path As String = sensorSelected.PathSensor
        If path = Nothing Then 'caso em que a abertura foi cancelada, o path ira vir nothinh e vc cancela o evento do butao
            Exit Sub
        End If
        Text = readTxtComplete(path)
        Dim y() As Double = getColumYOfStringComplete(Text)
        Dim x() As Double = getColumXOfStringComplete(Text)
        If (Form7.CheckBox2.Checked) Then
            y = removeZerosVetorY(x, y)
            x = removeZerosVetorX(x, y)
        End If
        For i = 0 To x.Length - 2 'o ultimo elemento é 0, pois o vetor foi acrescentado e nada foi adiconado ao mesmo
            Form7.Chart1.Series(sensorSelected.Nome).Points.AddXY(x(i), y(i))
        Next i

        If Form7.CheckBox2.Checked Then
            'deixando o gráfico no tamanho correto
            Form7.Chart1.ChartAreas(0).AxisY.Maximum = Form7.Chart1.Series(0).Points.FindMaxByValue("Y1").YValues(0)
            Form7.Chart1.ChartAreas(0).AxisY.Minimum = Form7.Chart1.Series(0).Points.FindMinByValue("Y1").YValues(0)
        End If

        FormDados.TextBox2.Text = Text
        Dim verticalLine = New VerticalLineAnnotation()
        verticalLine.AxisX = Form7.Chart1.ChartAreas.First.AxisX
        verticalLine.AllowMoving = True
        verticalLine.IsInfinitive = True
        verticalLine.LineColor = Color.Navy
        verticalLine.LineWidth = 2
        verticalLine.AnchorOffsetX = 50
        verticalLine.ClipToChartArea = Form7.Chart1.ChartAreas.First.Name
        verticalLine.Name = "VA"
        verticalLine.LineDashStyle = 1
        verticalLine.AnchorDataPoint = Form7.Chart1.Series.First.Points(0)
        Form7.Chart1.Annotations.Add(verticalLine)

        Dim RA = New RectangleAnnotation()
        RA.AxisX = verticalLine.AxisX
        RA.IsSizeAlwaysRelative = False
        RA.Width = MaiorRange() / 12
        RA.Height = 3
        RA.Name = "RA"
        RA.LineColor = Color.Blue
        RA.BackColor = Color.White
        RA.Y = 82.5
        RA.Text = "Hello"
        RA.ForeColor = Color.Navy
        RA.Font = New System.Drawing.Font("Arial", 8.0F)
        Form7.Chart1.Annotations.Add(RA)

        Form7.Visible = True
        Form7.WindowState = FormWindowState.Normal
        Form7.BringToFront()

    End Sub
    Private Function MaiorRange() As Double
        'redimensionando
        Dim maiorRang As Double = 0
        Dim lastPoint As Integer
        Dim range As Double
        For Each serie In Form7.Chart1.Series
            lastPoint = serie.Points.Count - 1
            range = serie.Points(lastPoint).XValue - serie.Points(0).XValue
            If range > maiorRang Then
                maiorRang = range
            End If
        Next
        Return maiorRang
    End Function

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim PathRef As String
        PathRef = ComboBox1.Text
        Dim filePath As String = IO.Path.Combine(Application.StartupPath, "TxtsDasReferencias", PathRef + ".txt") 'aqui está pegando o caminho (interno) do sensor de referencia escolhido dentre as opções

        Dim textRef As String 'variável para pegar os dados do txt em forma de string
        Dim textCalib As String 'variável para pegar os dados do txt em forma de string

        Dim indice As Integer
        Dim temporario As Double
        Dim yInterpolado(0) As Double

        Dim potencia(0) As Double
        Dim responsividade(0) As Double

        Dim columnXRef() As Double
        Dim columnYRef() As Double

        Dim columnXCalib() As Double
        Dim columnYCalib() As Double

        'curva do sensor de referencia dado pelo fabricante
        textRef = readTxtComplete(filePath) 'filepath é o caminho do arquivo do sensor de referencia dado pelo fabricante
        columnYRef = getColumYOfStringComplete(textRef) 'column y é a primeira coluna do txt
        columnXRef = getColumXOfStringComplete(textRef)  'column x é a segunda coluna do txt
        'curva do sensor de referencia no SETUP
        textCalib = readTxtComplete(GlobalVariables.OpenFileDialogSensor.FileName) 'aqui ele vai pegar o caminho do arquivo 
        columnYCalib = getColumYOfStringComplete(textCalib)
        columnXCalib = getColumXOfStringComplete(textCalib)

        Dim menor As Integer = 0
        If columnXCalib(0) > columnXRef(0) Then 'se o menor valor do Xcalib ta dentro da referencia, entao começa do zero
            menor = 0
        Else
            While columnXCalib(menor) < columnXRef(0)
                menor += 1
            End While 'menor será o menor indice valido do Xcalib
        End If


        Dim maior As Integer = columnXCalib.Length - 1
        If columnXCalib(columnXCalib.Length - 1) < columnXRef(columnXRef.Length - 1) Then
            maior = columnXCalib.Length - 1
        Else
            While columnXCalib(maior) > columnXRef(columnXRef.Length - 1)
                maior -= 1
            End While 'maior é o ultimo indice valido de Xcalib
        End If


        'filtrando os vetores calib e amostra para valores só dentro do range do fabricante
        Dim NewColumnXCalib = columnXCalib.Take(maior + 1).Skip(menor).ToArray()
        Dim NewColumnYCalib = columnYCalib.Take(maior + 1).Skip(menor).ToArray()

        'Em posse de todos os vetores, agora calcularemos a responsividade
        For i = 0 To NewColumnXCalib.Length - 1
            indice = menorque(NewColumnXCalib(i), columnXRef)

            temporario = ((NewColumnXCalib(i)) * (columnYRef(indice + 1) - columnYRef(indice)) + columnYRef(indice) * columnXRef(indice + 1) - columnXRef(indice) * columnYRef(indice + 1)) / (columnXRef(indice + 1) - columnXRef(indice))
            Add(Of Double)(yInterpolado, temporario)

            If temporario.Equals(0) Then
                Add(Of Double)(potencia, 0)
            Else
                Add(Of Double)(potencia, NewColumnYCalib(i) / temporario)
            End If

        Next i
        Array.Resize(responsividade, responsividade.Length - 1) 'a funcao add sempre deixa o ultimo lugar vago, tira-se entao
        Array.Resize(yInterpolado, yInterpolado.Length - 1)
        Array.Resize(potencia, potencia.Length - 1)
        'receber nome do usuário.
        Dim nomeUsuario = InputBox("Digite seu nome: ", "Nome do usuário")

        'recebe So O nome do sensor
        Dim nomeSensor As String = GetNameOfArchive(GlobalVariables.OpenFileDialogSensor.FileName)

        'aqui começa criação do arquivo
        Dim sfdPic As New SaveFileDialog()
        sfdPic.OverwritePrompt = True
        Dim sensorReferenciaUsado = New SensorFabricante(ComboBox1.Text)
        Try
            With sfdPic
                .Title = "Salve o arquivo como"
                .Filter = "txt|*.txt"
                .AddExtension = True
                .DefaultExt = ".txt"
                .FileName = nomeSensor & "_ESPECTRODEPOTENCIA_" & Now.ToShortDateString.Replace("/", "") & "_" & Now.ToShortTimeString.Replace(":", "")
                .ValidateNames = True
                .RestoreDirectory = True

                If .ShowDialog = DialogResult.OK Then
                    Dim outFile As IO.StreamWriter
                    Dim qlqr As String
                    Dim cabecalho As String
                    Dim datahoraAtual As DateTime = Now
                    cabecalho = "ARQUIVO DO ESPECTRO DE POTENCIA" & vbCrLf &
                        "Usuário: " & nomeUsuario & vbCrLf &
                        "Data e Hora: " & datahoraAtual.ToShortDateString & " " & datahoraAtual.ToShortTimeString & vbCrLf &
                        "Fonte de radiação: " & ComboBox3.Text & " " & TextBox18.Text & vbCrLf &
                        "Sensor de referência usado: " & sensorReferenciaUsado.Nome & vbCrLf &
                        "Área do sensor de referência (mm²): " & TextBox3.Text & vbCrLf &
                        "Comentário: A razão é entre a curva do sensor do fabricante no setup e a curva do fabricante." & vbCrLf &
                        "Razão" & " Comprimento de onda(nm)"
                    outFile = My.Computer.FileSystem.OpenTextFileWriter(sfdPic.FileName, False)
                    outFile.WriteLine(cabecalho)
                    For k = 0 To NewColumnXCalib.Length - 1
                        qlqr = potencia(k).ToString + " " + NewColumnXCalib(k).ToString
                        outFile.WriteLine(qlqr)
                    Next k
                    outFile.Close()
                Else
                    Return
                End If

            End With

            Dim r As DialogResult
            Dim msg As String = "O arquivo foi salvo corretamente." & vbNewLine
            msg &= "Você quer abrir o arquivo agora?"

            Dim title As String = "Abrir o arquivo."
            Dim btn = MessageBoxButtons.YesNo
            Dim ico = MessageBoxIcon.Information

            r = MessageBox.Show(msg, title, btn, ico)

            If r = System.Windows.Forms.DialogResult.Yes Then
                Dim startInfo As New ProcessStartInfo("notepad.exe")
                startInfo.WindowStyle = ProcessWindowStyle.Maximized
                startInfo.Arguments = sfdPic.FileName
                Process.Start(startInfo)
            Else
                Return
            End If

        Catch ex As Exception
            MessageBox.Show("Erro: Salvar o arquivo falhou ->> " & ex.Message.ToString())
        Finally
            sfdPic.Dispose()
        End Try
        Me.Hide()
    End Sub

    Private Sub TrackBar1_Scroll(sender As Object, e As EventArgs) Handles TrackBar1.Scroll
        TrackBar1.TickStyle = TickStyle.None
        TextBox14.Text = (10 ^ (TrackBar1.Value)).ToString("0.00E+00")
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If (CheckBox1.Checked) Then
            CheckBox2.Checked = False
            Label19.Text = "Ganho do pré-amplificador" & vbCrLf & "de transimpedância Keithley"
            Label19.Left = (Label19.Parent.Width \ 2) - (Label19.Width \ 2)
            TrackBar1.Visible = True
            ComboBox2.Visible = False
            TextBox14.Text = (10 ^ (TrackBar1.Value)).ToString("0.00E+00")
            ButtonCalcular.Text = "Salvar curva de responsividade"
            Button7.Text = "Ver curva de responsividade"
        Else
            CheckBox2.Checked = True
        End If
    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
        If (CheckBox2.Checked) Then
            CheckBox1.Checked = False
            Label19.Text = "Ganho do pré-amplificador " & vbCrLf & "de transimpedância da Stanford"
            Label19.Left = (Label19.Parent.Width \ 2) - (Label19.Width \ 2)
            TrackBar1.Visible = False
            ComboBox2.Visible = True
            If ComboBox2.Text.Length > 5 Then
                TextBox14.Text = ComboBox2.Text.Substring(0, ComboBox2.Text.Length - 4)
            Else
                TextBox14.Text = ""
            End If
            ButtonCalcular.Text = "Salvar curva de EQE"
            Button7.Text = "Ver curva de EQE"
        Else
            CheckBox1.Checked = True
        End If
    End Sub

    Private Sub CheckBox5_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox5.CheckedChanged
        If (CheckBox5.Checked) Then
            CheckBox6.Checked = False
            TextBox16.Text = "1,0"
        End If
    End Sub

    Private Sub CheckBox6_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox6.CheckedChanged
        If (CheckBox6.Checked) Then
            CheckBox5.Checked = False
            TextBox16.Text = "0,1"
            If ComboBox1.Text.Equals("818-BB-22") Then
                TextBox16.Text = "1,0"
                MsgBox(ChrW(215) & " O sensor 818 (Silício antigo) não tem switch, logo sempre vale 1.",, "Atenção !")
                CheckBox6.Checked = False
                CheckBox5.Checked = True
            End If

        End If
    End Sub

    Private Sub Button6_Click_1(sender As Object, e As EventArgs) Handles Button6.Click
        Form9.Visible = True
        Form9.WindowState = FormWindowState.Normal
        Form9.BringToFront()
    End Sub
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Label2.Left = (Label2.Parent.Width \ 2) - (Label2.Width \ 2)
        Label3.Left = (Label3.Parent.Width \ 2) - (Label3.Width \ 2)
        Label9.Left = (Label9.Parent.Width \ 2) - (Label9.Width \ 2)
        Label17.Left = (Label17.Parent.Width \ 2) - (Label17.Width \ 2)
        Label19.Left = (Label19.Parent.Width \ 2) - (Label19.Width \ 2)
        Label22.Left = (Label22.Parent.Width \ 2) - (Label22.Width \ 2)
        Label23.Left = (Label23.Parent.Width \ 2) - (Label23.Width \ 2)
        Label24.Left = (Label24.Parent.Width \ 2) - (Label24.Width \ 2)

        TextBox15.Text = CalculaGamma().ToString("0.00E+00")

    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        GlobalVariables.flagBut = 2
        Dim PathRef As String
        PathRef = ComboBox1.Text
        Dim filePath As String = IO.Path.Combine(Application.StartupPath, "TxtsDasReferencias", PathRef + ".txt") 'aqui está pegando o caminho (interno) do sensor de referencia escolhido dentre as opções

        'Parâmetros para o alfa (coeficiente que corrige os valores por causa das diferentes áreas e distancias)
        Dim alfa As Double = CalculaAlfa()
        Dim beta As Double = CalculaBeta()
        Dim gamma As Double = CalculaGamma()
        If (alfa = 0) Then
            MsgBox(ChrW(215) & " Área ou distância com valor ZERO não existe. Coloque um valor válido e continue.",, "Atenção !")
            Exit Sub 'isso faz com que saia do evento de botão clido, ele suspende todas as ações posteriores
        End If

        Dim textRef As String 'variável para pegar os dados do txt em forma de string
        Dim textCalib As String 'variável para pegar os dados do txt em forma de string
        Dim textAmostra As String 'variável para pegar os dados do txt em forma de string

        Dim indice As Integer
        Dim temporario As Double
        Dim yInterpolado(0) As Double

        Dim potencia(0) As Double
        Dim responsividade(0) As Double

        Dim columnXRef() As Double
        Dim columnYRef() As Double

        Dim columnXCalib() As Double
        Dim columnYCalib() As Double

        Dim columnXAmostra() As Double
        Dim columnYAmostra() As Double

        'curva do sensor de referencia dado pelo fabricante
        textRef = readTxtComplete(filePath) 'filepath é o caminho do arquivo do sensor de referencia dado pelo fabricante
        columnYRef = getColumYOfStringComplete(textRef) 'column y é a primeira coluna do txt
        columnXRef = getColumXOfStringComplete(textRef)  'column x é a segunda coluna do txt
        'curva do sensor de referencia no SETUP
        textCalib = readTxtComplete(GlobalVariables.OpenFileDialogSensor.FileName) 'aqui ele vai pegar o caminho do arquivo 
        columnYCalib = getColumYOfStringComplete(textCalib)
        columnXCalib = getColumXOfStringComplete(textCalib)
        'curva da amostra no SETUP
        textAmostra = readTxtComplete(GlobalVariables.OpenFileDialogAmostra.FileName)
        columnYAmostra = getColumYOfStringComplete(textAmostra)
        columnXAmostra = getColumXOfStringComplete(textAmostra)


        Dim menor As Integer = 0
        If columnXCalib(0) > columnXRef(0) Then 'se o menor valor do Xcalib ta dentro da referencia, entao começa do zero
            menor = 0
        Else
            While columnXCalib(menor) < columnXRef(0)
                menor += 1
            End While 'menor será o menor indice valido do Xcalib
        End If


        Dim maior As Integer = columnXCalib.Length - 1
        If columnXCalib(columnXCalib.Length - 1) < columnXRef(columnXRef.Length - 1) Then
            maior = columnXCalib.Length - 1
        Else
            While columnXCalib(maior) > columnXRef(columnXRef.Length - 1)
                maior -= 1
            End While 'maior é o ultimo indice valido de Xcalib
        End If


        'filtrando os vetores calib e amostra para valores só dentro do range do fabricante
        Dim NewColumnXCalib = columnXCalib.Take(maior + 1).Skip(menor).ToArray()
        Dim NewColumnYCalib = columnYCalib.Take(maior + 1).Skip(menor).ToArray()

        Dim NewColumnXAmostra = columnXAmostra.Take(maior + 1).Skip(menor).ToArray()
        Dim NewColumnYAmostra = columnYAmostra.Take(maior + 1).Skip(menor).ToArray()

        'Em posse de todos os vetores, agora calcularemos a responsividade
        For i = 0 To NewColumnXCalib.Length - 1
            indice = menorque(NewColumnXCalib(i), columnXRef)

            temporario = ((NewColumnXCalib(i)) * (columnYRef(indice + 1) - columnYRef(indice)) + columnYRef(indice) * columnXRef(indice + 1) - columnXRef(indice) * columnYRef(indice + 1)) / (columnXRef(indice + 1) - columnXRef(indice))
            Add(Of Double)(yInterpolado, temporario)

            If temporario.Equals(0) Then
                Add(Of Double)(potencia, 0)
            Else
                Add(Of Double)(potencia, NewColumnYCalib(i) / temporario)
            End If
            If (NewColumnYCalib(i).Equals(0)) Then
                Add(Of Double)(responsividade, 0)
            Else
                If CheckBox1.Checked Then
                    Add(Of Double)(responsividade, (NewColumnYAmostra(i) * temporario * alfa * beta) / NewColumnYCalib(i))
                End If
                If CheckBox2.Checked Then
                    Add(Of Double)(responsividade, (NewColumnYAmostra(i) * temporario * alfa * beta * gamma) / (NewColumnYCalib(i) * NewColumnXCalib(i) * 0.000000001))
                End If
            End If

        Next i
        Array.Resize(responsividade, responsividade.Length - 1) 'a funcao add sempre deixa o ultimo lugar vago, tira-se entao
        Array.Resize(yInterpolado, yInterpolado.Length - 1)
        Array.Resize(potencia, potencia.Length - 1)

        Dim sensorSelected = New SensorFabricante(ComboBox1.Text)

        ' N indica o numero como ele realmente é, o NX indica com X casas decimais
        Dim formatX As String
        Dim formatY As String
        formatX = "eixoX"
        formatY = "N2"

        Dim maximo As Double = Double.NaN
        Dim renameY As String

        If CheckBox2.Checked Then
            renameY = "EQE"
        Else
            renameY = sensorSelected.UnidadeResponsividade
        End If

        If Form7.CheckBox2.Checked Then
            renameY = "Log da " & renameY
            formatY = "E0"
        End If

        Dim nomeAmostra = "amostra"
        Dim sensorReferenciaUsado = New SensorFabricante(ComboBox1.Text)
        If Not String.IsNullOrEmpty(TextBox17.Text) Then
            nomeAmostra = TextBox17.Text
        End If

        Dim cabecalho As String = ""
        Dim tipoDeMedida As String = "_RESPONSIVIDADE_"
        Dim switchTemp As String = ""
        If CheckBox5.Checked Then
            switchTemp = "Posição HI, " & TextBox16.Text
        End If
        If CheckBox6.Checked Then
            switchTemp = "Posição LO, " & TextBox16.Text
        End If
        Dim datahoraAtual As DateTime = Now
        If CheckBox1.Checked Then
            tipoDeMedida = "_RESPONSIVIDADE_"
            cabecalho = "ARQUIVO DE MEDIDA DE RESPONSIVIDADE DA AMOSTRA " & TextBox17.Text & vbCrLf &
             "Data e Hora: " & datahoraAtual.ToShortDateString & " " & datahoraAtual.ToShortTimeString & vbCrLf &
             "Fonte de radiação: " & ComboBox3.Text & " " & TextBox18.Text & vbCrLf &
             "Sensor de referência usado: " & sensorReferenciaUsado.Nome & vbCrLf &
             "Área do sensor de referência (mm²): " & TextBox3.Text & vbCrLf &
             "Distância do sensor de referência (mm): " & TextBox4.Text & vbCrLf &
             "Área da amostra (mm²): " & TextBox5.Text & vbCrLf &
             "Distância da amostra (mm): " & TextBox6.Text & vbCrLf &
             "Janela do sensor: " & TextBox7.Text & vbCrLf &
             "Janela do Criostato: " & TextBox8.Text & vbCrLf &
             "Switch: " & switchTemp & vbCrLf &
             "Alfa: " & TextBoxAlfa.Text & vbCrLf &
             "Ganho Keithley: " & TextBox14.Text & vbCrLf &
             sensorReferenciaUsado.UnidadeResponsividade & " Comprimento de onda(nm)"
        End If
        If CheckBox2.Checked Then
            tipoDeMedida = "_EQE_"
            cabecalho = "ARQUIVO DE MEDIDA DE EQE DA AMOSTRA " & TextBox17.Text & vbCrLf &
             "Data e Hora: " & datahoraAtual.ToShortDateString & " " & datahoraAtual.ToShortTimeString & vbCrLf &
             "Fonte de radiação: " & ComboBox3.Text & " " & TextBox18.Text & vbCrLf &
             "Sensor de referência usado: " & sensorReferenciaUsado.Nome & vbCrLf &
             "Área do sensor de referência (mm²): " & TextBox3.Text & vbCrLf &
             "Distância do sensor de referência (mm): " & TextBox4.Text & vbCrLf &
             "Área da amostra (mm²): " & TextBox5.Text & vbCrLf &
             "Distância da amostra (mm): " & TextBox6.Text & vbCrLf &
             "Janela do sensor: " & TextBox7.Text & vbCrLf &
             "Janela do Criostato: " & TextBox8.Text & vbCrLf &
             "Switch: " & switchTemp & vbCrLf &
             "Alfa: " & TextBoxAlfa.Text & vbCrLf &
             "Ganho Stanford: " & TextBox14.Text & vbCrLf &
             "EQE " & " Comprimento de onda(nm)"
        End If

        Form7.Chart1.Titles.Clear()
        Form7.Chart1.Titles.Add(nomeAmostra) 'specify chart name
        Form7.Chart1.Titles(0).Font = New Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold) 'mexa aqui pra mudar a fonte do titulo
        Form7.Chart1.ChartAreas.Clear()
        Form7.Chart1.Series.Clear()
        Form7.Chart1.Annotations.Clear()
        Form7.Chart1.ChartAreas.Add(nomeAmostra)
        With Form7.Chart1.ChartAreas(nomeAmostra)
            .AxisX.Title = "Comprimento de onda(nm)" 'x label
            .AxisX.MajorGrid.LineColor = Color.SkyBlue
            .AxisY.MajorGrid.LineColor = Color.SkyBlue
            .AxisY.Maximum = maximo
            .AxisY.Title = renameY 'y label
            .AxisY.IsLogarithmic = Form7.CheckBox2.Checked
            .AxisX.LabelStyle.Format = formatX
            .AxisY.LabelStyle.Format = formatY
        End With
        If Form7.CheckBox2.Checked Then
            Form7.Chart1.ChartAreas(nomeAmostra).AxisY.IsStartedFromZero = False
        End If
        Dim textoCompleto As String = cabecalho + vbCrLf
        Form7.Chart1.Series.Clear()
        Form7.Chart1.Series.Add(nomeAmostra)
        Form7.Chart1.Series(nomeAmostra).Color = Color.FromKnownColor(KnownColor.Red)
        Form7.Chart1.Series(nomeAmostra).ChartType = DataVisualization.Charting.SeriesChartType.Line
        If (Form7.CheckBox2.Checked) Then
            responsividade = removeZerosVetorY(NewColumnXAmostra, responsividade)
            NewColumnXAmostra = removeZerosVetorX(NewColumnXAmostra, responsividade)
        End If
        For i = 0 To NewColumnXAmostra.Length - 2 'o ultimo elemento é 0, pois o vetor foi acrescentado e nada foi adiconado ao mesmo
            textoCompleto += responsividade(i).ToString + " " + NewColumnXAmostra(i).ToString + vbCrLf
            Form7.Chart1.Series(nomeAmostra).Points.AddXY(NewColumnXAmostra(i), responsividade(i))
        Next i

        If Form7.CheckBox2.Checked Then
            'deixando o gráfico no tamanho correto
            Form7.Chart1.ChartAreas(0).AxisY.Maximum = Form7.Chart1.Series(0).Points.FindMaxByValue("Y1").YValues(0)
            Form7.Chart1.ChartAreas(0).AxisY.Minimum = Form7.Chart1.Series(0).Points.FindMinByValue("Y1").YValues(0)
        End If

        FormDados.TextBox2.Text = textoCompleto

        Dim verticalLine = New VerticalLineAnnotation()
        verticalLine.AxisX = Form7.Chart1.ChartAreas.First.AxisX
        verticalLine.AllowMoving = True
        verticalLine.IsInfinitive = True
        verticalLine.LineColor = Color.Navy
        verticalLine.LineWidth = 2
        verticalLine.AnchorOffsetX = 50
        verticalLine.ClipToChartArea = Form7.Chart1.ChartAreas.First.Name
        verticalLine.Name = "VA"
        verticalLine.LineDashStyle = 1
        verticalLine.AnchorDataPoint = Form7.Chart1.Series.First.Points(0)
        'verticalLine.X = 1
        Form7.Chart1.Annotations.Add(verticalLine)

        Dim RA = New RectangleAnnotation()
        RA.AxisX = verticalLine.AxisX
        RA.IsSizeAlwaysRelative = False
        RA.Width = MaiorRange() / 12
        RA.Height = 3
        RA.Name = "RA"
        RA.LineColor = Color.Blue
        RA.BackColor = Color.White
        RA.Y = 82.5
        RA.Text = "Hello"
        RA.ForeColor = Color.Navy
        RA.Font = New System.Drawing.Font("Arial", 8.0F)
        Form7.Chart1.Annotations.Add(RA)

        Form7.Visible = True
        Form7.WindowState = FormWindowState.Normal
        Form7.BringToFront()

    End Sub

    Private Sub TextBox16_TextChanged(sender As Object, e As EventArgs) Handles TextBox16.TextChanged, TextBox14.TextChanged
        If Me.Visible Then
            TextBox9.Text = CalculaBeta().ToString("0.00E+00")
        End If
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        GlobalVariables.flagBut = 1
        Dim PathRef As String
        PathRef = ComboBox1.Text
        Dim filePath As String = IO.Path.Combine(Application.StartupPath, "TxtsDasReferencias", PathRef + ".txt") 'aqui está pegando o caminho (interno) do sensor de referencia escolhido dentre as opções

        'Parâmetros para o alfa (coeficiente que corrige os valores por causa das diferentes áreas e distancias)
        Dim alfa As Double = CalculaAlfa()
        Dim beta As Double = CalculaBeta()
        Dim gamma As Double = CalculaGamma()
        If (alfa = 0) Then
            MsgBox(ChrW(215) & " Área ou distância com valor ZERO não existe. Coloque um valor válido e continue.",, "Atenção !")
            Exit Sub 'isso faz com que saia do evento de botão clido, ele suspende todas as ações posteriores
        End If

        Dim textRef As String 'variável para pegar os dados do txt em forma de string
        Dim textCalib As String 'variável para pegar os dados do txt em forma de string
        Dim textAmostra As String 'variável para pegar os dados do txt em forma de string

        Dim indice As Integer
        Dim temporario As Double
        Dim yInterpolado(0) As Double

        Dim potencia(0) As Double
        Dim responsividade(0) As Double

        Dim columnXRef() As Double
        Dim columnYRef() As Double

        Dim columnXCalib() As Double
        Dim columnYCalib() As Double

        Dim columnXAmostra() As Double
        Dim columnYAmostra() As Double

        'curva do sensor de referencia dado pelo fabricante
        textRef = readTxtComplete(filePath) 'filepath é o caminho do arquivo do sensor de referencia dado pelo fabricante
        columnYRef = getColumYOfStringComplete(textRef) 'column y é a primeira coluna do txt
        columnXRef = getColumXOfStringComplete(textRef)  'column x é a segunda coluna do txt
        'curva do sensor de referencia no SETUP
        textCalib = readTxtComplete(GlobalVariables.OpenFileDialogSensor.FileName) 'aqui ele vai pegar o caminho do arquivo 
        columnYCalib = getColumYOfStringComplete(textCalib)
        columnXCalib = getColumXOfStringComplete(textCalib)
        'curva da amostra no SETUP
        textAmostra = readTxtComplete(GlobalVariables.OpenFileDialogAmostra.FileName)
        columnYAmostra = getColumYOfStringComplete(textAmostra)
        columnXAmostra = getColumXOfStringComplete(textAmostra)


        Dim menor As Integer = 0
        If columnXCalib(0) > columnXRef(0) Then 'se o menor valor do Xcalib ta dentro da referencia, entao começa do zero
            menor = 0
        Else
            While columnXCalib(menor) < columnXRef(0)
                menor += 1
            End While 'menor será o menor indice valido do Xcalib
        End If


        Dim maior As Integer = columnXCalib.Length - 1
        If columnXCalib(columnXCalib.Length - 1) < columnXRef(columnXRef.Length - 1) Then
            maior = columnXCalib.Length - 1
        Else
            While columnXCalib(maior) > columnXRef(columnXRef.Length - 1)
                maior -= 1
            End While 'maior é o ultimo indice valido de Xcalib
        End If


        'filtrando os vetores calib e amostra para valores só dentro do range do fabricante
        Dim NewColumnXCalib = columnXCalib.Take(maior + 1).Skip(menor).ToArray()
        Dim NewColumnYCalib = columnYCalib.Take(maior + 1).Skip(menor).ToArray()

        Dim NewColumnXAmostra = columnXAmostra.Take(maior + 1).Skip(menor).ToArray()
        Dim NewColumnYAmostra = columnYAmostra.Take(maior + 1).Skip(menor).ToArray()

        'Em posse de todos os vetores, agora calcularemos a responsividade
        For i = 0 To NewColumnXCalib.Length - 1
            indice = menorque(NewColumnXCalib(i), columnXRef)

            temporario = ((NewColumnXCalib(i)) * (columnYRef(indice + 1) - columnYRef(indice)) + columnYRef(indice) * columnXRef(indice + 1) - columnXRef(indice) * columnYRef(indice + 1)) / (columnXRef(indice + 1) - columnXRef(indice))
            Add(Of Double)(yInterpolado, temporario)

            If temporario.Equals(0) Then
                Add(Of Double)(potencia, 0)
            Else
                Add(Of Double)(potencia, NewColumnYCalib(i) / temporario)
            End If
            If (NewColumnYCalib(i).Equals(0)) Then
                Add(Of Double)(responsividade, 0)
            Else
                If CheckBox1.Checked Then
                    Add(Of Double)(responsividade, (NewColumnYAmostra(i) * temporario * alfa * beta) / NewColumnYCalib(i))
                End If
                If CheckBox2.Checked Then
                    Add(Of Double)(responsividade, (NewColumnYAmostra(i) * temporario * alfa * beta * gamma) / (NewColumnYCalib(i) * NewColumnXCalib(i) * 0.000000001))
                End If
            End If

        Next i
        Array.Resize(responsividade, responsividade.Length - 1) 'a funcao add sempre deixa o ultimo lugar vago, tira-se entao
        Array.Resize(yInterpolado, yInterpolado.Length - 1)
        Array.Resize(potencia, potencia.Length - 1)

        Dim sensorSelected = New SensorFabricante(ComboBox1.Text)

        ' N indica o numero como ele realmente é, o NX indica com X casas decimais
        Dim formatX As String
        Dim formatY As String
        formatX = "eixoX"
        formatY = "E0"

        Dim maximo As Double = Double.NaN
        Dim renameY As String = "Potência"
        If Form7.CheckBox2.Checked Then
            renameY = "Log da Potência"
            formatY = "E0"
            maximo = Double.NaN
        End If

        Dim nomeAmostra As String = "amostra"
        If Not String.IsNullOrEmpty(TextBox17.Text) Then
            nomeAmostra = TextBox17.Text
        End If

        Dim cabecalho As String
        Dim datahoraAtual As DateTime = Now
        cabecalho = "ARQUIVO DO ESPECTRO DE POTENCIA" & vbCrLf &
                        "Data e Hora: " & datahoraAtual.ToShortDateString & " " & datahoraAtual.ToShortTimeString & vbCrLf &
                        "Sensor de referência usado: " & sensorSelected.Nome & vbCrLf &
                        "Área do sensor de referência (mm²): " & TextBox3.Text & vbCrLf &
                        "Comentário: A razão é entre a curva do sensor do fabricante no setup e a curva do fabricante." & vbCrLf &
                        "Razão" & " Comprimento de onda(nm)"
        Dim textoCompleto = cabecalho + vbCrLf
        Form7.Chart1.Titles.Clear()
        Form7.Chart1.Titles.Add(nomeAmostra) 'specify chart name
        Form7.Chart1.Titles(0).Font = New Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold) 'mexa aqui pra mudar a fonte do titulo
        Form7.Chart1.ChartAreas.Clear()
        Form7.Chart1.Series.Clear()
        Form7.Chart1.Annotations.Clear()
        Form7.Chart1.ChartAreas.Add(nomeAmostra)
        With Form7.Chart1.ChartAreas(nomeAmostra)
            .AxisX.Title = "Comprimento de onda(nm)" 'x label
            .AxisX.MajorGrid.LineColor = Color.SkyBlue
            .AxisY.MajorGrid.LineColor = Color.SkyBlue
            .AxisY.Maximum = maximo
            .AxisY.Title = renameY 'y label
            .AxisY.IsLogarithmic = Form7.CheckBox2.Checked
            .AxisX.LabelStyle.Format = formatX
            .AxisY.LabelStyle.Format = formatY
        End With

        Form7.Chart1.Series.Clear()
        Form7.Chart1.Series.Add(nomeAmostra)
        Form7.Chart1.Series(nomeAmostra).Color = Color.FromKnownColor(KnownColor.Red)
        Form7.Chart1.Series(nomeAmostra).ChartType = DataVisualization.Charting.SeriesChartType.Line
        If (Form7.CheckBox2.Checked) Then
            potencia = removeZerosVetorY(NewColumnXAmostra, potencia)
            NewColumnXAmostra = removeZerosVetorX(NewColumnXAmostra, potencia)
        End If
        For i = 0 To NewColumnXAmostra.Length - 2 'o ultimo elemento é 0, pois o vetor foi acrescentado e nada foi adiconado ao mesmo
            textoCompleto += potencia(i).ToString + " " + NewColumnXAmostra(i).ToString + vbCrLf
            Form7.Chart1.Series(nomeAmostra).Points.AddXY(NewColumnXAmostra(i), potencia(i))
        Next i

        If Form7.CheckBox2.Checked Then
            'deixando o gráfico no tamanho correto
            Form7.Chart1.ChartAreas(0).AxisY.Maximum = Form7.Chart1.Series(0).Points.FindMaxByValue("Y1").YValues(0)
            Form7.Chart1.ChartAreas(0).AxisY.Minimum = Form7.Chart1.Series(0).Points.FindMinByValue("Y1").YValues(0)
        End If

        FormDados.TextBox2.Text = textoCompleto

        Dim verticalLine = New VerticalLineAnnotation()
        verticalLine.AxisX = Form7.Chart1.ChartAreas.First.AxisX
        verticalLine.AllowMoving = True
        verticalLine.IsInfinitive = True
        verticalLine.LineColor = Color.Navy
        verticalLine.LineWidth = 2
        verticalLine.AnchorOffsetX = 50
        verticalLine.ClipToChartArea = Form7.Chart1.ChartAreas.First.Name
        verticalLine.Name = "VA"
        verticalLine.LineDashStyle = 1
        verticalLine.AnchorDataPoint = Form7.Chart1.Series.First.Points(0)
        'verticalLine.X = 1
        Form7.Chart1.Annotations.Add(verticalLine)

        Dim RA = New RectangleAnnotation()
        RA.AxisX = verticalLine.AxisX
        RA.IsSizeAlwaysRelative = False
        RA.Width = MaiorRange() / 12
        RA.Height = 3
        RA.Name = "RA"
        RA.LineColor = Color.Blue
        RA.BackColor = Color.White
        RA.Y = 82.5
        RA.Text = "Hello"
        RA.ForeColor = Color.Navy
        RA.Font = New System.Drawing.Font("Arial", 8.0F)
        Form7.Chart1.Annotations.Add(RA)

        Form7.Visible = True
        Form7.WindowState = FormWindowState.Normal
        Form7.BringToFront()
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        TextBox14.Text = ComboBox2.Text.Substring(0, ComboBox2.Text.Length - 4)
    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox3.SelectedIndexChanged
        If ComboBox3.Text.Equals("Outra:") Then
            TextBox18.Visible = True
        Else
            TextBox18.Visible = False
        End If
    End Sub
End Class