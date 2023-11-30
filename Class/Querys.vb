Imports System.Data.SqlClient


Public Class Querys
    Public Shared Sub ExecQuery(Query As String)
        Try

            Dim _instanciaConn As New dao

            _instanciaConn.conectar()

            Dim Str As New SqlCommand(Query, _instanciaConn.SQLCNN)
            Str.ExecuteNonQuery()

            _instanciaConn.desconectar()

        Catch ex As Exception

        End Try
    End Sub

    Public Shared Function ExecutaQuerySimples(Query As String)
        Dim obj As New dao
        Dim retorno As String = ""
        Try
            obj.conectar()
            Dim sql As New SqlCommand(Query, obj.SQLCNN)
            retorno = sql.ExecuteScalar
            If retorno Is Nothing Then
                retorno = ""
            End If
        Catch ex As Exception
            ' MsgBox($"Excesão {ex.Message.ToString}")
        End Try
        obj.desconectar()
        Return retorno
    End Function

    Public Shared Function RetornarAllClients() As List(Of ClientModels)

        Dim lisClientsTemp As New List(Of ClientModels)
            Dim obj As New dao
        Try
            obj.conectar()
            Dim strvermsg As New SqlCommand("SELECT NOME, CPF FROM UNCCLIENTES (NOLOCK)", obj.SQLCNN)
            Dim rsvermsg = strvermsg.ExecuteReader

            While rsvermsg.Read

                Dim clienteView As New ClientModels
                clienteView.Nome = rsvermsg("NOME")
                clienteView.Cpf = rsvermsg("CPF")

                lisClientsTemp.Add(clienteView)
            End While

            Return lisClientsTemp
            'End If
        Catch ex As Exception

        End Try
        obj.desconectar()
    End Function

    Public Shared Function RetornarClientePorId(id As String) As ClientModels


        Dim obj As New dao
        Try
            obj.conectar()
            Dim strvermsg As New SqlCommand($"SELECT CODCLIENTE ,NOME, CPF FROM UNCCLIENTES (NOLOCK) WHERE CODCLIENTE =  {id}", obj.SQLCNN)
            Dim rsvermsg = strvermsg.ExecuteReader
            Dim clienteView As New ClientModels
            If rsvermsg.Read Then

                clienteView.Nome = rsvermsg("NOME")
                clienteView.Cpf = rsvermsg("CPF")

            End If


            Return clienteView
            'End If
        Catch ex As Exception

        End Try
        obj.desconectar()
    End Function
End Class
