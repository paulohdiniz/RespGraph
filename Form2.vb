Public Class Form2
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim path As String
        path = openFile()
        TextBox1.Text = path
    End Sub
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim path As String
        path = openFile()
        TextBox2.Text = path
    End Sub
    Private Sub ButtonOut_Click(sender As Object, e As EventArgs) Handles ButtonOut.Click
        Dim path As String
        path = openFile()
        TextBox7.Text = path
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim PathRef As String
        PathRef = ComboBox1.Text
        Dim filePath As String = IO.Path.Combine(Application.StartupPath, "TxtsDasReferencias", PathRef + ".txt") 'aqui está pegando o caminho (interno) do sensor de referencia escolhido dentre as opções

        'Parâmetros para o alfa (coeficiente que corrige os valores por causa das diferentes áreas e distancias)
        Dim areaSensorDeReferencia As Double
        Dim distanciaSensorDeReferencia As Double
        Dim areaAmostra As Double
        Dim distanciaAmostra As Double
        Dim sucess As Boolean

        'variavel booleana que verifica se os valores dos parametros de correção foram inseridos corretamente
        sucess = Double.TryParse(TextBox3.Text, areaSensorDeReferencia) And Double.TryParse(TextBox4.Text, distanciaSensorDeReferencia) And Double.TryParse(TextBox5.Text, areaAmostra) And Double.TryParse(TextBox6.Text, distanciaAmostra)

        Dim alfa As Double
        If (sucess) Then
            alfa = (areaSensorDeReferencia / areaAmostra) * (distanciaAmostra ^ 2 / distanciaSensorDeReferencia ^ 2)
        Else
            alfa = 1
        End If
        Dim text As String 'variável para pegar os dados do txt em forma de string
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


        text = readTxtComplete(filePath)
        columnYRef = getColumYOfStringComplete(text) 'column y é a primeira coluna do txt
        columnXRef = getColumXOfStringComplete(text)  'column x é a segunda coluna do txt

        text = readTxtComplete(TextBox1.Text)
        columnYCalib = getColumYOfStringComplete(text)
        columnXCalib = getColumXOfStringComplete(text)

        text = readTxtComplete(TextBox2.Text)
        columnYAmostra = getColumYOfStringComplete(text)
        columnXAmostra = getColumXOfStringComplete(text)

        For i = LBound(columnXCalib) + 1 To UBound(columnXCalib)
            indice = menorque(columnXCalib(i), columnXRef)

            If (indice = -1) Then
                temporario = columnXRef(columnXRef.Length - 1)
                Add(Of Double)(yInterpolado, temporario)

            Else
                temporario = ((columnXCalib(i)) * (columnYRef(indice + 1) - columnYRef(indice)) + columnYRef(indice) * columnXRef(indice + 1) - columnXRef(indice) * columnYRef(indice + 1)) / (columnXRef(indice + 1) - columnXRef(indice))
                Add(Of Double)(yInterpolado, temporario)
            End If
            Add(Of Double)(potencia, columnYCalib(i) / temporario)
            Add(Of Double)(responsividade, (columnYAmostra(i) * temporario * alfa) / columnYCalib(i))

        Next i
        Console.WriteLine(columnXRef.Length)
        Console.WriteLine(columnYRef.Length)
        Console.WriteLine(columnXCalib.Length)
        Console.WriteLine(columnYCalib.Length)
        Console.WriteLine(columnXAmostra.Length)
        Console.WriteLine(columnYAmostra.Length)
        Console.WriteLine("Potencia (length):")
        Console.WriteLine(potencia.Length)
        Console.WriteLine("Responsividade (length):")
        Console.WriteLine(responsividade.Length)
        Console.WriteLine("Range responsividade (length):")

        Console.WriteLine(LBound(responsividade))
        Console.WriteLine(UBound(responsividade))
        For i = 0 To 89
            Console.WriteLine(responsividade(i))
        Next i

        Dim outFile As IO.StreamWriter
        Dim qlqr As String
        Dim cabecalho As String
        Dim datahoraAtual As DateTime = Now
        cabecalho = "ARQUIVO DE MEDIDA DE RESPONSIVIDADE" & vbCrLf & "Usuário: " & TextBox8.Text & vbCrLf & "Amostra: " & TextBox9.Text & vbCrLf & "Data e Hora: " & datahoraAtual.ToShortDateString & " " & datahoraAtual.ToShortTimeString & vbCrLf & "Magnitude (mV)	Comprimento de onda(nm)"
        outFile = My.Computer.FileSystem.OpenTextFileWriter(TextBox7.Text, True)
        outFile.WriteLine(cabecalho)
        For i = LBound(responsividade) + 1 To responsividade.Length - 1
            qlqr = responsividade(i).ToString + " " + columnXAmostra(i).ToString
            outFile.WriteLine(qlqr)
            ' Console.WriteLine("pula")
            ' Console.WriteLine(qlqr)
            ' outFile.WriteLine(columnXAmostra(i))

        Next i
        outFile.Close()
        Me.Hide()
    End Sub


End Class