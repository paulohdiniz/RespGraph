Module Module1
    Public Function openFile() As String
        Dim openFD As New OpenFileDialog
        Dim strFileName As String
        openFD.Title = "Buscando arquivo..."
        openFD.RestoreDirectory = True
        openFD.Filter = "Text Files|*.txt;*.doc;*.med;*.ref|All files|*.*" 'med e ref sao formatos que saem os arquivos do programa principal
        Dim DidWork As Integer = openFD.ShowDialog()
        strFileName = openFD.FileName

        If DidWork = DialogResult.Cancel Then
            MessageBox.Show("Você cancelou a abertura")
            Return Nothing
        Else
            strFileName = openFD.FileName
            Return strFileName
        End If
    End Function
    Public Sub Add(Of T)(ByRef arr As T(), item As T) 'Coloca o item no ultimo espaço e abre + 1 vaga.
        arr(arr.Length - 1) = item
        Array.Resize(arr, arr.Length + 1)
    End Sub

    Public Function readTxtComplete(ByVal FILE_NAME As String) As String

        If System.IO.File.Exists(FILE_NAME) = True Then
            Dim TextLine As String
            TextLine = ""
            Dim objReader As New System.IO.StreamReader(FILE_NAME)

            Do While objReader.Peek() <> -1

                TextLine = TextLine & objReader.ReadLine() & vbNewLine

            Loop

            Return TextLine
        Else
            MessageBox.Show("O arquivo buscado não existe.")
            Return Nothing
        End If
    End Function
    Public Function clearString(ByVal stringWithColumns As String) As String
        'Essa funcao eliminará os valores que não forem , . e números deixando apenas as duas colunas como stringWithColumns
        Dim firstChar As Integer = Asc(stringWithColumns.Substring(0, 1))
        While firstChar > 57 Or firstChar < 48 'enquanto o primeiro char não for número
            stringWithColumns = stringWithColumns.Substring(1) 'retira o primeiro (13 ou 10) da string
            firstChar = Asc(stringWithColumns.Substring(0, 1)) 'pega o novo primeiro
        End While
        Dim lastChar As Integer = Asc(stringWithColumns.Substring(stringWithColumns.Length - 1))
        While lastChar > 57 Or lastChar < 48 'enquanto não for , . ou números ...
            stringWithColumns = stringWithColumns.Substring(0, stringWithColumns.Length - 1) 'retira o ultimo valor da string
            lastChar = Asc(stringWithColumns.Substring(stringWithColumns.Length - 1)) 'pega o novo ultimo
        End While
        'a partir desse ponto stringwithcolumns nao tem mais caracteres 13 ou 10 ou 32 no fim ou no começo dele, "pegamos" as duas colunas.
        Return stringWithColumns
    End Function
    Public Function getColumXOfStringComplete(ByVal textComplete As String) As Double() 'x é a segunda coluna do textcomplete
        Dim stringSearching As String
        Dim position As Integer
        Dim stringWithColumnsDirty As String
        Dim stringWithColumns As String 'apenas as colunas
        Dim vetorX(0) As Double
        Dim vetor(1) As String
        Dim xDouble As Double
        stringSearching = "onda(nm)"
        position = InStr(textComplete, stringSearching)
        stringWithColumnsDirty = textComplete.Substring(position + 9)

        stringWithColumns = clearString(stringWithColumnsDirty) 'usa a funcao clearstring (retira tudo que nao é numero) do começo e fim da string, DEIXA SO AS COLUNAS

        Dim linhas As String() = stringWithColumns.Split(vbLf) 'contando quantas linha teremos na string anteriormente retirada

        For i = 0 To (linhas.Length - 1)
            linhas(i) = clearString(linhas(i))
            linhas(i) = System.Text.RegularExpressions.Regex.Replace(linhas(i), vbTab, " ") 'troca todo tab por espaços (as vezes pode ter tab entre as colunas)
            linhas(i) = System.Text.RegularExpressions.Regex.Replace(linhas(i), "\s+", " ") 'Esse comando apaga espaços consecutivos entre os valores, um trim mais generico
            If (Not linhas(i).Equals(" ")) Then 'nao deixa dar o split se a linha do txt for um ou mais espaços
                vetor = linhas(i).Split(" ")
                vetor(1) = vetor(1).Replace(".", ",") 'para o vb o separador de decimal é ,
                If Double.TryParse(vetor(1), xDouble) Then 'se a string virar double o if é true
                    Add(Of Double)(vetorX, xDouble)
                End If
            End If
        Next i
        Array.Resize(vetorX, vetorX.Length - 1) 'tirando o ultimo elemento de vetorX pq era nulo
        Return vetorX
    End Function

    Public Function getColumYOfStringComplete(ByVal textComplete As String) As Double() 'y é a primeira coluna do textcomplete
        Dim stringSearching As String
        Dim position As Integer
        Dim stringWithColumnsDirty As String
        Dim stringWithColumns As String
        stringWithColumns = ""
        stringWithColumnsDirty = ""
        Dim vetorY(0) As Double
        Dim vetor(1) As String
        Dim yDouble As Double
        stringSearching = "onda(nm)"
        position = InStr(textComplete, stringSearching)
        If position = 0 Then
            MsgBox("O programa será reiniciado, você selecionou um arquivo inválido ou cancelou a abertura. Clique no botão AJUDA para saber mais",, "Erro Fatal !")
            'Fecha o programa e reabre.
            Application.Exit()
            Process.Start(Application.ExecutablePath)
        Else
            stringWithColumnsDirty = textComplete.Substring(position + 9)
        End If

        stringWithColumns = clearString(stringWithColumnsDirty) 'usa a funcao clearstring (retira todos char 10 e 13) do começo e fim da string, DEIXA SO AS COLUNAS

        Dim linhas As String() = stringWithColumns.Split(vbLf)

        For i = 0 To (linhas.Length - 1)
            linhas(i) = clearString(linhas(i))
            linhas(i) = System.Text.RegularExpressions.Regex.Replace(linhas(i), vbTab, " ") 'troca todo tab por espaços (as vezes pode ter tab entre as colunas)
            linhas(i) = System.Text.RegularExpressions.Regex.Replace(linhas(i), "\s+", " ") 'Esse comando apaga espaços consecutivos entre os valores, um trim mais generico
            If (Not linhas(i).Equals(" ")) Then 'nao deixa dar o split se a linha do txt for um ou mais espaços
                vetor = linhas(i).Split(" ")
                vetor(0) = vetor(0).Replace(".", ",") 'para o vb o separador de decimal é ,
                If Double.TryParse(vetor(0), yDouble) Then
                    Add(Of Double)(vetorY, yDouble)
                End If
            End If
        Next i
        Array.Resize(vetorY, vetorY.Length - 1) 'tirando o ultimo elemento de vetorY pq era nulo
        Return vetorY
    End Function

    Public Function menorque(ByVal valor As Double, Arr() As Double) As Integer
        Dim i As Integer = 0
        While (Arr(i) < valor) 'entra no minimo uma vez, pois o menor valor de referencia esta obrigatoriamente abrangendo todo NewCalib
            i += 1
        End While
        Return i - 1
    End Function

    Public Function RemoveWhitespace(fullString As String) As String
        Return New String(fullString.Where(Function(x) Not Char.IsWhiteSpace(x)).ToArray())
    End Function

    Public Function NormalizaVetor(ByVal vetor() As Double) As Double()
        Dim maiorValor As Double = 0.0
        For i = 0 To vetor.Length - 1
            If (vetor(i) > maiorValor) Then
                maiorValor = vetor(i)
            End If
        Next
        For i = 0 To vetor.Length - 1
            vetor(i) = vetor(i) / maiorValor
        Next
        Return vetor
    End Function

    Public Function CalculaAlfa() As Double

        Dim areaSensorDeReferencia As Double
        Dim distanciaSensorDeReferencia As Double
        Dim areaAmostra As Double
        Dim distanciaAmostra As Double
        Dim transmissaoSensor As Double
        Dim transmissaoCriostato As Double

        Dim sucesso As Boolean

        'variavel booleana que verifica se os valores dos parametros de correção foram inseridos corretamente
        sucesso = Double.TryParse(Form2.TextBox3.Text.Replace(".", ","), areaSensorDeReferencia) And
            Double.TryParse(Form2.TextBox4.Text.Replace(".", ","), distanciaSensorDeReferencia) And
            Double.TryParse(Form2.TextBox5.Text.Replace(".", ","), areaAmostra) And
            Double.TryParse(Form2.TextBox6.Text.Replace(".", ","), distanciaAmostra) And
            Double.TryParse(Form2.TextBox7.Text.Replace(".", ","), transmissaoSensor) And
            Double.TryParse(Form2.TextBox8.Text.Replace(".", ","), transmissaoCriostato)

        Dim alfa As Double
        If (sucesso) Then
            alfa = (areaSensorDeReferencia / areaAmostra) * (distanciaAmostra ^ 2 / distanciaSensorDeReferencia ^ 2) * (transmissaoSensor / transmissaoCriostato)
        Else
            alfa = 0
        End If
        Return alfa
    End Function

    Public Function GetNameOfArchive(ByVal pathArquivo As String) As String
        Dim nomeAmostra As String
        nomeAmostra = pathArquivo.Substring(pathArquivo.LastIndexOf("\") + 1, pathArquivo.Length - pathArquivo.LastIndexOf("\") - 5)
        Return nomeAmostra
    End Function

    Public Class SensorFabricante
        Public Property Nome As String
        Public Property Material As String
        Public Property Area As String
        Public Property RespMax As String
        Public Property FaixaEspectral As String
        Public Property UnidadeResponsividade As String
        Public Property PathSensor As String

        Public Sub New(ByVal nameSensor As String)
            Select Case nameSensor
                Case "S-010-H"
                    Me.Nome = "S-010-H"
                    Me.Material = "Silício"
                    Me.Area = "0,7853981634 mm²"
                    Me.RespMax = "500.000.000 V/W @ 889nm"
                    Me.FaixaEspectral = "300 - 1000nm"
                    Me.UnidadeResponsividade = "Responsividade ( A / W )"
                    Me.PathSensor = IO.Path.Combine(Application.StartupPath, "TxtsDasReferencias", "S-010-H" + ".txt")
                Case "IGA-010-E-LN6N"
                    Me.Nome = "IGA-010-E-LN6N"
                    Me.Material = "InGaAs"
                    Me.Area = "0,7853981634 mm²"
                    Me.RespMax = "0,9407 A/W @ 1481 nm"
                    Me.FaixaEspectral = "900 - 1550nm"
                    Me.UnidadeResponsividade = "Responsividade (A / W)"
                    Me.PathSensor = IO.Path.Combine(Application.StartupPath, "TxtsDasReferencias", "IGA-010-E-LN6N" + ".txt")
                Case "IS-010-E-LN6N"
                    Me.Nome = "IS-010-E-LN6N"
                    Me.Material = "InSb"
                    Me.Area = "0,7853981634 mm²"
                    Me.RespMax = "430.000 V/W @ 5,3um"
                    Me.FaixaEspectral = "1,0 - 5,5 um"
                    Me.UnidadeResponsividade = "Responsividade (V / W)"
                    Me.PathSensor = IO.Path.Combine(Application.StartupPath, "TxtsDasReferencias", "IS-010-E-LN6N" + ".txt")
                Case "MCT14-010-E-LN6N"
                    Me.Nome = "MCT14-010-E-LN6N"
                    Me.Material = "HgCdTe"
                    Me.Area = "1,0000 mm²"
                    Me.RespMax = "500.000 @ 13,5um"
                    Me.FaixaEspectral = "2 - 15 um"
                    Me.UnidadeResponsividade = "Responsividade (V / W)"
                    Me.PathSensor = IO.Path.Combine(Application.StartupPath, "TxtsDasReferencias", "MCT14-010-E-LN6N" + ".txt")
                Case "MCT20-010-E-LN6N"
                    Me.Nome = "MCT20-010-E-LN6N"
                    Me.Material = "HgCdTe"
                    Me.Area = "1,0000 mm²"
                    Me.RespMax = "780.000 V/W @ 18 um"
                    Me.FaixaEspectral = "2 - 20 um  "
                    Me.UnidadeResponsividade = "Responsividade (V / W)"
                    Me.PathSensor = IO.Path.Combine(Application.StartupPath, "TxtsDasReferencias", "MCT20-010-E-LN6N" + ".txt")
                Case "818-BB-22"
                    Me.Nome = "818-BB-22"
                    Me.Material = "Silício"
                    Me.Area = "5,1070515574919 mm²"
                    Me.RespMax = "0,6321 A/W @ 890nm"
                    Me.FaixaEspectral = "200 - 1100 nm"
                    Me.UnidadeResponsividade = "Responsividade (A / W)"
                    Me.PathSensor = IO.Path.Combine(Application.StartupPath, "TxtsDasReferencias", "818-BB-22" + ".txt")
            End Select

        End Sub
        Public Function Normalized() As SensorFabricante
            Me.PathSensor = Me.PathSensor.Substring(0, Me.PathSensor.Length - 4) + "_norm.txt"
            Me.Nome = Me.Nome + " (normalizado)"
            Return Me
        End Function
        Public Function isNormalized() As Boolean
            Return Me.PathSensor.Substring(Me.PathSensor.Length - 8, 8).Equals("norm.txt")
        End Function
    End Class
End Module
