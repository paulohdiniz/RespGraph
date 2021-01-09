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
    Public Sub Add(Of T)(ByRef arr As T(), item As T) 'Adiciona um elemento num array no seu final. Pega o array, aumenta seu tamanho em 1 e coloca o elemento item nesse posto.
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

    Public Function getColumXOfStringComplete(ByVal textComplete As String) As Double() 'x é a segunda coluna do textcomplete
        Dim stringSearching As String
        Dim position As Integer
        Dim stringWithColumns As String
        Dim vetorX(0) As Double
        MsgBox(vetorX.Length)
        Dim vetor(1) As String
        Dim xDouble As Double
        stringSearching = "onda(nm)"
        MsgBox(textComplete.Length)
        position = InStr(textComplete, stringSearching)
        stringWithColumns = textComplete.Substring(position + 9)
        Dim linhas As String() = stringWithColumns.Split(vbLf)
        For i = 0 To (linhas.Length - 2) 'o ultimo elemento de linhas não é linha válida

            If (Not linhas(i).Equals("") And Not linhas(i).Equals(vbLf) And Not linhas(i).Equals(vbCrLf)) Then

                linhas(i) = System.Text.RegularExpressions.Regex.Replace(linhas(i), "\s+", " ") 'Esse comando apaga espaços consecutivos entre os valores, um trim mais generico
                If (Not linhas(i).Equals(" ")) Then 'nao deixa dar o split se a linha do txt for um ou mais espaços
                    vetor = linhas(i).Split(" ")
                    vetor(1) = vetor(1).Replace(".", ",") 'para o vb o separador de decimal é ,
                    If Double.TryParse(vetor(1), xDouble) Then 'se a string virar double o if é true

                        Add(Of Double)(vetorX, xDouble)
                    End If
                End If

            End If
        Next i
        Return vetorX
    End Function

    Public Function getColumYOfStringComplete(ByVal textComplete As String) As Double() 'y é a primeira coluna do textcomplete
        Dim stringSearching As String
        Dim position As Integer
        Dim stringWithColumns As String
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
            stringWithColumns = textComplete.Substring(position + 9)
        End If
        Dim linhas As String() = stringWithColumns.Split(vbLf)

        For i = 0 To (linhas.Length - 1)

            If (Not linhas(i).Equals("") And Not linhas(i).Equals(vbLf) And Not linhas(i).Equals(vbCrLf)) Then

                linhas(i) = System.Text.RegularExpressions.Regex.Replace(linhas(i), "\s+", " ") 'Esse comando apaga espaços consecutivos entre os valores, um trim mais generico
                If (Not linhas(i).Equals(" ") And Not linhas(i).Equals("")) Then 'nao deixa dar o split se a linha do txt for um ou mais espaços
                    vetor = linhas(i).Split(" ")
                    vetor(0) = vetor(0).Replace(".", ",") 'para o vb o separador de decimal é ,
                    If Double.TryParse(vetor(0), yDouble) Then
                        Add(Of Double)(vetorY, yDouble)
                    End If
                End If

            End If
        Next i
        Return vetorY
    End Function

    Public Function menorque(ByVal valor As Double, Arr() As Double) As Integer
        Dim i As Integer = 0
        While (Arr(i) < valor)
            i += 1
        End While
        Return i - 1
    End Function
End Module
