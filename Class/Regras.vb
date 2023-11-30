Imports Unico.MaisCapitalApi.ClientController
Imports Unico.MaisCapitalApi.Variaveis
Public Class Regras
    ''' <summary>
    ''' Recebe um model cliente como parametro, realiza as validações e o insere no banco
    ''' </summary>
    ''' <param name="cliente"></param>
    Public Shared Function InsereCliente(cliente As RootCliente) As Integer
        Try
            'Regras para validar inserção no banco
            Dim codCliente = Querys.ExecutaQuerySimples($"INSERT INTO [dbo].[UNCCLIENTES] ([NOME] , [CNPJ], [TELEFONE], [EMAIL], [CODSTATUSCLIENTE]) VALUES ('{cliente.cliente.Nome}','{cliente.cliente.Cnpj}', '{cliente.cliente.Telefone}','{cliente.cliente.Email}','{cliente.cliente.CodstatusCliente}') SELECT @@IDENTITY AS 'CODCLIENTE'")
            Return codCliente

        Catch ex As Exception

        End Try
    End Function
    Public Shared Function VerificaStatusCadastro(codclient As Integer) As String
        Try
            Dim retorno As String
            'No banco criar uma Coluna bela status cadastro
            'Verificar cliente qual status cadastro dele
            'Retornar o tipo de status do cadastro

            Dim sb As New StringBuilder()
            sb.Append(" SELECT  ")
            sb.Append("   CA.STATUSCADASTRO  ")
            sb.Append(" FROM  ")
            sb.Append("   UNCCLIENTES CL (NOLOCK)  ")
            sb.Append("   INNER JOIN UNCSTATUSCADASTRO CA ON CA.CODSTATUSCADASTRO = CL.CODSTATUSCLIENTE  ")
            sb.Append(" WHERE  ")
            sb.Append($"   CODCLIENTE = {codclient} ")

            Dim query = sb.ToString
            retorno = Querys.ExecutaQuerySimples(query)

            Return retorno
        Catch ex As Exception

        End Try
    End Function

End Class
