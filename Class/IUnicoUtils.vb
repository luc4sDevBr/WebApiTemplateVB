Public Class IUnicoUtils
    ''' <summary>
    ''' Recebe como paramentro um texto inteiro, e duas strings de referencia e retorna o texto que estiver entre elas
    ''' </summary>
    ''' <param name="TextoCompleto"></param>
    ''' <param name="TextoIni"></param>
    ''' <param name="TextoFim"></param>
    ''' <returns></returns>
    Public Shared Function LocalizaTexto(TextoCompleto As String, TextoIni As String, TextoFim As String)
        Dim Retorno = ""
        Try

            Dim NumeroLetras = TextoIni.Length
            Dim QuebraTexto = String.Empty
            Dim InicioTextoProcurado As Int32 = TextoCompleto.IndexOf(TextoIni) + NumeroLetras
            If InicioTextoProcurado > 0 Then
                QuebraTexto = TextoCompleto.Substring(InicioTextoProcurado)
                Dim iFim As Int32 = QuebraTexto.IndexOf(TextoFim)
                If iFim > 0 Then
                    Retorno = QuebraTexto.Substring(0, iFim).ToString()
                End If
            End If

        Catch ex As Exception

        End Try
        Return Retorno
    End Function

End Class
