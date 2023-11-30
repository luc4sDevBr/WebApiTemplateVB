Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.Http
Imports System.Web.Mvc
Imports System.Web.Routing
Imports Microsoft.AspNet.FriendlyUrls

Public Module RouteConfig
    Sub RegisterRoutes(ByVal routes As RouteCollection)
        Dim settings = New FriendlyUrlSettings()
        settings.AutoRedirectMode = RedirectMode.Permanent
        routes.EnableFriendlyUrls(settings)
    End Sub
End Module