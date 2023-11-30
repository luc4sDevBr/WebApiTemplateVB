Imports System.Net
Imports System.Net.Http
Imports System.Web.Http
Imports System.Web.Script.Serialization
Imports Microsoft.Ajax.Utilities
Imports Newtonsoft.Json

Public Class ClientController
    Inherits ApiController

    ' GET api/values
    Public Function GetValues()
        Dim serialize As New JavaScriptSerializer
        Dim lista = serialize.Serialize(Querys.RetornarAllClients())


        Return lista

    End Function

    ' GET api/values/5
    Public Function GetValue(ByVal id As Integer)
        Dim serialize As New JavaScriptSerializer
        Dim client = serialize.Serialize(Querys.RetornarClientePorId(id))

        Return client
    End Function

    ' POST api/values
    'Public Sub PostValue(<FromBody()> ByVal value As String)

    'End Sub
    Public Function Post(<FromBody> ByVal q As String) As HttpResponseMessage
        Try

            Dim strRsp As String = JsonConvert.SerializeObject(q, Newtonsoft.Json.Formatting.Indented)
            Dim cliente = New ClientModels
            cliente.Nome = IUnicoUtils.LocalizaTexto(strRsp, "Nome\"": \""", "\"",")
            cliente.Cpf = IUnicoUtils.LocalizaTexto(strRsp, "Cpf\"": \""", "\"",")

            Regras.VerificaInfoCliente(cliente)


            Dim res = Request.CreateResponse(HttpStatusCode.OK)
            res.Content = New StringContent(strRsp, System.Text.Encoding.UTF8, "application/json")
            Return res
        Catch ex As Exception
            Dim res = Request.CreateResponse(HttpStatusCode.BadRequest)
            Dim strError As String = $"""erro"":""Parâmetros nulo e/ou inválidos => {ex.Message}"""
            res.Content = New StringContent(strError, System.Text.Encoding.UTF8, "application/json")
            Return res
        End Try
    End Function

    ' PUT api/values/5
    Public Sub PutValue(ByVal id As Integer, <FromBody()> ByVal value As String)

    End Sub

    ' DELETE api/values/5
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
