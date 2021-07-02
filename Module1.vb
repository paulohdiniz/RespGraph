Module Module1
    Public Function openFile() As String
        Dim openFD As New OpenFileDialog
        Dim strFileName As String
        openFD.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
        openFD.Title = "Buscando arquivo..."
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
            MessageBox.Show("File Does Not Exist")
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
            MsgBox("O programa será reiniciado, você selecionou um arquivo inválido ou cancelou a abertura. Clique no botão AJUDA para saber mais")
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
End Module
