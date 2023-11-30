Public Class Regras
    ''' <summary>
    ''' Recebe um model cliente como parametro, realiza as validações e o insere no banco
    ''' </summary>
    ''' <param name="cliente"></param>
    Public Shared Sub VerificaInfoCliente(cliente As ClientModels)
        Try
            'Regras para validar inserção no banco
            Querys.ExecQuery($"INSERT INTO [dbo].[UNCCLIENTES] ([NOME] , [CNPJ], [TELEFONE], [EMAIL]) VALUES ('{cliente.Nome}','{cliente.Cnpj}', '{cliente.Telefone}','{cliente.Email}')")
        Catch ex As Exception

        End Try
    End Sub

End Class
