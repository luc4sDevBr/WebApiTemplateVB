Imports System.Net
Imports System.Net.Http
Imports System.Web.Http
Imports System.Web.Script.Serialization
Imports Microsoft.Ajax.Utilities
Imports Newtonsoft.Json
Imports Unico.MaisCapitalApi.Variaveis

Public Class ClientController
    Inherits ApiController

    ' GET api/Client
    Public Function GetValues() As HttpResponseMessage
        Dim serialize As New JavaScriptSerializer
        Dim lista = serialize.Serialize(Querys.RetornarAllClients())

        Dim res = Request.CreateResponse(HttpStatusCode.OK)
        res.Content = New StringContent(lista, System.Text.Encoding.UTF8, "application/json")
        Return res

    End Function

    ' GET api/Client/5
    Public Function GetValue(ByVal id As Integer) As HttpResponseMessage
        Dim serialize As New JavaScriptSerializer
        Dim client = serialize.Serialize(Querys.RetornarClientePorId(id))

        Dim res = Request.CreateResponse(HttpStatusCode.OK)
        res.Content = New StringContent(client, System.Text.Encoding.UTF8, "application/json")
        Return res
    End Function

    ' POST api/Client
    'Public Sub PostValue(<FromBody()> ByVal value As String)

    'End Sub


    Public Function Post(<FromBody> ByVal q) As HttpResponseMessage
        Try
            Dim Objclient As RootCliente = JsonConvert.DeserializeObject(Of RootCliente)(q)

            Objclient.cliente.CodCliente = Regras.InsereCliente(Objclient)
            Dim StatusCadastroResponse = Regras.VerificaStatusCadastro(Objclient.cliente.CodCliente)

            Dim retornoPost As New PostRetornoModel
            retornoPost.objCliente = Objclient.cliente
            retornoPost.StatusCadastro = StatusCadastroResponse


            Dim serialize As New JavaScriptSerializer
            Dim clientresponse = serialize.Serialize(retornoPost)
            Dim res = Request.CreateResponse(HttpStatusCode.OK)
            res.Content = New StringContent($"{clientresponse}", System.Text.Encoding.UTF8, "application/json")
            Return res

        Catch ex As Exception
            Dim res = Request.CreateResponse(HttpStatusCode.BadRequest)
            Dim strError As String = $"""erro"":""Parâmetros nulo e/ou inválidos => {ex.Message}"""
            res.Content = New StringContent(strError, System.Text.Encoding.UTF8, "application/json")
            Return res
        End Try
    End Function

    ' PUT api/Client/5
    Public Sub PutValue(ByVal id As Integer, <FromBody()> ByVal value As String)

    End Sub

    ' DELETE api/Client/5
    Public Function DeleteValue(ByVal id As Integer) As HttpResponseMessage
        Try
            Querys.ExecQuery($"DELETE FROM [dbo].[UNCCLIENTES] WHERE CODCLIENTE = {id}")


            Dim res = Request.CreateResponse(HttpStatusCode.OK)
            res.Content = New StringContent("Deletado com sucesso!", System.Text.Encoding.UTF8, "application/json")
            Return res

        Catch ex As Exception

        End Try
    End Function
End Class
