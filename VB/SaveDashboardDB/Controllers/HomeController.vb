Imports System
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.Linq
Imports System.Threading.Tasks
Imports Microsoft.AspNetCore.Mvc
Imports SaveDashboardDB.Models

Namespace SaveDashboardDB.Controllers
    Public Class HomeController
        Inherits Controller

        Public Function Index() As IActionResult
            Return View()
        End Function

        Public Function [Error]() As IActionResult
'INSTANT VB TODO TASK: VB has no equivalent to the C# '??' operator:
            Return View(New ErrorViewModel With {.RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier})
        End Function
    End Class
End Namespace
