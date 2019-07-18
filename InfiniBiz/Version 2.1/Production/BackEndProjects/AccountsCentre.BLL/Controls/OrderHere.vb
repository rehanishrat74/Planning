Imports System.Web.UI.WebControls


Public Class OrderHere
    Inherits ImageButton

    Public _strProductCode As String

    Public Sub New()
        'CssClass = "acc-order-here"
        Me.ImageUrl = "/images/orderhere.jpg"
    End Sub

    Public Sub OrderHere_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles MyBase.Click
        Dim myPage As PageBase = CType(Page, PageBase)
        With myPage
            .Session(.ACC_ORDER_HERE_LINK) = _strProductCode
            .Response.Redirect("https://www.accountscentre.com/members/ServiceRegistration.aspx")
        End With

    End Sub


    Public Property ProductCode() As String
        Get
            Return _strProductCode
        End Get
        Set(ByVal Value As String)
            _strProductCode = Value
        End Set
    End Property
End Class
