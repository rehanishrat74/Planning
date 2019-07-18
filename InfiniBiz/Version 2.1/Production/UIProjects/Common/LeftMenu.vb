Public Class LeftMenuItem
    Private Const QT = Chr(34)
    Public Parent As LeftMenu
    Public ID As String
    Public Heading As String
    Public URL As String
    Public IsImage As Boolean
    Public IsSelected As Boolean
    Public IsMenu As Boolean
    Public IsHeading As Boolean
    Public IsHtml As Boolean
    Public Height As Int16
    Public Function Render() As String
        Dim renderString As String = ""

        If IsMenu Then
            If IsImage Then
                renderString = "<TR><TD height=" & Height & "px class=MENU align=center valign=center ><a href=" & QT & URL & QT & "><img border=0 src=" & QT & Heading & QT & " ></a></td></tr>"
            Else
                renderString = "<TR><TD height=" & Height & "px class=MENU onmouseover=" & QT & "this.className='MENUON';" & QT & " onmouseout=" & QT & "this.className='MENU';" & QT & " onclick=" & QT & "window.navigate('" & URL & "');" & QT & " >"
                If IsSelected Then
                    renderString = renderString & "<a style='cursor:hand'><B>&nbsp;" & Heading & "</b></a></TD></TR>"
                Else
                    renderString = renderString & "<a style='cursor:hand'>" & Heading & "</a></TD></TR>"
                End If
            End If
        ElseIf IsHeading Then
            renderString = "<TR><TD class=content height=" & Height & "px  onclick=" & QT & "window.navigate('" & URL & "');" & QT & " >"
            If IsSelected Then
                renderString = renderString & "<a style='cursor:default'><B>&nbsp;" & Heading & "</b></a></TD></TR>"
            Else
                renderString = renderString & "<a style='cursor:hand'>" & Heading & "</a></TD></TR>"
            End If
        ElseIf IsHtml Then
            renderString = "<TR><TD class=content height=" & Height & "px>" & Heading & "</TD></TR>"
        Else
            If IsImage Then
                If URL <> "" Then
                    renderString = "<TR><TD height=" & Height & "px  align=center valign=center ><a href=" & QT & URL & QT & "><img border=0 src=" & QT & Heading & QT & " ></a></td></tr>"
                Else
                    renderString = "<TR><TD height=" & Height & "px align=center valign=center ><img border=0 src=" & QT & Heading & QT & " ></td></tr>"
                End If

            Else
                renderString = "<TR><TD height=" & Height & "px></TD></TR>"
            End If
        End If
        Render = renderString
    End Function
End Class
Public Class LeftMenu
    Private _MenuItems As Collection
    Private _menuwidth As Int16
    Public Event RenderItem(ByVal Item As LeftMenuItem)
    Public Event BeforeRender()
    Public Event AfterRender()
    Public Sub New(Optional ByVal menuwidth As Int16 = 200)
        _MenuItems = New Collection()
        _menuwidth = menuwidth
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
        _MenuItems = Nothing
    End Sub
    Public Function AddItem(ByVal id As String, ByVal heading As String, ByVal url As String, Optional ByVal isimage As Boolean = False, Optional ByVal isselected As Boolean = False, Optional ByVal isMenu As Boolean = True, Optional ByVal Height As Int16 = 20, Optional ByVal IsHeading As Boolean = False, Optional ByVal IsHtml As Boolean = False) As LeftMenuItem
        Dim menuitem As New LeftMenuItem()
        With menuitem
            .ID = id
            .Heading = heading
            .URL = url
            .IsImage = isimage
            .IsSelected = isselected
            .Parent = Me
            .IsMenu = isMenu
            .Height = Height
            .IsHeading = IsHeading
            .IsHtml = IsHtml
        End With
        _MenuItems.Add(menuitem, id)
        AddItem = menuitem
        menuitem = Nothing
    End Function
    Public Function Render() As String
        Dim renderString As String = ""
        RaiseEvent BeforeRender()

        renderString = "<TABLE cellSpacing=0 cellPadding=0 border=0 width=" & _menuwidth.ToString & "px >"
        Dim menuitem As LeftMenuItem
        For Each menuitem In _MenuItems
            RaiseEvent RenderItem(menuitem)
            renderString = renderString & menuitem.Render
        Next
        renderString = renderString & "</TABLE>"
        Render = renderString
        RaiseEvent AfterRender()

    End Function
    Default Public ReadOnly Property Getitems(ByVal id As Object) As LeftMenuItem
        Get
            Getitems = _MenuItems(id)
        End Get

    End Property
End Class
