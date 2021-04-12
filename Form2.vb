Public Class Form2
    Private Sub ButtonCalibracao_Click(sender As Object, e As EventArgs) Handles ButtonCalibracao.Click
        GlobalVariables.OpenFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
        GlobalVariables.OpenFileDialog1.Title = "Buscando arquivo..."
        GlobalVariables.OpenFileDialog1.Filter = "Text Files|*.txt;*.doc;*.med;*.ref|All files|*.*" 'med e ref sao formatos que saem os arquivos do programa principal
        Dim DidWork As Integer = GlobalVariables.OpenFileDialog1.ShowDialog()
        If DidWork = DialogResult.Cancel Then
            MessageBox.Show("Você cancelou a abertura")
            TextBox1.Text = "Fail !"
            TextBox1.BackColor = Color.Red
            Exit Sub 'isso faz com que saia do evento de botão clido, ele suspende todas as ações posteriores

        Else
            TextBox1.Text = "Inserido !"
            TextBox1.BackColor = Color.SpringGreen

        End If

    End Sub
    Private Sub ButtonAmostra_Click(sender As Object, e As EventArgs) Handles ButtonAmostra.Click
        GlobalVariables.OpenFileDialog2.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
        GlobalVariables.OpenFileDialog2.Title = "Buscando arquivo..."
        GlobalVariables.OpenFileDialog2.Filter = "Text Files|*.txt;*.doc;*.med;*.ref|All files|*.*" 'med e ref sao formatos que saem os arquivos do programa principal
        Dim DidWork As Integer = GlobalVariables.OpenFileDialog2.ShowDialog()
        If DidWork = DialogResult.Cancel Then
            MessageBox.Show("Você cancelou a abertura")
            TextBox2.Text = "Fail !"
            TextBox2.BackColor = Color.Red
            Exit Sub 'isso faz com que saia do evento de botão clido, ele suspende todas as ações posteriores
        Else
            TextBox2.Text = "Inserido !"
            TextBox2.BackColor = Color.SpringGreen
        End If

    End Sub
    Private Sub ButtonSaida_Click(sender As Object, e As EventArgs) Handles ButtonSaida.Click
        Dim pathFolder As String
        Dim datahoraAtual As DateTime = Now
        If String.IsNullOrEmpty(TextBox9.Text) Then
            GlobalVariables.nameNewArchive = "File" & "-" & Now.Hour & "-" & Now.Minute & "-" & Now.Second & "-" & Now.Day & "-" & Now.Month & "-" & Now.Year
        Else
            GlobalVariables.nameNewArchive = TextBox9.Text
        End If

        FolderBrowserDialog1.ShowDialog()

        If String.IsNullOrEmpty(FolderBrowserDialog1.SelectedPath) Then
            MsgBox("Você cancelou a abertura")
            TextBox7.Text = "Fail !"
            TextBox7.BackColor = Color.Red
            Exit Sub 'isso faz com que saia do evento de botão clido, ele suspende todas as ações posteriores
        Else
            pathFolder = FolderBrowserDialog1.SelectedPath
            TextBox7.Text = "Selecionado !"
            TextBox7.BackColor = Color.SpringGreen

        End If
        GlobalVariables.pathNewArchive = pathFolder & "\" & GlobalVariables.nameNewArchive & ".txt"
        If System.IO.File.Exists(GlobalVariables.pathNewArchive) = True Then
            MsgBox("Já existe um arquivo com esse nome, para não sobescrever o mesmo (e perder o arquivo antigo) escolha outro nome.")
            Exit Sub
        Else
            'Chart1.SaveImage(pathNewArchive, System.Drawing.Imaging.ImageFormat.Png) 'aqui vamos deixar o arquivo criado
            MsgBox("O arquivo txt " & GlobalVariables.nameNewArchive & " será criado. Clique em Calcular !")
        End If

    End Sub

    Public Class GlobalVariables
        Public Shared OpenFileDialog1 As New OpenFileDialog
        Public Shared OpenFileDialog2 As New OpenFileDialog
        Public Shared FolderBrowserDialog1 As New FolderBrowserDialog
        Public Shared pathNewArchive As String
        Public Shared nameNewArchive As String

    End Class

    Private Sub ButtonCalcular_Click(sender As Object, e As EventArgs) Handles ButtonCalcular.Click
        Dim PathRef As String
        PathRef = ComboBox1.Text
        Dim filePath As String = IO.Path.Combine(Application.StartupPath, "TxtsDasReferencias", PathRef + ".txt") 'aqui está pegando o caminho (interno) do sensor de referencia escolhido dentre as opções

        'Parâmetros para o alfa (coeficiente que corrige os valores por causa das diferentes áreas e distancias)
        Dim areaSensorDeReferencia As Double
        Dim distanciaSensorDeReferencia As Double
        Dim areaAmostra As Double
        Dim distanciaAmostra As Double
        Dim sucesso As Boolean

        'variavel booleana que verifica se os valores dos parametros de correção foram inseridos corretamente
        sucesso = Double.TryParse(TextBox3.Text, areaSensorDeReferencia) And Double.TryParse(TextBox4.Text, distanciaSensorDeReferencia) And Double.TryParse(TextBox5.Text, areaAmostra) And Double.TryParse(TextBox6.Text, distanciaAmostra)
        'Caso qualquer um dos parâmetros inseridos for zero, dará mensagem de erro
        If (areaSensorDeReferencia = 0 Or distanciaSensorDeReferencia = 0 Or areaAmostra = 0 Or distanciaAmostra = 0) Then
            MsgBox("Parâmetro com valor ZERO não existe. Coloque um valor válido e continue.")
            Exit Sub 'isso faz com que saia do evento de botão clido, ele suspende todas as ações posteriores
        End If
        Dim alfa As Double
        If (sucesso) Then
            alfa = (areaSensorDeReferencia / areaAmostra) * (distanciaAmostra ^ 2 / distanciaSensorDeReferencia ^ 2)
        Else
            alfa = 1 'se faltar algum parametro para o cálculo, deixa o alfa = 1 para poder rodar o programa nesse caso específico.
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
        textCalib = readTxtComplete(GlobalVariables.OpenFileDialog1.FileName) 'aqui ele vai pegar o caminho do arquivo 
        columnYCalib = getColumYOfStringComplete(textCalib)
        columnXCalib = getColumXOfStringComplete(textCalib)
        'curva da amostra no SETUP
        textAmostra = readTxtComplete(GlobalVariables.OpenFileDialog2.FileName)
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


        Dim maior As Integer = 0
        If columnXCalib(columnXCalib.Length - 1) < columnXRef(columnXRef.Length - 1) Then
            maior = columnXCalib.Length
        Else
            While columnXCalib(maior) < columnXRef(columnXRef.Length - 1)
                maior += 1
            End While 'maior -1 é o ultimo indice valido de Xcalib
        End If



        'filtrando os vetores calib e amostra para valores só dentro do range do fabricante
        Dim NewColumnXCalib = columnXCalib.Skip(menor).Take(maior - menor).ToArray()
        Dim NewColumnYCalib = columnYCalib.Skip(menor).Take(maior - menor).ToArray()

        Dim NewColumnXAmostra = columnXAmostra.Skip(menor).Take(maior - menor).ToArray()
        Dim NewColumnYAmostra = columnYAmostra.Skip(menor).Take(maior - menor).ToArray()

        'Em posse de todos os vetores, agora calcularemos a responsividade
        For i = 0 To NewColumnXCalib.Length - 1
            indice = menorque(NewColumnXCalib(i), columnXRef)

            temporario = ((NewColumnXCalib(i)) * (columnYRef(indice + 1) - columnYRef(indice)) + columnYRef(indice) * columnXRef(indice + 1) - columnXRef(indice) * columnYRef(indice + 1)) / (columnXRef(indice + 1) - columnXRef(indice))
            Add(Of Double)(yInterpolado, temporario)

            Add(Of Double)(potencia, NewColumnYCalib(i) / temporario)
            Add(Of Double)(responsividade, (NewColumnYAmostra(i) * temporario * alfa) / NewColumnYCalib(i))

        Next i
        Array.Resize(responsividade, responsividade.Length - 1) 'a funcao add sempre deixa o ultimo lugar vago, tira-se entao

        Dim outFile As IO.StreamWriter
        Dim qlqr As String
        Dim cabecalho As String
        Dim datahoraAtual As DateTime = Now
        cabecalho = "ARQUIVO DE MEDIDA DE RESPONSIVIDADE" & vbCrLf & "Usuário: " & TextBox8.Text & vbCrLf & "Amostra: " & TextBox9.Text & vbCrLf & "Data e Hora: " & datahoraAtual.ToShortDateString & " " & datahoraAtual.ToShortTimeString & vbCrLf & "Magnitude (mV)	Comprimento de onda(nm)"
        outFile = My.Computer.FileSystem.OpenTextFileWriter(GlobalVariables.pathNewArchive, True)
        outFile.WriteLine(cabecalho)
        For k = 0 To responsividade.Length - 1
            qlqr = responsividade(k).ToString + " " + NewColumnXAmostra(k).ToString
            outFile.WriteLine(qlqr)
        Next k
        outFile.Close()
        Me.Hide()
    End Sub
End Class