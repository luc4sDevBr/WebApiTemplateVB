﻿Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web.Http

Public Module WebApiConfig
    Public Sub Register(ByVal config As HttpConfiguration)
        ' Configuração de Web API e serviços

        ' Rotas de Web API
        config.MapHttpAttributeRoutes()

        config.Routes.MapHttpRoute(
            name:="DefaultApi",
            routeTemplate:="api/{controller}/{id}",
            defaults:=New With {.id = RouteParameter.Optional}
        )


        ' Configuração e serviços da Web API
        config.Formatters.Remove(config.Formatters.XmlFormatter)
        config.Formatters.JsonFormatter.Indent = True

    End Sub
End Module
