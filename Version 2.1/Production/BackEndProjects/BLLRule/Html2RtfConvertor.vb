#Region ".................. Imports "

Imports Infinilogic.BusinessPlan.Common
Imports Infinilogic.BusinessPlan.BLL
Imports Infinilogic.BusinessPlan.BLLRules
Imports System.Text
Imports System.Xml
Imports System.Xml.Xsl
Imports System.IO

#End Region

Public Class Html2RtfConvertor

#Region ".................Public Methods "

    Public Shared Function TransformIntoRTF(ByRef xHtml As String, ByRef xslPath As String, ByVal params As XsltArgumentList) As String

        Return Transform(xHtml, xslPath, params)

    End Function

#End Region

#Region ".................Private Methods "

    Private Shared Function Transform(ByRef xHTML As String, ByRef xslPath As String, ByRef params As XsltArgumentList) As String

        xHTML = xHTML.Replace("&nbsp;", " ")
        Dim xmldoc As New XmlDocument
        xmldoc.LoadXml("<?xml version='1.0'?><html xmlns='http://www.w3.org/1999/xhtml' xmlns:xhtml2rtf='http://www.lutecia.info/download/xmlns/xhtml2rtf'>" & xHTML & "</html>")
        Dim transformer As New XslTransform
        'xslPath & 
        transformer.Load(xslPath & "xhtml2rtf.xsl")
        Dim xslargs As XsltArgumentList = params
        Dim sb As New StringBuilder(1024 * 64) ' 64K
        Dim sw As New StringWriter(sb)
        transformer.Transform(xmldoc.CreateNavigator(), xslargs, sw, Nothing)

        Dim x As String = sb.ToString
        Return x
    End Function

#End Region

End Class
